using Modelo;
using Modelo.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Datos.DBConexion;
using System.Data;
using System.Security.AccessControl;

namespace Vente_Aqui2.Controllers
{
    public class RegistrarController : Controller
    {
        // Vinculacion a Acciones Consulta en capa de Datos
        public AccionesConsulta consulta = new AccionesConsulta();

        //Retorno de vista para poder registrar moteles
        
        public ActionResult Registrar(string valor = "")
        {
            int ID_User = (int)(Session["ID_USer"]);
            int ID = consulta.buscarID(ID_User);
            ViewBag.validar = TempData["Mensaje"];
            ViewBag.Verificar = valor;
            return View();
        }

        //Todos los metodos de guardar
        #region

        [HttpPost]
        public ActionResult GuardarDatos(string nombre_text = "", string Ubicacion_text = "", int idsector = 0, int Pago1 = 0, int Pago2 = 0)
        {
            var User = (int)(Session["ID_USer"]);

            if (consulta.registrarMotel(nombre_text, Ubicacion_text, idsector, Pago1, Pago2, User))
            {
                
                return RedirectToAction("Registrar", new {valor = "Se guardo" });
            }
            
            return RedirectToAction("Registrar", new {valor = "No se guardo"});
        }

        [HttpPost]
        public ActionResult Guardar_Habitacion(int Tipo = 0,int Precio =0, int Tipo2 = 0, int Precio2 = 0,  int Tipo3 =0, int Precio3 =0)
        {
            int ID_User = (int)(Session["ID_USer"]);
            int ID = consulta.buscarID(ID_User);

            if (consulta.GuardarHabitaciones(Tipo, Precio, Tipo2, Precio2, ID,Tipo3,Precio3))
            {
                TempData["Mensaje"] = "Se guardo.";
                return RedirectToAction("Registrar");

                
            }
            TempData["Mensaje"] = "No se guardo.";
            return RedirectToAction("Registrar");
        }
        [HttpPost]
        public ActionResult Guardar_Servicios(int ID_Habitacion =0, int ID_Habitacion2 = 0, int ID_Habitacion3 = 0, int Aire =0, int Televisor = 0, int Jacuzzi = 0, int Kamasutra = 0, int WiFi = 0, int Aire2 = 0, int Televisor2 = 0, int Jacuzzi2 = 0, int Kamasutra2 = 0, int WiFi2 = 0,
            int Aire3 = 0, int Televisor3 = 0, int Jacuzzi3 = 0, int Kamasutra3 = 0, int WiFi3 = 0)
        {
            int ID_User = (int)(Session["ID_USer"]);
            int ID = consulta.buscarID(ID_User);
            consulta.Guardar_Servicio(ID, ID_Habitacion, Aire, ID_Habitacion2, Televisor, ID_Habitacion3, Jacuzzi, Kamasutra, WiFi, Aire2, Televisor2, Jacuzzi2, Kamasutra2,WiFi2,
                Aire3, Televisor3, Jacuzzi3, Kamasutra3, WiFi3);

            return RedirectToAction("Registrar");
        }

        #endregion

        //Retorno de vista de administrador a partir de login
        [Authorize]
        public ActionResult VistaAdministrador() 
        {
            return View();
        }

        //Retorno de vista de cliente a partir de login
        [Authorize]
        public ActionResult VistaCliente() 
        {
            return View();
        }


    }
}