namespace GUI
{
    partial class GestionEspecialidades
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreFiltro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.dgvEspecialidades = new System.Windows.Forms.DataGridView();
            this.btnAgregarMedico = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnXmlEspecialidades = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLimpiar.Location = new System.Drawing.Point(106, 212);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(157, 26);
            this.btnLimpiar.TabIndex = 118;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminar.Location = new System.Drawing.Point(106, 180);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(157, 26);
            this.btnEliminar.TabIndex = 117;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnModificar.Location = new System.Drawing.Point(106, 148);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(157, 26);
            this.btnModificar.TabIndex = 116;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(493, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 113;
            this.label10.Text = "Filtros";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "Nombre";
            // 
            // txtNombreFiltro
            // 
            this.txtNombreFiltro.Location = new System.Drawing.Point(463, 42);
            this.txtNombreFiltro.Name = "txtNombreFiltro";
            this.txtNombreFiltro.Size = new System.Drawing.Size(157, 20);
            this.txtNombreFiltro.TabIndex = 111;
            this.txtNombreFiltro.TextChanged += new System.EventHandler(this.txtNombreFiltro_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 110;
            this.label7.Text = "ID Selec";
            this.label7.Visible = false;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(107, 68);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(157, 20);
            this.txtId.TabIndex = 109;
            this.txtId.Visible = false;
            // 
            // dgvEspecialidades
            // 
            this.dgvEspecialidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidades.Location = new System.Drawing.Point(310, 71);
            this.dgvEspecialidades.Name = "dgvEspecialidades";
            this.dgvEspecialidades.Size = new System.Drawing.Size(462, 328);
            this.dgvEspecialidades.TabIndex = 108;
            // 
            // btnAgregarMedico
            // 
            this.btnAgregarMedico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAgregarMedico.Location = new System.Drawing.Point(107, 120);
            this.btnAgregarMedico.Name = "btnAgregarMedico";
            this.btnAgregarMedico.Size = new System.Drawing.Size(157, 26);
            this.btnAgregarMedico.TabIndex = 105;
            this.btnAgregarMedico.Text = "Agregar";
            this.btnAgregarMedico.UseVisualStyleBackColor = false;
            this.btnAgregarMedico.Click += new System.EventHandler(this.btnAgregarMedico_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(72, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 20);
            this.label5.TabIndex = 107;
            this.label5.Text = "Gestion de Especialidades";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 106;
            this.label1.Text = "Especialidad";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(107, 94);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(157, 20);
            this.txtNombre.TabIndex = 104;
            // 
            // btnXmlEspecialidades
            // 
            this.btnXmlEspecialidades.Location = new System.Drawing.Point(668, 21);
            this.btnXmlEspecialidades.Name = "btnXmlEspecialidades";
            this.btnXmlEspecialidades.Size = new System.Drawing.Size(107, 35);
            this.btnXmlEspecialidades.TabIndex = 119;
            this.btnXmlEspecialidades.Text = "Exportar XML";
            this.btnXmlEspecialidades.UseVisualStyleBackColor = true;
            this.btnXmlEspecialidades.Click += new System.EventHandler(this.btnXmlEspecialidades_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(9, 10);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(57, 21);
            this.btnMenu.TabIndex = 120;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // GestionEspecialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnXmlEspecialidades);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNombreFiltro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.dgvEspecialidades);
            this.Controls.Add(this.btnAgregarMedico);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Name = "GestionEspecialidades";
            this.Text = "GestionEspecialidades";
            this.Load += new System.EventHandler(this.GestionEspecialidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreFiltro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DataGridView dgvEspecialidades;
        private System.Windows.Forms.Button btnAgregarMedico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnXmlEspecialidades;
        private System.Windows.Forms.Button btnMenu;
    }
}