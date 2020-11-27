using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class JobItems
    {
        [JsonProperty("data")]
        public List<JobItemsData> JobItemsData { get; set; }

    }
}
