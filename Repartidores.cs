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
   //Definicion de la clase'Repartidores'y sus atributos
   public class Repartidores
   {
      public int IdRepartidor { get; set; }
      public string NombreRepartidor { get; set; }
      public string PrimerApellidoR { get; set; }
      public string SegundoApellidoR { get; set; }
      public DateTime FechaNacimientoR { get; set; }
      public DateTime FechaContratacionR { get; set; }
      public bool EstadoRepartidor { get; set; }
   }
}
