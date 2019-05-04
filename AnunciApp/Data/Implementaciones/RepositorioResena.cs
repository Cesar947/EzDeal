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
    public class RepositorioResena : IRepositorioResena
    {
        public bool Insertar(Resena nuevaResena)
        {

            bool respuesta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("INSERT INTO Resena(contenido, valoracion, codigo_publicacion, codigo_cliente) VALUES(@contenido, @calificacion, @codigoPublicacion, @codigoClienteRemitente)", conexion);
                
                    query.Parameters.AddWithValue("@codigoPublicacion", nuevaResena.codigoPublicacion.codigoPublicacion);
                    query.Parameters.AddWithValue("@codigoClienteRemitente", nuevaResena.codigoCliente.codigoUsuario);
                    query.Parameters.AddWithValue("@contenido", nuevaResena.contenido);
                    query.Parameters.AddWithValue("@calificacion", nuevaResena.valoracion);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
          
        }

      /*   public bool InsertarResena(Resena nuevaResena, Usuario clienteRemitente, Publicacion publicacionObjetivo)
         {
            throw new NotImplementedException();


        }*/
        public bool Actualizar(Resena resenaSeleccionada)
        {
            bool respuesta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("UPDATE Resena SET valoracion = @valoracion, contenido = @contenido  where codigo_resena = @codigoResenaSeleccionada", conexion);
                    query.Parameters.AddWithValue("@codigoResenaSeleccionada", resenaSeleccionada.codigoResena);
                    query.Parameters.AddWithValue("@contenido", resenaSeleccionada.contenido);
                    query.Parameters.AddWithValue("@valoracion", resenaSeleccionada.valoracion);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }
        public bool Eliminar(int resenaID)
        {
            bool respuesta = false;

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("DELETE FROM Resena where codigo_resena = @codigoResenaSeleccionada", conexion);
                    query.Parameters.AddWithValue("@codigoResenaSeleccionada", resenaID);

                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }
        public List<Resena> Listar()
        {

            var resenas = new List<Resena>();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT r.codigo_resena as Codigo, p.titulo, c.nombre as Nombre,"+
                        " c.apellidos as Apellidos, r.contenido as Contenido, r.valoracion as Valoracion" +
                        "  FROM Resena r, Usuario c, Publicacion p where c.codigo_usuario = r.codigo_cliente AND"+
                        " p.codigo_publicacion = r.codigo_publicacion", conexion);
                    using (var dataReader = query.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var resena = new Resena();
                            var cliente = new Usuario();
                            var publicacion = new Publicacion();

                            resena.codigoResena = Convert.ToInt32(dataReader["Codigo"]);
                            resena.codigoCliente = cliente;
                            resena.codigoCliente.nombre = dataReader["Nombre"].ToString();
                            resena.codigoCliente.apellidos = dataReader["Apellidos"].ToString();
                            resena.codigoPublicacion = publicacion;
                            resena.codigoPublicacion.titulo = dataReader["Titulo"].ToString();
                            resena.contenido = dataReader["Contenido"].ToString();
                            resena.valoracion = Convert.ToInt32(dataReader["Valoracion"]);

                            resenas.Add(resena);

                        }
                    }

                }
                return resenas;
            }
            catch (Exception ex)
            {
                throw;
            }
       

        }
        public Resena ListarPorId(int? id) {


            var resena = new Resena();
            var cliente = new Usuario();
            var publicacion = new Publicacion();
         
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("SELECT * FROM Resena r where r.codigo_resena = @id", conexion);
                    query.Parameters.AddWithValue("@id", id);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            resena.codigoResena = Convert.ToInt32(dr["codigo_resena"]);
                            resena.codigoCliente = cliente;
                            resena.codigoCliente.codigoUsuario = Convert.ToInt32(dr["codigo_cliente"]);
                            resena.codigoPublicacion = publicacion;
                            resena.codigoPublicacion.codigoPublicacion = Convert.ToInt32(dr["codigo_publicacion"]);
                            resena.contenido = dr["contenido"].ToString();
                            resena.valoracion = Convert.ToInt32(dr["valoracion"]);

                        }
                    }
                }
                return resena;
            }
            catch(Exception ex)
            {
                throw;
            }

        }


    }
}
