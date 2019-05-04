using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.Interfaces
{
    public interface IRepositorioUsuario : IRepositorioCRUD<Usuario>
    {
        List<Usuario> ListarCliente();
        List<Usuario> ListarAnunciante();
        bool InsertarCliente(Usuario c);
        bool InsertarAnunciante(Usuario a);
        //bool EliminarCliente(int id);
        //bool EliminarAnunciante(int id);
        bool ActualizarCliente(Usuario c);
        bool ActualizarAnunciante(Usuario a);
    }
}
