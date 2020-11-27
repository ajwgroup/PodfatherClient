using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PodfatherClient.Models
{
    ///<summary>
    /// Contains information about an item to be added to a specific job
    ///</summary>
    public class NewJobItemsData
    {
        ///<summary>
        /// Name of the item
        ///</summary>
        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        ///<summary>
        /// The merchadise group of the item
        ///</summary>
        [JsonProperty("merchGroup", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchGroup { get; set; }

        ///<summary>
        /// A product code for the item
        ///</summary>
        [JsonProperty("productCode", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductCode { get; set; }

        ///<summary>
        /// The unit price of the item
        ///</summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        ///<summary>
        /// The unit weight of the item
        ///</summary>
        [JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
        public double? Weight { get; set; }

        ///<summary>
        /// Quantity of this specific item for the job
        ///</summary>
        [JsonProperty("quantity")]
        [Required]
        public long Quantity { get; set; }
    }
}
