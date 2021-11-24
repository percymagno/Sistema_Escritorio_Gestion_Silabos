using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidades;
namespace CapaPresentacion
{
    public partial class C_CRUDDocente : UserControl
    {
        DataTable Docentes;
        public C_CRUDDocente()
        {
            InitializeComponent();

            // Mostramos los Docentes
            MostrarDocentes();
        }

        // Click Boton Agregar Docente
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_AddDocente AddDocente = new Frm_AddDocente();
            AddDocente.Show();
        }
        // Mostrar Docentes
        public void MostrarDocentes()
        {
            // Buscamos los docentes que existen en la BD y lo almacenamos en un DataTable
            Docentes = new D_Docente().MostrarDocentes();
            
            // Mostramos en el DataGridView los Docentes
            dgvDocentes.DataSource = Docentes;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDocentes.Rows.Count > 0)
            {
                int index = dgvDocentes.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvDocentes.Rows.Count - 1)
                {
                    String CodDocente = dgvDocentes.Rows[index].Cells[0].Value.ToString();
                    E_Docente Docente = new E_Docente();
                    Docente.CodDocente = CodDocente;
                    DialogResult confirm = MessageBox.Show("¿Realmente desea eliminar el docente " + CodDocente + "?", "Sistema de Silabos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (confirm == DialogResult.OK)
                    {
                        if (new D_Docente().EliminarDocente(Docente))
                            MessageBox.Show("Docente " + CodDocente + " eliminado!");
                        else
                            MessageBox.Show("No se pudo eliminar Docente " + CodDocente + "!");
                        MostrarDocentes();
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDocentes.Rows.Count > 0)
            {
                int index = dgvDocentes.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvDocentes.Rows.Count - 1)
                {
                    E_Docente Docente = new E_Docente();
                    Docente.CodDocente = dgvDocentes.Rows[index].Cells[0].Value.ToString();
                    Docente.Paterno = dgvDocentes.Rows[index].Cells[1].Value.ToString();
                    Docente.Materno = dgvDocentes.Rows[index].Cells[2].Value.ToString();
                    Docente.Nombres = dgvDocentes.Rows[index].Cells[3].Value.ToString();
                    Docente.Regimen = dgvDocentes.Rows[index].Cells[4].Value.ToString();
                    Docente.Correo = dgvDocentes.Rows[index].Cells[5].Value.ToString();
                    Docente.Telefono = dgvDocentes.Rows[index].Cells[6].Value.ToString();
                    Frm_AddDocente AddDocente = new Frm_AddDocente(Docente, true);
                    AddDocente.ShowDialog();
                }
            }
        }

        private void C_CRUDDocente_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
                MostrarDocentes();
        }
    }
}
