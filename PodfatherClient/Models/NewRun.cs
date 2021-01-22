using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PodfatherClient.Models
{
    public class NewRun
    {
        ///<summary>
        /// body
        /// Schema to create a Run
        ///</summary>
        [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public object Body { get; set; }

        ///<summary>
        /// name
        /// Run Name
        ///</summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public string Name { get; set; }

        ///<summary>
        /// Depot Identifier
        /// Identifier of the depot for the run
        ///</summary>
        [JsonProperty("depot", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public long Depot { get; set; }

        ///<summary>
        /// date
        /// Date the run is due to be completed
        ///</summary>
        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public DateTime Date { get; set; }

        ///<summary>
        /// Driver
        /// Identifier of the driver for the run
        ///</summary>
        [JsonProperty("driver", NullValueHandling = NullValueHandling.Ignore)]
        [Required]
        public long Driver { get; set; }
    }
}
