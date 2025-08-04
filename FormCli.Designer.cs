namespace AplicacionCliente
{
   partial class FormCli
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
         txtIdCliente = new TextBox();
         txtNombre = new TextBox();
         txtPrimerApellido = new TextBox();
         txtSegundoApellido = new TextBox();
         dtpFechaNacimiento = new DateTimePicker();
         cmbEstado = new ComboBox();
         label1 = new Label();
         label2 = new Label();
         label3 = new Label();
         label4 = new Label();
         label5 = new Label();
         label6 = new Label();
         dataGridView1 = new DataGridView();
         btnRegistrar = new Button();
         btnRegresar = new Button();
         btnSalir = new Button();
         btnConsultar = new Button();
         label7 = new Label();
         ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
         SuspendLayout();
         // 
         // txtIdCliente
         // 
         txtIdCliente.Location = new Point(42, 62);
         txtIdCliente.Name = "txtIdCliente";
         txtIdCliente.Size = new Size(100, 23);
         txtIdCliente.TabIndex = 0;
         // 
         // txtNombre
         // 
         txtNombre.Location = new Point(42, 113);
         txtNombre.Name = "txtNombre";
         txtNombre.Size = new Size(100, 23);
         txtNombre.TabIndex = 1;
         // 
         // txtPrimerApellido
         // 
         txtPrimerApellido.Location = new Point(42, 167);
         txtPrimerApellido.Name = "txtPrimerApellido";
         txtPrimerApellido.Size = new Size(100, 23);
         txtPrimerApellido.TabIndex = 2;
         // 
         // txtSegundoApellido
         // 
         txtSegundoApellido.Location = new Point(40, 217);
         txtSegundoApellido.Name = "txtSegundoApellido";
         txtSegundoApellido.Size = new Size(147, 23);
         txtSegundoApellido.TabIndex = 3;
         // 
         // dtpFechaNacimiento
         // 
         dtpFechaNacimiento.Location = new Point(40, 269);
         dtpFechaNacimiento.Name = "dtpFechaNacimiento";
         dtpFechaNacimiento.Size = new Size(200, 23);
         dtpFechaNacimiento.TabIndex = 4;
         // 
         // cmbEstado
         // 
         cmbEstado.FormattingEnabled = true;
         cmbEstado.Location = new Point(40, 319);
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
         label1.Location = new Point(42, 33);
         label1.Name = "label1";
         label1.Size = new Size(113, 21);
         label1.TabIndex = 6;
         label1.Text = "ID del Cliente";
         // 
         // label2
         // 
         label2.AutoSize = true;
         label2.BackColor = Color.Transparent;
         label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label2.ForeColor = Color.White;
         label2.Location = new Point(41, 88);
         label2.Name = "label2";
         label2.Size = new Size(159, 21);
         label2.TabIndex = 7;
         label2.Text = "Nombre del Cliente";
         // 
         // label3
         // 
         label3.AutoSize = true;
         label3.BackColor = Color.Transparent;
         label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label3.ForeColor = Color.White;
         label3.Location = new Point(40, 143);
         label3.Name = "label3";
         label3.Size = new Size(130, 21);
         label3.TabIndex = 8;
         label3.Text = "Primer Apellido";
         // 
         // label4
         // 
         label4.AutoSize = true;
         label4.BackColor = Color.Transparent;
         label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label4.ForeColor = Color.White;
         label4.Location = new Point(40, 193);
         label4.Name = "label4";
         label4.Size = new Size(147, 21);
         label4.TabIndex = 9;
         label4.Text = "Segundo Apellido";
         // 
         // label5
         // 
         label5.AutoSize = true;
         label5.BackColor = Color.Transparent;
         label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label5.ForeColor = Color.White;
         label5.Location = new Point(49, 245);
         label5.Name = "label5";
         label5.Size = new Size(148, 21);
         label5.TabIndex = 10;
         label5.Text = "Fecha Nacimiento";
         // 
         // label6
         // 
         label6.AutoSize = true;
         label6.BackColor = Color.Transparent;
         label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label6.ForeColor = Color.White;
         label6.Location = new Point(72, 295);
         label6.Name = "label6";
         label6.Size = new Size(59, 21);
         label6.TabIndex = 11;
         label6.Text = "Activo";
         // 
         // dataGridView1
         // 
         dataGridView1.BackgroundColor = Color.White;
         dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         dataGridView1.Location = new Point(206, 72);
         dataGridView1.Name = "dataGridView1";
         dataGridView1.Size = new Size(528, 115);
         dataGridView1.TabIndex = 12;
         // 
         // btnRegistrar
         // 
         btnRegistrar.BackColor = Color.RoyalBlue;
         btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegistrar.ForeColor = Color.White;
         btnRegistrar.Location = new Point(58, 376);
         btnRegistrar.Name = "btnRegistrar";
         btnRegistrar.Size = new Size(103, 39);
         btnRegistrar.TabIndex = 13;
         btnRegistrar.Text = "Registrar";
         btnRegistrar.UseVisualStyleBackColor = false;
         btnRegistrar.Click += btnRegistrar_Click;
         // 
         // btnRegresar
         // 
         btnRegresar.BackColor = Color.CornflowerBlue;
         btnRegresar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnRegresar.ForeColor = Color.Transparent;
         btnRegresar.Location = new Point(185, 376);
         btnRegresar.Name = "btnRegresar";
         btnRegresar.Size = new Size(104, 39);
         btnRegresar.TabIndex = 14;
         btnRegresar.Text = "Regresar";
         btnRegresar.UseVisualStyleBackColor = false;
         btnRegresar.Click += btnRegresar_Click;
         // 
         // btnSalir
         // 
         btnSalir.BackColor = Color.FromArgb(255, 128, 128);
         btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnSalir.ForeColor = Color.White;
         btnSalir.Location = new Point(713, 382);
         btnSalir.Name = "btnSalir";
         btnSalir.Size = new Size(75, 33);
         btnSalir.TabIndex = 15;
         btnSalir.Text = "Salir";
         btnSalir.UseVisualStyleBackColor = false;
         btnSalir.Click += btnSalir_Click;
         // 
         // btnConsultar
         // 
         btnConsultar.BackColor = Color.CornflowerBlue;
         btnConsultar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         btnConsultar.ForeColor = Color.White;
         btnConsultar.Location = new Point(371, 193);
         btnConsultar.Name = "btnConsultar";
         btnConsultar.Size = new Size(110, 36);
         btnConsultar.TabIndex = 16;
         btnConsultar.Text = "Consultar";
         btnConsultar.UseVisualStyleBackColor = false;
         btnConsultar.Click += btnConsultar_Click;
         // 
         // label7
         // 
         label7.AutoSize = true;
         label7.BackColor = Color.Transparent;
         label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
         label7.ForeColor = Color.White;
         label7.Location = new Point(341, 33);
         label7.Name = "label7";
         label7.Size = new Size(198, 21);
         label7.TabIndex = 17;
         label7.Text = "Información de Consulta";
         // 
         // FormCli
         // 
         AutoScaleDimensions = new SizeF(7F, 15F);
         AutoScaleMode = AutoScaleMode.Font;
         BackgroundImage = Properties.Resources.ServidorCliente;
         BackgroundImageLayout = ImageLayout.Stretch;
         ClientSize = new Size(800, 450);
         Controls.Add(label7);
         Controls.Add(btnConsultar);
         Controls.Add(btnSalir);
         Controls.Add(btnRegresar);
         Controls.Add(btnRegistrar);
         Controls.Add(dataGridView1);
         Controls.Add(label6);
         Controls.Add(label5);
         Controls.Add(label4);
         Controls.Add(label3);
         Controls.Add(label2);
         Controls.Add(label1);
         Controls.Add(cmbEstado);
         Controls.Add(dtpFechaNacimiento);
         Controls.Add(txtSegundoApellido);
         Controls.Add(txtPrimerApellido);
         Controls.Add(txtNombre);
         Controls.Add(txtIdCliente);
         Name = "FormCli";
         Text = "FormCli";
         ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
         ResumeLayout(false);
         PerformLayout();
      }

      #endregion

      private TextBox txtIdCliente;
      private TextBox txtNombre;
      private TextBox txtPrimerApellido;
      private TextBox txtSegundoApellido;
      private DateTimePicker dtpFechaNacimiento;
      private ComboBox cmbEstado;
      private Label label1;
      private Label label2;
      private Label label3;
      private Label label4;
      private Label label5;
      private Label label6;
      private DataGridView dataGridView1;
      private Button btnRegistrar;
      private Button btnRegresar;
      private Button btnSalir;
      private Button btnConsultar;
      private Label label7;
   }
}