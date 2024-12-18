﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;


namespace GUI
{
    public partial class AltaMedico : Form
    {
        public AltaMedico()
        {
            InitializeComponent();
            clbEspecialidades.ItemCheck += clbEspecialidades_ItemCheck;
        }

        List<Especialidad> listaEspecialidadesOriginal = new List<Especialidad>();
        private void Form1_Load(object sender, EventArgs e)
        {
            listaEspecialidadesOriginal = new BLLEspecialidad().ListarEspecialidades();
            clbEspecialidades.DataSource = listaEspecialidadesOriginal;
            clbEspecialidades.DisplayMember = "Descripcion";
            clbEspecialidades.ValueMember = "IdEspecialidad";
            ActualizarGrilla();
        }

        public void ActualizarGrilla()
        {
            dgvMedicos.DataSource = null;
            dgvMedicos.DataSource = new BLLMedico().ListarMedicos();
        }

        private List<int> especialidadesSeleccionadas = new List<int>();


        private void clbEspecialidades_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var especialidad = (Especialidad)clbEspecialidades.Items[e.Index];

            if (e.NewValue == CheckState.Checked)
            {
                if (!especialidadesSeleccionadas.Contains(especialidad.IdEspecialidad))
                {
                    especialidadesSeleccionadas.Add(especialidad.IdEspecialidad);
                }
            }
            else
            {
                if (especialidadesSeleccionadas.Contains(especialidad.IdEspecialidad))
                {
                    especialidadesSeleccionadas.Remove(especialidad.IdEspecialidad);
                }
            }
        }

        private void FiltrarEspecialidades(string filtro)
        {
            var especialidadesFiltradas = listaEspecialidadesOriginal
                .Where(especialidad => especialidad.Descripcion.ToLower().Contains(filtro.ToLower()))
                .ToList();

            clbEspecialidades.DataSource = null;
            clbEspecialidades.DataSource = especialidadesFiltradas;
            clbEspecialidades.DisplayMember = "Descripcion";
            clbEspecialidades.ValueMember = "IdEspecialidad";

            for (int i = 0; i < clbEspecialidades.Items.Count; i++)
            {
                var especialidad = (Especialidad)clbEspecialidades.Items[i];
                if (especialidadesSeleccionadas.Contains(especialidad.IdEspecialidad))
                {
                    clbEspecialidades.SetItemChecked(i, true);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FiltrarEspecialidades(txtFiltro.Text);
        }



        private void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtMatricula.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Medico medico = new Medico
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = txtMatricula.Text,
                Dni = txtDni.Text
            };

            List<int> especialidades = listaEspecialidadesOriginal
                .Where(especialidad => especialidadesSeleccionadas.Contains(especialidad.IdEspecialidad))
                .Select(especialidad => especialidad.IdEspecialidad)
                .ToList();

            if (especialidades.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int idMedico = new BLLMedico().AgregarMedico(medico, especialidades);

            ActualizarGrilla();
            btnLimpiar_Click(sender, e);
        }

        bool estado = true;

        private void dgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            txtFiltro.Text = "";
            int idMedico = (int)dgvMedicos.Rows[e.RowIndex].Cells["IdMedico"].Value;
            txtId.Text = idMedico.ToString();
            txtNombre.Text = dgvMedicos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtApellido.Text = dgvMedicos.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            txtMatricula.Text = dgvMedicos.Rows[e.RowIndex].Cells["Matricula"].Value.ToString();
            txtDni.Text = dgvMedicos.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
            estado = Convert.ToBoolean(dgvMedicos.Rows[e.RowIndex].Cells["Activo"].Value);

            if (estado)
            {
                btnEstado.Text = "Desactivar";
                btnEstado.BackColor = Color.Red;
            }
            else
            {
                btnEstado.Text = "Activar";
                btnEstado.BackColor = Color.Green;
            }
            clbEspecialidades.ClearSelected();
            for (int i = 0; i < clbEspecialidades.Items.Count; i++)
            {
                clbEspecialidades.SetItemChecked(i, false);
            }
            List<Especialidad> especialidades = new BLLMedico().ListarEspecialidadesPorMedico(idMedico);
            foreach (Especialidad item in especialidades)
            {
                for (int i = 0; i < clbEspecialidades.Items.Count; i++)
                {
                    if (((Especialidad)clbEspecialidades.Items[i]).IdEspecialidad == item.IdEspecialidad)
                    {
                        clbEspecialidades.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void txtNombreFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarMedicos();
        }

        private void txtDniFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarMedicos();
        }

        private void FiltrarMedicos()
        {
            ActualizarGrilla();
            List<Medico> medicos = (List<Medico>)dgvMedicos.DataSource;

            if (!string.IsNullOrEmpty(txtNombreFiltro.Text))
            {
                medicos = medicos.Where(medico =>
                    medico.Nombre.ToLower().Contains(txtNombreFiltro.Text.ToLower()) ||
                    medico.Apellido.ToLower().Contains(txtNombreFiltro.Text.ToLower())
                ).ToList();
            }

            if (!string.IsNullOrEmpty(txtDniFiltro.Text))
            {
                medicos = medicos.Where(medico => medico.Dni.ToLower().Contains(txtDniFiltro.Text.ToLower())).ToList();
            }

            dgvMedicos.DataSource = null;
            dgvMedicos.DataSource = medicos;
        }

        private void Limpiar(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDni.Text = "";
            txtMatricula.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtId.Text = "";
            btnEstado.Text = "Activar/Desactivar";
            btnEstado.BackColor = Color.Gray;
            clbEspecialidades.ClearSelected();
            for (int i = 0; i < clbEspecialidades.Items.Count; i++)
            {
                clbEspecialidades.SetItemChecked(i, false);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar un médico para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtMatricula.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Medico medico = new Medico
            {
                IdMedico = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = txtMatricula.Text,
                Dni = txtDni.Text
            };

            List<int> especialidades = listaEspecialidadesOriginal
                .Where(especialidad => especialidadesSeleccionadas.Contains(especialidad.IdEspecialidad))
                .Select(especialidad => especialidad.IdEspecialidad)
                .ToList();

            if (especialidades.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                BLLMedico bllMedico = new BLLMedico();
                bllMedico.ModificarMedico(medico);
                
                bllMedico.ActualizarEspecialidades(medico.IdMedico, especialidades);

                ActualizarGrilla();

                MessageBox.Show("Médico modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el médico: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar un medico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (estado)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea desactivar el medico?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    new BLLMedico().ActualizarEstadoMedico(Convert.ToInt32(txtId.Text), false);
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea activar el medico?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    new BLLMedico().ActualizarEstadoMedico(Convert.ToInt32(txtId.Text), true);
                }
            }

            ActualizarGrilla();
            btnLimpiar_Click(sender, e);

        }

        private void btnXmlEspecialidades_Click(object sender, EventArgs e)
        {

        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            BLLMedico bllMedico = new BLLMedico();
            bllMedico.ExportarXML();
        }
    }
}
