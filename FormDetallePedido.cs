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
   /// Formulario encargado de registrar y consultar los detalles de un pedido.
   /// Permite agregar múltiples artículos al detalle de un pedido y consultar los ya registrados.
   /// </summary>
   public partial class FormDetallePedido : Form
   {
      private TcpClient cliente;
      private int idPedido;

      // Lista de artículos disponibles obtenidos desde el servidor
      private List<Articulo> listaArticulos;

      // Lista temporal que almacena los artículos seleccionados antes de enviarlos al servidor
      private List<DetallePedidos> detallesTemporales;

      /// <summary>
      /// Constructor que recibe el cliente TCP y el ID del pedido.
      /// </summary>
      public FormDetallePedido(TcpClient cliente, int idPedido)
      {
         InitializeComponent();
         this.cliente = cliente;
         this.idPedido = idPedido;
         detallesTemporales = new List<DetallePedidos>();

         // Suscribimos el evento Load para que cargue artículos al iniciar
         this.Load += FormDetallePedido_Load;
      }

      /// <summary>
      /// Evento que se ejecuta cuando se carga el formulario.
      /// Solicita al servidor la lista de artículos activos.
      /// </summary>
      private void FormDetallePedido_Load(object sender, EventArgs e)
      {
         SolicitarArticulos();
      }

      /// <summary>
      /// Envia una solicitud al servidor para obtener los artículos activos.
      /// </summary>
      private void SolicitarArticulos()
      {
         ConexionTcp.Enviar(new Paquete
         {
            Comando = "ConsultarArticulosCMB"
         });
      }

      /// <summary>
      /// Carga en el ComboBox los artículos obtenidos del servidor.
      /// </summary>
      public void CargarArticulosDesdeServidor(List<Articulo> articulos)
      {
         listaArticulos = articulos;
         cmbArticulos.DataSource = listaArticulos;
         cmbArticulos.DisplayMember = "NombreArticulo";
         cmbArticulos.ValueMember = "IdArticulo";
      }

      /// <summary>
      /// Agrega un artículo a la lista temporal de detalles.
      /// </summary>
      private void btnAgregarArticulo_Click(object sender, EventArgs e)
      {
         if (cmbArticulos.SelectedItem == null || !int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
         {
            MessageBox.Show("Complete todos los campos correctamente.");
            return;
         }

         var articulo = (Articulo)cmbArticulos.SelectedItem;

         // Verifica si el artículo ya fue agregado antes
         if (detallesTemporales.Any(d => d.Articulo.IdArticulo == articulo.IdArticulo))
         {
            MessageBox.Show("Este artículo ya ha sido agregado.");
            return;
         }

         // Verifica que la cantidad no exceda el inventario disponible
         if (cantidad > articulo.InventarioArticulo)
         {
            MessageBox.Show($"No hay suficiente inventario. Disponible: {articulo.InventarioArticulo}");
            return;
         }

         decimal valorUnitario = Convert.ToDecimal(articulo.ValorArticulo);
         double monto = (double)(valorUnitario * cantidad * 1.12M); // Incluye 12% adicional

         var detalle = new DetallePedidos
         {
            Pedido = new Pedidos { IdPedido = idPedido },
            Articulo = articulo,
            CantidadArticulos = cantidad,
            ValorArticulo = monto
         };

         detallesTemporales.Add(detalle);
         MostrarDetalleTemporal();
      }

      /// <summary>
      /// Muestra en el DataGridView los artículos agregados temporalmente.
      /// </summary>
      private void MostrarDetalleTemporal()
      {
         var vista = detallesTemporales.Select(d => new
         {
            Articulo = d.Articulo.NombreArticulo,
            ValorUnitario = d.Articulo.ValorArticulo.ToString("C"),
            Cantidad = d.CantidadArticulos,
            MontoTotal = d.ValorArticulo.ToString("C")
         }).ToList();

         dgvDetalleTemporal.DataSource = null;
         dgvDetalleTemporal.DataSource = vista;
      }

      /// <summary>
      /// Envía todos los artículos temporales al servidor para su registro definitivo.
      /// </summary>
      private void btnRegistrar_Click(object sender, EventArgs e)
      {
         if (detallesTemporales.Count == 0)
         {
            MessageBox.Show("Agregue al menos un artículo al detalle.");
            return;
         }

         foreach (var detalle in detallesTemporales)
         {
            ConexionTcp.Enviar(new Paquete
            {
               Comando = "RegistrarDetallePedido",
               Datos = detalle
            });
         }

         MessageBox.Show("Todos los artículos han sido registrados.");
         detallesTemporales.Clear();
         dgvDetalleTemporal.DataSource = null;
      }

      /// <summary>
      /// Solicita al servidor los detalles ya registrados del pedido actual.
      /// </summary>
      private void btnConsultar_Click(object sender, EventArgs e)
      {
         ConexionTcp.Enviar(new Paquete
         {
            Comando = "ConsultarDetallePedido"
         });
      }

      /// <summary>
      /// Muestra en el DataGridView los detalles obtenidos desde el servidor.
      /// </summary>
      public void MostrarDetalles(List<DetallePedidos> lista)
      {
         var vista = lista.Select(d => new
         {
            PedidoID = d.Pedido?.IdPedido,
            Articulo = d.Articulo?.NombreArticulo,
            ValorUnitario = (d.ValorArticulo / (1.12 * d.CantidadArticulos)).ToString("C"),
            Cantidad = d.CantidadArticulos,
            Monto = d.ValorArticulo.ToString("C")
         }).OrderBy(d => d.PedidoID).ToList();

         dgvConsultas.DataSource = null;
         dgvConsultas.DataSource = vista;
      }

      /// <summary>
      /// Cierra el formulario actual y vuelve al formulario anterior.
      /// </summary>
      private void btnRegresar_Click(object sender, EventArgs e)
      {
         this.Owner?.Show();
         this.Close();
      }

      /// <summary>
      /// Cierra completamente la aplicación.
      /// </summary>
      private void btnSalir_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }
   }
}
