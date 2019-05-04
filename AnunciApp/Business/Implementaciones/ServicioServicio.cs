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
    public class ServicioServicio : IServicioServicio
    {
        private IRepositorioServicio repositorioServicio = new RepositorioServicio();
        public bool Insertar(Servicio t)
        {
            return repositorioServicio.Insertar(t);
        }
        public bool Actualizar(Servicio t)
        {
            return repositorioServicio.Actualizar(t);
        }
        public bool Eliminar(int id)
        {
            return repositorioServicio.Eliminar(id);
        }
        public List<Servicio> Listar()
        {
            return repositorioServicio.Listar();
        }
        public Servicio ListarPorId(int? id)
        {
            return repositorioServicio.ListarPorId(id);
        }
    }
}
