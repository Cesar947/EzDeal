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
    public class ServicioPublicacion : IServicioPublicacion
    {
        private IRepositorioPublicacion repositorioPublicacion = new RepositorioPublicacion();
        public bool Insertar(Publicacion t)
        {
            return repositorioPublicacion.Insertar(t);
        }
        public bool Actualizar(Publicacion t)
        {
            return repositorioPublicacion.Actualizar(t);
        }
        public bool Eliminar(int id)
        {
             return repositorioPublicacion.Eliminar(id);
        }
        public List<Publicacion> Listar()
        {
            return repositorioPublicacion.Listar();
        }
        public Publicacion ListarPorId(int? id)
        {
            return repositorioPublicacion.ListarPorId(id);
        }
        public List<Publicacion> findByServicio(int codigo_servicio)
        {
            return repositorioPublicacion.findByServicio(codigo_servicio);
        }
    }
}
