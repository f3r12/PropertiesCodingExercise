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
        /// <summary>
        /// Initializes a new instance of the <see cref="TableContext" /> class,
        /// which connects to the context instance given a DB connection string name.
        /// </summary>
        public TableContext() : base("MyConnection")
        {
        }

        /// <summary>
        /// Gets or sets the property list to be saved in the DB table.
        /// </summary>
        /// <value>The property list to be saved in the DB table.</value>
        public DbSet<Properties> Properties { get; set; }
    }
}
