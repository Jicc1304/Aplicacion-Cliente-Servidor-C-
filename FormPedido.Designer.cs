using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AplicacionCliente
{
   partial class FormPedido
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
         cmbIdCliente = new ComboBox();
         cmbIdRepartidor = new ComboBox();
         dtpFechaPedido = new DateTimePicker();
         txtDireccionPedido = new TextBox();
         label1 = new Label();
         label2 = new Label();
         label3 = new Label();
         Dirección = new Label();
         btnRegistrar = new Button();
         btnRegresar = new Button();
         btnConsultar = new Button();
         btnSalir = new Button();
         dgvConsultarPedidos = new DataGridView();
         btnSiguiente = new Button();
         ((System.ComponentModel.ISupportInitialize)dgvConsultarPedidos).BeginInit();
         SuspendLayout();
         // 
         // cmbIdCliente
         // 
         cmbIdCliente.FormattingEnabled = true;
         cmbIdCliente.Location = new Point(132, 63);
         cmbIdCliente.Name = "cmbIdCliente";
         cmbIdCliente.Size = new Size(121, 23);
         cmbIdCliente.TabIndex = 0;
         // 
         // cmbIdRepartidor
         // 
         cmbIdRepartidor.FormattingEnabled = true;
         cmbIdRepartidor.Location = new Point(132, 98);
         cmbIdRepartidor.Name = "cmbIdRepartidor";
         cmbIdRepartidor.Size = new Size(121, 23);
         cmbIdRepartidor.TabIndex = 1;
         // 
         // dtpFechaPedido
         // 
         dtpFechaPedido.CalendarForeColor = Color.Black;
         dtpFechaPedido.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         dtpFechaPedido.Format = DateTimePickerFormat.Short;
         dtpFechaPedido.Location = new Point(132, 130);
         dtpFechaPedido.Name = "dtpFechaPedido";
         dtpFechaPedido.Size = new Size(200, 29);
         dtpFechaPedido.TabIndex = 2;
         // 
         // txtDireccionPedido
         // 
         txtDireccionPedido.Location = new Point(132, 177);
         txtDireccionPedido.Name = "txtDireccionPedido";
         txtDireccionPedido.Size = new Size(471, 23);
         txtDireccionPedido.TabIndex = 3;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.BackColor = Color.Transparent;
         label1.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label1.ForeColor = Color.White;
         label1.Location = new Point(12, 63);
         label1.Name = "label1";
         label1.Size = new Size(72, 21);
         label1.TabIndex = 4;
         label1.Text = "Cliente: ";
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.BackColor = Color.Transparent;
         label2.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label2.ForeColor = Color.White;
         label2.Location = new Point(12, 98);
         label2.Name = "label2";
         label2.Size = new Size(100, 21);
         label2.TabIndex = 5;
         label2.Text = "Repartidor: ";
         // 
         // label3
         // 
         label3.AutoSize = true;
         label3.BackColor = Color.Transparent;
         label3.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label3.ForeColor = Color.White;
         label3.Location = new Point(10, 130);
         label3.Name = "label3";
         label3.Size = new Size(120, 21);
         label3.TabIndex = 6;
         label3.Text = "Fecha Pedido: ";
         // 
         // Dirección
         // 
         Dirección.AutoSize = true;
         Dirección.BackColor = Color.Transparent;
         Dirección.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         Dirección.ForeColor = Color.Transparent;
         Dirección.Location = new Point(12, 179);
         Dirección.Name = "Dirección";
         Dirección.Size = new Size(91, 21);
         Dirección.TabIndex = 7;
         Dirección.Text = "Dirección: ";
         // 
         // btnRegistrar
         // 
         btnRegistrar.BackColor = Color.RoyalBlue;
         btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegistrar.ForeColor = Color.White;
         btnRegistrar.Location = new Point(276, 12);
         btnRegistrar.Name = "btnRegistrar";
         btnRegistrar.Size = new Size(91, 38);
         btnRegistrar.TabIndex = 8;
         btnRegistrar.Text = "Registrar";
         btnRegistrar.UseVisualStyleBackColor = false;
         btnRegistrar.Click += btnRegistrar_Click;
         // 
         // btnRegresar
         // 
         btnRegresar.BackColor = Color.SlateBlue;
         btnRegresar.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegresar.ForeColor = Color.White;
         btnRegresar.Location = new Point(394, 14);
         btnRegresar.Name = "btnRegresar";
         btnRegresar.Size = new Size(98, 36);
         btnRegresar.TabIndex = 9;
         btnRegresar.Text = "Regresar";
         btnRegresar.UseVisualStyleBackColor = false;
         btnRegresar.Click += btnRegresar_Click;
         // 
         // btnConsultar
         // 
         btnConsultar.BackColor = Color.DeepSkyBlue;
         btnConsultar.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnConsultar.ForeColor = Color.White;
         btnConsultar.Location = new Point(276, 217);
         btnConsultar.Name = "btnConsultar";
         btnConsultar.Size = new Size(91, 41);
         btnConsultar.TabIndex = 10;
         btnConsultar.Text = "Consultar";
         btnConsultar.UseVisualStyleBackColor = false;
         btnConsultar.Click += btnConsultar_Click;
         // 
         // btnSalir
         // 
         btnSalir.BackColor = Color.FromArgb(255, 128, 128);
         btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnSalir.ForeColor = Color.White;
         btnSalir.Location = new Point(582, 307);
         btnSalir.Name = "btnSalir";
         btnSalir.Size = new Size(93, 28);
         btnSalir.TabIndex = 11;
         btnSalir.Text = "Salir";
         btnSalir.UseVisualStyleBackColor = false;
         btnSalir.Click += btnSalir_Click;
         // 
         // dgvConsultarPedidos
         // 
         dgvConsultarPedidos.BackgroundColor = Color.White;
         dgvConsultarPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dgvConsultarPedidos.Location = new Point(12, 264);
         dgvConsultarPedidos.Name = "dgvConsultarPedidos";
         dgvConsultarPedidos.Size = new Size(559, 100);
         dgvConsultarPedidos.TabIndex = 12;
         // 
         // btnSiguiente
         // 
         btnSiguiente.BackColor = Color.FromArgb(0, 192, 192);
         btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnSiguiente.ForeColor = Color.White;
         btnSiguiente.Location = new Point(582, 255);
         btnSiguiente.Name = "btnSiguiente";
         btnSiguiente.Size = new Size(93, 31);
         btnSiguiente.TabIndex = 14;
         btnSiguiente.Text = "Siguiente";
         btnSiguiente.UseVisualStyleBackColor = false;
         btnSiguiente.Click += btnSiguiente_Click;
         // 
         // FormPedido
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackgroundImage = Properties.Resources.ServidorCliente;
         BackgroundImageLayout = ImageLayout.Stretch;
         ClientSize = new Size(687, 376);
         Controls.Add(btnSiguiente);
         Controls.Add(dgvConsultarPedidos);
         Controls.Add(btnSalir);
         Controls.Add(btnConsultar);
         Controls.Add(btnRegresar);
         Controls.Add(btnRegistrar);
         Controls.Add(Dirección);
         Controls.Add(label3);
         Controls.Add(label2);
         Controls.Add(label1);
         Controls.Add(txtDireccionPedido);
         Controls.Add(dtpFechaPedido);
         Controls.Add(cmbIdRepartidor);
         Controls.Add(cmbIdCliente);
         Name = "FormPedido";
         Text = "Registrar Pedidos";
         ((System.ComponentModel.ISupportInitialize)dgvConsultarPedidos).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private ComboBox cmbIdCliente;
      private ComboBox cmbIdRepartidor;
      private DateTimePicker dtpFechaPedido;
      private TextBox txtDireccionPedido;
      private Label label1;
      private Label label2;
      private Label label3;
      private Label Dirección;
      private Button btnRegistrar;
      private Button btnRegresar;
      private Button btnConsultar;
      private Button btnSalir;
      private DataGridView dgvConsultarPedidos;
      private Button btnSiguiente;
   }
}