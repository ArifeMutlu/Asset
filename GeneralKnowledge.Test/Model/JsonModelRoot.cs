using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Model
{
    public class JsonModelRoot
    {
        [JsonProperty(PropertyName = "samples")]
        public List<JsonModel> samples { set; get; }
    }
}
