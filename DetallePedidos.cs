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
   //Declaración de la clase 'DetallePedidos' y sus atributos
   public class DetallePedidos
   {
      public Pedidos Pedido { get; set; }
      public Articulo Articulo { get; set; }
      public int CantidadArticulos { get; set; }
      public double ValorArticulo { get; set; }
   }
}
