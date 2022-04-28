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
//using CsvHelper;
using System.IO;
using System.Globalization;
using Lab05_Hans_Sempe_1083920.Models.Comparadores;

namespace Lab05_Hans_Sempe_1083920.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static MultiPathTree<int, Vehículos> arbolmultipath = new MultiPathTree<int, Vehículos>(); /*(new Models.Comparadores.CompareVehiculoPlaca().Compare);*/

        //CompareKeysDelegate<int> comparador = new CompareKeysDelegate<int>(new Lab05_Hans_Sempe_1083920.Models.Comparadores.CompareVehiculoPlaca());


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

        public IActionResult recivirDatos()
        {
            return View();
        }

        public IActionResult guardarDatos(int _placa, String _color, String _dueño, int _latitud, int _longitud)
        {


            if (_latitud < 90 || _latitud > -90)
            {
                if (_longitud < 180 || _longitud > -180)
                {
                    Vehículos nuevovehiculo = new Vehículos(_placa, _color, _dueño, _latitud, _longitud);

                    CompareVehiculoPlaca comparador2 = new Lab05_Hans_Sempe_1083920.Models.Comparadores.CompareVehiculoPlaca();

                    CompareKeysDelegate<int> comparador = new CompareKeysDelegate<int>(CompareNumbers);

                    //CompareKeysDelegate<int> comparador = new CompareKeysDelegate<int>(Compare);

                    arbolmultipath.Add(nuevovehiculo.Placa, nuevovehiculo, comparador);
        
                }
                else
                {
                    ViewBag.VehiculoFound = "Ingreso una coordenada erronea.";
                }
            }
            else
            {
                ViewBag.VehiculoFound = "Ingreso una coordenada erronea";
            }

            return View();


        }

        public IActionResult recivirDatosManual()
        {
            return View();
        }

        public IActionResult recivirDatosArchivo()
        {
            return View();
        }

        public IActionResult leerArchivo(string _archivo)
        {
            List<Vehículos> listaV = new List<Vehículos>();

            using (var streamReader = new StreamReader(@_archivo))
            {
               /* using (var cvsReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    listaV = cvsReader.GetRecords<Vehículos>().ToList();
                }
               */
            }

            foreach (Vehículos newV in listaV)
            {

                CompareVehiculoPlaca comparador2 = new Lab05_Hans_Sempe_1083920.Models.Comparadores.CompareVehiculoPlaca();

                CompareKeysDelegate<int> comparador = new CompareKeysDelegate<int>(CompareNumbers);

                //CompareKeysDelegate<int> comparador = new CompareKeysDelegate<int>(Compare);

                arbolmultipath.Add(newV.Placa, newV, comparador);
            }


            return View();
        }


        private int CompareNumbers(int value1, int value2)
        {
            if (value1 > value2)
            {
                return 1;
            }
            else if (value1 < value2)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

    }
}
