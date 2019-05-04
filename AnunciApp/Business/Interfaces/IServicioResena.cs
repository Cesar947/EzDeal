using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Business.InterfacesServicio;

namespace Business.InterfacesServicio
{
    public interface IServicioResena : IServicioCRUD <Resena>
    {
        //bool InsertarResena(Resena nuevaResena, Usuario clienteRemitente, Publicacion publicacionObjetivo);
    }
}
