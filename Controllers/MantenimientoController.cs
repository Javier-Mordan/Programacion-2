using Datos.DBConexion;
using Microsoft.Ajax.Utilities;
using Modelo;
using Modelo.Acciones;
using Negocio.Acciones;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vente_Aqui2.Controllers
{

    public class MantenimientoController : Controller
    {
        
        public AccionesMantenimiento mant = new AccionesMantenimiento();
        

        //Llamar a vista para poder realizar el loggeo de las acciones de mantenimiento

        
        public ActionResult LogsMantenimiento()
        {
            List<LogMantenimiento_Tabla> Log = mant.LogMantenimiento_Tablas();
            return View(Log);
        }

        //Acciones de guardar, eliminar y editar
        #region 

        public ActionResult Eliminar(int id)
        {
            if(mant.Eliminar(id))
            {
                TempData["Mensaje"] = "Eliminado correctamente";
                return RedirectToAction("LogsMantenimiento");
            }

            TempData["Mensaje"] = "No se pudo eliminar";
            return RedirectToAction("LogsMantenimiento");
        }


        [HttpPost]        
        public ActionResult GuardarDatos(string txtDescripcion = "", string txtNombre = "")
        {
            try
            {
                mant.RegistrarMant(txtDescripcion, txtNombre);
                TempData["Mensaje"] = "Se Guardo correctamente";
                return RedirectToAction("LogsMantenimiento");
            }
            catch
            {
                TempData["Mensaje"] = "No se pudo guardar";
                return RedirectToAction("LogsMantenimiento");
            }

        }

        
        [HttpGet]

        public ActionResult Editar(int id)
        {           

            LogMantenimiento_Tabla p = mant.Buscar(id);
            ViewBag.Mantenimiento = p.Id_Tabla;
            ViewBag.Nombre = p.Nom_Usuario;
            ViewBag.Descripcion = p.Descripcion;
            return View();
        }


        [HttpPost]
        public ActionResult RealizarEdicion(int ID_Tabla = 0,string nombre = "",string descripcion = "")
        {
            try
            {
                mant.Editar(ID_Tabla, nombre, descripcion);
                TempData["mensaje"] = "Se edito correctamente.";
                RedirectToAction("LogsMantenimiento");
            }
            catch
            {
                TempData["mensaje"] = "No se pudo editar";
                RedirectToAction("LogsMantenimiento");
            }
            return RedirectToAction("LogsMantenimiento");
        }

        #endregion


    }

}