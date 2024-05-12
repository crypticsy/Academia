# Import necessary modules for file handling, subprocess management, and web interface development
import os, subprocess
import pandas as pd
import streamlit as st

# Import specialized libraries and custom modules for ontology management and web interface enhancements
from owlready2 import *
from query import default_sparql_query, custom_sparql_query
from code_editor import code_editor
from streamlit_pills import pills
from utils import preview_class_hierarchy, create_network_graph, get_response_from_displayed_dataframe

# Find the path to the Java executable using the `which` command in Unix-like systems.
# This is required for the owlready2 library to interface with Java-based tools.
java_path = subprocess.check_output(["which", "java"]).decode().strip()
if not java_path: 
    raise RuntimeError("Java is not installed or cannot be found.")  # Raise an error if Java is not found

# Set the Java executable path for the owlready2 library, allowing it to use Java operations
owlready2.JAVA_EXE = java_path

# Get the directory where the current Python file resides, used for referencing relative paths
base_dir = os.path.dirname(__file__)

# Configure Streamlit's page appearance with title, favicon, and layout settings
st.set_page_config(page_title="Animated Movie Ontology", page_icon=os.path.join(base_dir, "assets", "fav.ico"), layout="wide")

# Load movie ontology from file and set up namespace
onto = get_ontology(os.path.join(base_dir, "Movie.rdf")).load()
onto_path.append(base_dir)  # Append base directory to ontology path
onto_base_iri = "http://www.semanticweb.org/crypticsy/ontologies/2024/2/movie#"  # Define base IRI for ontology
onto_namespace = onto.get_namespace(onto_base_iri)  # Create namespace for ontology






# ---------------------------- Display all entities with individuals ----------------------------

# Display a header on the Streamlit interface, marking the beginning of the entity selection section
st.header("Entities", divider="red")

# Identify top-level classes in the ontology that do not have superclasses within the same ontology
super_class_list = [cls for cls in onto.classes() if cls.iri.startswith(onto.base_iri) and not any(cls in superclass.subclasses() for superclass in onto.classes() if superclass != cls)]

# Create a dictionary to map entity names to their enumeration for use in a selection widget
entity_list = {x.name: n for n, x in enumerate(super_class_list)}
# Display a widget for selecting an entity using the 'pills' Streamlit component, which enhances UI
selected_entity_name = pills("Select an entity to preview", list(entity_list.keys()))
# Retrieve the class object based on the selected entity name
entity_choice = super_class_list[entity_list.get(selected_entity_name)]

# Create two columns for layout management in Streamlit
col1, col2 = st.columns(2)

# First column for displaying the class hierarchy of the selected entity
with col1:
    selected_individual = preview_class_hierarchy(entity_choice)  # Call to custom function to display hierarchy
    st.markdown("<br/>", unsafe_allow_html=True)  # Add a break for spacing

# Second column for displaying properties and interactions
with col2:
    class_properties = []  # List to store class properties
    unique_properties = set()  # Set to ensure property uniqueness

    # Iterate through instances of the selected class to gather properties
    for n1, instance in enumerate(entity_choice.instances()):
        for n2, prop in enumerate(instance.get_properties()):
            if prop.python_name not in unique_properties:
                unique_properties.add(prop.python_name)
                class_properties.append([selected_entity_name + f"{n1}-{n2}", prop.name, str(prop.range)])

    # Create a DataFrame from the properties and display it as a network graph
    df = pd.DataFrame(class_properties, columns=["Type", "Property", "Value"]).sort_values(by=["Type", "Property"])
    st.plotly_chart(create_network_graph(df, entity_choice.name), use_container_width=True)

# Visual divider in Streamlit interface
st.divider()
st.markdown("<br/>", unsafe_allow_html=True)
# Display a subheader that changes dynamically based on whether an individual is selected
st.subheader("Class Properties" if not selected_individual else "Class Properties : {0}".format(selected_individual))
col1, col2 = st.columns(2)

# Additional logic to manage and display properties of selected individuals
if selected_individual:
    for subclass in entity_choice.instances():
        if subclass.name == selected_individual.replace(" ", "_"):
            filtered_instance_data = []
            for prop in subclass.get_properties():
                for value in prop[subclass]:
                    if type(prop).__name__ == "DataPropertyClass": filtered_instance_data.append([prop.python_name, "Data Property", str(value)])
                    else: filtered_instance_data.append([prop.python_name, "Object Property", value.name])
            
            selected_df = pd.DataFrame(filtered_instance_data, columns=["Property", "Type", "Value"]).sort_values(by=["Type", "Property"])


