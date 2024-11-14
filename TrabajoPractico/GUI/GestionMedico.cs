using System;
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
        }

        List<Especialidad> listaEspecialidadesOriginal = new List<Especialidad>();
        private void Form1_Load(object sender, EventArgs e)
        {
            listaEspecialidadesOriginal = new BLLMedico().ListarEspecialidades();
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

        private void FiltrarEspecialidades(string filtro)
        {
            var especialidadesFiltradas = listaEspecialidadesOriginal
                .Where(especialidad => especialidad.Descripcion.ToLower().Contains(filtro.ToLower()))
                .ToList();

            clbEspecialidades.DataSource = especialidadesFiltradas;
            clbEspecialidades.DisplayMember = "Descripcion";
            clbEspecialidades.ValueMember = "IdEspecialidad";
        }


        private void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Matricula = txtMatricula.Text,
                Dni = txtDni.Text
            };

            List<int> especialidades = new List<int>();
            foreach (Especialidad item in clbEspecialidades.CheckedItems)
            {
                especialidades.Add(item.IdEspecialidad);
            }

            int idMedico = new BLLMedico().AgregarMedico(medico);

            new BLLMedico().AgregarEspecialidades(idMedico, especialidades);
            ActualizarGrilla();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FiltrarEspecialidades(txtFiltro.Text);
        }

        private void dgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int idMedico = (int)dgvMedicos.Rows[e.RowIndex].Cells["IdMedico"].Value;
            txtId.Text = idMedico.ToString();
            txtNombre.Text = dgvMedicos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            txtApellido.Text = dgvMedicos.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
            txtMatricula.Text = dgvMedicos.Rows[e.RowIndex].Cells["Matricula"].Value.ToString();
            txtDni.Text = dgvMedicos.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
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
            clbEspecialidades.ClearSelected();
            for (int i = 0; i < clbEspecialidades.Items.Count; i++)
            {
                clbEspecialidades.SetItemChecked(i, false);
            }
        }
    }
}
