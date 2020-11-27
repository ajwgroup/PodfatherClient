using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class JobFieldsData
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("fieldId")]
        public long FieldId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }

    }
}
