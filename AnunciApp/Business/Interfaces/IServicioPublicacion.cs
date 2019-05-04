using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Business.InterfacesServicio
{
    public interface IServicioPublicacion : IServicioCRUD<Publicacion>
    {
        List<Publicacion> findByServicio(int codigo_servicio);
    }
}
