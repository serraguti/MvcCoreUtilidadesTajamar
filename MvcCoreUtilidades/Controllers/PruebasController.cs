using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Filters;
using MvcCoreUtilidades.Helpers;

namespace MvcCoreUtilidades.Controllers
{
    public class PruebasController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        [EncryptedParameters()]
        public IActionResult Index(string nombre, int? edad)
        {
            if (nombre != null && edad != null){
                ViewData["NOMBRE"] = nombre;
                ViewData["EDAD"] = edad;
            }

            return View();
        }
    }
}
