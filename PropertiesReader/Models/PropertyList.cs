using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesReader.Models
{
    public class PropertyList
    {
        public IList<Properties> Properties { get; set; }
    }
}
