using Microsoft.AspNetCore.Mvc;

namespace StoreApp.controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Welcome";
            return View();
        }

        
    }
}