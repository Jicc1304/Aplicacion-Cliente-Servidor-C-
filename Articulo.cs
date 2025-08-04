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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibEntidades
{
   // Declaracion de la clase ´Articulo´ y sus atributos
   public class Articulo
   {
      
         public int IdArticulo { get; set; }
      public string NombreArticulo { get; set; }
      public TipoArticulo TipoArt { get; set; }
      // convierte un numero decimal en double
      [JsonConverter(typeof(ConvertidorDecimalADouble))]
      public double ValorArticulo { get; set; }
      public int InventarioArticulo { get; set; }
      public bool EstadoArticulo { get; set; }

   }
}

