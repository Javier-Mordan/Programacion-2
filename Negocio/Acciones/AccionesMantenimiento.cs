using Datos.DBConexion;
using Modelo;
using Modelo.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Acciones
{
    public  class AccionesMantenimiento : AccionesBD
    {
            

        public List<LogMantenimiento_Tabla> LogMantenimiento_Tablas()
        {
            return dbLibContext.LogMantenimiento_Tabla.ToList();
        }

        public void Cambiar_Estado(string user)
        {
            dbLibContext.Registro(user);
        }


        #region
        //Guardar nuevos mantenimientos        
        #region Guardar nuevos usuarios
        public void RegistrarMant(string txtDescripcion, string txtNombre)
        {           

            try
            {
                LogMantenimiento_Tabla tabla;
                bool validar = false;
                while(validar == false)
                {
                    
                    var usuario = dbLibContext.Lista_Usuarios.FirstOrDefault(u => u.Nom_Usuario == txtNombre);
                    if (usuario != null)
                    {
                        // Obtener el valor si el usuario existe
                        var valor = usuario.Estatus;
                        validar = true;
                    }                    
                }                
                

                tabla = new LogMantenimiento_Tabla
                {
                    Descripcion = txtDescripcion,
                    Nom_Usuario = txtNombre,
                    Fecha = DateTime.Now,
                    Estatus = "Activo"

                };
                dbLibContext.LogMantenimiento_Tabla.InsertOnSubmit(tabla);
                dbLibContext.SubmitChanges();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

        }
        #endregion

        //Buscar por Id

        public LogMantenimiento_Tabla Buscar(int id_tabla)
        {
            List<LogMantenimiento_Tabla> Tabla = LogMantenimiento_Tablas();

            LogMantenimiento_Tabla Mantenimiento = Tabla.FirstOrDefault(x=> x.Id_Tabla == id_tabla);

            return Mantenimiento;

        }

        //Eliminar Mantenimientos

        #region
        public bool Eliminar( int id)
        {
            try
            {
                dbLibContext.EliminarRegistroPorID(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        //Modificar tabla
        public bool Editar(int ID_Tabla,string nombre, string descripcion)
        {
            try
            {
                DateTime fecha = DateTime.Now;
                string Estatus = "Activo";
                dbLibContext.EditarMantenimiento(ID_Tabla,nombre, descripcion, fecha, Estatus);
                return true;
            }catch (Exception ex) 
            {
                return false;
            }
        }
        #endregion
    }
}
