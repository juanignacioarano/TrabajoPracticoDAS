namespace GUI
{
    partial class Menu
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
            this.btnGestionTurno = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnGestionMedico = new System.Windows.Forms.Button();
            this.btnGestionEspecialidad = new System.Windows.Forms.Button();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.scSQLSERVER = new System.ServiceProcess.ServiceController();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGestionTurno
            // 
            this.btnGestionTurno.Location = new System.Drawing.Point(12, 68);
            this.btnGestionTurno.Name = "btnGestionTurno";
            this.btnGestionTurno.Size = new System.Drawing.Size(230, 133);
            this.btnGestionTurno.TabIndex = 0;
            this.btnGestionTurno.Text = "GESTION TURNOS";
            this.btnGestionTurno.UseVisualStyleBackColor = true;
            this.btnGestionTurno.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(556, 68);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(230, 133);
            this.btnUsuarios.TabIndex = 1;
            this.btnUsuarios.Text = "GESTION USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Location = new System.Drawing.Point(287, 68);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(230, 133);
            this.btnPacientes.TabIndex = 2;
            this.btnPacientes.Text = "GESTION PACIENTES";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnGestionMedico
            // 
            this.btnGestionMedico.Location = new System.Drawing.Point(12, 207);
            this.btnGestionMedico.Name = "btnGestionMedico";
            this.btnGestionMedico.Size = new System.Drawing.Size(230, 133);
            this.btnGestionMedico.TabIndex = 3;
            this.btnGestionMedico.Text = "GESTION MEDICOS";
            this.btnGestionMedico.UseVisualStyleBackColor = true;
            this.btnGestionMedico.Click += new System.EventHandler(this.btnGestionMedico_Click);
            // 
            // btnGestionEspecialidad
            // 
            this.btnGestionEspecialidad.Location = new System.Drawing.Point(556, 207);
            this.btnGestionEspecialidad.Name = "btnGestionEspecialidad";
            this.btnGestionEspecialidad.Size = new System.Drawing.Size(230, 133);
            this.btnGestionEspecialidad.TabIndex = 4;
            this.btnGestionEspecialidad.Text = "GESTION ESPECIALIDADES";
            this.btnGestionEspecialidad.UseVisualStyleBackColor = true;
            this.btnGestionEspecialidad.Click += new System.EventHandler(this.btnGestionEspecialidad_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Controls.Add(this.label1);
            this.panelContenedor.Controls.Add(this.btnGestionEspecialidad);
            this.panelContenedor.Controls.Add(this.btnGestionMedico);
            this.panelContenedor.Controls.Add(this.btnPacientes);
            this.panelContenedor.Controls.Add(this.btnUsuarios);
            this.panelContenedor.Controls.Add(this.btnGestionTurno);
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(800, 450);
            this.panelContenedor.TabIndex = 6;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "Menú Principal";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 449);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionTurno;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnGestionMedico;
        private System.Windows.Forms.Button btnGestionEspecialidad;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Label label1;
        private System.ServiceProcess.ServiceController scSQLSERVER;
    }
}