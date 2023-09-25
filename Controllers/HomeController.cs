using Modelo.Acciones;
using Negocio.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Vente_Aqui2.Controllers
{
    public class HomeController : Controller
    {
        public AccionesConsulta consultas = new AccionesConsulta();
        
        public ActionResult Index()
        {
            ViewBag.Moteles = consultas.moteles();
            return View();
        }        

        
    }
}