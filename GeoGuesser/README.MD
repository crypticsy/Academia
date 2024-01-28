# Geo Guesser

In a quest to rival the human GeoGuessr champion, I delved into Convolutional Neural Networks (CNNs) to predict geographic locations. Utilizing DenseNet 121 and a dataset featuring around 50,000 GeoGuessr images from the GeoWorld challenge, the model achieved an impressive 80% accuracy during training and a noteworthy 60% accuracy in testing, surpassing the performance of its predecessors.
<br/>

## Pre-requisites

##### Conda Environment
Create a separate conda environment with the python version 3.9 using the following command:

```
conda create -n geoguesser python=3.9
```

then activate the environment:

```
conda activate geoguesser
```
 
and install the required libraries using the following command:

```
pip install -r requirements.txt
```
<br/>

##### Dataset Setup

- Download the dataset from the following [link](https://www.kaggle.com/datasets/ubitquitin/geolocation-geoguessr-images-50k/data):
```
https://www.kaggle.com/datasets/ubitquitin/geolocation-geoguessr-images-50k/data
```
and place the unzipped folder in the project.
<br/>


## Usage

As notebooks are not suitable for version control, we use quarto to convert the notebooks to qmd files for storage. The qmd files can be converted back to notebooks for analysis.

```bash
# Convert qmd files to jupyter notebooks
quarto convert [file_name].qmd

# Convert notebooks to qmd file for version control
quarto convert [file_name].ipynb 
```

<br/>
