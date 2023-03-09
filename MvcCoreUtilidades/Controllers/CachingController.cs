using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MvcCoreUtilidades.Controllers
{
    public class CachingController : Controller
    {
        private IMemoryCache memoryCache;

        public CachingController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        //LA DURACION ESTA ESTABLECIDA EN SEGUNDOS
        [ResponseCache(Duration = 15
            , Location = ResponseCacheLocation.Client)]
        public IActionResult MemoriaDistribuida()
        {
            string fecha =
                DateTime.Now.ToLongDateString()
                    + " -- " + DateTime.Now.ToLongTimeString();
            ViewData["FECHA"] = fecha;
            return View();
        }

        public IActionResult MemoriaPersonalizada(int? tiempo)
        {
            if (tiempo == null)
            {
                //PONEMOS EL ALMACEN DURANTE 60 SEGUNDOS LA PRIMERA VEZ
                tiempo = 5;
            }
            string fecha =
                DateTime.Now.ToLongDateString()
                + " -- " + DateTime.Now.ToLongTimeString();
            if (this.memoryCache.Get("FECHA") == null)
            {
                //NO EXISTE CACHE
                //CREAMOS LAS OPCIONES DE DURACION DEL CACHE
                MemoryCacheEntryOptions options =
                    new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(tiempo.Value));
                //CONFIGURAMOS EL TIEMPO AL GENERAR EL CACHE
                this.memoryCache.Set("FECHA", fecha, options);
                ViewData["MENSAJE"] = "Almacenando en Cache";
                ViewData["FECHA"] = this.memoryCache.Get("FECHA");
            }
            else
            {
                //TENEMOS UN OBJETO EN CACHE
                fecha = this.memoryCache.Get<string>("FECHA");
                ViewData["MENSAJE"] = "Recuperando Cache";
                ViewData["FECHA"] = fecha;
            }
            return View();
        }
    }
}
