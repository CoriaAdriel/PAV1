namespace Clase02
{
    partial class Usuarios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.btnRegistrarUsuario = new System.Windows.Forms.Button();
            this.txtRepetirContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.txtNombreDeUsuario = new System.Windows.Forms.TextBox();
            this.lblNombreDeUsuario = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gdrUsuarios = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contraseña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdrUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiarCampos);
            this.groupBox1.Controls.Add(this.btnRegistrarUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtContraseña);
            this.groupBox1.Controls.Add(this.lblContraseña);
            this.groupBox1.Controls.Add(this.txtNombreDeUsuario);
            this.groupBox1.Controls.Add(this.lblNombreDeUsuario);
            this.groupBox1.Controls.Add(this.txtRepetirContraseña);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 197);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Usuario";
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Location = new System.Drawing.Point(157, 135);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(70, 45);
            this.btnLimpiarCampos.TabIndex = 4;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // btnRegistrarUsuario
            // 
            this.btnRegistrarUsuario.Location = new System.Drawing.Point(233, 135);
            this.btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            this.btnRegistrarUsuario.Size = new System.Drawing.Size(70, 45);
            this.btnRegistrarUsuario.TabIndex = 3;
            this.btnRegistrarUsuario.Text = "Registrar Usuario";
            this.btnRegistrarUsuario.UseVisualStyleBackColor = true;
            this.btnRegistrarUsuario.Click += new System.EventHandler(this.btnRegistrarUsuario_Click);
            // 
            // txtRepetirContraseña
            // 
            this.txtRepetirContraseña.Location = new System.Drawing.Point(157, 97);
            this.txtRepetirContraseña.Name = "txtRepetirContraseña";
            this.txtRepetirContraseña.PasswordChar = '*';
            this.txtRepetirContraseña.Size = new System.Drawing.Size(151, 23);
            this.txtRepetirContraseña.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Repetir Contraseña";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(157, 68);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(151, 23);
            this.txtContraseña.TabIndex = 1;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(83, 71);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(70, 17);
            this.lblContraseña.TabIndex = 2;
            this.lblContraseña.Text = "Contraseña";
            // 
            // txtNombreDeUsuario
            // 
            this.txtNombreDeUsuario.Location = new System.Drawing.Point(157, 39);
            this.txtNombreDeUsuario.Name = "txtNombreDeUsuario";
            this.txtNombreDeUsuario.Size = new System.Drawing.Size(151, 23);
            this.txtNombreDeUsuario.TabIndex = 0;
            // 
            // lblNombreDeUsuario
            // 
            this.lblNombreDeUsuario.AutoSize = true;
            this.lblNombreDeUsuario.Location = new System.Drawing.Point(44, 42);
            this.lblNombreDeUsuario.Name = "lblNombreDeUsuario";
            this.lblNombreDeUsuario.Size = new System.Drawing.Size(109, 17);
            this.lblNombreDeUsuario.TabIndex = 0;
            this.lblNombreDeUsuario.Text = "Nombre de Usuario";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gdrUsuarios);
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 197);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Usuarios";
            // 
            // gdrUsuarios
            // 
            this.gdrUsuarios.AllowUserToAddRows = false;
            this.gdrUsuarios.AllowUserToDeleteRows = false;
            this.gdrUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdrUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Usuario,
            this.Contraseña});
            this.gdrUsuarios.Location = new System.Drawing.Point(6, 22);
            this.gdrUsuarios.Name = "gdrUsuarios";
            this.gdrUsuarios.ReadOnly = true;
            this.gdrUsuarios.Size = new System.Drawing.Size(367, 175);
            this.gdrUsuarios.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "IdUsuario";
            this.Id.FillWeight = 20F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Contraseña
            // 
            this.Contraseña.DataPropertyName = "Contraseña";
            this.Contraseña.HeaderText = "Contraseña";
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.ReadOnly = true;
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 436);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Usuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Usuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdrUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnRegistrarUsuario;
        private System.Windows.Forms.TextBox txtRepetirContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.TextBox txtNombreDeUsuario;
        private System.Windows.Forms.Label lblNombreDeUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gdrUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contraseña;
    }
}