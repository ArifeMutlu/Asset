using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExperience.Test.Models
{
    public class AssetList
    {
        public List<Asset> data;
        public AssetList()
        {
            data = new List<Asset>();
        }
    }
}