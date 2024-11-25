using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GestionEspecialidades : Form
    {
        public GestionEspecialidades()
        {
            InitializeComponent();
        }

        BLLEspecialidad bLLEspecialidad = new BLLEspecialidad();
        List<Especialidad> listaEspecialidadesOriginal = new List<Especialidad>();

        public void FiltrarEspecialidades(string filtro)
        {
            var especialidadesFiltradas = listaEspecialidadesOriginal
        .Where(especialidad => especialidad.Descripcion.ToLower().Contains(filtro.ToLower()))
         .ToList();

            dgvEspecialidades.DataSource = null;
            dgvEspecialidades.DataSource = especialidadesFiltradas;
        }

        private void txtNombreFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarEspecialidades(txtNombreFiltro.Text);
        }

        private void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bLLEspecialidad.AgregarEspecialidad(txtNombre.Text);
            txtNombre.Text = "";
            listaEspecialidadesOriginal = bLLEspecialidad.ListarEspecialidades();
            dgvEspecialidades.DataSource = listaEspecialidadesOriginal;
        }

        private void GestionEspecialidades_Load(object sender, EventArgs e)
        {
            listaEspecialidadesOriginal = bLLEspecialidad.ListarEspecialidades();
            dgvEspecialidades.DataSource = listaEspecialidadesOriginal;
        }

        private void btnXmlEspecialidades_Click(object sender, EventArgs e)
        {
            bLLEspecialidad.ExportarXmlEspecialidades();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, seleccione una especialidad para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta especialidad?",
                "Confirmación de eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int idEspecialidad = Convert.ToInt32(txtId.Text);

                bLLEspecialidad.EliminarEspecialidad(idEspecialidad);

                listaEspecialidadesOriginal = bLLEspecialidad.ListarEspecialidades();
                dgvEspecialidades.DataSource = listaEspecialidadesOriginal;
                txtId.Text = "";
                txtNombre.Text = "";
            }
        }

        bool estado = true;
        private void dgvEspecialidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            txtNombre.Text = dgvEspecialidades.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtId.Text = dgvEspecialidades.Rows[e.RowIndex].Cells[0].Value.ToString();

            //estado = Convert.ToBoolean(dgvEspecialidades.Rows[e.RowIndex].Cells["Activo"].Value);

            //if (estado)
            //{
            //    btnEstado.Text = "Desactivar";
            //    btnEstado.BackColor = Color.Red;
            //}
            //else
            //{
            //    btnEstado.Text = "Activar";
            //    btnEstado.BackColor = Color.Green;
            //}

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            //btnEstado.Text = "Activar/Desactivar";
            //btnEstado.BackColor = Color.Gray;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar una especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Descripción no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idEspecialidad = Convert.ToInt32(txtId.Text);

            Especialidad especialidad = new Especialidad
            {
                IdEspecialidad = idEspecialidad,
                Descripcion = txtNombre.Text
            };

            bLLEspecialidad.ModificarEspecialidad(especialidad);
            dgvEspecialidades.DataSource = null;
            dgvEspecialidades.DataSource = bLLEspecialidad.ListarEspecialidades();

            txtNombre.Text = "";
            txtId.Text = "";
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar una especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (estado)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea desactivar la especialidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    new BLLEspecialidad().ActualizarEstadoEspecialidad(Convert.ToInt32(txtId.Text), false);
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea activar la especialidad?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    new BLLEspecialidad().ActualizarEstadoEspecialidad(Convert.ToInt32(txtId.Text), true);
                }
            }

            btnLimpiar_Click(sender, e);
            dgvEspecialidades.DataSource = null;
            dgvEspecialidades.DataSource = bLLEspecialidad.ListarEspecialidades();
        }
    }
}
