using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data.Interfaces;
using Data.Implementacion;
using Business.InterfacesServicio;

namespace Business.Implementaciones
{
    public class ServicioSolicitud : IServicioSolicitud
    {
        private IRepositorioSolicitud repositorioSolicitud = new RepositorioSolicitud();
        public bool Insertar(Solicitud t)
        {
            return repositorioSolicitud.Insertar(t);
        }
        public bool Actualizar(Solicitud t)
        {
            return repositorioSolicitud.Actualizar(t);
        }
        public bool Eliminar(int id)
        {
            return repositorioSolicitud.Eliminar(id);
        }
        public List<Solicitud> Listar()
        {
            return repositorioSolicitud.Listar();
        }
        public Solicitud ListarPorId(int? id)
        {
            return repositorioSolicitud.ListarPorId(id);
        }
    }
}

