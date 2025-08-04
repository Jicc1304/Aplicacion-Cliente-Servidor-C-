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
   /// Clase encargada de gestionar las operaciones de base de datos relacionadas con los detalles de pedidos.
   /// </summary>
   public class DatosDetallePedido
   {
      // Cadena de conexión obtenida desde el archivo de configuración App.config
      private static readonly string cadenaConexion =
         ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

      /// <summary>
      /// Obtiene el inventario disponible de un artículo específico.
      /// </summary>
      public static int ObtenerInventarioArticulo(int idArticulo)
      {
         using (SqlConnection conn = new SqlConnection(cadenaConexion))
         {
            conn.Open();
            string query = "SELECT Inventario FROM Articulo WHERE Id = @IdArticulo";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
               cmd.Parameters.AddWithValue("@IdArticulo", idArticulo);
               object result = cmd.ExecuteScalar();

               if (result != null && int.TryParse(result.ToString(), out int inventario))
                  return inventario;
               else
                  return -1; // Error o no encontrado
            }
         }
      }

      /// <summary>
      /// Inserta un nuevo detalle de pedido si hay inventario suficiente.
      /// También descuenta el inventario del artículo.
      /// </summary>
      public static bool Insertar(DetallePedidos detalle)
      {
         using (SqlConnection conn = new SqlConnection(cadenaConexion))
         {
            conn.Open();
            SqlTransaction transaccion = conn.BeginTransaction();

            try
            {
               // Verificar inventario actual
               string consultaInventario = "SELECT Inventario FROM Articulo WHERE Id = @IdArticulo";
               SqlCommand cmdInventario = new SqlCommand(consultaInventario, conn, transaccion);
               cmdInventario.Parameters.AddWithValue("@IdArticulo", detalle.Articulo.IdArticulo);
               int inventarioActual = Convert.ToInt32(cmdInventario.ExecuteScalar());

               // Valida que haya inventario suficiente
               if (detalle.CantidadArticulos > inventarioActual)
               {
                  transaccion.Rollback();
                  return false;
               }

               // Calcular el monto con 12% de envío
               decimal valorUnitario = Convert.ToDecimal(detalle.ValorArticulo);
               decimal montoConImpuesto = valorUnitario * detalle.CantidadArticulos * 1.12m;

               // Insertar el detalle de pedido
               string queryInsert = @"INSERT INTO DetallePedido (Idpedido, Idarticulo, Cantidad, Monto)
                                      VALUES (@IdPedido, @IdArticulo, @Cantidad, @Monto)";
               SqlCommand cmdInsert = new SqlCommand(queryInsert, conn, transaccion);
               cmdInsert.Parameters.AddWithValue("@IdPedido", detalle.Pedido.IdPedido);
               cmdInsert.Parameters.AddWithValue("@IdArticulo", detalle.Articulo.IdArticulo);
               cmdInsert.Parameters.AddWithValue("@Cantidad", detalle.CantidadArticulos);
               cmdInsert.Parameters.AddWithValue("@Monto", montoConImpuesto);
               cmdInsert.ExecuteNonQuery();

               // Descuenta del inventario
               string queryUpdate = @"UPDATE Articulo SET Inventario = Inventario - @Cantidad
                                      WHERE Id = @IdArticulo";
               SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn, transaccion);
               cmdUpdate.Parameters.AddWithValue("@Cantidad", detalle.CantidadArticulos);
               cmdUpdate.Parameters.AddWithValue("@IdArticulo", detalle.Articulo.IdArticulo);
               cmdUpdate.ExecuteNonQuery();

               // Confirmar los cambios
               transaccion.Commit();
               return true;
            }
            catch
            {
               transaccion.Rollback();
               return false;
            }
         }
      }

      /// <summary>
      /// Obtiene todos los detalles de pedidos existentes, incluyendo el nombre del artículo y tipo.
      /// </summary>
      public static List<DetallePedidos> ObtenerTodos()
      {
         List<DetallePedidos> lista = new List<DetallePedidos>();

         using (SqlConnection conn = new SqlConnection(cadenaConexion))
         {
            conn.Open();

            string query = @"SELECT dp.Idpedido, dp.Idarticulo, dp.Cantidad, dp.Monto,
                                    a.Nombre AS NombreArticulo,
                                    a.Valor AS ValorUnitario,
                                    ta.Nombre AS TipoArticulo
                             FROM DetallePedido dp
                             INNER JOIN Articulo a ON dp.Idarticulo = a.Id
                             INNER JOIN TipoArticulo ta ON a.IdTipoArticulo = ta.Id";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
               while (reader.Read())
               {
                  // Tipo de artículo
                  var tipo = new TipoArticulo
                  {
                     NombreTipoArticulo = reader["TipoArticulo"].ToString()
                  };

                  // Artículo con nombre, ID y valor
                  var articulo = new Articulo
                  {
                     IdArticulo = Convert.ToInt32(reader["Idarticulo"]),
                     NombreArticulo = reader["NombreArticulo"].ToString(),
                     ValorArticulo = Convert.ToDouble(reader["ValorUnitario"]),
                     TipoArt = tipo
                  };

                  // Detalle del pedido
                  var detalle = new DetallePedidos
                  {
                     Pedido = new Pedidos { IdPedido = Convert.ToInt32(reader["Idpedido"]) },
                     Articulo = articulo,
                     CantidadArticulos = Convert.ToInt32(reader["Cantidad"]),
                     ValorArticulo = Convert.ToDouble(reader["Monto"]) // Monto total con 12%
                  };

                  lista.Add(detalle);
               }
            }
         }

         return lista;
      }
   }
}
