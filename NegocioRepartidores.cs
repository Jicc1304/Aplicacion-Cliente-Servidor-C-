/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicacion Cliente-Servidor.
 * Estudiante: Jose Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */

using LibEntidades;
using LibDatos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibNegocio
{
   /// <summary>
   /// Lógica de negocio para gestionar repartidores.
   /// </summary>
   public class NegocioRepartidores
   {
      /// <summary>
      /// Valida e intenta registrar un repartidor.
      /// </summary>
      public static string RegistrarRepartidores(Repartidores repartidor)
      {
         try
         {
            // Validaciones básicas de contenido y fechas
            if (string.IsNullOrWhiteSpace(repartidor.NombreRepartidor) ||
                string.IsNullOrWhiteSpace(repartidor.PrimerApellidoR) ||
                string.IsNullOrWhiteSpace(repartidor.SegundoApellidoR))
            {
               return "Error: Todos los campos de texto son obligatorios.";
            }

            if (repartidor.IdRepartidor <= 0)
            {
               return "Error: El ID debe ser un número positivo.";
            }

            if (repartidor.FechaNacimientoR >= DateTime.Today)
            {
               return "Error: La fecha de nacimiento debe ser anterior a hoy.";
            }

            if (repartidor.FechaContratacionR > DateTime.Today)
            {
               return "Error: La fecha de contratación no puede ser futura.";
            }

            // Verificar duplicados
            var existentes = DatosRepartidores.ObtenerTodos();
            if (existentes != null && existentes.Any(r => r.IdRepartidor == repartidor.IdRepartidor))
            {
               return "Error: Ya existe un repartidor con esa identificación.";
            }

            // Registro en la base de datos
            string resultado = DatosRepartidores.AgregarRepartidores(repartidor);
            return resultado;
         }
         catch (Exception ex)
         {
            return "Error inesperado al registrar repartidor: " + ex.Message;
         }
      }

      /// <summary>
      /// Devuelve todos los repartidores.
      /// </summary>
      public static List<Repartidores> Consultar()
      {
         return DatosRepartidores.ObtenerTodos();
      }

      /// <summary>
      /// Devuelve solo los repartidores activos.
      /// </summary>
      public static List<Repartidores> ConsultarActivos()
      {
         return DatosRepartidores.ObtenerTodos()
             .Where(r => r != null && r.EstadoRepartidor)
             .ToList();
      }
   }
}
