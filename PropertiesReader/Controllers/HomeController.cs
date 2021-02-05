using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PropertiesReader.Context;
using PropertiesReader.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PropertiesReader.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// The logger, to log any exceptions in the app.
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Gets or sets the DB context, to handle DB calls.
        /// </summary>
        /// <value>The DB context, to handle DB calls.</value>
        public TableContext _context { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        /// <param name="logger">The logger, to log any exceptions in the app.</param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new TableContext();
        }

        /// <summary>
        /// "Index" View.
        /// </summary>
        /// <returns>The Index View</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// "Show Properties" View.
        /// </summary>
        /// <returns>The "Show Properties" View, retrieving data fron json file</returns>
        public IActionResult ShowProperties()
        {
            WebClient webClient = new WebClient();
            string json = webClient.DownloadString(@"properties.json");
            PropertyList? propertyList = JsonConvert.DeserializeObject<PropertyList>(json);

            return View(propertyList);
        }

        /// <summary>
        /// Saves data (retrieved from UI) into the DB.
        /// </summary>
        /// <param name="id">The identifier for the data to be saved.</param>
        /// <param name="address">The address for the data to be saved.</param>
        /// <param name="yearBuilt">The year built for the data to be saved.</param>
        /// <param name="listPrice">The list price for the data to be saved.</param>
        /// <param name="monthlyRent">The monthly rent for the data to be saved.</param>
        /// <param name="grossYield">The gross yield for the data to be saved.</param>
        /// <returns>The "Show Properties" View, after saving data in the DB</returns>
        public IActionResult Save(int id, string address, int yearBuilt, long listPrice, long monthlyRent, long grossYield)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var property = _context.Properties
                .FirstOrDefault(m => m.Id == id);

            if (property == null)
            {
                SavePropertyOnDB(new Properties
                                {
                                    Id = id,
                                    Address = new Address { Address1 = address },
                                    Physical = new Physical { YearBuilt = yearBuilt },
                                    Financial = new Financial
                                                        {
                                                            ListPrice = listPrice,
                                                            MonthlyRent = monthlyRent,
                                                            GrossYield = grossYield
                                                        }
                                });
            }

            return RedirectToAction("ShowProperties", "Home");
        }

        /// <summary>
        /// Saves a property on database.
        /// </summary>
        /// <param name="property">The property to be saved on DB.</param>
        private void SavePropertyOnDB(Properties property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
        }

        /// <summary>
        /// "Privacy" View.
        /// </summary>
        /// <returns>The "Privacy" View</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// "Error" View.
        /// </summary>
        /// <returns>The "Error" View</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
