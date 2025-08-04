/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */
using LibEntidades;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AplicacionCliente
{
   public partial class FormTipoArticulo : Form
   {
      // Guarda la conexión TCP que se recibe del formulario principal
      private TcpClient clienteTcp;

      // Flujo de red que permite enviar y recibir datos
      private NetworkStream stream;

      // Constructor del formulario que recibe la conexión TCP desde el menú principal
      public FormTipoArticulo(TcpClient cliente)
      {
         InitializeComponent();
         clienteTcp = cliente;
         stream = cliente.GetStream();
      }

      // Evento que se ejecuta cuando se hace clic en el botón Registrar
      private void btnRegistrar_Click(object sender, EventArgs e)
      {
         // Verifica que los campos no estén vacíos
         if (string.IsNullOrEmpty(txtIdTipoArticulo.Text) ||
             string.IsNullOrEmpty(txtNombreTipoArticulo.Text) ||
             string.IsNullOrEmpty(txtDescripcionTipoArticulo.Text))
         {
            MessageBox.Show("Los campos no son válidos.");
            return;
         }

         // Verifica que el ID sea un número válido
         int id;
         if (!int.TryParse(txtIdTipoArticulo.Text, out id))
         {
            MessageBox.Show("El ID debe ser un número válido.");
            return;
         }

         // Empaqueta los datos del tipo de artículo para enviarlos al servidor
         Paquete paquete = new Paquete
         {
            Comando = "RegistrarTipoArticulo",
            Datos = new
            {
               IdTipoArticulo = id,
               NombreTipoArticulo = txtNombreTipoArticulo.Text,
               DescripcionTipoArticulo = txtDescripcionTipoArticulo.Text
            }
         };

         ConexionTcp.Enviar(paquete);
      }

      // Evento que se ejecuta cuando se hace clic en el botón Consultar
      private void btnConsultar_Click(object sender, EventArgs e)
      {
         // Crea el paquete que solicita la lista de tipos de artículo al servidor
         Paquete paquete = new Paquete
         {
            Comando = "ConsultarTipoArticulo"
         };

         ConexionTcp.Enviar(paquete);
      }

      // Muestra el mensaje de confirmación del servidor tras registrar un tipo de artículo
      public void MostrarRespuesta(string mensaje)
      {
         MessageBox.Show(mensaje);
         if (mensaje.StartsWith("Se ha registrado"))
         {
            Limpiar();
         }
      }

      // Muestra en el DataGridView los tipos de artículo consultados
      public void MostrarTipos(List<TipoArticulo> lista)
      {
         dgvConsultas.DataSource = null;
         dgvConsultas.DataSource = lista;
         ConfigurarColumnas();
      }

      // Configura los encabezados del DataGridView para que sean más amigables al usuario
      private void ConfigurarColumnas()
      {
         if (dgvConsultas.Columns.Count > 0)
         {
            dgvConsultas.Columns["IdTipoArticulo"].HeaderText = "ID Tipo";
            dgvConsultas.Columns["NombreTipoArticulo"].HeaderText = "Nombre";
            dgvConsultas.Columns["DescripcionTipoArticulo"].HeaderText = "Descripción";
         }
      }

      // Limpia todos los campos del formulario
      private void Limpiar()
      {
         txtIdTipoArticulo.Clear();
         txtNombreTipoArticulo.Clear();
         txtDescripcionTipoArticulo.Clear();
         txtIdTipoArticulo.Focus();
      }

      // Cierra el formulario actual y vuelve al anterior (sin cerrar la app)
      private void btnRegresar_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      // Cierra completamente la aplicación
      private void btnSalir_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      // Envía un paquete de prueba al servidor para verificar si la conexión está activa
      private void btnProbarConexion_Click(object sender, EventArgs e)
      {
         Paquete paquete = new Paquete
         {
            Comando = "Conectando",
            Datos = null
         };

         ConexionTcp.Enviar(paquete);
      }
   }
}
