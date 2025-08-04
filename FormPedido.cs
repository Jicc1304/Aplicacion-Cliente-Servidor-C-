/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using LibEntidades;

namespace AplicacionCliente
{
   /// <summary>
   /// Formulario encargado del registro y consulta de pedidos.
   /// Se comunica con el servidor para enviar y recibir información relacionada con los pedidos.
   /// </summary>
   public partial class FormPedido : Form
   {
      // Listas locales para almacenar los clientes y repartidores activos
      private List<Clientes> listaClientes;
      private List<Repartidores> listaRepartidores;

      // Objeto TcpClient para la conexión con el servidor
      private TcpClient cliente;

      // Variables para mantener el último ID de pedido registrado y estado de registro
      private int ultimoIdPedidoRegistrado = 0;
      private bool pedidoRegistrado = false;

      /// <summary>
      /// Constructor que inicializa el formulario y configura eventos iniciales.
      /// </summary>
      public FormPedido(TcpClient cliente)
      {
         InitializeComponent();
         this.cliente = cliente;

         // Asociamos el evento Load para que al cargar el formulario se pidan los datos
         this.Load += FormPedido_Load;

         // Configuramos el DateTimePicker para que no acepte fechas anteriores a hoy
         dtpFechaPedido.Format = DateTimePickerFormat.Short;
         dtpFechaPedido.MaxDate = DateTime.Today;
      }

      /// <summary>
      /// Muestra el resultado de un pedido registrado y almacena el ID generado.
      /// </summary>
      public void MostrarResultadoRegistroPedido(int idGenerado)
      {
         ultimoIdPedidoRegistrado = idGenerado;
         MessageBox.Show($"Pedido registrado con éxito. ID generado: {idGenerado}");

         // Activamos el botón "Siguiente" si estaba deshabilitado
         btnSiguiente.Enabled = true;
      }

      /// <summary>
      /// Evento que se ejecuta al cargar el formulario.
      /// Solicita al servidor las listas de clientes y repartidores activos.
      /// </summary>
      private void FormPedido_Load(object sender, EventArgs e)
      {
         // Solicitamos clientes activos
         ConexionTcp.Enviar(new Paquete
         {
            Comando = "ConsultarClientesActivos",
            Datos = null
         });

         // Solicitamos repartidores activos
         ConexionTcp.Enviar(new Paquete
         {
            Comando = "ConsultarRepartidoresActivos",
            Datos = null
         });
      }

      /// <summary>
      /// Carga los clientes recibidos del servidor en el ComboBox correspondiente.
      /// </summary>
      public void CargarClientesDesdeServidor(List<Clientes> lista)
      {
         listaClientes = lista;
         cmbIdCliente.DataSource = listaClientes;
         cmbIdCliente.DisplayMember = "NombreCliente";
         cmbIdCliente.ValueMember = "IdCliente";
      }

      /// <summary>
      /// Carga los repartidores recibidos del servidor en el ComboBox correspondiente.
      /// </summary>
      public void CargarRepartidoresDesdeServidor(List<Repartidores> lista)
      {
         listaRepartidores = lista;
         cmbIdRepartidor.DataSource = listaRepartidores;
         cmbIdRepartidor.DisplayMember = "NombreRepartidor";
         cmbIdRepartidor.ValueMember = "IdRepartidor";
      }

      /// <summary>
      /// Evento que se ejecuta al presionar el botón Registrar.
      /// Valida los datos y envía el pedido al servidor.
      /// </summary>
      private void btnRegistrar_Click(object sender, EventArgs e)
      {
         if (cmbIdCliente.SelectedItem == null || cmbIdRepartidor.SelectedItem == null || string.IsNullOrWhiteSpace(txtDireccionPedido.Text))
         {
            MessageBox.Show("Todos los campos son obligatorios.");
            return;
         }

         var nuevoPedido = new Pedidos
         {
            FechaPedido = dtpFechaPedido.Value.Date,
            Cliente = (Clientes)cmbIdCliente.SelectedItem,
            Repartidor = (Repartidores)cmbIdRepartidor.SelectedItem,
            DireccionPedido = txtDireccionPedido.Text.Trim()
         };

         Paquete paquete = new Paquete
         {
            Comando = "RegistrarPedido",
            Datos = nuevoPedido
         };

         ConexionTcp.Enviar(paquete);
      }

      /// <summary>
      /// Muestra la respuesta del servidor luego de registrar un pedido.
      /// </summary>
      public void MostrarRespuesta(string mensaje, Pedidos pedidoRegistrado)
      {
         MessageBox.Show(mensaje);
         ultimoIdPedidoRegistrado = pedidoRegistrado.IdPedido;

         if (mensaje.StartsWith("Se ha registrado"))
            LimpiarCampos();
      }

