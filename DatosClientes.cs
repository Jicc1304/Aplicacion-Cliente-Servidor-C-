/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using LibEntidades;

namespace LibDatos
{
   /// <summary>
   /// Clase encargada de acceder a los datos de los clientes en la base de datos.
   /// Permite obtener, insertar y buscar clientes por su ID.
   /// </summary>
   public class DatosClientes
   {
      // Cadena de conexión obtenida desde el archivo de configuración (App.config)
      private static readonly string connectionString =
          ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

      /// <summary>
      /// Obtiene todos los registros de clientes desde la base de datos.
      /// </summary>
      /// <returns>Lista de objetos Clientes con todos los registros encontrados.</returns>
      public static List<Clientes> ObtenerTodos()
      {
         var lista = new List<Clientes>();

         using (SqlConnection conn = new SqlConnection(connectionString))
         {
            conn.Open();
            string query = "SELECT * FROM Cliente";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
               while (reader.Read())
               {
                  // Se crea un objeto Clientes por cada fila del resultado y se agrega a la lista.
                  lista.Add(new Clientes
                  {
                     IdCliente = Convert.ToInt32(reader["Identificacion"]),
                     NombreCliente = reader["Nombre"].ToString(),
                     PrimerApellidoC = reader["PrimerApellido"].ToString(),
                     SegundoApellidoC = reader["SegundoApellido"].ToString(),
                     FechaNacimientoC = Convert.ToDateTime(reader["FechaNacimiento"]),
                     EstadoCliente = Convert.ToBoolean(reader["Activo"])
                  });
               }
            }
         }

         return lista;
      }

      /// <summary>
      /// Agrega un nuevo cliente a la base de datos.
      /// </summary>
      /// <param name="cliente">Objeto Cliente con los datos a insertar.</param>
      /// <returns>True si el registro fue exitoso, de lo contrario False.</returns>
      public static bool AgregarClientes(Clientes cliente)
      {
         using (SqlConnection conn = new SqlConnection(connectionString))
         {
            conn.Open();
            string query = @"INSERT INTO Cliente (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Activo)
                                 VALUES (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Activo)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
               // Se asignan los parámetros a partir de las propiedades del objeto cliente.
               cmd.Parameters.AddWithValue("@Identificacion", cliente.IdCliente);
               cmd.Parameters.AddWithValue("@Nombre", cliente.NombreCliente);
               cmd.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellidoC);
               cmd.Parameters.AddWithValue("@SegundoApellido", cliente.SegundoApellidoC);
               cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimientoC);
               cmd.Parameters.AddWithValue("@Activo", cliente.EstadoCliente);

               // Ejecuta la consulta y retorna true si se insertó al menos una fila.
               return cmd.ExecuteNonQuery() > 0;
            }
         }
      }

      /// <summary>
      /// Busca y retorna un cliente según su ID (identificación).
      /// </summary>
      /// <param name="id">Identificación del cliente a buscar.</param>
      /// <returns>Objeto Cliente si se encuentra, null si no existe.</returns>
      public static Clientes ObtenerPorId(int id)
      {
         using (SqlConnection conn = new SqlConnection(connectionString))
         {
            conn.Open();
            string query = "SELECT * FROM Cliente WHERE Identificacion = @Id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
               cmd.Parameters.AddWithValue("@Id", id);

               using (SqlDataReader reader = cmd.ExecuteReader())
               {
                  if (reader.Read())
                  {
                     // Se construye y retorna el objeto cliente con los datos del registro encontrado.
                     return new Clientes
                     {
                        IdCliente = Convert.ToInt32(reader["Identificacion"]),
                        NombreCliente = reader["Nombre"].ToString(),
                        PrimerApellidoC = reader["PrimerApellido"].ToString(),
                        SegundoApellidoC = reader["SegundoApellido"].ToString(),
                        FechaNacimientoC = Convert.ToDateTime(reader["FechaNacimiento"]),
                        EstadoCliente = Convert.ToBoolean(reader["Activo"])
                     };
                  }
               }
            }
         }

         return null; // Retorna null si no se encontró el cliente con el ID proporcionado.
      }
   }
}
