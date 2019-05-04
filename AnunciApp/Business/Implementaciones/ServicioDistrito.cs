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
    public class ServicioDistrito : IServicioDistrito
    {
        private IRepositorioDistrito repositorioDistrito = new RepositorioDistrito();
        public bool Insertar(Distrito t)
        {
            return repositorioDistrito.Insertar(t);
        }
        public bool Actualizar(Distrito t)
        {
            return repositorioDistrito.Actualizar(t);
        }
        public bool Eliminar(int id)
        {
            return repositorioDistrito.Eliminar(id);
        }
        public List<Distrito> Listar()
        {
            return repositorioDistrito.Listar();
        }
        public Distrito ListarPorId(int? id)
        {
            return repositorioDistrito.ListarPorId(id);
        }
    }
}
