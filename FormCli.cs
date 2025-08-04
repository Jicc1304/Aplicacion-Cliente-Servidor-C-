/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;
using System.Windows.Forms;
using LibEntidades;

namespace AplicacionCliente
{
   public partial class FormCli : Form
   {
      private TcpClient clienteTcp;

      public FormCli(TcpClient cliente)
      {
         InitializeComponent();
         clienteTcp = cliente;

         // Se cargan las opciones del ComboBox de estado
         cmbEstado.Items.Add("Activo");
         cmbEstado.Items.Add("Inactivo");
         cmbEstado.SelectedIndex = -1;

         // Se configura el DateTimePicker para que no permita fechas futuras
         dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
         dtpFechaNacimiento.MaxDate = DateTime.Today;
         dtpFechaNacimiento.Value = DateTime.Today.AddYears(-18); // Valor predeterminado: 18 años atrás
      }

      private void btnRegistrar_Click(object sender, EventArgs e)
      {
         // Se validan los campos obligatorios del formulario
         if (!int.TryParse(txtIdCliente.Text, out int id) || id <= 0 ||
             string.IsNullOrWhiteSpace(txtNombre.Text) ||
             string.IsNullOrWhiteSpace(txtPrimerApellido.Text) ||
             string.IsNullOrWhiteSpace(txtSegundoApellido.Text) ||
             cmbEstado.SelectedIndex == -1)
         {
            MessageBox.Show("Todos los campos deben ser completados correctamente.");
            return;
         }

         // Se construye un nuevo objeto de tipo Clientes con los datos del formulario
         Clientes nuevo = new Clientes
         {
            IdCliente = id,
            NombreCliente = txtNombre.Text.Trim(),
            PrimerApellidoC = txtPrimerApellido.Text.Trim(),
            SegundoApellidoC = txtSegundoApellido.Text.Trim(),
            FechaNacimientoC = dtpFechaNacimiento.Value.Date,
            EstadoCliente = cmbEstado.SelectedItem.ToString() == "Activo"
         };

         // Se prepara el paquete para enviar al servidor
         Paquete paquete = new Paquete
         {
            Comando = "RegistrarCliente",
            Datos = nuevo
         };

         ConexionTcp.Enviar(paquete);
      }

      private void btnConsultar_Click(object sender, EventArgs e)
      {
         // Se solicita al servidor la lista de clientes
         Paquete paquete = new Paquete
         {
            Comando = "ConsultarCliente"
         };

         ConexionTcp.Enviar(paquete);
      }

      public void MostrarRespuesta(string mensaje)
      {
         // Se muestra el mensaje recibido del servidor
         MessageBox.Show(mensaje);

         // Si el registro fue exitoso, se limpian los campos del formulario
         if (mensaje.StartsWith("Se ha registrado"))
         {
            LimpiarCampos();
         }
      }

      public void MostrarClientes(List<Clientes> lista)
      {
         // Se transforma la lista de clientes para que sea más amigable al usuario
         var clientesPlano = lista.ConvertAll(c => new
         {
            ID = c.IdCliente,
            Nombre = c.NombreCliente,
            Apellido1 = c.PrimerApellidoC,
            Apellido2 = c.SegundoApellidoC,
            FechaNacimiento = c.FechaNacimientoC.ToShortDateString(),
            Estado = c.EstadoCliente ? "Activo" : "Inactivo"
         });

         // Se carga la lista transformada en el DataGridView
         dataGridView1.DataSource = null;
         dataGridView1.DataSource = clientesPlano;

         // Se configuran los encabezados de las columnas
         ConfigurarColumnasDGV();
      }

      private void ConfigurarColumnasDGV()
      {
         // Este método cambia los encabezados de las columnas por nombres más claros
         if (dataGridView1.Columns.Count > 0)
         {
            dataGridView1.Columns["ID"].HeaderText = "ID Cliente";
            dataGridView1.Columns["Nombre"].HeaderText = "Nombre";
            dataGridView1.Columns["Apellido1"].HeaderText = "Primer Apellido";
            dataGridView1.Columns["Apellido2"].HeaderText = "Segundo Apellido";
            dataGridView1.Columns["FechaNacimiento"].HeaderText = "Nacimiento";
            dataGridView1.Columns["Estado"].HeaderText = "Estado";
         }
      }

      private void LimpiarCampos()
      {
         // Se limpian todos los controles del formulario
         txtIdCliente.Clear();
         txtNombre.Clear();
         txtPrimerApellido.Clear();
         txtSegundoApellido.Clear();
         dtpFechaNacimiento.Value = DateTime.Today.AddYears(-18);
         cmbEstado.SelectedIndex = -1;
         txtIdCliente.Focus();
      }

      private void btnRegresar_Click(object sender, EventArgs e)
      {
         // Se regresa al formulario principal
         this.Owner?.Show();
         this.Close();
      }

      private void btnSalir_Click(object sender, EventArgs e)
      {
         // Se cierra toda la aplicación
         Application.Exit();
      }
   }
}
