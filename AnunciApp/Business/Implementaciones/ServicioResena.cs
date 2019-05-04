using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Business.InterfacesServicio;
using Business.Implementaciones;
using Data.Implementacion;
using Data.Interfaces;

namespace Business.Implementaciones
{
    public class ServicioResena : IServicioResena
    {
        private IRepositorioResena repositorioResena = new RepositorioResena();

     /* public bool InsertarResena(Resena nuevaResena, Usuario clienteRemitente, Publicacion publicacionObjetivo)
        {
            throw new NotImplementedException();
        }*/
        
        public bool Insertar(Resena nuevaResena)
        {
            return repositorioResena.Insertar(nuevaResena);
        }
        public bool Actualizar(Resena resenaSeleccionada)
        {
            return repositorioResena.Actualizar(resenaSeleccionada);
        }
        public bool Eliminar(int resenaID)
        {
            return repositorioResena.Eliminar(resenaID);
        }
        public List<Resena> Listar()
        {
            return repositorioResena.Listar();
        }
        public Resena ListarPorId(int? id)
        {
            return repositorioResena.ListarPorId(id);
        }
    }
}
