using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Models;

namespace MvcCoreUtilidades.Controllers
{
    public class CochesController : Controller
    {
        private List<Coche> Cars;

        public CochesController()
        {
            this.Cars = new List<Coche>
            {
                new Coche { IdCoche = 1, Marca = "Pontiac"
                , Modelo = "Firebird", Imagen = "https://mudfeed.com/wp-content/uploads/2021/08/KITT-1200x640.jpg"},
                new Coche { IdCoche = 2, Marca = "Volkswagen"
                , Modelo = "Escarabajo", Imagen = "https://www.quadis.es/documents/80345/95274/herbie-el-volkswagen-beetle-mas.jpg"},
                new Coche { IdCoche = 3, Marca = "Ferrari"
                , Modelo = "Testarrosa", Imagen = "https://www.lavanguardia.com/files/article_main_microformat/uploads/2017/01/03/5f15f8b7c1229.png"},
                new Coche { IdCoche = 4, Marca = "Ford"
                , Modelo = "Mustang GT", Imagen = "https://cdn.autobild.es/sites/navi.axelspringer.es/public/styles/1200/public/media/image/2018/03/prueba-wolf-racing-mustang-gt.jpg"}
            };
        }

        //EN LA VISTA PRINCIPAL SERA DONDE INTEGRAREMOS
        //LAS PETICIONES ASINCRONAS
        public IActionResult Index()
        {
            return View();
        }

        //NECESITAMOS UNA PETICION PARA CADA VISTA ASINCRONA
        //QUE VAYAMOS A UTILIZAR
        //LOS METODOS PUEDEN LLAMARSE COMO QUERAMOS, ES DECIR,
        //DIFERENTES A LOS NOMBRES DE LAS VISTAS QUE UTILIZAN
        public IActionResult _CochesPartial()
        {
            //SI VAMOS A UTILIZAR UNA VISTA PARCIAL CON AJAX
            //DEBEMOS DEVOLVER PartialView
            //PartialView DEBE TENER EL NOMBRE DE LA VISTA PARCIAL
            //Y EL MODELO SI LO NECESITAMOS
            return PartialView("_CochesPartial", this.Cars);
        }
    }
}
