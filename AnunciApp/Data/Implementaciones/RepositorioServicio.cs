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
    public class RepositorioServicio : IRepositorioServicio
    {
        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
        public List<Servicio> Listar()
        {
            var servicios = new List<Servicio>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT * FROM Servicio", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var servicio = new Servicio();

                            servicio.codigoServicio = Convert.ToInt32(dr["codigo_servicio"]);
                            servicio.nombre = dr["Nombre"].ToString();
                            servicios.Add(servicio);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return servicios;
        }

        public Servicio ListarPorId(int? id)
        {
            throw new NotImplementedException();
        }


        public bool Actualizar(Servicio s)
        {
            throw new NotImplementedException();
        }

        public bool Insertar(Servicio s)
        {
            throw new NotImplementedException();
        }
    }
}
