# Define a default SPARQL query to fetch subclass relationships in RDF data
default_sparql_query = """PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
PREFIX owl: <http://www.w3.org/2002/07/owl#>
PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>
PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>
SELECT ?subject ?object
    WHERE { ?subject rdfs:subClassOf ?object 
}"""

# Define a dictionary of custom SPARQL queries to be executed on the RDF data
custom_sparql_query = {
    "Find Pixar Movies Rated 'Suitable for all ages'" : dict( query = """
        PREFIX movie: <http://www.semanticweb.org/crypticsy/ontologies/2024/2/movie#>
        PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
        PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>

        SELECT ?movieTitle ?isPixar ?is3D ?rating
        WHERE {
            ?m rdf:type movie:Movie ;
                movie:movieTitle ?movieTitle ;
                movie:isPixarMovie ?isPixar ;
                movie:is3D ?is3D .
            OPTIONAL { ?m movie:receivedRating ?rating }
            FILTER (?isPixar = "true"^^xsd:boolean && ?is3D = "true"^^xsd:boolean)
        }
        """, 
        columns = ["Movie", "isPixar", "is3D", "rating"],
        subheading = "3D Pixar movies rated 'Suitable for all ages'",
    ),
    
    "Find Critically Acclaimed Director" : dict( query = """
        PREFIX movie: <http://www.semanticweb.org/crypticsy/ontologies/2024/2/movie#>
        PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
        PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>

        SELECT DISTINCT ?director (COUNT(?movie) AS ?numberOfMovies)
        WHERE {
            ?movie rdf:type movie:Movie ;
                movie:movieTitle ?movieTitle ;
                movie:directedBy ?director ;
                movie:wonAward movie:Oscars_for_Best_Animated_Feature .
            ?director rdf:type movie:Director .
        }
        GROUP BY ?director
        """,
        columns = ["Director Name", "Number of directed movies with Oscar"],
        subheading = "Directors who have won an Oscar for Best Animated Feature",
    ),
    
    "Find Highly Nominated Movies" : dict( query = """
        PREFIX movie: <http://www.semanticweb.org/crypticsy/ontologies/2024/2/movie#>
        PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>
        PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>

        SELECT ?movieTitle ?nominationCount
        WHERE {
        ?movie rdf:type movie:Movie ;
                movie:movieTitle ?movieTitle ;
                movie:awardNominationsCount ?nominationCount .
            FILTER (?nominationCount > 20)
        }
        """,
        columns = ["Movie", "Number of nominations"],
        subheading = "Movies with more than 20 award nominations",
    ),
    
    "Find Leading Comedy Voice Actor" : dict( query = """
        PREFIX movie: <http://www.semanticweb.org/crypticsy/ontologies/2024/2/movie#>
        PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>

        SELECT ?voiceActor ?movieTitle ?character ?earnedBoxOffice
        WHERE {
            ?movie rdf:type movie:Movie ;
                movie:movieTitle ?movieTitle ;
                movie:featuresCharacter ?character ;
                movie:belongsToGenre movie:Comedy ;
                movie:earnedBoxOffice ?earnedBoxOffice ;
                movie:earnedBoxOffice movie:USD_500_Million_to_1_Billion .
            ?character movie:voicedBy ?voiceActor.
            ?voiceActor rdf:type movie:VoiceActor.
        }
        """,
        columns = ["Movie", "Voice Actor", "Character", "Box Office Earnings"],
        subheading = "Voice actors who have earned over 500 million dollars in comedy movies",
    ),
    
    "Find Moderately Successful Movie" : dict( query = """
        PREFIX movie: <http://www.semanticweb.org/crypticsy/ontologies/2024/2/movie#>
        PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>

        SELECT ?movieTitle ?genre ?earnedBoxOffice ?nominationCount
        WHERE {
            ?movie rdf:type movie:Movie ;
                movie:movieTitle ?movieTitle ;
                movie:belongsToGenre ?genre ;
                movie:earnedBoxOffice ?earnedBoxOffice ;
                movie:awardNominationsCount ?nominationCount .
            FILTER ((?earnedBoxOffice = movie:USD_100_Million_to_500_Million || ?earnedBoxOffice = movie:USD_500_Million_to_1_Billion) && (?nominationCount > 10) && (?nominationCount < 30))
        }
        """,
        columns = ["Movie", "Genre", "Box Office Earnings", "Number of nominations"],
        subheading = "Movies with 10 to 30 award nominations and box office earnings between 100 million and 1 billion dollars",
    ),
    
    "Find Movies produced by Studio at Japan that have Japanese as default language" : dict( query = """
        PREFIX movie: <http://www.semanticweb.org/crypticsy/ontologies/2024/2/movie#>
        PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>

        SELECT ?studio ?countryAddress ?movieTitle ?language
        WHERE {
            ?movie rdf:type movie:Movie ;
                movie:movieTitle ?movieTitle ;
                movie:producedByStudio ?studio ;
                movie:language ?language .
            ?studio rdf:type movie:Studio ;
                movie:countryAddress ?countryAddress ;
                movie:countryAddress "Japan" .
            FILTER (?country = "Japan" && ?language = "japanese")
        }
        """,
        columns = ["Studio", "Studio Location (Country)", "Movie", "Language"],
        subheading = "Movies produced by studios in Japan with Japanese as the default language",
    ),
}