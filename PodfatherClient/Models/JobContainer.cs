using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class JobContainer
    {
        [JsonProperty("data")]
        public Job Job { get; set; }
    }
}
