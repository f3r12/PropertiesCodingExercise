﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;

        public TableContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new TableContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowProperties()
        {
            WebClient webClient = new WebClient();
            string json = webClient.DownloadString(@"properties.json");
            PropertyList? propertyList = JsonConvert.DeserializeObject<PropertyList>(json);

            return View(propertyList);
        }

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

        private void SavePropertyOnDB(Properties property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
