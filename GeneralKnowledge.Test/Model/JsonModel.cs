using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Model
{
    public class JsonModel
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime date { get; set; }

        [JsonProperty(PropertyName = "temperature")]
        public decimal temperature { get; set; }

        [JsonProperty(PropertyName = "pH")]
        public decimal pH { get; set; }

        [JsonProperty(PropertyName = "phosphate")]
        public decimal phosphate { get; set; }

        [JsonProperty(PropertyName = "chloride")]
        public decimal chloride { get; set; }

        [JsonProperty(PropertyName = "nitrate")]
        public decimal nitrate { get; set; }
    }
}
