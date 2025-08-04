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
   /// Clase encargada de la gestión de datos para la entidad TipoArticulo.
   /// Permite insertar registros, obtener todos los tipos existentes y generar el siguiente ID disponible.
   /// </summary>
   public class DatosTipoArticulo
   {
      // Cadena de conexión a la base de datos, obtenida desde el archivo App.config
      private static string cadena = System.Configuration.ConfigurationManager
          .ConnectionStrings["MiConexionSQL"].ConnectionString;

      /// <summary>
      /// Inserta un nuevo tipo de artículo en la base de datos.
      /// </summary>
      /// <param name="tipo">Objeto TipoArticulo con los datos a registrar.</param>
      /// <returns>Mensaje indicando si el registro fue exitoso o si ocurrió un error.</returns>
      public static string Insertar(TipoArticulo tipo)
      {
         using (SqlConnection conexion = new SqlConnection(cadena))
         {
            // Sentencia SQL con parámetros para evitar inyecciones
            string query = "INSERT INTO TipoArticulo (Id, Nombre, Descripcion) VALUES (@Id, @Nombre, @Descripcion)";
            SqlCommand cmd = new SqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@Id", tipo.IdTipoArticulo);
            cmd.Parameters.AddWithValue("@Nombre", tipo.NombreTipoArticulo);
            cmd.Parameters.AddWithValue("@Descripcion", tipo.DescripcionTipoArticulo);

            try
            {
               // Se abre la conexión y se ejecuta la consulta
               conexion.Open();
               cmd.ExecuteNonQuery();
               return "Se ha registrado el tipo de artículo correctamente.";
            }
            catch (SqlException ex)
            {
               // En caso de error se devuelve el mensaje del sistema
               return "Error al registrar tipo de artículo: " + ex.Message;
            }
         }
      }

      /// <summary>
      /// Obtiene todos los tipos de artículo registrados en la base de datos.
      /// </summary>
      /// <returns>Lista de objetos TipoArticulo o null si ocurre un error.</returns>
      public static List<TipoArticulo> ObtenerTodos()
      {
         List<TipoArticulo> lista = new List<TipoArticulo>();

         using (SqlConnection conexion = new SqlConnection(cadena))
         {
            // Consulta SQL que obtiene los campos necesarios y los renombra para mapear directamente
            string query = @"
               SELECT 
                  Id AS IdTipoArticulo,
                  Nombre AS NombreTipoArticulo,
                  Descripcion AS DescripcionTipoArticulo
               FROM TipoArticulo";

            SqlCommand cmd = new SqlCommand(query, conexion);

            try
            {
               conexion.Open();
               SqlDataReader reader = cmd.ExecuteReader();

               while (reader.Read())
               {
                  // Se construye el objeto TipoArticulo con los datos obtenidos
                  lista.Add(new TipoArticulo
                  {
                     IdTipoArticulo = Convert.ToInt32(reader["IdTipoArticulo"]),
                     NombreTipoArticulo = reader["NombreTipoArticulo"].ToString(),
                     DescripcionTipoArticulo = reader["DescripcionTipoArticulo"].ToString()
                  });
               }
            }
            catch
            {
               // Si ocurre una excepción, se retorna null para indicar error
               return null;
            }
         }

         return lista;
      }

      /// <summary>
      /// Obtiene el siguiente ID disponible para un nuevo tipo de artículo.
      /// </summary>
      /// <returns>Entero que representa el siguiente ID a utilizar.</returns>
      public static int ObtenerSiguienteId()
      {
         using (SqlConnection conexion = new SqlConnection(cadena))
         {
            // Consulta que obtiene el ID máximo y le suma 1. Si no hay registros, retorna 1.
            string query = "SELECT ISNULL(MAX(Id), 0) + 1 FROM TipoArticulo";
            SqlCommand cmd = new SqlCommand(query, conexion);
            conexion.Open();
            return (int)cmd.ExecuteScalar();
         }
      }
   }
}
