/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Calling API methods.
*/

using Newtonsoft.Json;

namespace CH08
{
    public class SearchUser
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
