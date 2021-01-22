using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class CreatedRun
    {
        [JsonProperty("data")]
        public CreatedRunJobData Data { get; set; }
    }
}
