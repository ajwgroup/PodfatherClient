using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PodfatherClient.Models
{
    public class NewJob
    {
        ///<summary>
        /// Site Identifier
        /// This ID correlates to the website Invoice Address
        ///</summary>
        [JsonProperty("site", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public long Site { get; set; }

        ///<summary>
        /// Customer Identifier
        /// This ID correlates to the website Address
        ///</summary>
        [JsonProperty("customer", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public long Customer { get; set; }

        ///<summary>
        /// Depot Identifier
        /// This ID correlates to the website From Depot
        ///</summary>
        [JsonProperty("depot", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public long Depot { get; set; }

        ///<summary>
        /// Job Template Identifier
        ///</summary>
        [JsonProperty("template", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public long Template { get; set; }

        ///<summary>
        /// Run Identifier
        /// This ID correlates to the website Run
        ///</summary>
        [JsonProperty("run", NullValueHandling = NullValueHandling.Ignore)]
        public long? Run { get; set; }

        ///<summary>
        /// Time range start of the due by time for the job
        ///</summary>
        [JsonProperty("dueByStart", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DueByStart { get; set; }

        ///<summary>
        /// This correlates to the website Delivery Due By
        ///</summary>
        [JsonProperty("dueBy", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public DateTime DueBy { get; set; }

        ///<summary>
        /// Main instructions field for the driver
        /// This correlates to the website Special Instructions
        ///</summary>
        [JsonProperty("instructions1", NullValueHandling = NullValueHandling.Ignore)]
        public string Instructions1 { get; set; }

        ///<summary>
        /// Supplementary instructions field for driver
        ///</summary>
        [JsonProperty("instructions2", NullValueHandling = NullValueHandling.Ignore)]
        public string Instructions2 { get; set; }

        ///<summary>
        /// Prevent the job from being downloaded to handheld devices
        ///</summary>
        [JsonProperty("provisional", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Provisional { get; set; }

        ///<summary>
        /// The amount of time (mins) taken to complete the job at the destination
        ///</summary>
        [JsonProperty("dropTime", NullValueHandling = NullValueHandling.Ignore)]
        public long? DropTime { get; set; }

        ///<summary>
        /// The price of the job, if not set will be the total price of items
        ///</summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        ///<summary>
        /// An array of standard items
        ///</summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<NewJobItemsData> Items { get; set; }
    }
}
