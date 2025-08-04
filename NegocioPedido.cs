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
   /// Clase que contiene la lógica de negocio relacionada con los pedidos.
   /// Valida los datos antes de enviarlos a la capa de datos y coordina su registro o consulta.
   /// </summary>
   public class NegocioPedido
   {
      // Variable para llevar un control local del último ID generado (no usada en la base de datos)
      private static int ultimoIdGenerado = 0;

      
      // Genera el siguiente ID para un pedido, incrementando el último ID local.
      
      public static int ObtenerSiguienteId()
      {
         return ++ultimoIdGenerado;
      }

      /// <summary>
      /// Registra un nuevo pedido, aplicando las validaciones correspondientes.
      /// </summary>
      /// <param name="pedido">Objeto Pedidos con los datos a registrar.</param>
      /// <returns>Mensaje indicando éxito o detalle del error ocurrido.</returns>
      public static string RegistrarPedidos(Pedidos pedido)
      {
         try
         {
            // Validación de que la fecha no sea anterior al día actual
            if (pedido.FechaPedido.Date < DateTime.Now.Date)
               return "Error: La fecha del pedido no puede ser anterior a la fecha actual.";

            // Validación de cliente
            if (pedido.Cliente == null || pedido.Cliente.IdCliente <= 0)
               return "Error: Debe seleccionar un cliente válido.";

            // Validación de repartidor
            if (pedido.Repartidor == null || pedido.Repartidor.IdRepartidor <= 0)
               return "Error: Debe seleccionar un repartidor válido.";

            // Validación de dirección
            if (string.IsNullOrWhiteSpace(pedido.DireccionPedido))
               return "Error: La dirección del pedido es obligatoria.";

            // Se intenta registrar el pedido en la base de datos
            int idGenerado = DatosPedido.Insertar(pedido);

            // Si se genera un ID válido, se asigna al objeto original
            if (idGenerado > 0)
            {
               pedido.IdPedido = idGenerado;
               return $"Se ha registrado el pedido correctamente con ID: {idGenerado}.";
            }
            else
            {
               return "Error inesperado al registrar el pedido.";
            }
         }
         catch (Exception ex)
         {
            // Captura y devolución de cualquier error no controlado
            return "Error no definido: " + ex.Message;
         }
      }

      // Lista local de pedidos, usada opcionalmente si no se trabaja directamente con la base de datos
      private static List<Pedidos> listaPedidos = new List<Pedidos>();

      /// <summary>
      /// Obtiene el último ID registrado en la lista local de pedidos.
      /// </summary>
      /// <returns>ID del último pedido registrado localmente, o 0 si no hay ninguno.</returns>
      public static int ObtenerUltimoId()
      {
         return listaPedidos.Count > 0 ? listaPedidos[^1].IdPedido : 0;
      }

      /// <summary>
      /// Consulta todos los pedidos registrados en la base de datos.
      /// </summary>
      /// <returns>Lista de objetos Pedidos.</returns>
      public static List<Pedidos> Consultar()
      {
         return DatosPedido.ObtenerTodos();
      }
   }
}
