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
    public class RepositorioSolicitud : IRepositorioSolicitud
    {
        public bool Insertar(Solicitud s)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("Insert into Solicitud values (@codigoPublicacion, @codigoCliente, @mensaje)", conexion);
                    query.Parameters.AddWithValue("@codigoPublicacion", s.codigoPublicacion.codigoPublicacion);
                    query.Parameters.AddWithValue("@codigoCliente", s.codigoCliente.codigoUsuario);
                    query.Parameters.AddWithValue("@mensaje", s.mensajeSolicitud);
                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rpta;
        }
        public bool Actualizar(Solicitud s)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE Solicitud set codigo_publicacion = @codigoPublicacion, codigo_cliente = @codigoCliente, mensaje_solicitud = @mensaje", conexion);
                    query.Parameters.AddWithValue("@codigoPublicacion", s.codigoPublicacion.codigoPublicacion);
                    query.Parameters.AddWithValue("@codigoCliente", s.codigoCliente.codigoUsuario);
                    query.Parameters.AddWithValue("@mensaje", s.mensajeSolicitud);
                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rpta;
        }
        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }
        public List<Solicitud> Listar()
        {
            var solicitudes = new List<Solicitud>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("Select s.codigo_solicitud, p.titulo as titulo , u.nombre as nombre_cliente, s.mensaje_solicitud as mensaje " +
                                                "FROM Solicitud s join Usuario u on s.codigo_cliente = u.codigo_usuario join Publicacion p on s.codigo_publicacion = p.codigo_publicacion", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var solicitud = new Solicitud();
                            var publicacion = new Publicacion();
                            var usuario = new Usuario();

                            solicitud.codigoSolicitud = Convert.ToInt32(dr["codigo_solicitud"]);
                            solicitud.codigoCliente = usuario;
                            solicitud.codigoCliente.nombre = dr["nombre_cliente"].ToString();
                            solicitud.codigoPublicacion = publicacion;
                            solicitud.codigoPublicacion.titulo = dr["titulo"].ToString();
                            solicitud.mensajeSolicitud = dr["mensaje"].ToString();

                            solicitudes.Add(solicitud);
                        }
                    }
                }
                return solicitudes;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public Solicitud ListarPorId(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
