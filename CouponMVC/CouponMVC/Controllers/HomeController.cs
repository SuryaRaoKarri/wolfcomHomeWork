using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CouponMVC.Models;
using System.Net.Http;

namespace CouponMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<FinalPrice> finalPrices;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("1/700/DISC10").Result;
            finalPrices = response.Content.ReadAsAsync<IEnumerable<FinalPrice>>().Result;
            return View();
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
