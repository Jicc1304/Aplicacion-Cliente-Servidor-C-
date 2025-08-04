/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */

using LibEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace LibDatos
{
   /// <summary>
   /// Clase encargada de realizar operaciones relacionadas con los repartidores en la base de datos.
   /// Permite agregar nuevos repartidores y consultar todos los registros existentes.
   /// </summary>
   public class DatosRepartidores
   {
      // Cadena de conexión obtenida desde el archivo App.config
      private static string cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

      /// <summary>
      /// Inserta un nuevo repartidor en la base de datos.
      /// </summary>
      /// <param name="rep">Objeto Repartidores con los datos a registrar.</param>
      /// <returns>Mensaje indicando si el registro fue exitoso o no.</returns>
      public static string AgregarRepartidores(Repartidores rep)
      {
         try
         {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
               conexion.Open();

               // Consulta SQL con parámetros para insertar el repartidor
               string query = @"INSERT INTO Repartidor 
                                (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, FechaContratacion, Activo)
                                VALUES (@Id, @Nombre, @Apellido1, @Apellido2, @FechaNacimiento, @FechaContratacion, @Activo)";

               using (SqlCommand comando = new SqlCommand(query, conexion))
               {
                  // Se asignan los valores a los parámetros desde el objeto recibido
                  comando.Parameters.AddWithValue("@Id", rep.IdRepartidor);
                  comando.Parameters.AddWithValue("@Nombre", rep.NombreRepartidor);
                  comando.Parameters.AddWithValue("@Apellido1", rep.PrimerApellidoR);
                  comando.Parameters.AddWithValue("@Apellido2", rep.SegundoApellidoR);
                  comando.Parameters.AddWithValue("@FechaNacimiento", rep.FechaNacimientoR);
                  comando.Parameters.AddWithValue("@FechaContratacion", rep.FechaContratacionR);
                  comando.Parameters.AddWithValue("@Activo", rep.EstadoRepartidor);

                  // Se ejecuta la consulta y se evalúa si se insertó correctamente
                  int filas = comando.ExecuteNonQuery();
                  return filas > 0 ? "Se ha registrado el repartidor correctamente." : "No se pudo registrar el repartidor.";
               }
            }
         }
         catch (Exception ex)
         {
            // En caso de error, se devuelve un mensaje detallado con la excepción
            return "Error inesperado al registrar repartidor: " + ex.Message;
         }
      }

      /// <summary>
      /// Obtiene todos los repartidores registrados en la base de datos.
      /// </summary>
      /// <returns>Lista de objetos Repartidores con los datos obtenidos.</returns>
      public static List<Repartidores> ObtenerTodos()
      {
         List<Repartidores> lista = new List<Repartidores>();

         try
         {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
               conexion.Open();
               string query = "SELECT * FROM Repartidor";

               using (SqlCommand comando = new SqlCommand(query, conexion))
               using (SqlDataReader lector = comando.ExecuteReader())
               {
                  // Se recorre cada fila del resultado y se construye un objeto Repartidores
                  while (lector.Read())
                  {
                     Repartidores r = new Repartidores
                     {
                        IdRepartidor = Convert.ToInt32(lector["Identificacion"]),
                        NombreRepartidor = lector["Nombre"].ToString(),
                        PrimerApellidoR = lector["PrimerApellido"].ToString(),
                        SegundoApellidoR = lector["SegundoApellido"].ToString(),
                        FechaNacimientoR = Convert.ToDateTime(lector["FechaNacimiento"]),
                        FechaContratacionR = Convert.ToDateTime(lector["FechaContratacion"]),
                        EstadoRepartidor = Convert.ToBoolean(lector["Activo"])
                     };

                     // Se agrega el objeto a la lista
                     lista.Add(r);
                  }
               }
            }
         }
         catch
         {
            // En caso de error, no se interrumpe la ejecución pero no se muestra mensaje
            // Se puede agregar log o manejo si se desea en el futuro
         }

         return lista;
      }
   }
}
