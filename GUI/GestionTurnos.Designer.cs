namespace GUI
{
    partial class GestionTurnos
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtDniFiltro = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreFiltro = new System.Windows.Forms.TextBox();
            this.dgvTurno = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaTurno = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnPresentar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFechaFiltro = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.hideButton1 = new GUI.HideButton();
            this.cmbMedico = new GUI.FilteredComboBox();
            this.cmbPaciente = new GUI.FilteredComboBox();
            this.btnXml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurno)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 128;
            this.label9.Text = "DNI";
            // 
            // txtDniFiltro
            // 
            this.txtDniFiltro.Location = new System.Drawing.Point(326, 82);
            this.txtDniFiltro.Name = "txtDniFiltro";
            this.txtDniFiltro.Size = new System.Drawing.Size(157, 20);
            this.txtDniFiltro.TabIndex = 127;
            this.txtDniFiltro.TextChanged += new System.EventHandler(this.txtDniFiltro_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(276, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 126;
            this.label8.Text = "Nombre";
            // 
            // txtNombreFiltro
            // 
            this.txtNombreFiltro.Location = new System.Drawing.Point(326, 47);
            this.txtNombreFiltro.Name = "txtNombreFiltro";
            this.txtNombreFiltro.Size = new System.Drawing.Size(157, 20);
            this.txtNombreFiltro.TabIndex = 125;
            this.txtNombreFiltro.TextChanged += new System.EventHandler(this.txtNombreFiltro_TextChanged);
            // 
            // dgvTurno
            // 
            this.dgvTurno.AllowUserToAddRows = false;
            this.dgvTurno.AllowUserToDeleteRows = false;
            this.dgvTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurno.Location = new System.Drawing.Point(279, 108);
            this.dgvTurno.Name = "dgvTurno";
            this.dgvTurno.ReadOnly = true;
            this.dgvTurno.Size = new System.Drawing.Size(502, 295);
            this.dgvTurno.TabIndex = 124;
            this.dgvTurno.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurno_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 129;
            this.label1.Text = "Motivo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(25, 85);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(170, 20);
            this.txtMotivo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 132;
            this.label2.Text = "Paciente";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 134;
            this.label3.Text = "Medico";
            // 
            // dtpFechaTurno
            // 
            this.dtpFechaTurno.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaTurno.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaTurno.Location = new System.Drawing.Point(25, 255);
            this.dtpFechaTurno.MinDate = new System.DateTime(2024, 11, 24, 23, 26, 30, 0);
            this.dtpFechaTurno.Name = "dtpFechaTurno";
            this.dtpFechaTurno.ShowUpDown = true;
            this.dtpFechaTurno.Size = new System.Drawing.Size(170, 20);
            this.dtpFechaTurno.TabIndex = 3;
            this.dtpFechaTurno.Value = new System.DateTime(2024, 11, 24, 23, 26, 30, 0);
            this.dtpFechaTurno.ValueChanged += new System.EventHandler(this.dtpFechaTurno_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 136;
            this.label4.Text = "Fecha del Turno";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAgregar.Location = new System.Drawing.Point(26, 281);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(169, 24);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Nuevo Turno";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(26, 371);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(169, 24);
            this.btnEliminar.TabIndex = 138;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCancelar.Location = new System.Drawing.Point(26, 341);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(169, 24);
            this.btnCancelar.TabIndex = 139;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnPresentar
            // 
            this.btnPresentar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPresentar.Location = new System.Drawing.Point(26, 311);
            this.btnPresentar.Name = "btnPresentar";
            this.btnPresentar.Size = new System.Drawing.Size(169, 24);
            this.btnPresentar.TabIndex = 141;
            this.btnPresentar.Text = "Presentar";
            this.btnPresentar.UseVisualStyleBackColor = false;
            this.btnPresentar.Click += new System.EventHandler(this.btnPresentar_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(26, 46);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(170, 20);
            this.txtId.TabIndex = 142;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 143;
            this.label5.Text = "Id Selec";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(515, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 144;
            this.label10.Text = "Filtros";
            // 
            // dtpFechaFiltro
            // 
            this.dtpFechaFiltro.Location = new System.Drawing.Point(554, 82);
            this.dtpFechaFiltro.Name = "dtpFechaFiltro";
            this.dtpFechaFiltro.Size = new System.Drawing.Size(181, 20);
            this.dtpFechaFiltro.TabIndex = 145;
            this.dtpFechaFiltro.ValueChanged += new System.EventHandler(this.dtpFechaFiltro_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(511, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 146;
            this.label6.Text = "Fecha";
            // 
            // hideButton1
            // 
            this.hideButton1.Location = new System.Drawing.Point(6, 6);
            this.hideButton1.Name = "hideButton1";
            this.hideButton1.Size = new System.Drawing.Size(58, 20);
            this.hideButton1.TabIndex = 140;
            // 
            // cmbMedico
            // 
            this.cmbMedico.Location = new System.Drawing.Point(25, 189);
            this.cmbMedico.Name = "cmbMedico";
            this.cmbMedico.SelectedIndex = -1;
            this.cmbMedico.Size = new System.Drawing.Size(170, 44);
            this.cmbMedico.TabIndex = 2;
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.Location = new System.Drawing.Point(25, 124);
            this.cmbPaciente.Name = "cmbPaciente";
            this.cmbPaciente.SelectedIndex = -1;
            this.cmbPaciente.Size = new System.Drawing.Size(170, 44);
            this.cmbPaciente.TabIndex = 1;
            // 
            // btnXml
            // 
            this.btnXml.Location = new System.Drawing.Point(665, 12);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(107, 26);
            this.btnXml.TabIndex = 147;
            this.btnXml.Text = "Exportar XML";
            this.btnXml.UseVisualStyleBackColor = true;
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // GestionTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnXml);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFechaFiltro);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnPresentar);
            this.Controls.Add(this.hideButton1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaTurno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMedico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPaciente);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDniFiltro);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNombreFiltro);
            this.Controls.Add(this.dgvTurno);
            this.Name = "GestionTurnos";
            this.Text = "GestionTurnos";
            this.Load += new System.EventHandler(this.GestionTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDniFiltro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreFiltro;
        private System.Windows.Forms.DataGridView dgvTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMotivo;
        private FilteredComboBox cmbPaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FilteredComboBox cmbMedico;
        private System.Windows.Forms.DateTimePicker dtpFechaTurno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private HideButton hideButton1;
        private System.Windows.Forms.Button btnPresentar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFechaFiltro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXml;
    }
}