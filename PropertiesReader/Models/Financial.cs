using System.ComponentModel.DataAnnotations;

namespace PropertiesReader.Models
{
    public class Financial
    {
        /// <summary>
        /// Gets or sets the list price retrieved from json file.
        /// </summary>
        /// <value>The list price retrieved from json file.</value>
        [DataType(DataType.Currency)]
        public long ListPrice { get; set; }

        /// <summary>
        /// Gets or sets the monthly rent retrieved from json file.
        /// </summary>
        /// <value>The monthly rent retrieved from json file.</value>
        [DataType(DataType.Currency)]
        public long MonthlyRent { get; set; }

        /// <summary>
        /// Gets or sets the gross yield retrieved from json file.
        /// </summary>
        /// <value>The gross yield retrieved from json file.</value>
        public long GrossYield { get; set; }
    }
}