using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class SiteContainer
    {
        [JsonProperty("data")]
        public Site Site { get; set; }
    }
}
