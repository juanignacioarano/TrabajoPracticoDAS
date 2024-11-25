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
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtNumeroDeAfiliado.Clear();
            cmbGenero.SelectedIndex = -1;
            dtpFechaDeNacimiento.Value = DateTime.Now;
            btnEstado.Text = "Activar/Desactivar";
            btnEstado.BackColor = Color.Gray;
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
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                txtEmail.IsEmpty ||
                string.IsNullOrWhiteSpace(cmbGenero.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroDeAfiliado.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!txtEmail.IsValidEmail())
            {
                MessageBox.Show("El email ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (!ValidarCampos())
                return;

            Paciente paciente = new Paciente
            {
                IdPaciente = Convert.ToInt32(txtId.Text),
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

            new BLLPaciente().ModificarPaciente(paciente);

            ActualizarDataGridView();

            LimpiarFormulario();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar un paciente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            if(estado)
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea desactivar el paciente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    new BLLPaciente().ActualizarEstadoPaciente(Convert.ToInt32(txtId.Text), false);
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea activar el paciente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    new BLLPaciente().ActualizarEstadoPaciente(Convert.ToInt32(txtId.Text), true);
                }
            }

            ActualizarDataGridView();
            LimpiarFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        bool estado = true;

        private void dgvPaciente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            DataGridViewRow row = dgvPaciente.Rows[e.RowIndex];
            txtId.Text = row.Cells["IdPaciente"].Value.ToString();
            txtNombre.Text = row.Cells["Nombre"].Value.ToString();
            txtApellido.Text = row.Cells["Apellido"].Value.ToString();
            txtDni.Text = row.Cells["DNI"].Value.ToString();
            txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
            txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            dtpFechaDeNacimiento.Value = Convert.ToDateTime(row.Cells["FechaNacimiento"].Value);
            txtNumeroDeAfiliado.Text = row.Cells["NumeroDeAfiliado"].Value.ToString();
            cmbGenero.SelectedItem = row.Cells["Genero"].Value.ToString();
            estado = Convert.ToBoolean(row.Cells["Activo"].Value);

            if (estado)
            {
                btnEstado.Text = "Desactivar";
                btnEstado.BackColor = Color.Red;
            } else
            {
                btnEstado.Text = "Activar";
                btnEstado.BackColor = Color.Green;
            }

        }

        private void dgvPaciente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            new BLLPaciente().ExportarXML();
        }
    }
}
