using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class CreatedJob
    {
        [JsonProperty("job")]
        public JobContainer JobContainer { get; set; }
    }
}
