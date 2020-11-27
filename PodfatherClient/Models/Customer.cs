using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PodfatherClient.Models
{
    [JsonObject("data")]
    public class Customer
    {
        [JsonProperty("id")]
        public long? Id { get; set; }
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }
        [JsonProperty("address1")]
        [Required]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("address3")]
        public string Address3 { get; set; }
        [JsonProperty("city")]
        [Required]
        public string City { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("postcode")]
        [Required]
        public string Postcode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }
        [JsonProperty("accountNumber2")]
        public string AccountNumber2 { get; set; }
        [JsonProperty("autoEmail")]
        public bool? AutoEmail { get; set; }
    }
}
