/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */

using LibDatos;
using LibEntidades;
using System.Collections.Generic;

namespace LibNegocio
{
   /// <summary>
   /// Clase de lógica de negocio encargada de validar y gestionar el registro y la consulta de artículos.
   /// Se encarga de aplicar las reglas antes de interactuar con la capa de datos.
   /// </summary>
   public class NegocioArticulo
   {
      /// <summary>
      /// Valida y registra un nuevo artículo. Aplica reglas de negocio antes de insertar en la base de datos.
      /// </summary>
      /// <param name="art">Objeto Articulo a registrar.</param>
      /// <returns>Mensaje indicando éxito o detalle del error.</returns>
      public static string RegistrarArticulo(Articulo art)
      {
         // Validaciones básicas de los campos obligatorios
         if (string.IsNullOrWhiteSpace(art.NombreArticulo) ||
             art.TipoArt == null || art.TipoArt.IdTipoArticulo <= 0 ||
             art.ValorArticulo <= 0 || art.InventarioArticulo < 0)
         {
            return "Error: Todos los campos deben ser válidos.";
         }

         // Se verifica que no exista un artículo con el mismo nombre
         List<Articulo> existentes = DatosArticulo.ObtenerTodos();
         if (existentes.Exists(a => a.NombreArticulo.Equals(art.NombreArticulo)))
         {
            return "Error: Ya existe un artículo con ese nombre.";
         }

         // Si pasa las validaciones, se registra el artículo usando la capa de datos
         return DatosArticulo.Insertar(art);
      }

      /// <summary>
      /// Consulta y devuelve todos los artículos registrados.
      /// </summary>
      /// <returns>Lista de artículos, o lista vacía si no hay registros.</returns>
      public static List<Articulo> Consultar()
      {
         return DatosArticulo.ObtenerTodos();
      }

      /// <summary>
      /// Consulta y devuelve únicamente los artículos que están activos.
      /// </summary>
      /// <returns>Lista de artículos activos, o vacía si no hay ninguno.</returns>
      public static List<Articulo> ConsultarActivos()
      {
         List<Articulo> articulos = DatosArticulo.ObtenerTodos();
         return articulos?.FindAll(a => a.EstadoArticulo);
      }
   }
}
