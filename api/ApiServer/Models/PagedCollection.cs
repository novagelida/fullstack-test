using Newtonsoft.Json;
using System.Collections.Generic;

namespace ApiServer.Models
{
    public class PagedCollection<T>
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<T> Collection { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Offset { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }

        public int Size { get; set; }
    }
}
