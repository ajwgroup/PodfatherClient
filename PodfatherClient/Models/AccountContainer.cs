using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class AccountContainer
    {
        [JsonProperty("data")]
        public Account Account { get; set; }
    }
}
