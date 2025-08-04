/* 
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27 / 7 / 2025
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibEntidades
{
   // Esta etiqueta indica que la clase se puede serializar,
   // lo cual es necesario para enviarla por la red o guardarla en un archivo.
   [Serializable]

   /// <summary>
   /// Clase Paquete utilizada para enviar y recibir información entre el cliente y el servidor.
   /// Contiene un comando que indica la acción a realizar, y los datos que acompañan esa acción.
   /// </summary>
   public class Paquete
   {
      /// <summary>
      /// Comando que indica la operación a ejecutar (por ejemplo: "RegistrarCliente", "ConsultarPedido", etc.).
      /// </summary>
      public string Comando { get; set; }

      /// <summary>
      /// Objeto que contiene los datos asociados al comando. Puede ser cualquier tipo de entidad (cliente, pedido, etc.).
      /// </summary>
      public object Datos { get; set; }
   }
}


