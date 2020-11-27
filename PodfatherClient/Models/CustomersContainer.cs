using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class CustomersContainer
    {
        [JsonProperty("data")]
        public List<Customer> Customers { get; set; }
    }
}
