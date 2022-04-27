using Lab05_Hans_Sempe_1083920.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Lab05_Hans_Sempe_1083920.ADT;
using System.IO;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;

namespace Lab05_Hans_Sempe_1083920.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static MultiPathTree<int, Vehículos> arbolmultipath = new MultiPathTree<int, Vehículos>(); /*(new Models.Comparadores.CompareVehiculoPlaca().Compare);*/





        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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


        public IActionResult mostrarArbol()
        {
            return View();
        }

        public IActionResult recivirDatosAVL()
        {
            return View();
        }










    }
}
