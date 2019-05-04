using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Entity;
using Data.Interfaces;

namespace Data.Implementacion
{
    public class RepositorioDistrito : IRepositorioDistrito
    {
        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
        public List<Distrito> Listar()
        {
            var distritos = new List<Distrito>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT * FROM Distrito", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var distrito = new Distrito();

                            distrito.codigoDistrito = Convert.ToInt32(dr["codigo_distrito"]);
                            distrito.nombre = dr["Nombre"].ToString();
                            distritos.Add(distrito);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return distritos;
        }

        public Distrito ListarPorId(int? id)
        {
            throw new NotImplementedException();
        }


        public bool Actualizar(Distrito s)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Distrito s)
        {
            throw new NotImplementedException();
        }
    }
}
