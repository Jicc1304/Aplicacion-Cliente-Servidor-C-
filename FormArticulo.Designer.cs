namespace AplicacionCliente
{
   partial class FormArticulo
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
         txtIdArticulo = new TextBox();
         txtNombreArticulo = new TextBox();
         txtValorArticulo = new TextBox();
         txtInventario = new TextBox();
         cmbTipoArticulo = new ComboBox();
         cmbEstado = new ComboBox();
         label1 = new Label();
         label2 = new Label();
         label3 = new Label();
         label4 = new Label();
         label5 = new Label();
         dgvConsultas = new DataGridView();
         btnRegistrar = new Button();
         btnRegresar = new Button();
         btnSalir = new Button();
         btnConsultar = new Button();
         label6 = new Label();
         ((System.ComponentModel.ISupportInitialize)dgvConsultas).BeginInit();
         SuspendLayout();
         // 
         // txtIdArticulo
         // 
         txtIdArticulo.Location = new Point(25, 22);
         txtIdArticulo.Name = "txtIdArticulo";
         txtIdArticulo.Size = new Size(105, 23);
         txtIdArticulo.TabIndex = 0;
         // 
         // txtNombreArticulo
         // 
         txtNombreArticulo.Location = new Point(25, 78);
         txtNombreArticulo.Name = "txtNombreArticulo";
         txtNombreArticulo.Size = new Size(105, 23);
         txtNombreArticulo.TabIndex = 1;
         // 
         // txtValorArticulo
         // 
         txtValorArticulo.Location = new Point(305, 22);
         txtValorArticulo.Name = "txtValorArticulo";
         txtValorArticulo.Size = new Size(100, 23);
         txtValorArticulo.TabIndex = 2;
         // 
         // txtInventario
         // 
         txtInventario.Location = new Point(433, 22);
         txtInventario.Name = "txtInventario";
         txtInventario.Size = new Size(100, 23);
         txtInventario.TabIndex = 3;
         // 
         // cmbTipoArticulo
         // 
         cmbTipoArticulo.FormattingEnabled = true;
         cmbTipoArticulo.Location = new Point(159, 22);
         cmbTipoArticulo.Name = "cmbTipoArticulo";
         cmbTipoArticulo.Size = new Size(121, 23);
         cmbTipoArticulo.TabIndex = 4;
         // 
         // cmbEstado
         // 
         cmbEstado.FormattingEnabled = true;
         cmbEstado.Location = new Point(571, 22);
         cmbEstado.Name = "cmbEstado";
         cmbEstado.Size = new Size(121, 23);
         cmbEstado.TabIndex = 5;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.BackColor = Color.Transparent;
         label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label1.ForeColor = Color.White;
         label1.Location = new Point(12, 48);
         label1.Name = "label1";
         label1.Size = new Size(118, 21);
         label1.TabIndex = 6;
         label1.Text = "ID del articulo";
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.BackColor = Color.Transparent;
         label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label2.ForeColor = Color.White;
         label2.Location = new Point(12, 104);
         label2.Name = "label2";
         label2.Size = new Size(164, 21);
         label2.TabIndex = 7;
         label2.Text = "Nombre del articulo";
         // 
         // label3
         // 
         label3.AutoSize = true;
         label3.BackColor = Color.Transparent;
         label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label3.ForeColor = Color.White;
         label3.Location = new Point(159, 55);
         label3.Name = "label3";
         label3.Size = new Size(130, 21);
         label3.TabIndex = 8;
         label3.Text = "Tipo de artículo";
         // 
         // label4
         // 
         label4.AutoSize = true;
         label4.BackColor = Color.Transparent;
         label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label4.ForeColor = Color.White;
         label4.Location = new Point(325, 54);
         label4.Name = "label4";
         label4.Size = new Size(54, 21);
         label4.TabIndex = 9;
         label4.Text = "Valor ";
         // 
         // label5
         // 
         label5.AutoSize = true;
         label5.BackColor = Color.Transparent;
         label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label5.ForeColor = Color.White;
         label5.Location = new Point(442, 55);
         label5.Name = "label5";
         label5.Size = new Size(79, 21);
         label5.TabIndex = 10;
         label5.Text = "Cantidad";
         // 
         // dgvConsultas
         // 
         dgvConsultas.BackgroundColor = Color.White;
         dgvConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dgvConsultas.Location = new Point(40, 187);
         dgvConsultas.Name = "dgvConsultas";
         dgvConsultas.Size = new Size(719, 100);
         dgvConsultas.TabIndex = 11;
         // 
         // btnRegistrar
         // 
         btnRegistrar.BackColor = Color.RoyalBlue;
         btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegistrar.ForeColor = Color.White;
         btnRegistrar.Location = new Point(258, 139);
         btnRegistrar.Name = "btnRegistrar";
         btnRegistrar.Size = new Size(89, 33);
         btnRegistrar.TabIndex = 12;
         btnRegistrar.Text = "Registrar";
         btnRegistrar.UseVisualStyleBackColor = false;
         btnRegistrar.Click += btnRegistrar_Click;
         // 
         // btnRegresar
         // 
         btnRegresar.BackColor = Color.CornflowerBlue;
         btnRegresar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegresar.ForeColor = Color.White;
         btnRegresar.Location = new Point(371, 139);
         btnRegresar.Name = "btnRegresar";
         btnRegresar.Size = new Size(91, 33);
         btnRegresar.TabIndex = 13;
         btnRegresar.Text = "Regresar";
         btnRegresar.UseVisualStyleBackColor = false;
         btnRegresar.Click += btnRegresar_Click;
         // 
         // btnSalir
         // 
         btnSalir.BackColor = Color.FromArgb(255, 128, 128);
         btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnSalir.ForeColor = Color.White;
         btnSalir.Location = new Point(707, 311);
         btnSalir.Name = "btnSalir";
         btnSalir.Size = new Size(81, 33);
         btnSalir.TabIndex = 14;
         btnSalir.Text = "Salir";
         btnSalir.UseVisualStyleBackColor = false;
         btnSalir.Click += btnSalir_Click;
         // 
         // btnConsultar
         // 
         btnConsultar.BackColor = Color.DeepSkyBlue;
         btnConsultar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnConsultar.ForeColor = Color.White;
         btnConsultar.Location = new Point(325, 293);
         btnConsultar.Name = "btnConsultar";
         btnConsultar.Size = new Size(112, 33);
         btnConsultar.TabIndex = 15;
         btnConsultar.Text = "Consultar";
         btnConsultar.UseVisualStyleBackColor = false;
         btnConsultar.Click += btnConsultar_Click;
         // 
         // label6
         // 
         label6.AutoSize = true;
         label6.BackColor = Color.Transparent;
         label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label6.ForeColor = Color.White;
         label6.Location = new Point(605, 55);
         label6.Name = "label6";
         label6.Size = new Size(61, 21);
         label6.TabIndex = 16;
         label6.Text = "Estado";
         // 
         // FormArticulo
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackgroundImage = Properties.Resources.ServidorCliente;
         BackgroundImageLayout = ImageLayout.Stretch;
         ClientSize = new Size(800, 450);
         Controls.Add(label6);
         Controls.Add(btnConsultar);
         Controls.Add(btnSalir);
         Controls.Add(btnRegresar);
         Controls.Add(btnRegistrar);
         Controls.Add(dgvConsultas);
         Controls.Add(label5);
         Controls.Add(label4);
         Controls.Add(label3);
         Controls.Add(label2);
         Controls.Add(label1);
         Controls.Add(cmbEstado);
         Controls.Add(cmbTipoArticulo);
         Controls.Add(txtInventario);
         Controls.Add(txtValorArticulo);
         Controls.Add(txtNombreArticulo);
         Controls.Add(txtIdArticulo);
         Name = "FormArticulo";
         Text = "Articulos";
         Load += FormArticulo_Load_1;
         Click += btnRegistrar_Click;
         ((System.ComponentModel.ISupportInitialize)dgvConsultas).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private TextBox txtIdArticulo;
      private TextBox txtNombreArticulo;
      private TextBox txtValorArticulo;
      private TextBox txtInventario;
      private ComboBox cmbTipoArticulo;
      private ComboBox cmbEstado;
      private Label label1;
      private Label label2;
      private Label label3;
      private Label label4;
      private Label label5;
      private DataGridView dgvConsultas;
      private Button btnRegistrar;
      private Button btnRegresar;
      private Button btnSalir;
      private Button btnConsultar;
      private Label label6;
   }
}