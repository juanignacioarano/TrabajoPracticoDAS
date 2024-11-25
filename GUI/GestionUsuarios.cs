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
    public partial class GestionUsuarios : Form
    {
        public GestionUsuarios()
        {
            InitializeComponent();
        }

        BLLUsuario bLLUsuario = new BLLUsuario();

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bLLUsuario.RegistrarUsuario(txtUsername.Text, txtClave.Text);
            txtUsername.Text = "";
            txtClave.Text = "";
            Recargar();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Debe seleccionar un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea eliminar este usuario?",
                "Confirmación de eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bLLUsuario.EliminarUsuario(Convert.ToInt32(txtId.Text));
                txtId.Text = "";
                txtUsername.Text = "";
                Recargar();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Debe completar el nombre de usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea modificar este usuario?",
                "Confirmación de modificación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                Usuario usuario = new Usuario
                {
                    IdUsuario = Convert.ToInt32(txtId.Text),
                    NombreUsuario = txtUsername.Text,
                    Contraseña = string.IsNullOrWhiteSpace(txtClave.Text) ? null : txtClave.Text
                };

                bLLUsuario.ModificarUsuario(usuario);

                txtUsername.Text = "";
                txtClave.Text = "";
                txtId.Text = "";

                Recargar();
            }
        }


        private void GestionUsuarios_Load(object sender, EventArgs e)
        {
            Recargar();
            
        }

        public void Recargar()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = bLLUsuario.ListarUsuarios();
            dgvUsuarios.Columns["Contraseña"].Visible = false;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
            txtId.Text = row.Cells["IdUsuario"].Value.ToString();
            txtUsername.Text = row.Cells["NombreUsuario"].Value.ToString();

        }

        private void txtNombreFiltro_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreFiltro.Text))
            {
                Recargar();
                return;
            }

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = bLLUsuario.ListarUsuarios().Where(x => x.NombreUsuario.Contains(txtNombreFiltro.Text)).ToList();
            dgvUsuarios.Columns["Contraseña"].Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtUsername.Text = "";
            txtClave.Text = "";
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            bLLUsuario.ExportarXML();
        }
    }
}
