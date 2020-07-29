using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {


        public HomeController()
        {

        }


        public ActionResult Index()
        {
            //En todas las paginas y peticiones con esto saco los datos guardados en el login ej:
            
            var ctx = HttpContext.User.Identity;
            ////Method 2
            //var principal =ClaimsPrincipal.Current;
            //System.Security.Claims.Claim claim2 = principal.FindFirst("NAME_USER");


            ///y con esto recojes el dato gardado en la session en todas las peticiones 
            var principal = ClaimsPrincipal.Current;
            string IdUser = principal.FindFirst("Id_User").Value;
            //string nombre = principal.FindFirst("nombre").Value;
            // string Dato2 = principal.FindFirst("").Value;




            string texto = "***  hola ****";

            Debug.WriteLine("***   Init procces ");
           

                return View();
          
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}