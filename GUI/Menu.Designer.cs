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
            this.btnUsuarios.Location = new System.Drawing.Point(541, 68);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(253, 133);
            this.btnUsuarios.TabIndex = 1;
            this.btnUsuarios.Text = "GESTION USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Location = new System.Drawing.Point(259, 68);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(265, 133);
            this.btnPacientes.TabIndex = 2;
            this.btnPacientes.Text = "GESTION PACIENTES";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnGestionMedico
            // 
            this.btnGestionMedico.Location = new System.Drawing.Point(45, 237);
            this.btnGestionMedico.Name = "btnGestionMedico";
            this.btnGestionMedico.Size = new System.Drawing.Size(268, 177);
            this.btnGestionMedico.TabIndex = 3;
            this.btnGestionMedico.Text = "GESTION MEDICOS";
            this.btnGestionMedico.UseVisualStyleBackColor = true;
            this.btnGestionMedico.Click += new System.EventHandler(this.btnGestionMedico_Click);
            // 
            // btnGestionEspecialidad
            // 
            this.btnGestionEspecialidad.Location = new System.Drawing.Point(454, 237);
            this.btnGestionEspecialidad.Name = "btnGestionEspecialidad";
            this.btnGestionEspecialidad.Size = new System.Drawing.Size(309, 180);
            this.btnGestionEspecialidad.TabIndex = 4;
            this.btnGestionEspecialidad.Text = "GESTION ESPECIALIDADES";
            this.btnGestionEspecialidad.UseVisualStyleBackColor = true;
            this.btnGestionEspecialidad.Click += new System.EventHandler(this.btnGestionEspecialidad_Click);
            // 
            // panelContenedor
            // 
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
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panelContenedor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionTurno;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnGestionMedico;
        private System.Windows.Forms.Button btnGestionEspecialidad;
        private System.Windows.Forms.Panel panelContenedor;
    }
}