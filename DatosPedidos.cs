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
   /// Clase responsable de manejar las operaciones de acceso a datos relacionadas con los pedidos.
   /// </summary>
   public class DatosPedido
   {
      // Cadena de conexión obtenida del archivo de configuración
      private static readonly string cadenaConexion =
         ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

      /// <summary>
      /// Inserta un nuevo pedido en la base de datos y retorna el ID generado automáticamente.
      /// </summary>
      /// <param name="pedido">Objeto Pedidos con los datos a insertar.</param>
      /// <returns>ID del pedido insertado.</returns>
      public static int Insertar(Pedidos pedido)
      {
         int idGenerado = 0;

         // Se establece la conexión utilizando la cadena definida
         using (SqlConnection conn = new SqlConnection(cadenaConexion))
         {
            conn.Open();

            // Consulta SQL para insertar el pedido y devolver el ID generado
            string query = @"INSERT INTO Pedido (FechaPedido, IdCliente, IdRepartidor, Direccion)
                             VALUES (@Fecha, @Cliente, @Repartidor, @Direccion);
                             SELECT SCOPE_IDENTITY();"; // Devuelve el ID del registro recién insertado

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
               // Asignación de parámetros a la consulta
               cmd.Parameters.AddWithValue("@Fecha", pedido.FechaPedido);
               cmd.Parameters.AddWithValue("@Cliente", pedido.Cliente.IdCliente);
               cmd.Parameters.AddWithValue("@Repartidor", pedido.Repartidor.IdRepartidor);
               cmd.Parameters.AddWithValue("@Direccion", pedido.DireccionPedido);

               // Ejecuta la consulta y recupera el ID generado
               object result = cmd.ExecuteScalar();
               idGenerado = Convert.ToInt32(result);

               // Se asigna el ID generado al objeto original
               pedido.IdPedido = idGenerado;
            }
         }

         // Se retorna el ID generado al llamador
         return idGenerado;
      }

      /// <summary>
      /// Consulta todos los pedidos registrados en la base de datos junto con sus clientes y repartidores asociados.
      /// </summary>
      /// <returns>Lista de objetos Pedidos con información completa.</returns>
      public static List<Pedidos> ObtenerTodos()
      {
         var lista = new List<Pedidos>();

         // Se establece la conexión a la base de datos
         using (SqlConnection conn = new SqlConnection(cadenaConexion))
         {
            conn.Open();

            // Consulta SQL que une pedidos con clientes y repartidores
            string query = @"SELECT p.Id, p.FechaPedido, p.Direccion,
                                    c.Identificacion, c.Nombre, c.PrimerApellido, c.SegundoApellido, c.FechaNacimiento, c.Activo,
                                    r.Identificacion AS IdRepartidor, r.Nombre AS NombreR, r.PrimerApellido AS Apellido1, r.SegundoApellido AS Apellido2,
                                    r.FechaNacimiento AS FechaNacR, r.FechaContratacion, r.Activo AS ActivoR
                             FROM Pedido p
                             INNER JOIN Cliente c ON p.IdCliente = c.Identificacion
                             INNER JOIN Repartidor r ON p.IdRepartidor = r.Identificacion";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
               // Itera sobre los resultados de la consulta
               while (reader.Read())
               {
                  // Construcción del objeto Cliente a partir de los datos leídos
                  var cliente = new Clientes
                  {
                     IdCliente = Convert.ToInt32(reader["Identificacion"]),
                     NombreCliente = reader["Nombre"].ToString(),
                     PrimerApellidoC = reader["PrimerApellido"].ToString(),
                     SegundoApellidoC = reader["SegundoApellido"].ToString(),
                     FechaNacimientoC = Convert.ToDateTime(reader["FechaNacimiento"]),
                     EstadoCliente = Convert.ToBoolean(reader["Activo"])
                  };

                  // Construcción del objeto Repartidor con los datos correspondientes
                  var repartidor = new Repartidores
                  {
                     IdRepartidor = Convert.ToInt32(reader["IdRepartidor"]),
                     NombreRepartidor = reader["NombreR"].ToString(),
                     PrimerApellidoR = reader["Apellido1"].ToString(),
                     SegundoApellidoR = reader["Apellido2"].ToString(),
                     FechaNacimientoR = Convert.ToDateTime(reader["FechaNacR"]),
                     FechaContratacionR = Convert.ToDateTime(reader["FechaContratacion"]),
                     EstadoRepartidor = Convert.ToBoolean(reader["ActivoR"])
                  };

                  // Construcción del objeto Pedido uniendo los anteriores
                  var pedido = new Pedidos
                  {
                     IdPedido = Convert.ToInt32(reader["Id"]),
                     FechaPedido = Convert.ToDateTime(reader["FechaPedido"]),
                     DireccionPedido = reader["Direccion"].ToString(),
                     Cliente = cliente,
                     Repartidor = repartidor
                  };

                  // Agrega el pedido completo a la lista de resultados
                  lista.Add(pedido);
               }
            }
         }

         // Retorna la lista de pedidos obtenida
         return lista;
      }
   }
}
