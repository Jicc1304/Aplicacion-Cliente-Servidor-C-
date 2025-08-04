/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */

using System;
using System.Collections.Generic;
using LibEntidades;
using LibDatos;
using System.Linq;

namespace LibNegocio
{
   /// <summary>
   /// Clase que contiene la lógica de negocio relacionada con la gestión de clientes.
   /// Realiza validaciones y coordina con la capa de datos.
   /// </summary>
   public class NegocioCliente
   {
      /// <summary>
      /// Registra un nuevo cliente luego de aplicar validaciones de negocio.
      /// </summary>
      /// <param name="cliente">Objeto Cliente a registrar.</param>
      /// <returns>Mensaje indicando el resultado del proceso.</returns>
      public static string RegistrarCliente(Clientes cliente)
      {
         try
         {
            // Validación de campos obligatorios de texto
            if (string.IsNullOrWhiteSpace(cliente.NombreCliente) ||
                string.IsNullOrWhiteSpace(cliente.PrimerApellidoC) ||
                string.IsNullOrWhiteSpace(cliente.SegundoApellidoC))
            {
               return "Error: Todos los campos de texto son obligatorios.";
            }

            // Validación de ID positivo
            if (cliente.IdCliente <= 0)
            {
               return "Error: La identificación debe ser un número positivo.";
            }

            // Validación de fecha de nacimiento (no puede ser hoy o futura)
            if (cliente.FechaNacimientoC.Date >= DateTime.Today)
            {
               return "Error: La fecha de nacimiento debe ser anterior a hoy.";
            }

            // Verificación de duplicado por identificación
            Clientes existente = DatosClientes.ObtenerPorId(cliente.IdCliente);
            if (existente != null)
            {
               return "Error: Ya existe un cliente con esa identificación.";
            }

            // Intento de inserción en la base de datos
            bool resultado = DatosClientes.AgregarClientes(cliente);
            return resultado ? "Se ha registrado el cliente correctamente." : "Error: No se pudo registrar el cliente.";
         }
         catch (Exception ex)
         {
            // Captura de errores inesperados
            return "Error inesperado: " + ex.Message;
         }
      }

      /// <summary>
      /// Obtiene la lista de todos los clientes registrados.
      /// </summary>
      /// <returns>Lista de clientes.</returns>
      public static List<Clientes> Consultar()
      {
         return DatosClientes.ObtenerTodos();
      }

      /// <summary>
      /// Busca y devuelve un cliente según su identificación.
      /// </summary>
      /// <param name="id">Identificación del cliente.</param>
      /// <returns>Objeto Cliente si se encuentra, null si no existe.</returns>
      public static Clientes BuscarPorId(int id)
      {
         return DatosClientes.ObtenerPorId(id);
      }

      /// <summary>
      /// Verifica si un cliente con el ID indicado existe en la base de datos.
      /// </summary>
      /// <param name="id">Identificación del cliente a verificar.</param>
      /// <returns>True si existe, False si no.</returns>
      public static bool ClienteExiste(int id)
      {
         return DatosClientes.ObtenerPorId(id) != null;
      }

      /// <summary>
      /// Consulta y devuelve todos los clientes que están marcados como activos.
      /// </summary>
      /// <returns>Lista de clientes activos.</returns>
      public static List<Clientes> ConsultarActivos()
      {
         return DatosClientes.ObtenerTodos()
             .Where(r => r != null && r.EstadoCliente)
             .ToList();
      }
   }
}