selected_property = None
with col1:
    # Conditionally handle the absence of selected instances
    if not selected_individual:
        st.warning("No instances selected")
    else:
        # Display and allow interaction with properties of the selected individual
        selected_property = get_response_from_displayed_dataframe(selected_df[["Type", "Property", "Value"]], return_type="multiple", key_suffix="selected_property")

# Further interaction based on the properties of the selected individual
if selected_individual and not selected_df.empty:
    with col2:
        fig = create_network_graph(selected_df, selected_individual)  # Generate a network graph of the properties
        st.plotly_chart(fig, use_container_width=True)

# Interaction to update instance properties if any property is selected
if selected_property is not None:
    st.markdown("<br/>", unsafe_allow_html=True)
    st.subheader("Update Instance Properties")
    
    col1, col2, col3, col4 = st.columns(4)
    
    # Setup columns for various aspects of property editing
    with col1:
        st.selectbox("Selected individual", [selected_individual], key="individual", disabled=True)

    with col2:
        property_name = selected_property["Property"].values[0]
        st.selectbox("Selected property", [property_name], key="property", disabled=True)
    
    # Dynamic handling based on the type of property (Data or Object)
    with col3:
        if selected_property["Type"].values[0] == "Data Property":
            new_value = st.text_input("New value", selected_property["Value"].values[0])
        else:
            property_entity = getattr(onto, property_name)
            # Derive possible values for object properties based on ontology definition
            if property_entity.range:
                range_classes = property_entity.range
                property_values = []
                for range_class in range_classes:
                    property_values.extend([inst.name for inst in range_class.instances()])
            
            old_value = selected_property["Value"].values[0]
            new_value = st.selectbox("New value", property_values, key="new_value", index= property_values.index(old_value))
            if selected_property["Type"].values[0] == "Object Property":
                new_value = next((inst for cls in range_classes for inst in cls.instances() if inst.name == new_value), None)
    
    with col4:
        st.write("")
        st.write("")
        # Update button interaction
        update_action = st.button("💾 \u2003 Update", key="update")
        if update_action:
            subclass = getattr(onto, selected_individual.replace(" ", "_"))
            if selected_property["Type"].values[0] == "Data Property":
                current_value = getattr(subclass, property_name)
                
                try:
                    new_value = float(new_value)
                except:
                    try:
                        if new_value.lower() in ["true", "false"]:
                            new_value = bool(new_value)
                    except:
                        pass
                
                setattr(subclass, property_name, [new_value])
            else:
                # Modify object properties by replacing old values
                if isinstance(getattr(subclass, property_name), list):
                    getattr(subclass, property_name).remove(old_value)  # Remove old value
                    getattr(subclass, property_name).append(new_value)  # Append new value
                else:
                    setattr(subclass, property_name, new_value)  # Direct assignment
            
            onto.save(file=os.path.join(base_dir, "Movie.rdf"))  # Save changes to the ontology file
            st.experimental_rerun()  # Rerun the Streamlit app to reflect updates







# ---------------------------- Search using a keyword ----------------------------

# Add spacing for visual separation in the Streamlit interface
st.markdown("<br/><br/>", unsafe_allow_html=True)

# Display a header indicating the start of the search section with a red divider
st.header("Search", divider="red")

# Create a text input field pre-filled with "DreamWorks" to receive a keyword for searching the ontology
choice = st.text_input("Enter a keyword to search", "DreamWorks")

try:
    search_engine = getattr(onto, choice, None)
except Exception as e:
    e

# Check if the search returned any results
if not search_engine:
    # Display a warning message if no results are found
    st.warning("No search results found")
else:
    # If search results exist, prepare to list all properties of the found class/entity
    data = []
    # Iterate over all properties of the searched entity and collect their values
    for prop in search_engine.get_properties():
        for value in prop[search_engine]:
            if type(prop).__name__ == "DataPropertyClass": data.append([prop.python_name, "Data Property", str(value)])
            else: data.append([prop.python_name, "Object Property", value.name])
    
    # Display the properties and their values in a DataFrame sorted by type and property name
    st.dataframe(pd.DataFrame(data, columns=["Property", "Type",  "Value"]).sort_values(by=["Type", "Property"]),
                 hide_index=True,  # Hide the DataFrame index for a cleaner look
                 use_container_width=True)  # Adjust the width of the DataFrame to match the container's width







# ---------------------------- Run specific sparql query ----------------------------

# Add significant vertical spacing for visual separation in the Streamlit interface
st.markdown("<br/><br/><br/><br/>", unsafe_allow_html=True)

# Display a header indicating the start of the SPARQL query section with a red divider
st.header("SPARQL Query", divider="red")

