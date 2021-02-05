using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesReader.Models
{
    public class PropertyList
    {
        /// <summary>
        /// Gets or sets the properties to be shown in the UI.
        /// </summary>
        /// <value>The properties to be shown in the UI.</value>
        public IList<Properties> Properties { get; set; }
    }
}
