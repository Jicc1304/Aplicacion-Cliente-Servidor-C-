/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */
using System.Net;
using System.Net.Sockets;
using System.IO;
using System;
using System.Windows.Forms;
using LibNegocio;
using LibEntidades;
using System;
using System.Text.Json;
using System.Data.SqlClient;
using System.Threading;



namespace AplicacionServidor
{
   public partial class FormServidor : Form
   {
      // Campo para manejar el servidor TCP
      private ServidorTCP servidorTCP;

      public FormServidor()
      {
         InitializeComponent();

         // Inicializar servidor TCP y asignar los delegados
         servidorTCP = new ServidorTCP();
         servidorTCP.MostrarEnBitacora = MostrarMensaje;
         servidorTCP.ActualizarCantidadClientes = ActualizarClientes;
      }

      /// <summary>
      /// Muestra mensajes en el TextBox bitácora
      /// </summary>
      private void MostrarMensaje(string mensaje)
      {
         if (InvokeRequired)
         {
            Invoke(new Action<string>(MostrarMensaje), mensaje);
         }
         else
         {
            txtBitacora.AppendText(mensaje + Environment.NewLine);
            // Mover el cursor al final
            txtBitacora.SelectionStart = txtBitacora.Text.Length;
            txtBitacora.ScrollToCaret();
         }
      }

      /// <summary>
      /// Actualiza la cantidad de clientes conectados
      /// </summary>
      private void ActualizarClientes(int cantidad)
      {
         if (InvokeRequired)
         {
            Invoke(new Action<int>(ActualizarClientes), cantidad);
         }
         else
         {
            lblClientes.Text = $"Clientes conectados: {cantidad}";
         }
      }

      /// <summary>
      /// Evento al hacer clic en Iniciar Servidor
      /// </summary>
      private void menuIniciarServidor_Click(object sender, EventArgs e)
      {
         servidorTCP.Iniciar();
      }

      /// <summary>
      /// Evento al hacer clic en Detener Servidor
      /// </summary>
      private void menuDetenerServidor_Click(object sender, EventArgs e)
      {
         servidorTCP.Detener();
      }

      /// <summary>
      /// Evento al hacer clic en Salir
      /// </summary>
      private void menuSalir_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void FormServidor_Load(object sender, EventArgs e)
      {

      }
   }
}


