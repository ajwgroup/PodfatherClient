using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class JobFields
    {
        [JsonProperty("data")]
        public List<JobFieldsData> JobFieldsData { get; set; }
    }
}
