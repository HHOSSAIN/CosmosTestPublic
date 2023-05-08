using CosmosTestPublic.Data;
using CosmosTestPublic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CosmosTestPublic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly testcosmos101context _context;

        public HomeController(ILogger<HomeController> logger, testcosmos101context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<bool> db_test()
        {
            #region create global settings
            var globalSettings1 = new GlobalSettings()
            {
                Id = Guid.NewGuid().ToString(),
               
                templates = new List<Template>()
               {
                   new Template()
                    {
                        Id = Guid.NewGuid().ToString(),
                        templateContent = "<h1>This is GS public1</h1>"
                    },
                    new Template()
                    {
                        Id = Guid.NewGuid().ToString(),
                        templateContent = "<h1>This is GS public2 </h1>"
                    },

               },                                                          
            };
            _context.GlobalSettings.Add(globalSettings1);
            await _context.SaveChangesAsync();

            return true;
            #endregion
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}