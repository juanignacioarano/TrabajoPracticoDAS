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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idEspecialidad = 0;
            idEspecialidad = Convert.ToInt32(txtId.Text);
            bLLEspecialidad.EliminarEspecialidad(idEspecialidad);

        }
    }
}
