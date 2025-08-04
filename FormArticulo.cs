/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */
using LibEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text.Json;
using System.Windows.Forms;

namespace AplicacionCliente
{
   public partial class FormArticulo : Form
   {
      // Guarda la conexión TCP que se recibe desde el formulario principal
      private TcpClient clienteTcp;

      // Flujo de red para enviar/recibir datos
      private NetworkStream stream;

      // Constructor del formulario que recibe el cliente TCP
      public FormArticulo(TcpClient cliente)
      {
         InitializeComponent();
         clienteTcp = cliente;
         stream = cliente.GetStream();

         // Carga los valores "Sí" y "No" en el ComboBox de estado
         CargarEstados();

         // Cuando el formulario termine de cargar, se solicita la lista de tipos de artículo
         this.Load += FormArticulo_Load;
      }

      // Al cargarse el formulario, se envía el comando para consultar los tipos de artículo
      private void FormArticulo_Load(object sender, EventArgs e)
      {
         ConexionTcp.Enviar(new Paquete
         {
            Comando = "ConsultarTipoArticulo"
         });
      }

      // Carga los valores del ComboBox de estado: "Sí" y "No"
      private void CargarEstados()
      {
         cmbEstado.Items.Clear();
         cmbEstado.Items.Add("Sí");
         cmbEstado.Items.Add("No");
         cmbEstado.SelectedIndex = -1;
      }

      // Evento que se ejecuta al hacer clic en el botón Registrar
      private void btnRegistrar_Click(object sender, EventArgs e)
      {
         // Validación de todos los campos del formulario
         if (!int.TryParse(txtIdArticulo.Text.Trim(), out int id) ||
             string.IsNullOrWhiteSpace(txtNombreArticulo.Text) ||
             !double.TryParse(txtValorArticulo.Text, out double valor) ||
             !int.TryParse(txtInventario.Text, out int inventario) ||
             cmbTipoArticulo.SelectedIndex == -1 ||
             cmbEstado.SelectedIndex == -1)
         {
            MessageBox.Show("Todos los campos deben ser válidos y completos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         // Se crea el objeto Articulo con los datos ingresados
         Articulo nuevo = new Articulo
         {
            IdArticulo = id,
            NombreArticulo = txtNombreArticulo.Text.Trim(),
            ValorArticulo = valor,
            InventarioArticulo = inventario,
            EstadoArticulo = cmbEstado.Text == "Sí",
            TipoArt = new TipoArticulo
            {
               IdTipoArticulo = Convert.ToInt32(cmbTipoArticulo.SelectedValue)
            }
         };

         // Se empaqueta la información para enviarla al servidor
         ConexionTcp.Enviar(new Paquete
         {
            Comando = "RegistrarArticulo",
            Datos = nuevo
         });
      }

      // Envía un comando al servidor para consultar los artículos registrados
      private void btnConsultar_Click(object sender, EventArgs e)
      {
         ConexionTcp.Enviar(new Paquete
         {
            Comando = "ConsultarArticulo"
         });
      }

      // Muestra el mensaje de respuesta del servidor al registrar un artículo
      public void MostrarRespuesta(string mensaje)
      {
         MessageBox.Show(mensaje);
         if (mensaje.StartsWith("Se ha registrado"))
         {
            Limpiar();
         }
      }

      // Muestra los artículos consultados en el DataGridView
      public void MostrarArticulos(List<Articulo> lista)
      {
         if (lista == null || lista.Count == 0)
         {
            MessageBox.Show("No hay artículos registrados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         // Se proyecta la lista en un formato plano para mostrar en el DataGridView
         var articulosPlano = lista.Select(a => new
         {
            a.IdArticulo,
            a.NombreArticulo,
            TipoArticulo = a.TipoArt?.NombreTipoArticulo,
            ValorArticulo = "₡" + a.ValorArticulo.ToString("N2"),
            a.InventarioArticulo,
            Estado = a.EstadoArticulo ? "Sí" : "No"
         }).ToList();

         dgvConsultas.DataSource = null;
         dgvConsultas.DataSource = articulosPlano;

         // Se configura manualmente el encabezado de las columnas
         ConfigurarDgvConsultas();
      }

      // Ajusta los nombres visibles de las columnas del DataGridView para que se vean ordenados y comprensibles
      private void ConfigurarDgvConsultas()
      {
         if (dgvConsultas.Columns.Count > 0)
         {
            dgvConsultas.Columns["IdArticulo"].HeaderText = "ID Artículo";
            dgvConsultas.Columns["NombreArticulo"].HeaderText = "Nombre";
            dgvConsultas.Columns["TipoArticulo"].HeaderText = "Tipo de Artículo";
            dgvConsultas.Columns["ValorArticulo"].HeaderText = "Valor (₡)";
            dgvConsultas.Columns["InventarioArticulo"].HeaderText = "Inventario";
            dgvConsultas.Columns["Estado"].HeaderText = "Activo";
         }
      }

      // Carga en el ComboBox los tipos de artículo recibidos desde el servidor
      public void MostrarTiposArticulo(List<TipoArticulo> lista)
      {
         if (lista == null || lista.Count == 0)
         {
            MessageBox.Show("No hay tipos de artículo disponibles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         cmbTipoArticulo.DataSource = null;
         cmbTipoArticulo.DataSource = lista;
         cmbTipoArticulo.DisplayMember = "NombreTipoArticulo";
         cmbTipoArticulo.ValueMember = "IdTipoArticulo";
         cmbTipoArticulo.SelectedIndex = -1;
      }

      // Limpia todos los campos del formulario y coloca el foco en el campo ID
      private void Limpiar()
      {
         txtIdArticulo.Clear();
         txtNombreArticulo.Clear();
         txtValorArticulo.Clear();
         txtInventario.Clear();
         cmbTipoArticulo.SelectedIndex = -1;
         cmbEstado.SelectedIndex = -1;
         txtIdArticulo.Focus();
      }

      // Cierra este formulario y muestra el formulario anterior
      private void btnRegresar_Click(object sender, EventArgs e)
      {
         this.Owner?.Show();
         this.Close();
      }

      // Cierra completamente la aplicación
      private void btnSalir_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void FormArticulo_Load_1(object sender, EventArgs e)
      {

      }
   }
}
