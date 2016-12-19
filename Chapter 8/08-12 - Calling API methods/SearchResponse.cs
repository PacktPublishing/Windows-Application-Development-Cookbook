/*
    Exemplary file for Chapter 8 - Internet-based Scenarios.
    Recipe: Calling API methods.
*/

using Newtonsoft.Json;
using System.Collections.Generic;

namespace CH08
{
    public class SearchResponse
    {
        [JsonProperty("users")]
        public List<SearchUser> Users { get; set; }
    }
}
