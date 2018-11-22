using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Model
{
    public class JsonResultRoot
    {
        [JsonProperty(PropertyName = "samples")]
        public List<JsonResult> samples { set; get; }

        public JsonResultRoot()
        {
            samples = new List<JsonResult>();
        }
    }
}
