# Import necessary libraries
import os, pathlib
from math import sqrt, ceil

import numpy as np
from PIL import Image
import plotly.offline as pyo
import plotly.graph_objects as go



# Constants
img_width   = 224  # Image width for preprocessing
img_height  = 224  # Image height for preprocessing
random_seed = 123  # Set a fixed random seed for reproducibility
batch_size  = 32  # Define the batch size for training data

# File and directory paths
working_dir     = pathlib.Path().absolute()  # Path to the working directory
geo_data_dir    = pathlib.Path(os.path.join(working_dir, 'compressed_dataset'))  # Path to the data directory
geo_train_dir   = pathlib.Path(os.path.join(working_dir, 'train_dataset'))  # Path to the train dataset directory
geo_test_dir    = pathlib.Path(os.path.join(working_dir, 'test_dataset'))  # Path to the test dataset directory


# Function to extract metadata from a give file
def extract_metadata_from_folder(path):
    metadata = []
    for file_path in path.glob('*'):
        # Get the width and height of the image
        width, height = Image.open(file_path).size
        
        metadata.append({
            'country': path.name,
            'image_name': file_path.name,
            'width': width,
            'height': height,
            'size': file_path.stat().st_size,
            'path': file_path
        })
    
    return metadata

# Function to add custom styling to the plot
def add_plot_styling(fig):
    fig.update_layout(
        plot_bgcolor='rgba(0,0,0,0.05)',  # Set background color to transparent
    )
    return fig

# Function to plot heatmap
def plot_heatmap(df, title_text, color_threshold=0.90):
    # Shaping Data to fit graph by finding the max size of the grid to fit all the images
    grid_size = ceil(sqrt(df.shape[0]))**2
    
    pad = '-'
    n_labels = df.country.to_list() + ([pad] * (grid_size - df.shape[0]))
    n_samples = df.frequency.to_list() + ([np.nan] * (grid_size - df.shape[0]))
    
    samples = np.split(np.array(n_samples), sqrt(grid_size))
    
    fig = go.Figure(data=go.Heatmap(
        z=samples,
        x0=0,
        dx=1,
        y0=0,
        dy=1,
        colorscale='Emrld',
        text=n_labels,
        hoverinfo='text',
    ))
    
    # Add labels within the heatmap
    for i, country in enumerate(df['country']):
        x_pos = i % int(sqrt(grid_size))
        y_pos = i // int(sqrt(grid_size))
        fig.add_annotation(
            x=x_pos,  # Center the label within the grid cell
            y=y_pos,
            text= "{}<br> Count: {}".format(n_labels[i].replace(' ', '<br>'), n_samples[i]),
            showarrow=False,
            font=dict(
                color='#474747' if n_samples[i] < df.frequency.quantile(color_threshold) else 'white',
                size=10),
        )
    
    # hide axis labels
    fig.update_xaxes(showticklabels=False)
    fig.update_yaxes(showticklabels=False, autorange='reversed')
    
    # change the dimensions of the figure
    fig.update_layout(
        title=title_text,
        height=1200,
        width=1200
    )
    fig = add_plot_styling(fig)
    
    # Use iplot to display the graph in the Jupyter Notebook
    pyo.iplot(fig)