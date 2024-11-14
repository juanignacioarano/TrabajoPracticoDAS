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

            dgvMedicos.DataSource = new BLLMedico().ListarMedicos();
        }

        private void FiltrarEspecialidades(string filtro)
        {
            // Filtrar las especialidades en función del texto ingresado
            var especialidadesFiltradas = listaEspecialidadesOriginal
                .Where(especialidad => especialidad.Descripcion.ToLower().Contains(filtro.ToLower()))
                .ToList();

            // Actualizar el DataSource del CheckedListBox
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


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FiltrarEspecialidades(txtFiltro.Text);
        }

        private void dgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int idMedico = (int)dgvMedicos.Rows[e.RowIndex].Cells["IdMedico"].Value;
            List<Especialidad> especialidades = new BLLMedico().ListarEspecialidadesPorMedico(idMedico);
            foreach (Especialidad item in clbEspecialidades.Items)
            {
                item.Seleccionado = especialidades.Any(x => x.IdEspecialidad == item.IdEspecialidad);
            }


        }
    }
}
