using Datos.DBConexion;
using System.Data;
using Modelo;
using Modelo.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Negocio.Acciones
{
    public class AccionesMoteles : AccionesBD
    {
        public AccionesConsulta consulta = new AccionesConsulta();
        public List<_HabitacionXMotel> listMoteles()
        {
            return dbLibContext._HabitacionXMotel.ToList();
        }

        public _HabitacionXMotel Buscar_Precios(int Motel, int Tipo)
        {
            _HabitacionXMotel _HabitacionXMotel;
            _HabitacionXMotel = new _HabitacionXMotel();
            _HabitacionXMotel = dbLibContext._HabitacionXMotel.FirstOrDefault(x => x.Id_Motel == Motel && x.Id_TipoHabitaciones == Tipo);

            return _HabitacionXMotel;
        }

        public List<ServiciosXhabitaciones> listServicios(int motel)
        {            
            List<ServiciosXhabitaciones> Servicios = dbLibContext.ServiciosXhabitaciones.Where(x => x.ID_Motel == motel).ToList();
            return Servicios;
        }
        public List<Servicios> servicios()
        {
            List<Servicios> servicios = dbLibContext.Servicios.ToList();
            return servicios;
        }

    }
}
