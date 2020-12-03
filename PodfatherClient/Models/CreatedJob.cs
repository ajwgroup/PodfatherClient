using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class CreatedJob
    {
        [JsonProperty("job")]
        public Jobs Job { get; set; }
        [JsonProperty("fields")]
        public JobFields JobFields { get; set; }

        [JsonProperty("items")]
        public JobItems JobItems { get; set; }

    }
}
