using System.Text.Json.Serialization;

namespace TestZippopotamus
{
    public class Place
    {
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }

        public string State { get; set; }

        public string StateAbbreviature { get; set; }

        public string Latitude { get; set; }

        public string Longtitude { get; set; }
    }
}