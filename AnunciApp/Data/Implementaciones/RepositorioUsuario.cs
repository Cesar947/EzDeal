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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public bool InsertarAnunciante(Usuario nuevoAnunciante)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();


                    var query = new SqlCommand("INSERT INTO Usuario Values( @contrasena,@email, @nombre, @apellidos," +
                        "@url_contacto, @telefono, @codigoDistrito, @rol)", conexion);
                    query.Parameters.AddWithValue("@email", nuevoAnunciante.email);
                    query.Parameters.AddWithValue("@contrasena", nuevoAnunciante.contrasena);
                    query.Parameters.AddWithValue("@nombre", nuevoAnunciante.nombre);
                    query.Parameters.AddWithValue("@apellidos", nuevoAnunciante.apellidos);
                    query.Parameters.AddWithValue("@telefono", nuevoAnunciante.telefono);
                    query.Parameters.AddWithValue("@url_contacto", nuevoAnunciante.urlContacto);
                    query.Parameters.AddWithValue("@codigoDistrito", nuevoAnunciante.codigoDistrito.codigoDistrito);
                    query.Parameters.AddWithValue("@rol", 1);
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

        public bool InsertarCliente(Usuario nuevoCliente)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();
                    //Cliente gileeees no se olviden

                    var query = new SqlCommand("INSERT INTO Usuario Values(@contrasena, @email, @nombre, @apellidos, null, null," +
                        " @codigoDistrito, @rol)", conexion);

                    query.Parameters.AddWithValue("@email", nuevoCliente.email);
                    query.Parameters.AddWithValue("@contrasena", nuevoCliente.contrasena);
                    query.Parameters.AddWithValue("@nombre", nuevoCliente.nombre);
                    query.Parameters.AddWithValue("@apellidos", nuevoCliente.apellidos);
                    query.Parameters.AddWithValue("@codigoDistrito", nuevoCliente.codigoDistrito.codigoDistrito);
                    query.Parameters.AddWithValue("@rol", '0');
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

        public bool Insertar(Usuario u)
        {
            throw new NotImplementedException();
        }

        public bool Actualizar(Usuario u)
        {
            throw new NotImplementedException();
        }

        public bool ActualizarAnunciante(Usuario anunciante)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("UPDATE Usuario set email = @Email, contrasena = @Contrasena, " +
                        "nombre = @Nombre, apellidos = @Apellidos, url_contacto = @Contacto, telefono = @Telefono," +
                        " codigo_Distrito = @Distrito where coidgo_usuario = @Id"
                       , conexion);
                    query.Parameters.AddWithValue("@Id", anunciante.codigoUsuario);
                    query.Parameters.AddWithValue("@Email", anunciante.email);
                    query.Parameters.AddWithValue("@Contrasena", anunciante.contrasena);
                    query.Parameters.AddWithValue("@Nombre", anunciante.nombre);
                    query.Parameters.AddWithValue("@Apellidos", anunciante.apellidos);
                    query.Parameters.AddWithValue("@Contacto", anunciante.urlContacto);
                    query.Parameters.AddWithValue("@Telefono", anunciante.telefono);
                    query.Parameters.AddWithValue("@Distrito", anunciante.codigoDistrito);
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

        public bool ActualizarCliente(Usuario cliente)
        {
            bool rpta = false;
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("UPDATE Usuario set email = @Email, contrasena = @Contrasena, " +
                        "nombre = @Nombre, apellidos = @Apellidos, codigo_Distrito = @Distrito where codigo_usuario = @Id"
                       , conexion);
                    query.Parameters.AddWithValue("@Id", cliente.codigoUsuario);
                    query.Parameters.AddWithValue("@Email", cliente.email);
                    query.Parameters.AddWithValue("@Contrasena", cliente.contrasena);
                    query.Parameters.AddWithValue("@Nombre", cliente.nombre);
                    query.Parameters.AddWithValue("@Apellidos", cliente.apellidos);
                    query.Parameters.AddWithValue("@Distrito", cliente.codigoDistrito.codigoDistrito);
                    //query.Parameters.AddWithValue("@Rol", cliente.rol);
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
                    var query = new SqlCommand("Delete from Usuario where codigo_usuario = @id", conexion);
                    query.Parameters.AddWithValue("@id", id);
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

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }
        public Usuario ListarPorId(int? id)
        {
            Usuario usuario = new Usuario();
            Distrito distrito = new Distrito();

            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("Select * from Usuario Where codigo_usuario = @id", conexion);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            usuario.codigoUsuario = Convert.ToInt32(dr["codigo_usuario"]);
                            distrito.codigoDistrito = Convert.ToInt32(dr["codigo_distrito"]);
                            usuario.contrasena = Convert.ToString(dr["contrasena"]);
                            usuario.email = Convert.ToString(dr["email"]);
                            usuario.nombre = Convert.ToString(dr["nombre"]);
                            usuario.apellidos = Convert.ToString(dr["apellidos"]);
                            usuario.urlContacto = Convert.ToString(dr["url_contacto"]);
                            usuario.telefono = Convert.ToString(dr["telefono"]);
                            usuario.rol = Convert.ToInt32(dr["rol"]);

                            usuario.codigoDistrito = distrito;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }

        public List<Usuario> ListarCliente()
        {
            var clientes = new List<Usuario>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();

                    var query = new SqlCommand("SELECT u.codigo_usuario as Codigo, u.email as Email, u.nombre as Nombre," +
                        " u.apellidos as Apellidos, d.nombre as Distrito" +
                        " FROM Usuario u join Distrito d on d.codigo_distrito = u.codigo_Distrito where u.rol = 0", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            var cliente = new Usuario();
                            var distrito = new Distrito();

                            cliente.codigoUsuario = Convert.ToInt32(dr["Codigo"]);
                            cliente.email = dr["Email"].ToString();
                            cliente.nombre = dr["Nombre"].ToString();
                            cliente.apellidos = dr["Apellidos"].ToString();
                            cliente.codigoDistrito = distrito;
                            cliente.codigoDistrito.nombre = dr["Distrito"].ToString();

                            clientes.Add(cliente);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return clientes;
        }

        public List<Usuario> ListarAnunciante()
        {
            var anunciantes = new List<Usuario>();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["servicioUPCDB"].ToString()))
                {
                    conexion.Open();
                    var query = new SqlCommand("SELECT u.codigo_usuario as Codigo, u.email as Email, u.nombre as Nombre, " +
                        "u.apellidos as Apellidos, u.url_contacto as Contacto, u.telefono as Telefono, d.nombre as Distrito " +
                        "FROM Usuario u, Distrito d where u.rol = 1 and d.codigo_distrito = u.codigo_distrito", conexion);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var anunciante = new Usuario();
                            var distrito = new Distrito();

                            anunciante.codigoUsuario = Convert.ToInt32(dr["Codigo"]);
                            anunciante.email = dr["Email"].ToString();
                            anunciante.nombre = dr["Nombre"].ToString();
                            anunciante.apellidos = dr["Apellidos"].ToString();
                            anunciante.urlContacto = dr["Contacto"].ToString();
                            anunciante.telefono = dr["Telefono"].ToString();
                            anunciante.codigoDistrito = distrito;
                            anunciante.codigoDistrito.nombre = dr["Distrito"].ToString();

                            anunciantes.Add(anunciante);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return anunciantes;

        }
    }
}

