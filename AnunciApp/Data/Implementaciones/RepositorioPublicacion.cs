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
    public class RepositorioPublicacion : IRepositorioPublicacion
    {
        public bool Insertar(Publicacion t)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("Insert into Publicacion values (@publicista, @titulo, @descripcion, @costo, @servicio)", conexion);
                    query.Parameters.AddWithValue("@publicista", t.codigoPublicista.codigoUsuario);
                    query.Parameters.AddWithValue("@titulo", t.titulo);
                    query.Parameters.AddWithValue("@descripcion", t.descripcion);
                    query.Parameters.AddWithValue("@costo", t.costoServicio);
                    query.Parameters.AddWithValue("@servicio", t.codigoServicio.codigoServicio);
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
        public bool Actualizar(Publicacion t)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();
                
                    //var publicacionSeleccionada = ListarPorId(id)

                    var query = new SqlCommand("UPDATE Publicacion set titulo = @titulo, descripcion = @descripcion, costo_servicio = @costo, codigo_servicio = @servicio where codigo_publicacion = @publicacionID", conexion);
                    query.Parameters.AddWithValue("@publicacionID", t.codigoPublicacion);
                    query.Parameters.AddWithValue("@titulo", t.titulo);
                    query.Parameters.AddWithValue("@descripcion", t.descripcion);
                    query.Parameters.AddWithValue("@costo", t.costoServicio);
                    query.Parameters.AddWithValue("@servicio", t.codigoServicio.codigoServicio);
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
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("Delete from Publicacion where codigo_publicacion = @id", conexion);
                    query.Parameters.AddWithValue("@id", id);
                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return rpta;
        }
        public List<Publicacion> Listar()
        {
            var anuncios = new List<Publicacion>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("Select p.codigo_publicacion, u.nombre as nombre_publicista, p.codigo_publicista, p.titulo, p.descripcion as descripcion, p.costo_servicio, p.codigo_servicio, s.nombre as servicio" +
                                               " FROM Publicacion p join Usuario u on p.codigo_publicista = u.codigo_usuario join Servicio s on s.codigo_servicio = p.codigo_Servicio ", conexion);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var publicacion = new Publicacion();
                            var usuario = new Usuario();
                            var servicio = new Servicio();

                            publicacion.codigoPublicacion = Convert.ToInt32(dr["codigo_publicacion"]);
                            publicacion.codigoPublicista = usuario;
                            publicacion.codigoPublicista.codigoUsuario = Convert.ToInt32(dr["codigo_publicista"]);
                            publicacion.codigoPublicista.nombre = dr["nombre_publicista"].ToString();
                            publicacion.titulo = dr["titulo"].ToString();
                            publicacion.descripcion = dr["descripcion"].ToString();
                            publicacion.costoServicio = Convert.ToInt32(dr["costo_servicio"]);
                            publicacion.codigoServicio = servicio;
                            publicacion.codigoServicio.codigoServicio = Convert.ToInt32(dr["codigo_servicio"]);
                            publicacion.codigoServicio.nombre = dr["servicio"].ToString();

                            anuncios.Add(publicacion);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return anuncios;
        }
        public Publicacion ListarPorId(int? id)
        {
            Publicacion publicacion = new Publicacion();
            Usuario usuario = new Usuario();
            Servicio servicio = new Servicio();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("Select * from Publicacion Where codigo_publicacion = @id", conexion);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            publicacion.codigoPublicacion = Convert.ToInt32(dr["codigo_publicacion"]);
                            publicacion.codigoPublicista = usuario;
                            publicacion.codigoPublicista.codigoUsuario = Convert.ToInt32(dr["codigo_publicista"]);
                            publicacion.titulo = dr["titulo"].ToString();
                            publicacion.descripcion = dr["descripcion"].ToString();
                            publicacion.costoServicio = Convert.ToInt32(dr["costo_servicio"]);
                            publicacion.codigoServicio = servicio;
                            publicacion.codigoServicio.codigoServicio = Convert.ToInt32(dr["codigo_servicio"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return publicacion;
        }
    }
}

