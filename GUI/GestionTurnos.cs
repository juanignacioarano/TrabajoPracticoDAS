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
using BE;

namespace GUI
{
    public partial class GestionTurnos : Form
    {
        public GestionTurnos()
        {
            InitializeComponent();
        }

        private void GestionTurnos_Load(object sender, EventArgs e)
        {
            Recargar();
            dtpFechaTurno.Value = DateTime.Now;
        }

        public void Recargar()
        {
            var pacientes = new BLLPaciente().ListarPacientesActivos();
            cmbPaciente.SetItems(
                pacientes,
                paciente => $"{((Paciente)paciente).Nombre} {((Paciente)paciente).Apellido} - DNI: {((Paciente)paciente).DNI}",
                "IdPaciente"
            );

            var medicos = new BLLMedico().ListarMedicosActivos();
            cmbMedico.SetItems(
                medicos,
                medico => $"{((Medico)medico).Nombre} {((Medico)medico).Apellido} - Especialidades: {((Medico)medico).Especialidades}",
                "IdMedico"
            );


            dgvTurno.DataSource = null;
            dgvTurno.DataSource = new BLLTurno().ListarTurnos();
            dgvTurno.Columns["IdMedico"].Visible = false;
            dgvTurno.Columns["IdPaciente"].Visible = false;
            
            Limpiar();

        }

        public void Limpiar()
        {
            txtId.Text = "";
            txtMotivo.Text = "";
            cmbMedico.SelectedIndex = -1;
            cmbPaciente.SelectedIndex = -1;
            dtpFechaTurno.Value = DateTime.Now;
            txtNombreFiltro.Text = "";
            txtDniFiltro.Text = "";
            dtpFechaFiltro.Value = DateTime.Now;
        }

        private DateTime? filtroFecha;

        public void FiltrarTurnos()
        {
            var turnos = new BLLTurno().ListarTurnos();

            if (filtroFecha.HasValue)
            {
                turnos = turnos.Where(turno => turno.FechaHora.Date == filtroFecha.Value.Date).ToList();
            }

            if (!string.IsNullOrWhiteSpace(txtNombreFiltro.Text))
            {
                string filtroNombre = txtNombreFiltro.Text.ToLower();
                turnos = turnos.Where(turno =>
                    turno.Paciente.ToLower().Contains(filtroNombre) ||
                    turno.Medico.ToLower().Contains(filtroNombre)
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(txtDniFiltro.Text))
            {
                string filtroDni = txtDniFiltro.Text;
                turnos = turnos.Where(turno =>
                    turno.DniPaciente.ToString().Contains(filtroDni) ||
                    turno.DniMedico.ToString().Contains(filtroDni)
                ).ToList();
            }

            dgvTurno.DataSource = null;
            dgvTurno.DataSource = turnos;
            dgvTurno.Columns["IdMedico"].Visible = false;
            dgvTurno.Columns["IdPaciente"].Visible = false;
        }

        private void txtNombreFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarTurnos();
        }

        private void txtDniFiltro_TextChanged(object sender, EventArgs e)
        {
            FiltrarTurnos();
        }

        private void dtpFechaFiltro_ValueChanged(object sender, EventArgs e)
        {
            filtroFecha = dtpFechaFiltro.Value;
            txtNombreFiltro.Text = "";
            txtDniFiltro.Text = "";
            FiltrarTurnos();
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbMedico.SelectedIndex == -1 || cmbPaciente.SelectedIndex == -1 || txtMotivo.Text == "")
            {
                MessageBox.Show("Complete todos los campos");
                return;
            }

            if(dtpFechaTurno.Value < DateTime.Now)
            {
                MessageBox.Show("La fecha del turno no puede ser anterior a la fecha actual");
                return;
            }

            var turno = new Turno
            {
                IdMedico = (int)cmbMedico.SelectedValue,
                IdPaciente = (int)cmbPaciente.SelectedValue,
                FechaHora = dtpFechaTurno.Value,
                Motivo = txtMotivo.Text
            };

            new BLLTurno().AgregarTurno(turno);
            Recargar();
        }



        private void btnPresentar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un turno");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea presentar el turno?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int idTurno = int.Parse(txtId.Text);
                new BLLTurno().RegistrarLlegada(idTurno, DateTime.Now);
            }
            Recargar();
        }

        private void dgvTurno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            DataGridViewRow row = dgvTurno.Rows[e.RowIndex];
            int idTurno = (int)row.Cells["IdTurno"].Value;
            txtId.Text = idTurno.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un turno");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cancelar el turno?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int idTurno = int.Parse(txtId.Text);
                new BLLTurno().CancelarTurno(idTurno);
            }

            Recargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un turno");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cancelar el turno?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                int idTurno = int.Parse(txtId.Text);
                new BLLTurno().EliminarTurno(idTurno);
            }

            Recargar();
        }

        private void dtpFechaTurno_ValueChanged(object sender, EventArgs e)
        {
            dtpFechaTurno.MinDate = DateTime.Now;
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            new BLLTurno().ExportarXML();
        }
    }
}
