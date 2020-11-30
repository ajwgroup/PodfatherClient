using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class SitesContainer
    {
        [JsonProperty("data")]
        public List<Site> Sites { get; set; }
    }
    
}
