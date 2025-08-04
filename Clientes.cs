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
   // Declara clase clientes con sus atributos
   public class Clientes
   {
      public int IdCliente { get; set; }
      public string NombreCliente { get; set; }
      public string PrimerApellidoC { get; set; }
      public string SegundoApellidoC { get; set; }
      public DateTime FechaNacimientoC { get; set; }
      public bool EstadoCliente { get; set; }


   }
}
