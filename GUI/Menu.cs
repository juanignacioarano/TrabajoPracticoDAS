using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private Form currentChildForm = null;

        private void AbrirFormularioHijo(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            currentChildForm.TopLevel = false;
            currentChildForm.FormBorderStyle = FormBorderStyle.None;
            currentChildForm.Dock = DockStyle.Fill;

            currentChildForm.Size = panelContenedor.ClientSize;

            this.panelContenedor.Controls.Add(currentChildForm);
            this.panelContenedor.Tag = currentChildForm;
            currentChildForm.BringToFront();
            currentChildForm.Show();
        }


        private void VerificarEstadoSQLServer()
        {
            try
            {
                scSQLSERVER.ServiceName = "MSSQLSERVER"; 
                scSQLSERVER.MachineName = "."; 

                if (scSQLSERVER.Status != ServiceControllerStatus.Running)
                {
                    MessageBox.Show(
                        "El servicio SQL Server está detenido. Por favor, inícialo antes de continuar.",
                        "SQL Server Detenido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    //Close();
                }
                else
                {
                    MessageBox.Show(
                        "El servicio SQL Server está en ejecución.",
                        "SQL Server en ejecución",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al verificar el estado del servicio SQL Server: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                //Close();
            }
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new GestionPacientes());
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new GestionUsuarios());
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new Login());
            VerificarEstadoSQLServer();
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new GestionTurnos());

        }

        private void btnGestionEspecialidad_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new GestionEspecialidades());

        }

        private void btnGestionMedico_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new AltaMedico());
        }
    }
}
