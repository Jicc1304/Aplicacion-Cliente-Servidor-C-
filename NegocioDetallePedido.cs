/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */
using System;
using System.Collections.Generic;
using LibDatos;
using LibEntidades;

namespace LibNegocio
{
   /// <summary>
   /// Clase de negocio encargada de validar la lógica para registrar y consultar detalles de pedido.
   /// </summary>
   public class NegocioDetallePedido
   {
      /// <summary>
      /// Valida los datos del detalle de pedido y lo registra si todo es correcto.
      /// </summary>
      public static string RegistrarDetalle(DetallePedidos detalle)
      {
         try
         {
            // Validación: verificar que se haya seleccionado un pedido y un artículo
            if (detalle.Pedido == null || detalle.Articulo == null)
               return "Error: Debe seleccionar un pedido y un artículo.";

            // Validación: cantidad debe ser positiva
            if (detalle.CantidadArticulos <= 0)
               return "Error: La cantidad debe ser mayor que cero.";

            // Validación: valor del artículo debe ser positivo
            if (detalle.ValorArticulo <= 0)
               return "Error: El valor del artículo debe ser mayor que cero.";

            // Obtener el inventario actual desde la capa de datos
            int inventarioDisponible = DatosDetallePedido.ObtenerInventarioArticulo(detalle.Articulo.IdArticulo);

            // Validar error al obtener inventario
            if (inventarioDisponible == -1)
               return "Error: No se pudo obtener el inventario del artículo.";

            // Validar que haya suficiente inventario para la cantidad solicitada
            if (detalle.CantidadArticulos > inventarioDisponible)
               return $"Error: Solo hay {inventarioDisponible} unidades disponibles del artículo.";

            // Intentar insertar el detalle (con actualización de inventario incluida)
            bool insertado = DatosDetallePedido.Insertar(detalle);

            // Respuesta según resultado de la operación
            return insertado ? "Detalle del pedido registrado con éxito." : "No se pudo registrar el detalle.";
         }
         catch (Exception ex)
         {
            // Manejo de errores imprevistos
            return "Error al registrar detalle: " + ex.Message;
         }
      }

      /// <summary>
      /// Devuelve todos los detalles de pedido existentes.
      /// </summary>
      public static List<DetallePedidos> Consultar()
      {
         return DatosDetallePedido.ObtenerTodos();
      }
   }
}
