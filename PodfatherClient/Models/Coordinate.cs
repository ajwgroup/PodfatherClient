using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PodfatherClient.Models
{
    [JsonObject("coordinate")]
    public class Coordinate
    {
        [JsonProperty("latitude")]
        [Required]
        public double? Latitude { get; set; }
        [JsonProperty("longitude")]
        [Required]
        public double? Longitude { get; set; }
    }
}