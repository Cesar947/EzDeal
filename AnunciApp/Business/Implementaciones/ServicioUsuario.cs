using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data.Implementacion;
using Data.Interfaces;
using Business.InterfacesServicio;

namespace Business.Implementaciones
{
    public class ServicioUsuario : IServicioUsuario
    {

        IRepositorioUsuario repositorioUsuario = new RepositorioUsuario();

        public List<Usuario> ListarCliente()
        {
            return repositorioUsuario.ListarCliente();
        }
        public List<Usuario> ListarAnunciante()
        {
            return repositorioUsuario.ListarAnunciante();
        }
        public bool InsertarCliente(Usuario c)
        {
            return repositorioUsuario.InsertarCliente(c);
        }
        public bool InsertarAnunciante(Usuario a)
        {
            return repositorioUsuario.InsertarAnunciante(a);
        }
        public bool ActualizarCliente(Usuario c)
        {
            return repositorioUsuario.ActualizarCliente(c);
        }
        public bool ActualizarAnunciante(Usuario a)
        {
            return repositorioUsuario.ActualizarAnunciante(a);
        }
        public bool Eliminar(int id)
        {
            return repositorioUsuario.Eliminar(id);
        }
        public bool Insertar(Usuario u)
        {
            throw new NotImplementedException();
        }
        public bool Actualizar(Usuario u)
        {
            throw new NotImplementedException();
        }
        public List<Usuario> Listar()
        {
            return repositorioUsuario.Listar();
        }
        public Usuario ListarPorId(int? id)
        {
            return repositorioUsuario.ListarPorId(id);
        }
    }
}
