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
    public partial class GestionPacientes : Form
    {
        public GestionPacientes()
        {
            InitializeComponent();
        }

        private void GestionPacientes_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtNumeroDeAfiliado.Clear();
            cmbGenero.SelectedIndex = -1;
            dtpFechaDeNacimiento.Value = DateTime.Now;
        }

        public void FiltrarPacientes()
        {
            ActualizarDataGridView();
            List<Paciente> pacientes = (List<Paciente>)dgvPaciente.DataSource;
            

            if (!string.IsNullOrEmpty(txtNombreFiltro.Text))
            {
                pacientes = pacientes.Where(paciente =>
                    paciente.Nombre.ToLower().Contains(txtNombreFiltro.Text.ToLower()) ||
                    paciente.Apellido.ToLower().Contains(txtNombreFiltro.Text.ToLower())
                ).ToList();
            }

            if (!string.IsNullOrEmpty(txtDniFiltro.Text))
            {
                pacientes = pacientes.Where(paciente => paciente.DNI.ToLower().Contains(txtDniFiltro.Text.ToLower())).ToList();
            }

            dgvPaciente.DataSource = null;
            dgvPaciente.DataSource = pacientes;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(cmbGenero.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroDeAfiliado.Text))

            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!int.TryParse(txtDni.Text, out _))
            {
                MessageBox.Show("El DNI debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!long.TryParse(txtTelefono.Text, out _))
            {
                MessageBox.Show("El teléfono debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            Paciente paciente = new Paciente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DNI = txtDni.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                FechaNacimiento = dtpFechaDeNacimiento.Value,
                NumeroDeAfiliado = txtNumeroDeAfiliado.Text,
                Genero = cmbGenero.SelectedItem.ToString()
            };

            new BLLPaciente().AgregarPaciente(paciente);

            ActualizarDataGridView();

            LimpiarFormulario();
        }

        private void ActualizarDataGridView()
        {
            dgvPaciente.DataSource = null;
            dgvPaciente.DataSource = new BLLPaciente().ListarPacientes();
        }

        private void txtNombreFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarPacientes();
        }

        private void txtDniFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarPacientes();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
