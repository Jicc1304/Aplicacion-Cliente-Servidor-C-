namespace AplicacionServidor
{
   partial class FormServidor: System.Windows.Forms.Form
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
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
      ///  Required method for Designer support - do not modify
      ///  the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         txtBitacora = new TextBox();
         lblClientes = new Label();
         menuStrip1 = new MenuStrip();
         servidorToolStripMenuItem = new ToolStripMenuItem();
         MenuIniciarServidor = new ToolStripMenuItem();
         MenuDetenerServidor = new ToolStripMenuItem();
         menuSalir = new ToolStripMenuItem();
         menuStrip1.SuspendLayout();
         SuspendLayout();
         // 
         // txtBitacora
         // 
         txtBitacora.BackColor = Color.White;
         txtBitacora.ForeColor = SystemColors.Desktop;
         txtBitacora.Location = new Point(21, 144);
         txtBitacora.Multiline = true;
         txtBitacora.Name = "txtBitacora";
         txtBitacora.ReadOnly = true;
         txtBitacora.ScrollBars = ScrollBars.Vertical;
         txtBitacora.Size = new Size(470, 40);
         txtBitacora.TabIndex = 0;
         // 
         // lblClientes
         // 
         lblClientes.AutoSize = true;
         lblClientes.BackColor = Color.Transparent;
         lblClientes.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         lblClientes.ForeColor = SystemColors.ButtonHighlight;
         lblClientes.Location = new Point(21, 104);
         lblClientes.Name = "lblClientes";
         lblClientes.Size = new Size(208, 25);
         lblClientes.TabIndex = 1;
         lblClientes.Text = "Clientes conectados: 0";
         // 
         // menuStrip1
         // 
         menuStrip1.Items.AddRange(new ToolStripItem[] { servidorToolStripMenuItem });
         menuStrip1.Location = new Point(0, 0);
         menuStrip1.Name = "menuStrip1";
         menuStrip1.Size = new Size(559, 24);
         menuStrip1.TabIndex = 2;
         menuStrip1.Text = "menuStrip1";
         // 
         // servidorToolStripMenuItem
         // 
         servidorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { MenuIniciarServidor, MenuDetenerServidor, menuSalir });
         servidorToolStripMenuItem.Name = "servidorToolStripMenuItem";
         servidorToolStripMenuItem.Size = new Size(62, 20);
         servidorToolStripMenuItem.Text = "Servidor";
         // 
         // MenuIniciarServidor
         // 
         MenuIniciarServidor.Name = "MenuIniciarServidor";
         MenuIniciarServidor.Size = new Size(161, 22);
         MenuIniciarServidor.Text = "Iniciar Servidor";
         MenuIniciarServidor.Click += menuIniciarServidor_Click;
         // 
         // MenuDetenerServidor
         // 
         MenuDetenerServidor.Name = "MenuDetenerServidor";
         MenuDetenerServidor.Size = new Size(161, 22);
         MenuDetenerServidor.Text = "Detener Servidor";
         MenuDetenerServidor.Click += menuDetenerServidor_Click;
         // 
         // menuSalir
         // 
         menuSalir.Name = "menuSalir";
         menuSalir.Size = new Size(161, 22);
         menuSalir.Text = "Salir";
         menuSalir.Click += menuSalir_Click;
         // 
         // FormServidor
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackColor = Color.White;
         BackgroundImage = Properties.Resources.ServidorCliente;
         BackgroundImageLayout = ImageLayout.Stretch;
         ClientSize = new Size(559, 322);
         Controls.Add(lblClientes);
         Controls.Add(txtBitacora);
         Controls.Add(menuStrip1);
         Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
         MainMenuStrip = menuStrip1;
         Name = "FormServidor";
         Text = "Servidor";
         Load += FormServidor_Load;
         menuStrip1.ResumeLayout(false);
         menuStrip1.PerformLayout();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private TextBox txtBitacora;
      private Label lblClientes;
      private MenuStrip menuStrip1;
      private ToolStripMenuItem servidorToolStripMenuItem;
      private ToolStripMenuItem MenuIniciarServidor;
      private ToolStripMenuItem MenuDetenerServidor;
      private ToolStripMenuItem menuSalir;
   }
}
