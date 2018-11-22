using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebExperience.Test.Models;

namespace GeneralKnowledge.Test.App
{
    public class AssetDBContext : DbContext
    {
        public AssetDBContext() : base("DefaultConnection")
        {

        }

        public DbSet<Asset> Assets { get; set; }
    }
}
