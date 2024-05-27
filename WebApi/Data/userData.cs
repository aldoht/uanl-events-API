using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WebApi.Models;

namespace WebApi.Data
{
    public class userData
    {
        public static bool signUp(User usuario)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection.urlConn))
            {
                SqlCommand spInsercion = new SqlCommand("InsertarUsuario", conn);
                spInsercion.CommandType = CommandType.StoredProcedure;
                spInsercion.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                spInsercion.Parameters.AddWithValue("@IdDependencia", usuario.IdDependencia);
                spInsercion.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                spInsercion.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                spInsercion.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                spInsercion.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                spInsercion.Parameters.AddWithValue("@CorreoUniversitario", usuario.Correo);
                spInsercion.Parameters.AddWithValue("@IdRol", usuario.IdRol);

                try
                {
                    conn.Open();
                    spInsercion.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static bool createUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection.urlConn))
            {
                SqlCommand spInsercion = new SqlCommand("InsertarUsuario", conn);
                spInsercion.CommandType = CommandType.StoredProcedure;
                spInsercion.Parameters.AddWithValue("@IdUsuario", user.IdUsuario);
                spInsercion.Parameters.AddWithValue("@IdDependencia", user.IdDependencia);
                spInsercion.Parameters.AddWithValue("@Nombre", user.Nombre);
                spInsercion.Parameters.AddWithValue("@ApellidoMaterno", user.ApellidoMaterno);
                spInsercion.Parameters.AddWithValue("@ApellidoPaterno", user.ApellidoPaterno);
                spInsercion.Parameters.AddWithValue("@Teléfono", user.Telefono);
                spInsercion.Parameters.AddWithValue("@CorreoUniversitario", user.Correo);
                spInsercion.Parameters.AddWithValue("@IdRol", user.IdRol);

                try
                {
                    conn.Open();
                    spInsercion.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }


        public static bool createEvent(Event evento)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection.urlConn))
            {
                SqlCommand spInsercion = new SqlCommand("InsertarEvento", conn);
                spInsercion.CommandType = CommandType.StoredProcedure;
                spInsercion.Parameters.AddWithValue("@IdCategoria", evento.IdCategoria);
                spInsercion.Parameters.AddWithValue("@Nombre", evento.Nombre);
                spInsercion.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                spInsercion.Parameters.AddWithValue("@Fecha", evento.Fecha);
                spInsercion.Parameters.AddWithValue("@Poster", evento.Poster);
                spInsercion.Parameters.AddWithValue("@Hora", evento.Hora);
                spInsercion.Parameters.AddWithValue("@IdUsuario", evento.IdUsuario);
                spInsercion.Parameters.AddWithValue("@Lugar", evento.Lugar);
                spInsercion.Parameters.AddWithValue("@Costo", evento.Costo);
                spInsercion.Parameters.AddWithValue("@EsNumerado", evento.EsNumerado);
                spInsercion.Parameters.AddWithValue("@Cupo", evento.Cupo);
                spInsercion.Parameters.AddWithValue("@IdDependencia", evento.IdDependencia);

                try
                {
                    conn.Open();
                    var ultimoIdEvento = spInsercion.ExecuteScalar();

                    if (ultimoIdEvento != DBNull.Value)
                    {
                        evento.IdEvento = Convert.ToInt32(ultimoIdEvento);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }


        public bool deleteEvent(int idEvento)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection.urlConn))
            {
                SqlCommand spEliminacion = new SqlCommand("EliminarEvento", conn);
                spEliminacion.CommandType = CommandType.StoredProcedure;
                spEliminacion.Parameters.AddWithValue("@IdEvento", idEvento);

                try
                {
                    conn.Open();
                    spEliminacion.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public bool editEvent(Event evento)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection.urlConn))
            {
                SqlCommand spModificacion = new SqlCommand("EditarEvento", conn);
                spModificacion.CommandType = CommandType.StoredProcedure;
                spModificacion.Parameters.AddWithValue("@IdEvento", evento.IdEvento);
                spModificacion.Parameters.AddWithValue("@IdCategoria", evento.IdCategoria);
                spModificacion.Parameters.AddWithValue("@Nombre", evento.Nombre);
                spModificacion.Parameters.AddWithValue("@Descripcion", evento.Descripcion);
                spModificacion.Parameters.AddWithValue("@Fecha", evento.Fecha);
                spModificacion.Parameters.AddWithValue("@Poster", evento.Poster);
                spModificacion.Parameters.AddWithValue("@Hora", evento.Hora);
                spModificacion.Parameters.AddWithValue("@IdUsuario", evento.IdUsuario);
                spModificacion.Parameters.AddWithValue("@Lugar", evento.Lugar);
                spModificacion.Parameters.AddWithValue("@Costo", evento.Costo);
                spModificacion.Parameters.AddWithValue("@EsNumerado", evento.EsNumerado);
                spModificacion.Parameters.AddWithValue("@Cupo", evento.Cupo);
                spModificacion.Parameters.AddWithValue("@IdDependencia", evento.IdDependencia);

                try
                {
                    conn.Open();
                    spModificacion.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public List<Event> GetEvents()
        {
            List<Event> eventos = new List<Event>();

            using (SqlConnection conn = new SqlConnection(dbConnection.urlConn))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Eventos", conn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Event evento = new Event
                            {
                                IdEvento = reader.GetInt32(reader.GetOrdinal("IdEvento")),
                                IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                                Poster = reader.GetString(reader.GetOrdinal("Poster")),
                                Hora = reader.GetTimeSpan(reader.GetOrdinal("Hora")),
                                IdUsuario = reader.GetString(reader.GetOrdinal("IdUsuario")),
                                Lugar = reader.GetString(reader.GetOrdinal("Lugar")),
                                Costo = reader.GetDecimal(reader.GetOrdinal("Costo")),
                                EsNumerado = reader.GetBoolean(reader.GetOrdinal("EsNumerado")),
                                Cupo = reader.GetInt32(reader.GetOrdinal("Cupo")),
                                IdDependencia = reader.GetInt32(reader.GetOrdinal("IdDependencia"))
                            };
                            eventos.Add(evento);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return eventos;
        }

        public bool crearBoleto(Ticket boleto)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection.urlConn))
            {
                SqlCommand spInsercion = new SqlCommand("CrearBoleto", conn);
                spInsercion.CommandType = CommandType.StoredProcedure;
                spInsercion.Parameters.AddWithValue("@IdRegistro", boleto.IdRegistro);
                spInsercion.Parameters.AddWithValue("@CodigoQR", boleto.CodigoQR);
                spInsercion.Parameters.AddWithValue("@Asistencia", boleto.Asistencia);
                spInsercion.Parameters.AddWithValue("@Imagen", boleto.Imagen);

                try
                {
                    conn.Open();
                    spInsercion.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public User buscarUsuario(string IdUsuario)
        {
            User usuario = null;

            using (SqlConnection conn = new SqlConnection(dbConnection.urlConn))
            {
                SqlCommand spBusqueda = new SqlCommand("BuscarUsuario", conn);
                spBusqueda.CommandType = CommandType.StoredProcedure;
                spBusqueda.Parameters.AddWithValue("@IdUsuario", IdUsuario);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = spBusqueda.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new User
                            {
                                IdUsuario = reader.GetString(reader.GetOrdinal("IdUsuario")),
                                IdDependencia = reader.GetInt32(reader.GetOrdinal("IdDependencia")),
                                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                                ApellidoMaterno = reader.GetString(reader.GetOrdinal("ApellidoMaterno")),
                                ApellidoPaterno = reader.GetString(reader.GetOrdinal("ApellidoPaterno")),
                                Telefono = reader.GetString(reader.GetOrdinal("Teléfono")),
                                Correo = reader.GetString(reader.GetOrdinal("CorreoUniversitario")),
                                IdRol = reader.GetInt32(reader.GetOrdinal("IdRol"))
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return usuario;
        }
    }
}