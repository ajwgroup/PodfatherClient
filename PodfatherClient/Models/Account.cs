using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    [JsonObject("data")]
    public class Account
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

    }
}
