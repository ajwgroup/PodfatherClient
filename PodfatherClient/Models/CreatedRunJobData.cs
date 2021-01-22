using Newtonsoft.Json;
using System;

namespace PodfatherClient.Models
{
    public class CreatedRunJobData
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("createat")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("driver")]
        public long Driver { get; set; }
        [JsonProperty("depot")]
        public long Depot { get; set; }
    }
}