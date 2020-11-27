using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class Pod
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("cosmeticId")]
        public long CosmeticId { get; set; }
        [JsonProperty("job")]
        public long Job { get; set; }
        [JsonProperty("customer")]
        public long Customer { get; set; }
        [JsonProperty("site")]
        public long Site { get; set; }
        [JsonProperty("depot")]
        public long Depot { get; set; }
        [JsonProperty("driver")]
        public long Driver { get; set; }
        [JsonProperty("run")]
        public long Run { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("template")]
        public long Template { get; set; }
        [JsonProperty("fields")]
        public List<PodField> PodFields { get; set; }
        [JsonProperty("items")]
        public PodItems PodItems { get; set; }

    }
}
