using System.Collections.Generic;
using System.Text.Json.Serialization;

public class FeatureCollection
{
    // Todo Earthquake Problem - ADD YOUR CODE HERE
    // Create additional classes as necessary
   // will contains list of earthquake features
     [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }

    public class Feature
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }
        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }
    }

    public class Geometry
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("place")]
        public string Place { get; set; }
        [JsonPropertyName("mag")]
        public double Mag { get; set; }
        [JsonPropertyName("time")]
        public long Time { get; set; }
    }
}