      /// <summary>
      /// Muestra en el DataGridView todos los pedidos recibidos del servidor.
      /// </summary>
      public void MostrarPedidos(List<Pedidos> lista)
      {
         if (lista == null || lista.Count == 0)
         {
            MessageBox.Show("No hay pedidos registrados.");
            return;
         }

         var pedidosPlano = lista.Select(p => new
         {
            Id_Pedido = p.IdPedido,
            Fecha_Pedido = p.FechaPedido.ToShortDateString(),
            Id_Cliente = p.Cliente?.IdCliente,
            Nombre_Cliente = p.Cliente?.NombreCliente,
            Primer_Apellido_Cliente = p.Cliente?.PrimerApellidoC,
            Segundo_Apellido_Cliente = p.Cliente?.SegundoApellidoC,
            Id_Repartidor = p.Repartidor?.IdRepartidor,
            Nombre_Repartidor = p.Repartidor?.NombreRepartidor,
            Primer_Apellido_Repartidor = p.Repartidor?.PrimerApellidoR,
            Segundo_Apellido_Repartidor = p.Repartidor?.SegundoApellidoR,
            Direccion_Entrega = p.DireccionPedido
         }).ToList();

         dgvConsultarPedidos.DataSource = null;
         dgvConsultarPedidos.AutoGenerateColumns = false;
         dgvConsultarPedidos.Columns.Clear();

         dgvConsultarPedidos.Columns.Add("Id_Pedido", "ID Pedido");
         dgvConsultarPedidos.Columns.Add("Fecha_Pedido", "Fecha");
         dgvConsultarPedidos.Columns.Add("Id_Cliente", "ID Cliente");
         dgvConsultarPedidos.Columns.Add("Nombre_Cliente", "Nombre Cliente");
         dgvConsultarPedidos.Columns.Add("Primer_Apellido_Cliente", "1er Apellido");
         dgvConsultarPedidos.Columns.Add("Segundo_Apellido_Cliente", "2do Apellido");
         dgvConsultarPedidos.Columns.Add("Id_Repartidor", "ID Repartidor");
         dgvConsultarPedidos.Columns.Add("Nombre_Repartidor", "Nombre Repartidor");
         dgvConsultarPedidos.Columns.Add("Primer_Apellido_Repartidor", "1er Apellido Rep.");
         dgvConsultarPedidos.Columns.Add("Segundo_Apellido_Repartidor", "2do Apellido Rep.");
         dgvConsultarPedidos.Columns.Add("Direccion_Entrega", "Dirección Entrega");

         dgvConsultarPedidos.Columns["Id_Pedido"].DataPropertyName = "Id_Pedido";
         dgvConsultarPedidos.Columns["Fecha_Pedido"].DataPropertyName = "Fecha_Pedido";
         dgvConsultarPedidos.Columns["Id_Cliente"].DataPropertyName = "Id_Cliente";
         dgvConsultarPedidos.Columns["Nombre_Cliente"].DataPropertyName = "Nombre_Cliente";
         dgvConsultarPedidos.Columns["Primer_Apellido_Cliente"].DataPropertyName = "Primer_Apellido_Cliente";
         dgvConsultarPedidos.Columns["Segundo_Apellido_Cliente"].DataPropertyName = "Segundo_Apellido_Cliente";
         dgvConsultarPedidos.Columns["Id_Repartidor"].DataPropertyName = "Id_Repartidor";
         dgvConsultarPedidos.Columns["Nombre_Repartidor"].DataPropertyName = "Nombre_Repartidor";
         dgvConsultarPedidos.Columns["Primer_Apellido_Repartidor"].DataPropertyName = "Primer_Apellido_Repartidor";
         dgvConsultarPedidos.Columns["Segundo_Apellido_Repartidor"].DataPropertyName = "Segundo_Apellido_Repartidor";
         dgvConsultarPedidos.Columns["Direccion_Entrega"].DataPropertyName = "Direccion_Entrega";

         dgvConsultarPedidos.DataSource = pedidosPlano;
      }

      /// <summary>
      /// Evento que se ejecuta al hacer clic en el botón Consultar.
      /// Solicita al servidor la lista de pedidos registrados.
      /// </summary>
      private void btnConsultar_Click(object sender, EventArgs e)
      {
         ConexionTcp.Enviar(new Paquete
         {
            Comando = "ConsultarPedido",
            Datos = null
         });
      }

      /// <summary>
      /// Evento que se ejecuta al hacer clic en el botón Regresar.
      /// Cierra el formulario y vuelve al menú anterior.
      /// </summary>
      private void btnRegresar_Click(object sender, EventArgs e)
      {
         this.Owner?.Show();
         this.Close();
      }

      /// <summary>
      /// Evento que se ejecuta al hacer clic en el botón Salir.
      /// Cierra toda la aplicación.
      /// </summary>
      private void btnSalir_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      /// <summary>
      /// Abre el formulario de detalle de pedido con el último ID registrado.
      /// </summary>
      private void btnSiguiente_Click(object sender, EventArgs e)
      {
         if (ultimoIdPedidoRegistrado <= 0)
         {
            MessageBox.Show("Debe registrar un pedido antes de continuar.");
            return;
         }

         FormDetallePedido formDetalle = new FormDetallePedido(cliente, ultimoIdPedidoRegistrado);
         formDetalle.Owner = this;
         formDetalle.Show();
         this.Hide();
      }

      /// <summary>
      /// Limpia todos los campos del formulario a su estado por defecto.
      /// </summary>
      private void LimpiarCampos()
      {
         cmbIdCliente.SelectedIndex = -1;
         cmbIdRepartidor.SelectedIndex = -1;
         dtpFechaPedido.Value = DateTime.Today;
         txtDireccionPedido.Clear();
      }
   }
}
