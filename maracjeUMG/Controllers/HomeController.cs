using maracjeUMG.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;

namespace maracjeUMG.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public IActionResult AdminCat()
        {
            return RedirectToAction("Index", "Catedratico");
        }

        public IActionResult AdminAlu()
        {
            return RedirectToAction("Index", "Estudiantes");
        }

        public IActionResult AdminUsu()
        {
            return RedirectToAction("Index", "Usuarios");
        }

        [Authorize(Roles = "3")]
        public IActionResult Alumno()
        {
            return View();
        }

        [Authorize(Roles = "2")]
        public IActionResult Catedratico()
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