using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bizagi.Business.Reports.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string message,  int error = 0)
        {
            switch (error)
            {
                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.Description = "Esto es muy vergonzoso, esperemos que no vuelva a pasar ..";
                    ViewBag.MessageEx = message;                    
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "La URL que está intentando ingresar no existe";
                    ViewBag.MessageEx = message;                    
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Algo salio muy mal :( ..";
                    ViewBag.MessageEx = message;                    
                    break;
            }
            return View("~/Views/Error/Index.cshtml");
        }
    }
}