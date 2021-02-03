using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertiesReader.Models
{
    public class Properties
    {
        [Key]
        public int Id { get; set; }

        public Address Address { get; set; }

        public Physical Physical { get; set; }

        public Financial Financial { get; set; }
    }
}
