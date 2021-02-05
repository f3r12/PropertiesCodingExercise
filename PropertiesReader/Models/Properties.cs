using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesReader.Models
{
    public class Properties
    {
        /// <summary>
        /// Gets or sets the identifier for the primary key in DB.
        /// </summary>
        /// <value>The identifier for the primary key in DB.</value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the address that is retrieved from json file.
        /// </summary>
        /// <value>The address that is retrieved from json file.</value>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the physical that is retrieved from json file.
        /// </summary>
        /// <value>The physical that is retrieved from json file.</value>
        public Physical Physical { get; set; }

        /// <summary>
        /// Gets or sets the financial that is retrieved from json file.
        /// </summary>
        /// <value>The financial that is retrieved from json file.</value>
        public Financial Financial { get; set; }
    }
}
