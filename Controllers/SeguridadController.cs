using Modelo.Acciones;
using Negocio.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;

namespace Vente_Aqui2.Controllers
{
    public class SeguridadController : Controller
    {
        //Vinculacion a Acciones Consulta en capa de Datos
        public AccionesConsulta validar = new AccionesConsulta();
        public AccionesMantenimiento mantenimiento = new AccionesMantenimiento();

        //Creando la vista del signup
        #region Sign-up
       
        
        [HttpPost]
        public ActionResult Verificar_Usuario(string uname = "", string psw = "", string psw2 = "", int user = 0) 
        {
            try
            {
                bool verificado = false;
                while (verificado != true)
                {
                    if (psw == psw2)
                    {
                        validar.RegistrarUsuarios(uname, psw2);
                        verificado = true;
                    }
                    else
                    {
                        verificado = false;
                    }
                }

                string vista = "";

                string controlador = "";
                vista = "VistaCliente";
                controlador = "Registrar";
                return RedirectToAction(vista, controlador);
            }
            catch
            {
                return RedirectToAction("VistaCliente", "Registrar");
            }

        }
        #endregion

        //Retorno de vista para Login

        #region Login
        public ActionResult Login()
        {
          return View();
        }
        
        

        [HttpPost]
        

        //Proceso de verificacion de datos para el LogIn
        public ActionResult VerificarLogin(string uname, string psw ) 
        {
            var Usuario = validar.listadousuarios().ToList();
            string vista= "";
            string controlador = "";
            mantenimiento.Cambiar_Estado(uname);                  

            try
            {
                
                if (Usuario.Exists(x => x.Nom_Usuario == uname && x.Psswd == psw && x.Tipo_usuario == "Client"))
                {

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                        1,                              // Número de versión del ticket (normalmente 1)
                        uname,                       // Nombre de usuario autenticado
                        DateTime.Now,                   // Hora de emisión del ticket
                        DateTime.Now.AddMinutes(30),    // Hora de expiración del ticket (30 minutos en este ejemplo)
                        false,                          // Persiste en cookies (false para no persistente)
                         ""
                    );

                    Session["ID_USer"] = validar.ID_Motel(uname,psw);

                    
                    return RedirectToAction("Index", "Home");
                }               

                else
                {
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Home", "Home");

            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }

        #endregion 
    }
}