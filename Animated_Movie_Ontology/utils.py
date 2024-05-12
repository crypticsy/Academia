# Import necessary libraries for data manipulation, visualization, and web application development
import numpy as np
import pandas as pd
import networkx as nx
import streamlit as st
import plotly.graph_objects as go

# Import AgGrid for interactive data grid functionality within Streamlit
from st_aggrid import AgGrid, GridOptionsBuilder





def get_response_from_displayed_dataframe(df, return_type="single", key_suffix=""):
    """ Display DataFrame using AgGrid and return selected value """
    
    # Set up grid options for the DataFrame display
    gb = GridOptionsBuilder.from_dataframe(df)
    gb.configure_selection('single')
    gb.configure_grid_options(domLayout='normal')
    grid_options = gb.build()

    # Configure default column properties for better user interface
    grid_options['defaultColDef'] = {
        'flex': 1,
        'minWidth': 100,  # Adjust minWidth as necessary to ensure responsiveness
        'filter': True,
        'sortable': True,
        'resizable': True
    }
    # Generate a unique key for the AgGrid component
    unique_key = f"ag_grid_{key_suffix}_{return_type}_{hash(tuple(df.values.flatten()))}"
    

    # Display the DataFrame using AgGrid and capture the response
    grid_response = AgGrid(df, gridOptions=grid_options, fit_columns_on_grid_load=True, key=unique_key)
    
    # Return appropriate response based on user selection
    if type(grid_response) is None:
        return None
    elif type(grid_response['selected_rows']) == pd.DataFrame and return_type == "single":
        return grid_response['selected_rows']['Instances'][0]
    elif type(grid_response['selected_rows']) == pd.DataFrame and return_type == "multiple":
        return grid_response['selected_rows']
    return None



def preview_class_hierarchy(cls, level=0):
    """ Recursive function to print class hierarchy """
    # Initialize the response to None to handle the case where no instances are selected
    response = None
    
    if level == 0:
        # At root level, directly display instances of the class without using an expander
        data = pd.DataFrame([x.name.replace("_", ' ') for x in cls.instances()], columns=["Instances"])
        new_response = get_response_from_displayed_dataframe(data, return_type="single", key_suffix=cls.name + f"{level}")
        if new_response:
            response = new_response  # Update the response if an instance is selected

        # Recursively display and handle selections for all subclasses
        for subclass in cls.subclasses():
            new_response = preview_class_hierarchy(subclass, level + 1)
            if new_response:
                response = new_response  # Update the response with selections from deeper levels

    else:
        # For non-root levels, use expanders to allow users to expand/collapse the view of subclasses
        if len(cls.instances()) == 0:
            # If no instances are available, display an empty expander
            st.expander(cls.name).empty()
        else:
            # If instances are available, display them within an expander
            with st.expander(cls.name):
                data = pd.DataFrame([x.name.replace("_", ' ') for x in cls.instances()], columns=["Instances"])
                new_response = get_response_from_displayed_dataframe(data, return_type="single", key_suffix=cls.name + f"{level}")
                if new_response:
                    response = new_response  # Update the response if an instance is selected


    # Return the final selected instance or None if no selection is made
    return response





def create_network_graph(selected_df, selected_data):
    """ Generate a 3D network graph from DataFrame data and a selected node. """
    # Initialize a new graph
    G = nx.Graph()

    # Add the main node with a unique color and size
    G.add_node(selected_data, size=50, label=selected_data, color="#FFC300")

    # Iterate through the DataFrame to add property and value nodes and edges
    for idx, row in selected_df.iterrows():
        prop = row['Property']
        value = row['Value']

        # Create nodes for properties with a unique identifier including the row index
        prop_node = f"{prop}_{idx}_prop"
        G.add_node(prop_node, size=10, label=prop, color='lightblue')

        # Create nodes for values with a unique identifier including the row index
        value_node = f"{prop}_{idx}_value"
        G.add_node(value_node, size=25, label=value, color='lightgreen')

        # Connect the main node to property nodes and property nodes to value nodes
        G.add_edge(selected_data, prop_node)
        G.add_edge(prop_node, value_node)

    # Set up positions for nodes in the graph: main node at center, others in concentric circles
    pos = {}
    center = np.array([0, 0, 0])
    prop_radius = 2  # radius for property nodes
    value_radius = 4  # radius for value nodes

    pos[selected_data] = center

    # Calculate angles for property nodes to distribute them around the main node
    prop_nodes = [node for node in G if node.endswith('_prop')]
    angles = np.linspace(0, 2 * np.pi, len(prop_nodes), endpoint=False)
    for node, angle in zip(prop_nodes, angles):
        x, y = prop_radius * np.cos(angle), prop_radius * np.sin(angle)
        pos[node] = np.array([x, y, 0])  # Z-coordinate set to 0 for simplicity

    # Calculate positions for value nodes around their respective property nodes
    value_nodes = [node for node in G if node.endswith('_value')]
    for node, prop_node in zip(value_nodes, prop_nodes):
        angle = angles[prop_nodes.index(prop_node)]
        x, y = value_radius * np.cos(angle), value_radius * np.sin(angle)
        pos[node] = np.array([x, y, 0])  # Maintain Z-coordinate in line

    # Create traces for edges using calculated positions
    edge_x = []
    edge_y = []
    edge_z = []
    for edge in G.edges():
        x0, y0, z0 = pos[edge[0]]
        x1, y1, z1 = pos[edge[1]]
        edge_x.extend([x0, x1, None])  # Straight lines between nodes
        edge_y.extend([y0, y1, None])
        edge_z.extend([z0, z1, None])

    # Create traces for nodes
    node_x = [pos[node][0] for node in G]
    node_y = [pos[node][1] for node in G]
    node_z = [pos[node][2] for node in G]

    # Configure Plotly traces for the graph
    edge_trace = go.Scatter3d(
        x=edge_x, y=edge_y, z=edge_z,
        line=dict(width=2, color='#888', dash='dot'),
        mode='lines',
        hoverinfo='none'  # Disable hover effects for lines
    )

    # Configure Plotly traces for nodes
    node_trace = go.Scatter3d(
        x=node_x, y=node_y, z=node_z,
        mode='markers+text',
        text=[G.nodes[node]['label'] for node in G],
        hoverinfo='text',
        marker=dict(
            showscale=False,
            size=[G.nodes[node]['size'] for node in G],
            color=[G.nodes[node]['color'] for node in G],
            line_width=2
        )
    )

    # Set up the 3D visualization layout
    fig = go.Figure(data=[edge_trace, node_trace],
                    layout=go.Layout(
                        width=800,
                        height=500,
                        showlegend=False,
                        scene=dict(
                            xaxis=dict(showgrid=False, zeroline=False, showticklabels=False, title_text=''),
                            yaxis=dict(showgrid=False, zeroline=False, showticklabels=False, title_text=''),
                            zaxis=dict(showgrid=False, zeroline=False, showticklabels=False, title_text='')
                        ),
                        margin=dict(b=0, l=0, r=0, t=0),
                        scene_camera_eye=dict(x=0.87, y=0.58, z=0.8),
                        hovermode='closest'
                    ))

    return fig
