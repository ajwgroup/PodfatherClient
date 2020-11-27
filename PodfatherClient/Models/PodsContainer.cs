using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PodfatherClient.Models
{
    public class PodsContainer
    {
        [JsonProperty("data")]
        public List<Pod> Pods { get; set; }
    }
}
