using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRepositorioCRUD<T>
    {
        bool Insertar(T t);
        bool Actualizar(T t);
        bool Eliminar(int id);
        List<T> Listar();
        T ListarPorId(int? id);
    }
}
