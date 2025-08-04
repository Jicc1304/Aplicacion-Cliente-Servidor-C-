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
   public partial class FormRepartidores : Form
   {
      private TcpClient cliente;

      // Constructor del formulario que inicializa componentes, estados y fechas
      public FormRepartidores(TcpClient cliente)
      {
         InitializeComponent();
         CargarEstados();
         ConfigurarDatePickers();
         this.cliente = cliente;
      }

      // Este método carga las opciones del ComboBox de estado (Sí/No)
      private void CargarEstados()
      {
         cmbEstado.Items.Clear();
         cmbEstado.Items.Add("Sí");
         cmbEstado.Items.Add("No");
         cmbEstado.SelectedIndex = 0;
      }

      // Configura los controles de fecha para nacimiento y contratación
      private void ConfigurarDatePickers()
      {
         dtpNacimiento.Format = DateTimePickerFormat.Short;
         dtpNacimiento.MaxDate = DateTime.Today.AddYears(-18);
         dtpNacimiento.Value = dtpNacimiento.MaxDate;

         dtpContratación.Format = DateTimePickerFormat.Short;
         dtpContratación.MaxDate = DateTime.Today;
         dtpContratación.Value = DateTime.Today;
      }

      // Este método se ejecuta al hacer clic en el botón Registrar.
      // Valida los campos y construye un objeto Repartidores para enviarlo al servidor
      private void btnRegistrar_Click(object sender, EventArgs e)
      {
         try
         {
            if (!int.TryParse(txtId.Text.Trim(), out int id))
            {
               MessageBox.Show("El ID debe ser un número entero válido.");
               txtId.Focus();
               return;
            }

            if (dtpNacimiento.Value > DateTime.Today.AddYears(-18))
            {
               MessageBox.Show("El repartidor debe tener al menos 18 años cumplidos.");
               return;
            }

            if (dtpContratación.Value > DateTime.Today)
            {
               MessageBox.Show("La fecha de contratación no puede ser futura.");
               return;
            }

            Repartidores nuevo = new Repartidores
            {
               IdRepartidor = id,
               NombreRepartidor = txtNombre.Text.Trim(),
               PrimerApellidoR = txtApellido1.Text.Trim(),
               SegundoApellidoR = txtApellido2.Text.Trim(),
               FechaNacimientoR = dtpNacimiento.Value,
               FechaContratacionR = dtpContratación.Value,
               EstadoRepartidor = cmbEstado.SelectedItem.ToString() == "Sí"
            };

            Paquete paquete = new Paquete
            {
               Comando = "RegistrarRepartidor",
               Datos = nuevo
            };

            ConexionTcp.Enviar(paquete);
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error inesperado: " + ex.Message);
         }
      }

      // Este método recibe un mensaje de respuesta y lo muestra en pantalla
      public void MostrarRespuesta(string mensaje)
      {
         MessageBox.Show(mensaje);
         if (mensaje.StartsWith("Se ha registrado"))
            LimpiarCampos();
      }

      // Este método recibe una lista de repartidores y la muestra en el DataGridView
      public void MostrarRepartidores(List<Repartidores> lista)
      {
         dgvRepartidores.DataSource = null;
         dgvRepartidores.DataSource = lista;
         ConfigurarColumnas();
      }

      // Configura los encabezados visibles de las columnas del DataGridView
      private void ConfigurarColumnas()
      {
         if (dgvRepartidores.Columns.Count > 0)
         {
            dgvRepartidores.Columns["IdRepartidor"].HeaderText = "ID";
            dgvRepartidores.Columns["NombreRepartidor"].HeaderText = "Nombre";
            dgvRepartidores.Columns["PrimerApellidoR"].HeaderText = "Primer Apellido";
            dgvRepartidores.Columns["SegundoApellidoR"].HeaderText = "Segundo Apellido";
            dgvRepartidores.Columns["FechaNacimientoR"].HeaderText = "Nacimiento";
            dgvRepartidores.Columns["FechaContratacionR"].HeaderText = "Contratación";
            dgvRepartidores.Columns["EstadoRepartidor"].HeaderText = "Activo";
         }
      }

      // Al presionar el botón Consultar, se solicita la lista de repartidores al servidor
      private void btnConsultar_Click(object sender, EventArgs e)
      {
         Paquete paquete = new Paquete
         {
            Comando = "ConsultarRepartidores",
            Datos = null
         };

         ConexionTcp.Enviar(paquete);
      }

      // Este método limpia todos los campos del formulario
      private void LimpiarCampos()
      {
         txtId.Clear();
         txtNombre.Clear();
         txtApellido1.Clear();
         txtApellido2.Clear();
         dtpNacimiento.Value = DateTime.Today.AddYears(-18);
         dtpContratación.Value = DateTime.Today;
         cmbEstado.SelectedIndex = 0;
      }

      // Al presionar el botón Regresar, se vuelve al formulario anterior
      private void btnRegresar_Click(object sender, EventArgs e)
      {
         FormMenuPrincipal menu = new FormMenuPrincipal();
         this.Owner?.Show();
         this.Close();
      }

      // Al presionar el botón Salir, se cierra la aplicación completamente
      private void btnSalir_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      // Al hacer clic en el menú Repartidores, se vuelve a abrir este mismo formulario
      private void MenuRepartidores_Click(object sender, EventArgs e)
      {
         FormRepartidores frm = new FormRepartidores(cliente);
         frm.Show();
         this.Hide();
      }
   }
}
