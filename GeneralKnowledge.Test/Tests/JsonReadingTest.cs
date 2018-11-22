using GeneralKnowledge.Test.App.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {
        public string Name { get { return "JSON Reading Test";  } }

        public void Run()
        {
              var jsonData = Resources.SamplePoints;
              string jsonStr = Encoding.UTF8.GetString(jsonData);
              JsonModelRoot lcList = JsonConvert.DeserializeObject<JsonModelRoot>(jsonStr);

              JsonResultRoot lcResults = new JsonResultRoot();
              JsonResult lcResult = new JsonResult();

              lcResult = lcList.samples.GroupBy(i => 1)
              .Select(g => new JsonResult {
                  Parameter = "temperature",
                  Low = g.Min(i => i.temperature),
                  Avg = g.Average(i => i.temperature),
                  Max = g.Max(i => i.temperature)
              }).SingleOrDefault();
              lcResults.samples.Add(lcResult);

              lcResult = lcList.samples.GroupBy(i => 1)
              .Select(g => new JsonResult
              {
                  Parameter = "pH",
                  Low = g.Min(i => i.pH),
                  Avg = g.Average(i => i.pH),
                  Max = g.Max(i => i.pH)
              }).SingleOrDefault();
              lcResults.samples.Add(lcResult);

              lcResult = lcList.samples.GroupBy(i => 1)
              .Select(g => new JsonResult
              {
                  Parameter = "Chloride",
                  Low = g.Min(i => i.chloride),
                  Avg = g.Average(i => i.chloride),
                  Max = g.Max(i => i.chloride)
              }).SingleOrDefault();
              lcResults.samples.Add(lcResult);

              lcResult = lcList.samples.GroupBy(i => 1)
              .Select(g => new JsonResult
              {
                  Parameter = "Phosphate",
                  Low = g.Min(i => i.phosphate),
                  Avg = g.Average(i => i.phosphate),
                  Max = g.Max(i => i.phosphate)
              }).SingleOrDefault();
              lcResults.samples.Add(lcResult);

            lcResult = lcList.samples.GroupBy(i => 1)
            .Select(g => new JsonResult
            {
                Parameter = "Nitrate",
                Low = g.Min(i => i.nitrate),
                Avg = g.Average(i => i.nitrate),
                Max = g.Max(i => i.nitrate)
            }).SingleOrDefault();
            lcResults.samples.Add(lcResult);
            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z
            string json = JsonConvert.SerializeObject(lcResults);
            jsonData = Encoding.ASCII.GetBytes(json);
            PrintOverview(jsonData);
        }

        private void PrintOverview(byte[] data)
        {
            string jsonStr = Encoding.UTF8.GetString(data);
            JsonResultRoot lcList = JsonConvert.DeserializeObject<JsonResultRoot>(jsonStr);
            foreach (var jsonResult in lcList.samples)
            {
                Console.WriteLine(jsonResult.Parameter + "-" + jsonResult.Low.ToString("N2") + "-" + jsonResult.Avg.ToString("N2") + "-" + jsonResult.Max.ToString("N2"));
                
            }
            Console.ReadKey();
        }
    }
}
