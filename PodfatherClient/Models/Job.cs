using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class Job
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        ///<summary>
        /// This correlates to the website Job #
        ///</summary>
        [JsonProperty("cosmeticId")]
        public long CosmeticId { get; set; }        
        ///<summary>
        /// This ID correlates to the website Invoice Address
        ///</summary>
        [JsonProperty("site")]
        public long Site { get; set; }

        ///<summary>
        /// This ID correlates to the website Address
        ///</summary>
        [JsonProperty("customer")]
        public long Customer { get; set; }

        ///<summary>
        /// This ID correlates to the website From Depot
        ///</summary>
        [JsonProperty("depot")]
        public long Depot { get; set; }

        ///<summary>
        /// This ID correlates to the website Run
        ///</summary>
        [JsonProperty("run")]
        public long? Run { get; set; }

        ///<summary>
        /// This correlates to the website Special Instructions
        ///</summary>
        [JsonProperty("instructions1")]
        public string Instructions1 { get; set; }

        [JsonProperty("instructions2")]
        public string Instructions2 { get; set; }

        [JsonProperty("provisional")]
        public bool? Provisional { get; set; }

        ///<summary>
        /// This correlates to the website PO #
        ///</summary>
        [JsonProperty("orderRef")]
        public string OrderRef { get; set; }

        [JsonProperty("orderRef2")]
        public string OrderRef2 { get; set; }

        [JsonProperty("dueByStart")]
        public DateTime? DueByStart { get; set; }

        ///<summary>
        /// This correlates to the website Delivery Due By
        ///</summary>
        [JsonProperty("dueBy")]
        public DateTime DueBy { get; set; }

        [JsonProperty("dropTime")]
        public long? DropTime { get; set; }

        [JsonProperty("price")]
        public double? Price { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("receivedByHandheld")]
        public DateTime? ReceivedByHandheld { get; set; }

        [JsonProperty("template")]
        public long Template { get; set; }
    }
}
