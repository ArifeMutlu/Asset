using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Model
{
    public class JsonResult
    {
        [JsonProperty(PropertyName = "Parameter")]
        public string Parameter { get; set; }
        [JsonProperty(PropertyName = "Low")]
        public decimal Low { get; set; }
        [JsonProperty(PropertyName = "Avg")]
        public decimal Avg { get; set; }
        [JsonProperty(PropertyName = "Max")]
        public decimal Max { get; set; }
    }
}
