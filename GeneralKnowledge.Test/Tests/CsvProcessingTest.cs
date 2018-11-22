using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebExperience.Test.Models;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted
            List<Asset> assetlist = new List<Asset>();

            var csvFile = Resources.AssetImport;
            csvFile = csvFile.Replace('\n', '\r');
            string[] lines = csvFile.Split(new char[] { '\r' },StringSplitOptions.RemoveEmptyEntries);
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(',').Length;
            // Allocate the data array.
            string[,] values = new string[num_rows, num_cols];
            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                Asset asset = new Asset();
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    if (r != 0)
                    {
                        if (c == 0)
                            asset.asset_id = new Guid(line_r[c]);
                        else if (c == 1)
                            asset.file_name = line_r[c];
                        else if (c == 2)
                            asset.mime_type = line_r[c];
                        else if (c == 3)
                            asset.created_by = line_r[c];
                        else if (c == 4)
                            asset.email = line_r[c];
                        else if (c == 5)
                            asset.country = line_r[c];
                        else if (c == 6)
                            asset.description = line_r[c];
                    }
                    values[r, c] = line_r[c];
                }
                if (r != 0)
                    assetlist.Add(asset);
            }

            BulkCopy(assetlist);

        }



        private void BulkCopy(List<Asset> assetlist)
        {
             using (SqlConnection sqlconn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-WebExperience.Test-20141015102139;Integrated Security=True"))
             {
                try
                {
                    
                    sqlconn.Open();
                    var table = new DataTable();
                    table.Columns.Add("asset_id", typeof(Guid));
                    table.Columns.Add("file_name", typeof(string));
                    table.Columns.Add("mime_type", typeof(string));
                    table.Columns.Add("created_by", typeof(string));
                    table.Columns.Add("email", typeof(string));
                    table.Columns.Add("country", typeof(string));
                    table.Columns.Add("description", typeof(string));
                    foreach (Asset item in assetlist)
                    {
                        DataRow row = table.NewRow();
                        row[0] = item.asset_id;
                        row[1] = item.file_name;
                        row[2] = item.mime_type;
                        row[3] = item.created_by;
                        row[4] = item.email;
                        row[5] = item.country;
                        row[6] = item.description;
                        table.Rows.Add(row);
                    }
                    using (var bulk = new SqlBulkCopy(sqlconn))
                    {
                        bulk.DestinationTableName = "Assets";
                        bulk.WriteToServer(table);
                    }
                }
                finally
                {
                    sqlconn.Close();
                }
                   
             }
        }
    }

}
