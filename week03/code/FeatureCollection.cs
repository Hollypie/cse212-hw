using System.Text.Json;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public List<Feature> Features { get; set; }


}

public class Feature
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public Properties Properties {get; set;}
    

}

public class Properties 
{
    public decimal Mag { get; set; }
    public string Place { get; set; }
}



