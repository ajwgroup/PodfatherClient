using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class PodData
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("data")]
        public List<PodDataFieldData> PodDataFieldData { get; set; }
    }
}
