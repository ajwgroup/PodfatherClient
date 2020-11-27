using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PodfatherClient.Models
{
    public class PodDataFieldData
    {
        [JsonProperty("fieldName")]
        public string FieldName { get; set; }
        [JsonProperty("fieldValue")]
        public string FieldValue { get; set; }

    }
}
