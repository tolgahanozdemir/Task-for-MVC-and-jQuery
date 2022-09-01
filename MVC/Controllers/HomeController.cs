using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Homepage()
        {
            return View();
        }

        public IActionResult Contact()
        {
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