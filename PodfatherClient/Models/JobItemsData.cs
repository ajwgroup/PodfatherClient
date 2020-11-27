using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class JobItemsData : NewJobItemsData
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
