using Datos.DBConexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio.Acciones;
using Negocio.Acciones;
using Modelo;
using System.Web.UI.WebControls;

namespace Vente_Aqui2.Controllers
{
    public class MotelesController : Controller
    {
        public AccionesMoteles Moteles = new Negocio.Acciones.AccionesMoteles();

        [Authorize]
        public ActionResult Tu_Kukita(int Id_Motel = 0)
        {
            List<ServiciosXhabitaciones> servicios;
            ViewBag.Servicios = servicios = Moteles.listServicios(Id_Motel);            
            List<ServiciosXhabitaciones> Basico = servicios.Where(x => x.ID_Habitaciones == 1).ToList();
            List<Servicios> LServicios = Moteles.servicios();
            ViewBag.Sbasico = Basico;
            ViewBag.LVIP = servicios.Where(x => x.ID_Habitaciones == 3).ToList();
            ViewBag.LPresidencial = servicios.Where(x => x.ID_Habitaciones ==2).ToList();
            ViewBag.LServicios = LServicios;
            _HabitacionXMotel Precio = Moteles.Buscar_Precios(Id_Motel, 1);
            if (Precio != null)
            {
                ViewBag.Basico = Precio.Precio;
            }
            _HabitacionXMotel Precio2 = Moteles.Buscar_Precios(Id_Motel, 3);
            if (Precio2 != null)
            {
                ViewBag.VIP = Precio2.Precio;
            }
            _HabitacionXMotel Precio3 = Moteles.Buscar_Precios(Id_Motel, 2);
            if (Precio3 != null)
            {
                ViewBag.Presidencial = Precio3.Precio;
            }



            return View();
        }
       
    }
}
