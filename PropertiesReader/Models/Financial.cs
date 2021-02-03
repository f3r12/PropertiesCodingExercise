using System.ComponentModel.DataAnnotations;

namespace PropertiesReader.Models
{
    public class Financial
    {
        [DataType(DataType.Currency)]
        public long ListPrice { get; set; }

        [DataType(DataType.Currency)]
        public long MonthlyRent { get; set; }

        public long GrossYield { get; set; }
    }
}