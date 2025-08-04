namespace AplicacionCliente
{
   partial class FormTipoArticulo
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
         txtIdTipoArticulo = new TextBox();
         txtNombreTipoArticulo = new TextBox();
         txtDescripcionTipoArticulo = new TextBox();
         btnRegistrar = new Button();
         btnRegresar = new Button();
         btnSalir = new Button();
         btnConsultar = new Button();
         dgvConsultas = new DataGridView();
         label1 = new Label();
         label2 = new Label();
         label3 = new Label();
         btnProbarConexion = new Button();
         ((System.ComponentModel.ISupportInitialize)dgvConsultas).BeginInit();
         SuspendLayout();
         // 
         // txtIdTipoArticulo
         // 
         txtIdTipoArticulo.Location = new Point(34, 44);
         txtIdTipoArticulo.Name = "txtIdTipoArticulo";
         txtIdTipoArticulo.Size = new Size(100, 23);
         txtIdTipoArticulo.TabIndex = 0;
         // 
         // txtNombreTipoArticulo
         // 
         txtNombreTipoArticulo.Location = new Point(34, 100);
         txtNombreTipoArticulo.Name = "txtNombreTipoArticulo";
         txtNombreTipoArticulo.Size = new Size(100, 23);
         txtNombreTipoArticulo.TabIndex = 1;
         // 
         // txtDescripcionTipoArticulo
         // 
         txtDescripcionTipoArticulo.Location = new Point(34, 167);
         txtDescripcionTipoArticulo.Name = "txtDescripcionTipoArticulo";
         txtDescripcionTipoArticulo.Size = new Size(163, 23);
         txtDescripcionTipoArticulo.TabIndex = 2;
         // 
         // btnRegistrar
         // 
         btnRegistrar.BackColor = Color.RoyalBlue;
         btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegistrar.ForeColor = Color.White;
         btnRegistrar.Location = new Point(286, 20);
         btnRegistrar.Name = "btnRegistrar";
         btnRegistrar.Size = new Size(94, 39);
         btnRegistrar.TabIndex = 3;
         btnRegistrar.Text = "Registrar";
         btnRegistrar.UseVisualStyleBackColor = false;
         btnRegistrar.Click += btnRegistrar_Click;
         // 
         // btnRegresar
         // 
         btnRegresar.BackColor = Color.CornflowerBlue;
         btnRegresar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegresar.ForeColor = Color.White;
         btnRegresar.Location = new Point(34, 374);
         btnRegresar.Name = "btnRegresar";
         btnRegresar.Size = new Size(110, 39);
         btnRegresar.TabIndex = 4;
         btnRegresar.Text = "Regresar";
         btnRegresar.UseVisualStyleBackColor = false;
         btnRegresar.Click += btnRegresar_Click;
         // 
         // btnSalir
         // 
         btnSalir.BackColor = Color.FromArgb(255, 128, 128);
         btnSalir.Location = new Point(705, 125);
         btnSalir.Name = "btnSalir";
         btnSalir.Size = new Size(75, 23);
         btnSalir.TabIndex = 5;
         btnSalir.Text = "Salir";
         btnSalir.UseVisualStyleBackColor = false;
         btnSalir.Click += btnSalir_Click;
         // 
         // btnConsultar
         // 
         btnConsultar.BackColor = SystemColors.ActiveCaption;
         btnConsultar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnConsultar.ForeColor = Color.White;
         btnConsultar.Location = new Point(572, 257);
         btnConsultar.Name = "btnConsultar";
         btnConsultar.Size = new Size(93, 31);
         btnConsultar.TabIndex = 6;
         btnConsultar.Text = "Consultar";
         btnConsultar.UseVisualStyleBackColor = false;
         btnConsultar.Click += btnConsultar_Click;
         // 
         // dgvConsultas
         // 
         dgvConsultas.BackgroundColor = Color.White;
         dgvConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dgvConsultas.Location = new Point(34, 220);
         dgvConsultas.Name = "dgvConsultas";
         dgvConsultas.Size = new Size(519, 114);
         dgvConsultas.TabIndex = 7;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.BackColor = Color.Transparent;
         label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label1.ForeColor = Color.White;
         label1.Location = new Point(34, 20);
         label1.Name = "label1";
         label1.Size = new Size(148, 21);
         label1.TabIndex = 8;
         label1.Text = "ID tipo de artículo";
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.BackColor = Color.Transparent;
         label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label2.ForeColor = Color.White;
         label2.Location = new Point(34, 76);
         label2.Name = "label2";
         label2.Size = new Size(199, 21);
         label2.TabIndex = 9;
         label2.Text = "Nombre Tipo de Artículo";
         // 
         // label3
         // 
         label3.AutoSize = true;
         label3.BackColor = Color.Transparent;
         label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label3.ForeColor = Color.White;
         label3.Location = new Point(34, 139);
         label3.Name = "label3";
         label3.Size = new Size(226, 21);
         label3.TabIndex = 10;
         label3.Text = "Descripcion de Tipo Articulo";
         // 
         // btnProbarConexion
         // 
         btnProbarConexion.Location = new Point(705, 167);
         btnProbarConexion.Name = "btnProbarConexion";
         btnProbarConexion.Size = new Size(75, 45);
         btnProbarConexion.TabIndex = 11;
         btnProbarConexion.Text = "Probar Conexión";
         btnProbarConexion.UseVisualStyleBackColor = true;
         btnProbarConexion.Click += btnProbarConexion_Click;
         // 
         // FormTipoArticulo
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackgroundImage = Properties.Resources.ServidorCliente;
         BackgroundImageLayout = ImageLayout.Stretch;
         ClientSize = new Size(800, 450);
         Controls.Add(btnProbarConexion);
         Controls.Add(label3);
         Controls.Add(label2);
         Controls.Add(label1);
         Controls.Add(dgvConsultas);
         Controls.Add(btnConsultar);
         Controls.Add(btnSalir);
         Controls.Add(btnRegresar);
         Controls.Add(btnRegistrar);
         Controls.Add(txtDescripcionTipoArticulo);
         Controls.Add(txtNombreTipoArticulo);
         Controls.Add(txtIdTipoArticulo);
         Name = "FormTipoArticulo";
         Text = "FormTipoArticulo";
         ((System.ComponentModel.ISupportInitialize)dgvConsultas).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private TextBox txtIdTipoArticulo;
      private TextBox txtNombreTipoArticulo;
      private TextBox txtDescripcionTipoArticulo;
      private Button btnRegistrar;
      private Button btnRegresar;
      private Button btnSalir;
      private Button btnConsultar;
      private DataGridView dgvConsultas;
      private Label label1;
      private Label label2;
      private Label label3;
      private Button btnProbarConexion;
   }
}