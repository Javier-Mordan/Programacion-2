using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.DBConexion;
using System.Data;
using System.Windows.Markup;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;

namespace Modelo.Acciones 
{ 

        public class AccionesConsulta : AccionesBD
        {
        public List<Motel> moteles()
        {
            List<Motel> moteles = dbLibContext.Motel.ToList();
        return moteles;
        }

        //Metodo de listado de moteles 
        #region ListadoMoteles
        public List<Motel> listMoteles()
            {
            return dbLibContext.Motel.ToList();
            }
        //Listar la tabla de motel formas de pago
        public List<Motel_Forma_Pago> listMPagos()
        {
            return dbLibContext.Motel_Forma_Pago.ToList();
        }

        public List<_HabitacionXMotel> listHabitacion()
        {
            return dbLibContext._HabitacionXMotel.ToList();
        }

        //public List<Formas_de_pagoXMotele> listFormadePago()
        //{
        //    return dbLibContext.Formas_de_pagoXMoteles.ToList();
        //}

       
        #endregion
        
        //Metodo para guardar datos de moteles en la base de datos
        #region Registrar
        public bool registrarMotel(string nombre, string ubicacion, int idsector,int formaPago1 , int formapago2, int User)
        {
            string resultado = "";
            bool verificar = false;
            try
            {
                Motel_Forma_Pago Pagos;
                dbLibContext.Guardar_Motel(nombre, ubicacion, idsector, User);
                

                //buscar el ultimo id insertado
                var ultimoRegistro = dbLibContext.Motel.FirstOrDefault(x => x.ID_Usuario == User);
                
                int maxHotel = ultimoRegistro.Id_Motel;

                //validar cual forma de pago fue seleccionada
                int tipoPagos = (formaPago1 > 0 || formapago2 > 0) ? 1 : 2 ;
                //Guardando las formas de pago
                if (formaPago1 > 0 && formapago2 > 0)
                {
                    dbLibContext.GuardarPagos(maxHotel, formaPago1);                    
                    dbLibContext.SubmitChanges();
                    dbLibContext.GuardarPagos(maxHotel, formapago2);

                }
                else
                {
                    dbLibContext.GuardarPagos(maxHotel, tipoPagos);
                    dbLibContext.SubmitChanges();
                }          
                                                                   
                
                dbLibContext.SubmitChanges();

                return verificar = true;
            }
            catch (Exception e)
            {

                return verificar = false;
            }

            return verificar;

        }

        #endregion

        //Accion de listado usuarios registrados

        #region ListadoUsuarios
        public List<Lista_Usuarios> listadousuarios()
        {
            return dbLibContext.Lista_Usuarios.ToList();
        }
        #endregion
        
        //Guardar nuevos usuarios        
        #region Guardar nuevos usuarios
        public string RegistrarUsuarios(string Usuario, string pws)
        {
            try
            {                

                

                using (SHA256 sha256 = SHA256.Create())
                {

                    byte[] bytes = Encoding.UTF8.GetBytes(pws);

                    // Calcula el hash
                    byte[] hashBytes = sha256.ComputeHash(bytes);

                    // Convierte el hash en una cadena hexadecimal
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    string password = builder.ToString();

                    dbLibContext.Guardar_Usuario(Usuario, pws, "Client", true);
                }
                return "Se guardo correctamente";

            }catch
            {
                return "No se guardo";
            }

        }
        #endregion

        //Guardar habitaciones
        #region
        public bool GuardarHabitaciones(int Tipo1, int precio1, int Tipo2, int precio2, int ID, int Tipo3, int precio3)
        {
            try
            {
                dbLibContext.Guardar_Habitaciones(precio1, ID,Tipo1);
                dbLibContext.Guardar_Habitaciones(precio2, ID,Tipo2);
                dbLibContext.Guardar_Habitaciones(precio3, ID, Tipo3);
                
                return true;
            }
            catch { return false; }
        }
        public int buscarID(int ID)
        {
            return dbLibContext.Motel.OrderByDescending(x => x.Id_Motel).FirstOrDefault(x => x.ID_Usuario == ID)?.Id_Motel ?? 0;
        }
        #endregion

        //Guardar Servicios
        #region

        public void Guardar_Servicio(int Motel, int Habitacion, int Servicio, int Habitacion2, int Servicio2, int Habitacion3, int Servicio3, int Servicio4, int Servicio5,
            int Servicio01, int Servicio02, int Servicio03, int Servicio04, int Servicio05, int Servicio11, int Servicio12, int Servicio13, int Servicio14, int Servicio15)
        {
            try
            {
                if (Servicio != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion, Servicio);

                }
                if (Servicio2 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion, Servicio2);

                }
                if (Servicio3 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion, Servicio3);

                }
                if (Servicio4 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion, Servicio4);

                }
                if (Servicio5 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion, Servicio5);

                }
                if (Servicio01 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion2, Servicio01);

                }
                if (Servicio02 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion2, Servicio02);

                }
                if (Servicio03 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion2, Servicio03);

                }
                if (Servicio04 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion2, Servicio04);
                    
                }
                if (Servicio05 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion2, Servicio05);

                }
                if (Servicio11 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion3, Servicio11);

                }
                if (Servicio12 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion3, Servicio12);

                }
                if (Servicio13 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion3, Servicio13);

                }
                if (Servicio14 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion3, Servicio14);

                }
                if (Servicio15 != 0)
                {
                    dbLibContext.Guardar_Servicios(Motel, Habitacion3, Servicio15);

                }
            }
            catch
            {
                
            }
                    
        }

        public List<ServiciosXhabitaciones> ListaServisios(int ID)
        {
            var Servicios = dbLibContext.ServiciosXhabitaciones.Where(x => x.ID_Motel == ID).ToList();
            return Servicios;
        }
        #endregion

        #region
        public string Desencriptar( int passw)
        {

            string psw = passw.ToString();
            using (SHA256 sha256 = SHA256.Create())
            {

                byte[] bytes = Encoding.UTF8.GetBytes(psw);

                // Calcula el hash
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convierte el hash en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                string password = builder.ToString();

                return password;
            }
        }
        #endregion

        public int ID_Motel (string name, string psw)
        {
            var User = dbLibContext.Lista_Usuarios.FirstOrDefault(x => x.Nom_Usuario == name && x.Psswd == psw);
            return User.Id_Usuario;
        }
    }
}
