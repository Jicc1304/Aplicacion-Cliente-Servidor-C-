/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibEntidades
{
   // Declaracion de la clase'Pedidos' y sus atributos
   public class Pedidos
   {
      public int IdPedido { get; set; }
      public DateTime FechaPedido { get; set; }
      public Clientes Cliente { get; set; }
      public Repartidores Repartidor { get; set; }
      public string DireccionPedido { get; set; }

   }
}
