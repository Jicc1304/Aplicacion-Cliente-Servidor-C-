namespace AplicacionCliente
{
   partial class FormMenuPrincipal
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         menuStrip1 = new MenuStrip();
         archivoToolStripMenuItem = new ToolStripMenuItem();
         conectarAlServidorToolStripMenuItem = new ToolStripMenuItem();
         probarConexiónToolStripMenuItem = new ToolStripMenuItem();
         salirToolStripMenuItem = new ToolStripMenuItem();
         gestiónToolStripMenuItem = new ToolStripMenuItem();
         tToolStripMenuItem = new ToolStripMenuItem();
         articuloToolStripMenuItem = new ToolStripMenuItem();
         clientesToolStripMenuItem = new ToolStripMenuItem();
         repartidoresToolStripMenuItem = new ToolStripMenuItem();
         pedidosToolStripMenuItem = new ToolStripMenuItem();
         probarConexionToolStripMenuItem = new ToolStripMenuItem();
         lblEstadoConexion = new Label();
         txtIdCliente = new TextBox();
         lblNombreCliente = new Label();
         lblMensajeLogin = new Label();
         btnValidarCliente = new Button();
         label3 = new Label();
         menuStrip1.SuspendLayout();
         SuspendLayout();
         // 
         // menuStrip1
         // 
         menuStrip1.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, gestiónToolStripMenuItem });
         menuStrip1.Location = new Point(0, 0);
         menuStrip1.Name = "menuStrip1";
         menuStrip1.Size = new Size(605, 24);
         menuStrip1.TabIndex = 0;
         menuStrip1.Text = "menuStrip1";
         // 
         // archivoToolStripMenuItem
         // 
         archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { conectarAlServidorToolStripMenuItem, probarConexiónToolStripMenuItem, salirToolStripMenuItem });
         archivoToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
         archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
         archivoToolStripMenuItem.Size = new Size(62, 20);
         archivoToolStripMenuItem.Text = "Archivo";
         // 
         // conectarAlServidorToolStripMenuItem
         // 
         conectarAlServidorToolStripMenuItem.Name = "conectarAlServidorToolStripMenuItem";
         conectarAlServidorToolStripMenuItem.Size = new Size(189, 22);
         conectarAlServidorToolStripMenuItem.Text = "Conectar Al Servidor";
         conectarAlServidorToolStripMenuItem.Click += conectarAlServidorToolStripMenuItem_Click;
         // 
         // probarConexiónToolStripMenuItem
         // 
         probarConexiónToolStripMenuItem.Name = "probarConexiónToolStripMenuItem";
         probarConexiónToolStripMenuItem.Size = new Size(189, 22);
         probarConexiónToolStripMenuItem.Text = "Probar Conexión";
         probarConexiónToolStripMenuItem.Click += probarConexiónToolStripMenuItem_Click;
         // 
         // salirToolStripMenuItem
         // 
         salirToolStripMenuItem.Name = "salirToolStripMenuItem";
         salirToolStripMenuItem.Size = new Size(189, 22);
         salirToolStripMenuItem.Text = "Salir";
         salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
         // 
         // gestiónToolStripMenuItem
         // 
         gestiónToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tToolStripMenuItem, articuloToolStripMenuItem, clientesToolStripMenuItem, repartidoresToolStripMenuItem, pedidosToolStripMenuItem, probarConexionToolStripMenuItem });
         gestiónToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
         gestiónToolStripMenuItem.Name = "gestiónToolStripMenuItem";
         gestiónToolStripMenuItem.Size = new Size(62, 20);
         gestiónToolStripMenuItem.Text = "Gestión";
         // 
         // tToolStripMenuItem
         // 
         tToolStripMenuItem.Name = "tToolStripMenuItem";
         tToolStripMenuItem.Size = new Size(166, 22);
         tToolStripMenuItem.Text = "Tipo de Articulo";
         tToolStripMenuItem.Click += tipoArtículoToolStripMenuItem_Click;
         // 
         // articuloToolStripMenuItem
         // 
         articuloToolStripMenuItem.Name = "articuloToolStripMenuItem";
         articuloToolStripMenuItem.Size = new Size(166, 22);
         articuloToolStripMenuItem.Text = "Articulo";
         articuloToolStripMenuItem.Click += artículosToolStripMenuItem_Click;
         // 
         // clientesToolStripMenuItem
         // 
         clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
         clientesToolStripMenuItem.Size = new Size(166, 22);
         clientesToolStripMenuItem.Text = "Clientes";
         clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
         // 
         // repartidoresToolStripMenuItem
         // 
         repartidoresToolStripMenuItem.Name = "repartidoresToolStripMenuItem";
         repartidoresToolStripMenuItem.Size = new Size(166, 22);
         repartidoresToolStripMenuItem.Text = "Repartidores";
         repartidoresToolStripMenuItem.Click += MenuRepartidores_Click;
         // 
         // pedidosToolStripMenuItem
         // 
         pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
         pedidosToolStripMenuItem.Size = new Size(166, 22);
         pedidosToolStripMenuItem.Text = "Pedidos";
         pedidosToolStripMenuItem.Click += Pedidos_Click;
         // 
         // probarConexionToolStripMenuItem
         // 
         probarConexionToolStripMenuItem.Name = "probarConexionToolStripMenuItem";
         probarConexionToolStripMenuItem.Size = new Size(166, 22);
         probarConexionToolStripMenuItem.Text = "Probar Conexion";
         probarConexionToolStripMenuItem.Click += probarConexiónToolStripMenuItem_Click;
         // 
         // lblEstadoConexion
         // 
         lblEstadoConexion.AutoSize = true;
         lblEstadoConexion.BackColor = Color.Transparent;
         lblEstadoConexion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         lblEstadoConexion.ForeColor = Color.Transparent;
         lblEstadoConexion.Location = new Point(18, 219);
         lblEstadoConexion.Name = "lblEstadoConexion";
         lblEstadoConexion.Size = new Size(69, 21);
         lblEstadoConexion.TabIndex = 1;
         lblEstadoConexion.Text = "Estado: ";
         // 
         // txtIdCliente
         // 
         txtIdCliente.Location = new Point(42, 123);
         txtIdCliente.Name = "txtIdCliente";
         txtIdCliente.Size = new Size(170, 23);
         txtIdCliente.TabIndex = 2;
         // 
         // lblNombreCliente
         // 
         lblNombreCliente.AutoSize = true;
         lblNombreCliente.BackColor = Color.Transparent;
         lblNombreCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         lblNombreCliente.ForeColor = Color.White;
         lblNombreCliente.Location = new Point(30, 99);
         lblNombreCliente.Name = "lblNombreCliente";
         lblNombreCliente.Size = new Size(197, 21);
         lblNombreCliente.TabIndex = 3;
         lblNombreCliente.Text = "Ingrese su Identificación";
         // 
         // lblMensajeLogin
         // 
         lblMensajeLogin.AutoSize = true;
         lblMensajeLogin.BackColor = Color.Transparent;
         lblMensajeLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         lblMensajeLogin.ForeColor = Color.Transparent;
         lblMensajeLogin.Location = new Point(65, 149);
         lblMensajeLogin.Name = "lblMensajeLogin";
         lblMensajeLogin.Size = new Size(86, 21);
         lblMensajeLogin.TabIndex = 4;
         lblMensajeLogin.Text = "Resultado";
         // 
         // btnValidarCliente
         // 
         btnValidarCliente.BackColor = Color.Teal;
         btnValidarCliente.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnValidarCliente.ForeColor = Color.White;
         btnValidarCliente.Location = new Point(248, 99);
         btnValidarCliente.Name = "btnValidarCliente";
         btnValidarCliente.Size = new Size(75, 31);
         btnValidarCliente.TabIndex = 5;
         btnValidarCliente.Text = "Validar";
         btnValidarCliente.UseVisualStyleBackColor = false;
         btnValidarCliente.Click += btnValidarCliente_Click;
         // 
         // label3
         // 
         label3.AutoSize = true;
         label3.BackColor = Color.Transparent;
         label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label3.ForeColor = Color.White;
         label3.Location = new Point(269, 40);
         label3.Name = "label3";
         label3.Size = new Size(144, 30);
         label3.TabIndex = 6;
         label3.Text = "Iniciar Sesion";
         // 
         // FormMenuPrincipal
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         AutoSize = true;
         BackgroundImage = Properties.Resources.ServidorCliente;
         BackgroundImageLayout = ImageLayout.Stretch;
         ClientSize = new Size(605, 301);
         Controls.Add(label3);
         Controls.Add(btnValidarCliente);
         Controls.Add(lblMensajeLogin);
         Controls.Add(lblNombreCliente);
         Controls.Add(txtIdCliente);
         Controls.Add(lblEstadoConexion);
         Controls.Add(menuStrip1);
         Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
         MainMenuStrip = menuStrip1;
         Name = "FormMenuPrincipal";
         Text = "Menu Principal";
         menuStrip1.ResumeLayout(false);
         menuStrip1.PerformLayout();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private MenuStrip menuStrip1;
      private ToolStripMenuItem archivoToolStripMenuItem;
      private ToolStripMenuItem gestiónToolStripMenuItem;
      private ToolStripMenuItem tToolStripMenuItem;
      private ToolStripMenuItem articuloToolStripMenuItem;
      private Label lblEstadoConexion;
      private ToolStripMenuItem conectarAlServidorToolStripMenuItem;
      private ToolStripMenuItem probarConexiónToolStripMenuItem;
      private ToolStripMenuItem salirToolStripMenuItem;
      private ToolStripMenuItem clientesToolStripMenuItem;
      private ToolStripMenuItem repartidoresToolStripMenuItem;
      private ToolStripMenuItem pedidosToolStripMenuItem;
      private ToolStripMenuItem probarConexionToolStripMenuItem;
      private TextBox txtIdCliente;
      private Label lblNombreCliente;
      private Label lblMensajeLogin;
      private Button btnValidarCliente;
      private Label label3;
   }
}