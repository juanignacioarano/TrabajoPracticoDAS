﻿namespace GUI
{
    partial class AltaMedico
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregarMedico = new System.Windows.Forms.Button();
            this.dgvMedicos = new System.Windows.Forms.DataGridView();
            this.clbEspecialidades = new System.Windows.Forms.CheckedListBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEstado = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreFiltro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDniFiltro = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnXml = new System.Windows.Forms.Button();
            this.txtDni = new GUI.NumericTextBox();
            this.hideButton1 = new GUI.HideButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(87, 94);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(157, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(87, 120);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(157, 20);
            this.txtApellido.TabIndex = 1;
            this.txtApellido.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Especialidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Matricula";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(87, 277);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(157, 20);
            this.txtMatricula.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(102, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gestion de Medico";
            // 
            // btnAgregarMedico
            // 
            this.btnAgregarMedico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAgregarMedico.Location = new System.Drawing.Point(87, 306);
            this.btnAgregarMedico.Name = "btnAgregarMedico";
            this.btnAgregarMedico.Size = new System.Drawing.Size(157, 26);
            this.btnAgregarMedico.TabIndex = 10;
            this.btnAgregarMedico.Text = "Agregar";
            this.btnAgregarMedico.UseVisualStyleBackColor = false;
            this.btnAgregarMedico.Click += new System.EventHandler(this.btnAgregarMedico_Click);
            // 
            // dgvMedicos
            // 
            this.dgvMedicos.AllowUserToAddRows = false;
            this.dgvMedicos.AllowUserToDeleteRows = false;
            this.dgvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicos.Location = new System.Drawing.Point(286, 68);
            this.dgvMedicos.Name = "dgvMedicos";
            this.dgvMedicos.ReadOnly = true;
            this.dgvMedicos.Size = new System.Drawing.Size(486, 331);
            this.dgvMedicos.TabIndex = 11;
            this.dgvMedicos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicos_CellClick);
            // 
            // clbEspecialidades
            // 
            this.clbEspecialidades.FormattingEnabled = true;
            this.clbEspecialidades.Location = new System.Drawing.Point(87, 207);
            this.clbEspecialidades.Name = "clbEspecialidades";
            this.clbEspecialidades.Size = new System.Drawing.Size(157, 64);
            this.clbEspecialidades.TabIndex = 18;
            this.clbEspecialidades.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbEspecialidades_ItemCheck);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(87, 184);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(157, 20);
            this.txtFiltro.TabIndex = 3;
            this.txtFiltro.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "DNI";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnModificar.Location = new System.Drawing.Point(87, 338);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(157, 26);
            this.btnModificar.TabIndex = 22;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEstado
            // 
            this.btnEstado.BackColor = System.Drawing.Color.Gray;
            this.btnEstado.Location = new System.Drawing.Point(87, 370);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(157, 26);
            this.btnEstado.TabIndex = 23;
            this.btnEstado.Text = "Activar/Desactivar";
            this.btnEstado.UseVisualStyleBackColor = false;
            this.btnEstado.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(87, 68);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(157, 20);
            this.txtId.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Nombre";
            // 
            // txtNombreFiltro
            // 
            this.txtNombreFiltro.Location = new System.Drawing.Point(403, 42);
            this.txtNombreFiltro.Name = "txtNombreFiltro";
            this.txtNombreFiltro.Size = new System.Drawing.Size(157, 20);
            this.txtNombreFiltro.TabIndex = 26;
            this.txtNombreFiltro.TextChanged += new System.EventHandler(this.txtNombreFiltro_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(571, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "DNI";
            // 
            // txtDniFiltro
            // 
            this.txtDniFiltro.Location = new System.Drawing.Point(603, 42);
            this.txtDniFiltro.Name = "txtDniFiltro";
            this.txtDniFiltro.Size = new System.Drawing.Size(157, 20);
            this.txtDniFiltro.TabIndex = 28;
            this.txtDniFiltro.TextChanged += new System.EventHandler(this.txtDniFiltro_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(528, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "Filtros";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLimpiar.Location = new System.Drawing.Point(87, 40);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(157, 22);
            this.btnLimpiar.TabIndex = 31;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.TextChanged += new System.EventHandler(this.Limpiar);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnXml
            // 
            this.btnXml.Location = new System.Drawing.Point(665, 9);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(107, 26);
            this.btnXml.TabIndex = 127;
            this.btnXml.Text = "Exportar XML";
            this.btnXml.UseVisualStyleBackColor = true;
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(87, 146);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(157, 28);
            this.txtDni.TabIndex = 2;
            // 
            // hideButton1
            // 
            this.hideButton1.Location = new System.Drawing.Point(12, 12);
            this.hideButton1.Name = "hideButton1";
            this.hideButton1.Size = new System.Drawing.Size(58, 20);
            this.hideButton1.TabIndex = 126;
            // 
            // AltaMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnXml);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.hideButton1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDniFiltro);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNombreFiltro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnEstado);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.clbEspecialidades);
            this.Controls.Add(this.dgvMedicos);
            this.Controls.Add(this.btnAgregarMedico);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Name = "AltaMedico";
            this.Text = "Gestion de Medico";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAgregarMedico;
        private System.Windows.Forms.DataGridView dgvMedicos;
        private System.Windows.Forms.CheckedListBox clbEspecialidades;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreFiltro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDniFiltro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLimpiar;
        private HideButton hideButton1;
        private NumericTextBox txtDni;
        private System.Windows.Forms.Button btnXml;
    }
}

