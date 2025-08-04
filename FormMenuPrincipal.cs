/**
 * UNED II Cuatrimestre.
 * Proyecto 2: Aplicación Cliente-Servidor.
 * Estudiante: José Isaac Castillo Cordero.
 * Fecha: 27/7/2025
 */

using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using LibEntidades;

namespace AplicacionCliente
{
   /// <summary>
   /// Formulario principal de la aplicación cliente.
   /// Desde aquí se valida al cliente y se navega a los distintos formularios de gestión.
   /// </summary>
   public partial class FormMenuPrincipal : Form
   {
      // Cliente y flujo de red para enviar/recibir información con el servidor
      private TcpClient clienteTcp;
      private NetworkStream stream;

      /// <summary>
      /// Constructor del formulario. Inicializa componentes y configuración inicial.
      /// </summary>
      public FormMenuPrincipal()
      {
         InitializeComponent();
         lblEstadoConexion.Text = "Estado: No conectado";

         // Se asigna esta instancia a la clase ConexionTcp para que pueda invocar sus métodos
         ConexionTcp.FormMenuPrincipal = this;

         // Se desactiva el menú de gestión hasta que se valide el cliente
         gestiónToolStripMenuItem.Enabled = false;
      }

      /// <summary>
      /// Muestra el mensaje de bienvenida y habilita el menú de gestión cuando se valida un cliente.
      /// </summary>
      /// <param name="cliente">Objeto cliente validado.</param>
      public void MostrarClienteValidado(Clientes cliente)
      {
         lblMensajeLogin.Text = $"Bienvenido {cliente.NombreCliente} {cliente.PrimerApellidoC}";
         gestiónToolStripMenuItem.Enabled = true;
      }

      /// <summary>
      /// Muestra un mensaje en caso de que el cliente no exista en la base de datos.
      /// </summary>
      /// <param name="mensaje">Mensaje de error o advertencia.</param>
      public void MostrarMensajeLogin(string mensaje)
      {
         lblMensajeLogin.Text = mensaje;
         gestiónToolStripMenuItem.Enabled = false;
      }

      /// <summary>
      /// Evento del botón "Validar". Envia el ID ingresado al servidor para validación.
      /// </summary>
      private void btnValidarCliente_Click(object sender, EventArgs e)
      {
         if (!string.IsNullOrWhiteSpace(txtIdCliente.Text))
         {
            Paquete paquete = new Paquete
            {
               Comando = "ValidarCliente",
               Datos = txtIdCliente.Text.Trim()
            };

            ConexionTcp.Enviar(paquete);
         }
         else
         {
            lblMensajeLogin.Text = "Ingrese un ID válido.";
         }
      }

      /// <summary>
      /// Evento del menú para conectar al servidor. 
      /// Establece la conexión y prepara el flujo de red para enviar datos.
      /// </summary>
      private void conectarAlServidorToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ConexionTcp.Conectar();

         clienteTcp = ConexionTcp.ClienteTcp;

         // Validar que se logró la conexión antes de intentar usar el stream
         if (clienteTcp != null && clienteTcp.Connected)
         {
            stream = clienteTcp.GetStream();
            lblEstadoConexion.Text = "Estado: Conectado";
         }
         else
         {
            lblEstadoConexion.Text = "Estado: No conectado";
            // No se necesita otro MessageBox porque ya se muestra desde ConexionTcp.Conectar()
         }
      }


      /// <summary>
      /// Evento para cerrar la aplicación desde el menú.
      /// </summary>
      private void salirToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      /// <summary>
      /// Evento del menú que abre el formulario de gestión de tipos de artículos.
      /// </summary>
      private void tipoArtículoToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (!EstaConectado()) return;

         FormTipoArticulo form = new FormTipoArticulo(clienteTcp);
         form.Show();
      }

      /// <summary>
      /// Evento del menú que abre el formulario de gestión de artículos.
      /// </summary>
      private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (!EstaConectado()) return;

         FormArticulo form = new FormArticulo(clienteTcp);
         form.Show();
      }

      /// <summary>
      /// Evento del menú que permite enviar un mensaje de prueba al servidor.
      /// </summary>
      private void probarConexiónToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (!EstaConectado()) return;

         var paquete = new Paquete
         {
            Comando = "ProbarConexion",
            Datos = "Test"
         };

         string json = JsonSerializer.Serialize(paquete);
         byte[] buffer = Encoding.UTF8.GetBytes(json);

         try
         {
            stream.Write(buffer, 0, buffer.Length);
            lblEstadoConexion.Text = "Mensaje enviado correctamente.";
         }
         catch (Exception ex)
         {
            lblEstadoConexion.Text = "Error al enviar: " + ex.Message;
         }
      }

      /// <summary>
      /// Verifica si el cliente TCP está conectado antes de permitir acciones.
      /// </summary>
      /// <returns>True si está conectado, False si no.</returns>
      private bool EstaConectado()
      {
         if (clienteTcp == null || !clienteTcp.Connected)
         {
            MessageBox.Show("Debe conectarse primero.");
            return false;
         }
         return true;
      }

      /// <summary>
      /// Evento del menú que abre el formulario de clientes.
      /// </summary>
      private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (!EstaConectado()) return;

         FormCli form = new FormCli(clienteTcp);
         form.Show();
      }

      /// <summary>
      /// Evento que se ejecuta al cargar el formulario. 
      /// Agrega dinámicamente el menú de "Repartidores".
      /// </summary>
      private void FormMenuPrincipal_Load(object sender, EventArgs e)
      {
         ToolStripMenuItem menuRepartidores = new ToolStripMenuItem("Repartidores");
         menuRepartidores.Click += MenuRepartidores_Click;
         menuStrip1.Items.Add(menuRepartidores);
      }

      /// <summary>
      /// Evento que abre el formulario de repartidores al seleccionar el menú correspondiente.
      /// </summary>
      private void MenuRepartidores_Click(object sender, EventArgs e)
      {
         if (!EstaConectado()) return;

         FormRepartidores form = new FormRepartidores(clienteTcp);
         form.Show();
      }

      /// <summary>
      /// Evento que abre el formulario de pedidos desde el menú.
      /// </summary>
      private void Pedidos_Click(object sender, EventArgs e)
      {
         if (!EstaConectado()) return;

         FormPedido form = new FormPedido(clienteTcp);
         form.Show();
      }
   }
}
