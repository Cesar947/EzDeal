using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;


namespace Business.InterfacesServicio
{
    public interface IServicioUsuario : IServicioCRUD<Usuario>
    {
        List<Usuario> ListarCliente();
        List<Usuario> ListarAnunciante();
        bool InsertarCliente(Usuario c);
        bool InsertarAnunciante(Usuario a);
        bool ActualizarCliente(Usuario c);
        bool ActualizarAnunciante(Usuario a);
    }
}
