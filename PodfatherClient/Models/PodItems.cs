using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class PodItems
    {
        [JsonProperty("data")]
        public List<PodData> PodData { get; set; }
    }
}
