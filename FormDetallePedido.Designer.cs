namespace AplicacionCliente
{
   partial class FormDetallePedido
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
         cmbArticulos = new ComboBox();
         txtCantidad = new TextBox();
         dgvConsultas = new DataGridView();
         btnRegistrar = new Button();
         btnConsultar = new Button();
         btnSalir = new Button();
         btnRegresar = new Button();
         label2 = new Label();
         label3 = new Label();
         label4 = new Label();
         label5 = new Label();
         btnAgregarArticulo = new Button();
         dgvDetalleTemporal = new DataGridView();
         label1 = new Label();
         ((System.ComponentModel.ISupportInitialize)dgvConsultas).BeginInit();
         ((System.ComponentModel.ISupportInitialize)dgvDetalleTemporal).BeginInit();
         SuspendLayout();
         // 
         // cmbArticulos
         // 
         cmbArticulos.BackColor = SystemColors.InactiveCaption;
         cmbArticulos.FormattingEnabled = true;
         cmbArticulos.Location = new Point(28, 80);
         cmbArticulos.Name = "cmbArticulos";
         cmbArticulos.Size = new Size(121, 23);
         cmbArticulos.TabIndex = 1;
         // 
         // txtCantidad
         // 
         txtCantidad.BackColor = SystemColors.InactiveCaption;
         txtCantidad.Location = new Point(28, 131);
         txtCantidad.Name = "txtCantidad";
         txtCantidad.Size = new Size(121, 23);
         txtCantidad.TabIndex = 2;
         // 
         // dgvConsultas
         // 
         dgvConsultas.BackgroundColor = SystemColors.ButtonFace;
         dgvConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dgvConsultas.Location = new Point(3, 263);
         dgvConsultas.Name = "dgvConsultas";
         dgvConsultas.Size = new Size(776, 93);
         dgvConsultas.TabIndex = 3;
         // 
         // btnRegistrar
         // 
         btnRegistrar.BackColor = Color.RoyalBlue;
         btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegistrar.ForeColor = Color.White;
         btnRegistrar.Location = new Point(12, 383);
         btnRegistrar.Name = "btnRegistrar";
         btnRegistrar.Size = new Size(87, 38);
         btnRegistrar.TabIndex = 5;
         btnRegistrar.Text = "Registrar";
         btnRegistrar.UseVisualStyleBackColor = false;
         btnRegistrar.Click += btnRegistrar_Click;
         // 
         // btnConsultar
         // 
         btnConsultar.BackColor = Color.IndianRed;
         btnConsultar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnConsultar.ForeColor = Color.White;
         btnConsultar.Location = new Point(352, 222);
         btnConsultar.Name = "btnConsultar";
         btnConsultar.Size = new Size(101, 35);
         btnConsultar.TabIndex = 6;
         btnConsultar.Text = "Consultar";
         btnConsultar.UseVisualStyleBackColor = false;
         btnConsultar.Click += btnConsultar_Click;
         // 
         // btnSalir
         // 
         btnSalir.BackColor = Color.FromArgb(255, 128, 128);
         btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnSalir.ForeColor = Color.White;
         btnSalir.Location = new Point(704, 383);
         btnSalir.Name = "btnSalir";
         btnSalir.Size = new Size(75, 40);
         btnSalir.TabIndex = 7;
         btnSalir.Text = "Salir";
         btnSalir.UseVisualStyleBackColor = false;
         btnSalir.Click += btnSalir_Click;
         // 
         // btnRegresar
         // 
         btnRegresar.BackColor = Color.LightSteelBlue;
         btnRegresar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegresar.ForeColor = Color.White;
         btnRegresar.Location = new Point(123, 383);
         btnRegresar.Name = "btnRegresar";
         btnRegresar.Size = new Size(89, 40);
         btnRegresar.TabIndex = 8;
         btnRegresar.Text = "Regresar";
         btnRegresar.UseVisualStyleBackColor = false;
         btnRegresar.Click += btnRegresar_Click;
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.BackColor = Color.Transparent;
         label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label2.ForeColor = Color.White;
         label2.Location = new Point(28, 56);
         label2.Name = "label2";
         label2.Size = new Size(71, 21);
         label2.TabIndex = 10;
         label2.Text = "Articulo";
         // 
         // label3
         // 
         label3.AutoSize = true;
         label3.BackColor = Color.Transparent;
         label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label3.ForeColor = Color.White;
         label3.Location = new Point(28, 106);
         label3.Name = "label3";
         label3.Size = new Size(79, 21);
         label3.TabIndex = 11;
         label3.Text = "Cantidad";
         // 
         // label4
         // 
         label4.AutoSize = true;
         label4.BackColor = Color.Transparent;
         label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label4.ForeColor = Color.White;
         label4.Location = new Point(314, 355);
         label4.Name = "label4";
         label4.Size = new Size(181, 25);
         label4.TabIndex = 12;
         label4.Text = "Detalles del pedido";
         // 
         // label5
         // 
         label5.AutoSize = true;
         label5.BackColor = Color.Transparent;
         label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label5.ForeColor = Color.White;
         label5.Location = new Point(206, 9);
         label5.Name = "label5";
         label5.Size = new Size(380, 25);
         label5.TabIndex = 13;
         label5.Text = "Seleccione los datos de detalle del pedido";
         // 
         // btnAgregarArticulo
         // 
         btnAgregarArticulo.BackColor = Color.RoyalBlue;
         btnAgregarArticulo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnAgregarArticulo.ForeColor = Color.White;
         btnAgregarArticulo.Location = new Point(173, 79);
         btnAgregarArticulo.Name = "btnAgregarArticulo";
         btnAgregarArticulo.Size = new Size(108, 75);
         btnAgregarArticulo.TabIndex = 14;
         btnAgregarArticulo.Text = "Agregar Articulo";
         btnAgregarArticulo.UseVisualStyleBackColor = false;
         btnAgregarArticulo.Click += btnAgregarArticulo_Click;
         // 
         // dgvDetalleTemporal
         // 
         dgvDetalleTemporal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dgvDetalleTemporal.Location = new Point(305, 79);
         dgvDetalleTemporal.Name = "dgvDetalleTemporal";
         dgvDetalleTemporal.Size = new Size(446, 95);
         dgvDetalleTemporal.TabIndex = 15;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.BackColor = Color.Transparent;
         label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label1.ForeColor = Color.White;
         label1.Location = new Point(434, 55);
         label1.Name = "label1";
         label1.Size = new Size(164, 21);
         label1.TabIndex = 16;
         label1.Text = "Articulos Agregados";
         // 
         // FormDetallePedido
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackgroundImage = Properties.Resources.ServidorCliente;
         BackgroundImageLayout = ImageLayout.Stretch;
         ClientSize = new Size(800, 450);
         Controls.Add(label1);
         Controls.Add(dgvDetalleTemporal);
         Controls.Add(btnAgregarArticulo);
         Controls.Add(label5);
         Controls.Add(label4);
         Controls.Add(label3);
         Controls.Add(label2);
         Controls.Add(btnRegresar);
         Controls.Add(btnSalir);
         Controls.Add(btnConsultar);
         Controls.Add(btnRegistrar);
         Controls.Add(dgvConsultas);
         Controls.Add(txtCantidad);
         Controls.Add(cmbArticulos);
         Name = "FormDetallePedido";
         Text = "Detalle Pedidos";
         ((System.ComponentModel.ISupportInitialize)dgvConsultas).EndInit();
         ((System.ComponentModel.ISupportInitialize)dgvDetalleTemporal).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion
      private ComboBox cmbArticulos;
      private TextBox txtCantidad;
      private DataGridView dgvConsultas;
      private Button btnRegistrar;
      private Button btnConsultar;
      private Button btnSalir;
      private Button btnRegresar;
      private Label label2;
      private Label label3;
      private Label label4;
      private Label label5;
      private Button btnAgregarArticulo;
      private DataGridView dgvDetalleTemporal;
      private Label label1;
   }
}
