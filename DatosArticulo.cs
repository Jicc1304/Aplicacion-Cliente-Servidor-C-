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
using System.Data;
using System.Data.SqlClient;

namespace LibDatos
{
   /// <summary>
   /// Clase encargada de gestionar el acceso a datos para los artículos en la base de datos.
   /// Incluye métodos para insertar y obtener artículos desde SQL Server.
   /// </summary>
   public class DatosArticulo
   {
      // Cadena de conexión obtenida del archivo de configuración (App.config)
      private static string cadena = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;

      /// <summary>
      /// Inserta un nuevo artículo en la base de datos.
      /// </summary>
      /// <param name="art">Objeto Articulo que contiene los datos a registrar.</param>
      /// <returns>Mensaje indicando si el registro fue exitoso o no.</returns>
      public static string Insertar(Articulo art)
      {
         // Se crea y abre la conexión usando la cadena configurada.
         using (SqlConnection con = new SqlConnection(cadena))
         {
            // Consulta SQL parametrizada para insertar un nuevo artículo.
            string sql = @"INSERT INTO Articulo(Id, Nombre, IdTipoArticulo, Valor, Inventario, Activo)
                               VALUES(@Id, @Nombre, @IdTipoArticulo, @Valor, @Inventario, @Activo)";

            SqlCommand cmd = new SqlCommand(sql, con);

            // Se asignan los valores a los parámetros desde el objeto Articulo.
            cmd.Parameters.AddWithValue("@Id", art.IdArticulo);
            cmd.Parameters.AddWithValue("@Nombre", art.NombreArticulo);
            cmd.Parameters.AddWithValue("@IdTipoArticulo", art.TipoArt.IdTipoArticulo);

            // El valor es un campo decimal, por eso se especifica el tipo y su precisión.
            cmd.Parameters.Add("@Valor", SqlDbType.Decimal).Value = art.ValorArticulo;
            cmd.Parameters["@Valor"].Precision = 11;
            cmd.Parameters["@Valor"].Scale = 2;

            cmd.Parameters.AddWithValue("@Inventario", art.InventarioArticulo);
            cmd.Parameters.AddWithValue("@Activo", art.EstadoArticulo);

            // Se abre la conexión y se ejecuta la consulta.
            con.Open();
            int resultado = cmd.ExecuteNonQuery();

            // Se retorna un mensaje dependiendo si se insertó correctamente.
            return resultado > 0 ? "Se ha registrado el artículo correctamente." : "No se pudo registrar.";
         }
      }

      /// <summary>
      /// Obtiene todos los artículos registrados en la base de datos junto con el nombre de su tipo.
      /// </summary>
      /// <returns>Lista de objetos Articulo con sus datos completos.</returns>
      public static List<Articulo> ObtenerTodos()
      {
         List<Articulo> lista = new List<Articulo>();

         using (SqlConnection con = new SqlConnection(cadena))
         {
            // Consulta SQL para obtener todos los artículos y su tipo de artículo asociado.
            string sql = @"
   SELECT A.Id, A.Nombre, A.IdTipoArticulo, A.Valor, A.Inventario, A.Activo,
          T.Nombre AS NombreTipo
   FROM Articulo A
   JOIN TipoArticulo T ON A.IdTipoArticulo = T.Id";

            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            // Se ejecuta el lector de datos para recorrer los resultados.
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               // Se agregan los artículos a la lista construyendo el objeto desde los datos del lector.
               lista.Add(new Articulo
               {
                  IdArticulo = Convert.ToInt32(reader["Id"]),
                  NombreArticulo = reader["Nombre"].ToString(),
                  TipoArt = new TipoArticulo
                  {
                     IdTipoArticulo = Convert.ToInt32(reader["IdTipoArticulo"]),
                     NombreTipoArticulo = reader["NombreTipo"].ToString()
                  },
                  ValorArticulo = Convert.ToDouble(reader["Valor"]),
                  InventarioArticulo = Convert.ToInt32(reader["Inventario"]),
                  EstadoArticulo = Convert.ToBoolean(reader["Activo"])
               });
            }
         }

         return lista;
      }
   }
}
