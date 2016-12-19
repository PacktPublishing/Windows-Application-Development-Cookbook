/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Calling API methods.
*/

using Newtonsoft.Json;

namespace CH08
{
    public class SearchRequestParameters
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("min_age")]
        public int MinimumAge { get; set; }

        [JsonProperty("max_age")]
        public int MaximumAge { get; set; }
    }
}
