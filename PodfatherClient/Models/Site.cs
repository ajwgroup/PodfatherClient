using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    [JsonObject("data")]
    public class Site
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        [JsonProperty("customer")]
        public long? Customer { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("address3")]
        public string Address3 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("contact")]
        public string Contact { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        [JsonProperty("accountNumber2")]
        public string AccountNumber2 { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("autoEmail")]
        public bool? AutoEmail { get; set; }
        [JsonProperty("coordinate")]
        public Coordinate Coordinate { get; set; }
        [JsonProperty("etaEmailNotifications")]
        public bool? EtaEmailNotifications { get; set; }
        [JsonProperty("etaSmsNotifications")]
        public bool? EtaSmsNotifications { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
    }
}
