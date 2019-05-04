using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.Interfaces
{
    public interface IRepositorioResena : IRepositorioCRUD<Resena>
    {
        //bool InsertarResena(Resena nuevaResena, Usuario clienteRemitente, Publicacion publicacionObjetivo);
    }
}
