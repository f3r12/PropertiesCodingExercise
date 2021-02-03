using PropertiesReader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesReader.Context
{
    public class TableContext : DbContext
    {
        public TableContext() : base("MyConnection")
        {
        }

        public DbSet<Properties> Properties { get; set; }
    }
}