# Provide a dropdown menu for users to select from a predefined set of SPARQL queries
choice = st.selectbox("Select a search you want to perform", list(custom_sparql_query.keys()))

# Retrieve the selected query details from the dictionary of custom SPARQL queries
choice_dict = custom_sparql_query.get(choice)

# Additional vertical spacing
st.markdown("<br/>", unsafe_allow_html=True)

# Display the subheading of the selected query as a smaller header
st.markdown("###### {}".format(choice_dict.get("subheading")))

# Show the actual SPARQL query in a code block with syntax highlighting
st.code(choice_dict.get("query"), language="sparql")

# Execute the selected SPARQL query and create a DataFrame from the results
results = pd.DataFrame(default_world.sparql(choice_dict.get('query')), columns=choice_dict.get('columns'))

# Display the results in a DataFrame within the Streamlit interface, adjusting its width to match the container and hiding the index for clarity
st.dataframe(results, use_container_width=True, hide_index=True)

# Additional vertical spacing
st.markdown("<br/>", unsafe_allow_html=True)

# Provide an expander widget that allows users to write and execute their own custom SPARQL queries
with st.expander("⚙️ Custom SPARQL Query"):
    # Further vertical spacing within the expander
    st.markdown("<br/>", unsafe_allow_html=True)
    # Display a subheader within the expander encouraging users to write their own queries
    st.write("###### Write your own SPARQL query here")

    # Define the configuration for the code editor, including buttons for executing the query
    editor_btns = [{
        "name": "Run",
        "feather": "Play",
        "primary": True,
        "hasText": True,
        "showWithIcon": True,
        "commands": ["submit"],
        "style": {"bottom": "0.44rem", "right": "0.4rem"}
    }]

    # Embed a code editor for writing SPARQL queries with specific language settings and button configurations
    code = code_editor(default_sparql_query, lang="sparql", buttons=editor_btns, options={"wrap": True, "showLineNumber": True})

    # Check if there is any text in the code editor after the "Run" button has been pressed
    if code['text']:
        try:
            # Attempt to execute the custom SPARQL query entered in the editor
            custom_results = list(default_world.sparql(code['text']))
            # Display the results in a DataFrame, similar to the predefined query results
            st.dataframe(pd.DataFrame(custom_results), use_container_width=True, hide_index=True)
        except Exception as e:
            # If there is an error during query execution, display an error message to the user
            st.error(f"An error occurred: {e}")









# ---------------------------- Reasoner ----------------------------
# Add spacing for visual separation in the Streamlit interface
st.markdown("<br/><br/><br/><br/>", unsafe_allow_html=True)
# Create a header for the section dedicated to Oscar-winning movies
st.header("Reasoner", divider="red")

# Define a new class within the ontology to represent movies that have won an Oscar for Best Animated Feature
with onto:
    class OscarMovies(onto.Movie):
        # Set the logical condition that for a movie to be classified as an Oscar-winning movie,
        # it must have won the Oscar for Best Animated Feature
        equivalent_to = [
            onto.Movie and onto.wonAward.value(onto.Oscars_for_Best_Animated_Feature)
        ]

# Create instances of OscarMovies
# These instances are explicitly stated to have won the Oscar for Best Animated Feature
oscarMovie = OscarMovies(name="Dumbo", wonAward=[onto.Oscars_for_Best_Animated_Feature])
oscarMovie = OscarMovies(name="Pinocchio", wonAward=[onto.Oscars_for_Best_Animated_Feature])

# Attempt to load the reasoner to classify and infer properties based on the defined ontology and data
try:
    with onto:
        sync_reasoner(infer_property_values=True)  # This call infers additional ontology data properties
        st.success("Reasoner loaded successfully")  # Notify the user of successful reasoning
except OwlReadyJavaError as e:  # Catch and handle any Java-related errors from the Owlready2 reasoner
    st.error(f"Reasoning failed: {str(e)}")  # Display an error message if the reasoner fails

# Query the ontology for instances of the OscarMovies class
oscar_movies = list(OscarMovies.instances())

# Display the results in Streamlit, showing a list of Oscar-winning animated movies
st.markdown("<br/>", unsafe_allow_html=True)  # Add a bit of vertical space before listing movies
st.write("##### Oscar-winning animated movies:")

# Iterate through each instance of Oscar-winning movies and display their names
# Highlight "Dumbo" and "Pinocchio" specifically with a success message styling
for movie in oscar_movies:
    if movie.name in ["Dumbo", "Pinocchio"]:
        st.success(f"- {movie.name.replace('_', ' ')}")  # Format the movie name nicely, replacing underscores with spaces
    else:
        st.write(f"- {movie.name.replace('_', ' ')}")  # Display other movie names normally