using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tema10.Models;


namespace Tema10.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Index()
        {
            return View();
        }

       
    }
}