/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibEntidades
{
   /// <summary>
   /// Convierte valores decimal a double al deserializar y viceversa.
   /// Útil para mantener compatibilidad con tipos numéricos en JSON.
   /// </summary>
   public class ConvertidorDecimalADouble : JsonConverter<double>
   {
      /// <summary>
      /// Convierte un valor decimal del JSON a double.
      /// </summary>
      public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
      {
         if (reader.TryGetDecimal(out decimal dec))
            return (double)dec;

         throw new JsonException("Error al convertir decimal a double.");
      }

      /// <summary>
      /// Escribe un valor double como número en JSON.
      /// </summary>
      public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
      {
         writer.WriteNumberValue(value);
      }

      /// <summary>
      /// Conversión directa de decimal a double.
      /// </summary>
      public static double Convertir(decimal valor)
      {
         return (double)valor;
      }
   }
}
