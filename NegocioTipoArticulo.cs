/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicacion Cliente-Servidor.
 * Estudiante: Jose Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */

using LibDatos;
using LibEntidades;
using System;
using System.Collections.Generic;

namespace LibNegocio
{
   /// <summary>
   /// Lógica de negocio para tipos de artículo.
   /// </summary>
   public class NegocioTipoArticulo
   {
      /// <summary>
      /// Valida y registra un tipo de artículo.
      /// </summary>
      public static string RegistrarTipoArticulo(TipoArticulo tipoArt)
      {
         try
         {
            // Revisión de datos obligatorios
            if (tipoArt.IdTipoArticulo <= 0)
               return "Error: El ID debe ser un número positivo.";

            if (string.IsNullOrEmpty(tipoArt.NombreTipoArticulo) ||
                string.IsNullOrEmpty(tipoArt.DescripcionTipoArticulo))
               return "Error: Todos los campos son requeridos.";

            // Prevención de duplicados por ID
            List<TipoArticulo> lista = DatosTipoArticulo.ObtenerTodos();
            if (lista != null && lista.Exists(t => t.IdTipoArticulo == tipoArt.IdTipoArticulo))
               return "Error: Ya existe un tipo de artículo con ese ID.";

            // Llamada a la capa de datos
            return DatosTipoArticulo.Insertar(tipoArt);
         }
         catch (Exception ex)
         {
            return "Error al registrar tipo de artículo: " + ex.Message;
         }
      }

      /// <summary>
      /// Devuelve todos los tipos registrados.
      /// </summary>
      public static List<TipoArticulo> Consultar()
      {
         return DatosTipoArticulo.ObtenerTodos();
      }
   }
}
