namespace AplicacionCliente
{
   partial class FormRepartidores
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
         txtId = new TextBox();
         txtNombre = new TextBox();
         txtApellido1 = new TextBox();
         txtApellido2 = new TextBox();
         dtpNacimiento = new DateTimePicker();
         dtpContratación = new DateTimePicker();
         cmbEstado = new ComboBox();
         dgvRepartidores = new DataGridView();
         btnRegistrar = new Button();
         btnRegresar = new Button();
         btnSalir = new Button();
         btnConsultar = new Button();
         label1 = new Label();
         label2 = new Label();
         label3 = new Label();
         label4 = new Label();
         label5 = new Label();
         label6 = new Label();
         label7 = new Label();
         ((System.ComponentModel.ISupportInitialize)dgvRepartidores).BeginInit();
         SuspendLayout();
         // 
         // txtId
         // 
         txtId.Location = new Point(12, 23);
         txtId.Name = "txtId";
         txtId.Size = new Size(100, 23);
         txtId.TabIndex = 0;
         // 
         // txtNombre
         // 
         txtNombre.Location = new Point(149, 23);
         txtNombre.Name = "txtNombre";
         txtNombre.Size = new Size(100, 23);
         txtNombre.TabIndex = 1;
         // 
         // txtApellido1
         // 
         txtApellido1.Location = new Point(328, 23);
         txtApellido1.Name = "txtApellido1";
         txtApellido1.Size = new Size(100, 23);
         txtApellido1.TabIndex = 2;
         // 
         // txtApellido2
         // 
         txtApellido2.Location = new Point(514, 23);
         txtApellido2.Name = "txtApellido2";
         txtApellido2.Size = new Size(100, 23);
         txtApellido2.TabIndex = 3;
         // 
         // dtpNacimiento
         // 
         dtpNacimiento.Location = new Point(12, 95);
         dtpNacimiento.Name = "dtpNacimiento";
         dtpNacimiento.Size = new Size(200, 23);
         dtpNacimiento.TabIndex = 4;
         // 
         // dtpContratación
         // 
         dtpContratación.Location = new Point(266, 95);
         dtpContratación.Name = "dtpContratación";
         dtpContratación.Size = new Size(200, 23);
         dtpContratación.TabIndex = 5;
         // 
         // cmbEstado
         // 
         cmbEstado.FormattingEnabled = true;
         cmbEstado.Location = new Point(517, 95);
         cmbEstado.Name = "cmbEstado";
         cmbEstado.Size = new Size(121, 23);
         cmbEstado.TabIndex = 6;
         // 
         // dgvRepartidores
         // 
         dgvRepartidores.BackgroundColor = Color.White;
         dgvRepartidores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dgvRepartidores.GridColor = Color.Black;
         dgvRepartidores.Location = new Point(12, 154);
         dgvRepartidores.Name = "dgvRepartidores";
         dgvRepartidores.Size = new Size(667, 97);
         dgvRepartidores.TabIndex = 7;
         // 
         // btnRegistrar
         // 
         btnRegistrar.BackColor = Color.CornflowerBlue;
         btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegistrar.ForeColor = Color.White;
         btnRegistrar.Location = new Point(42, 271);
         btnRegistrar.Name = "btnRegistrar";
         btnRegistrar.Size = new Size(95, 34);
         btnRegistrar.TabIndex = 8;
         btnRegistrar.Text = "Registrar";
         btnRegistrar.UseVisualStyleBackColor = false;
         btnRegistrar.Click += btnRegistrar_Click;
         // 
         // btnRegresar
         // 
         btnRegresar.BackColor = Color.LightSteelBlue;
         btnRegresar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegresar.ForeColor = Color.White;
         btnRegresar.Location = new Point(174, 272);
         btnRegresar.Name = "btnRegresar";
         btnRegresar.Size = new Size(87, 33);
         btnRegresar.TabIndex = 9;
         btnRegresar.Text = "Regresar";
         btnRegresar.UseVisualStyleBackColor = false;
         btnRegresar.Click += btnRegresar_Click;
         // 
         // btnSalir
         // 
         btnSalir.BackColor = Color.FromArgb(255, 128, 128);
         btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnSalir.ForeColor = Color.White;
         btnSalir.Location = new Point(685, 318);
         btnSalir.Name = "btnSalir";
         btnSalir.Size = new Size(103, 30);
         btnSalir.TabIndex = 10;
         btnSalir.Text = "Salir";
         btnSalir.UseVisualStyleBackColor = false;
         btnSalir.Click += btnSalir_Click;
         // 
         // btnConsultar
         // 
         btnConsultar.BackColor = SystemColors.ActiveCaption;
         btnConsultar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnConsultar.ForeColor = Color.White;
         btnConsultar.Location = new Point(685, 190);
         btnConsultar.Name = "btnConsultar";
         btnConsultar.Size = new Size(103, 36);
         btnConsultar.TabIndex = 11;
         btnConsultar.Text = "Consultar";
         btnConsultar.UseVisualStyleBackColor = false;
         btnConsultar.Click += btnConsultar_Click;
         // 
         // label1
         // 
         label1.AutoSize = true;
         label1.BackColor = Color.Transparent;
         label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label1.ForeColor = Color.White;
         label1.Location = new Point(21, 49);
         label1.Name = "label1";
         label1.Size = new Size(116, 21);
         label1.TabIndex = 12;
         label1.Text = "Identificación";
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.BackColor = Color.Transparent;
         label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label2.ForeColor = Color.White;
         label2.Location = new Point(174, 49);
         label2.Name = "label2";
         label2.Size = new Size(77, 21);
         label2.TabIndex = 13;
         label2.Text = "Nombre ";
         // 
         // label3
         // 
         label3.AutoSize = true;
         label3.BackColor = Color.Transparent;
         label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label3.ForeColor = Color.White;
         label3.Location = new Point(328, 49);
         label3.Name = "label3";
         label3.Size = new Size(130, 21);
         label3.TabIndex = 14;
         label3.Text = "Primer Apellido";
         // 
         // label4
         // 
         label4.AutoSize = true;
         label4.BackColor = Color.Transparent;
         label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label4.ForeColor = Color.White;
         label4.Location = new Point(507, 49);
         label4.Name = "label4";
         label4.Size = new Size(147, 21);
         label4.TabIndex = 15;
         label4.Text = "Segundo Apellido";
         // 
         // label5
         // 
         label5.AutoSize = true;
         label5.BackColor = Color.Transparent;
         label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label5.ForeColor = Color.White;
         label5.Location = new Point(288, 121);
         label5.Name = "label5";
         label5.Size = new Size(180, 21);
         label5.TabIndex = 16;
         label5.Text = "Fecha de Contratación";
         // 
         // label6
         // 
         label6.AutoSize = true;
         label6.BackColor = Color.Transparent;
         label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label6.ForeColor = Color.White;
         label6.Location = new Point(42, 121);
         label6.Name = "label6";
         label6.Size = new Size(171, 21);
         label6.TabIndex = 17;
         label6.Text = "Fecha de Nacimiento";
         // 
         // label7
         // 
         label7.AutoSize = true;
         label7.BackColor = Color.Transparent;
         label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label7.ForeColor = Color.White;
         label7.Location = new Point(555, 121);
         label7.Name = "label7";
         label7.Size = new Size(59, 21);
         label7.TabIndex = 18;
         label7.Text = "Activo";
         // 
         // FormRepartidores
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackgroundImage = Properties.Resources.ServidorCliente;
         BackgroundImageLayout = ImageLayout.Stretch;
         ClientSize = new Size(800, 450);
         Controls.Add(label7);
         Controls.Add(label6);
         Controls.Add(label5);
         Controls.Add(label4);
         Controls.Add(label3);
         Controls.Add(label2);
         Controls.Add(label1);
         Controls.Add(btnConsultar);
         Controls.Add(btnSalir);
         Controls.Add(btnRegresar);
         Controls.Add(btnRegistrar);
         Controls.Add(dgvRepartidores);
         Controls.Add(cmbEstado);
         Controls.Add(dtpContratación);
         Controls.Add(dtpNacimiento);
         Controls.Add(txtApellido2);
         Controls.Add(txtApellido1);
         Controls.Add(txtNombre);
         Controls.Add(txtId);
         Name = "FormRepartidores";
         Text = "Datos de Repartidores";
         ((System.ComponentModel.ISupportInitialize)dgvRepartidores).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private TextBox txtId;
      private TextBox txtNombre;
      private TextBox txtApellido1;
      private TextBox txtApellido2;
      private DateTimePicker dtpNacimiento;
      private DateTimePicker dtpContratación;
      private ComboBox cmbEstado;
      private DataGridView dgvRepartidores;
      private Button btnRegistrar;
      private Button btnRegresar;
      private Button btnSalir;
      private Button btnConsultar;
      private Label label1;
      private Label label2;
      private Label label3;
      private Label label4;
      private Label label5;
      private Label label6;
      private Label label7;
   }
}