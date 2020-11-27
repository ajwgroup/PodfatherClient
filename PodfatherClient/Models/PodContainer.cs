using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class PodContainer
    {
        [JsonProperty("data")]
        public Pod Pod { get; set; }
    }
}
