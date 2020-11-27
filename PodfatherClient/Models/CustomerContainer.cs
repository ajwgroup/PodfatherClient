using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class CustomerContainer
    {
        [JsonProperty("data")]
        public Customer Customer { get; set; }
    }
}
