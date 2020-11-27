﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PodfatherClient.Models
{
    [JsonObject("data")]
    public class NewSite
    {
        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public long? Customer { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public string Name { get; set; }
        [JsonProperty("address1", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public string Address1 { get; set; }
        [JsonProperty("address2", NullValueHandling = NullValueHandling.Ignore)]
        public string Address2 { get; set; }
        [JsonProperty("address3", NullValueHandling = NullValueHandling.Ignore)]
        public string Address3 { get; set; }
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public string City { get; set; }
        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public string Region { get; set; }
        [JsonProperty("postcode", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public string Postcode { get; set; }
        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public string Contact { get; set; }
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("accountNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }
        [JsonProperty("accountNumber2", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber2 { get; set; }
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
        [JsonProperty("autoEmail", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AutoEmail { get; set; }
        [JsonProperty("coordinate", NullValueHandling = NullValueHandling.Ignore)]
        public Coordinate Coordinate { get; set; }
        [JsonProperty("etaEmailNotifications", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EtaEmailNotifications { get; set; }
        [JsonProperty("etaSmsNotifications", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EtaSmsNotifications { get; set; }
    }
}
