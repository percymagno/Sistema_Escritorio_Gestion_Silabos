using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class C_CRUDCurso : UserControl
    {
        public C_CRUDCurso()
        {
            InitializeComponent();
            MostrarCursos();
        }
        // Metodos
        // Mostrar Cursos, todos los cursos o por busqueda
        private void MostrarCursos(String str = "")
        {
            DataTable dt;
            if (str == "") // Mostrar todos los cursos
            {
                dt = new N_Curso().ObtenerCursos();
            }
            else // buscar docentes
            {
                dt = new N_Curso().BuscarCurso(str);
            }
            dgvCursos.DataSource = dt;
        }
        // Eventos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_AddCurso AddCurso = new Frm_AddCurso();
            AddCurso.ShowDialog();
            MostrarCursos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.Rows.Count > 0)
            {
                int index = dgvCursos.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvCursos.Rows.Count - 1)
                {
                    String CodCurso = dgvCursos.Rows[index].Cells[0].Value.ToString();
                    DialogResult confirm = MessageBox.Show("¿Realmente desea eliminar el curso " + CodCurso + "?", "Sistema de Silabos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (confirm == DialogResult.OK)
                    {
                        if (new N_Curso { CodCurso = CodCurso }.EliminarCurso())
                            MessageBox.Show("Curso " + CodCurso + " eliminado!");
                        else
                            MessageBox.Show("No se pudo eliminar Curso " + CodCurso + "!");
                        MostrarCursos();
                    }
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.Rows.Count > 0)
            {
                int index = dgvCursos.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvCursos.Rows.Count - 1)
                {
                    N_Curso Curso = new N_Curso 
                    {
                        CodCurso = dgvCursos.Rows[index].Cells[0].Value.ToString(),
                        Nombre = dgvCursos.Rows[index].Cells[1].Value.ToString(),
                        Creditos = Int32.Parse(dgvCursos.Rows[index].Cells[2].Value.ToString()),
                        Categoria = dgvCursos.Rows[index].Cells[3].Value.ToString(),
                    };

                    Frm_AddCurso AddCurso = new Frm_AddCurso(Curso);
                    AddCurso.ShowDialog();
                    MostrarCursos();
                }
            }
        }

        private void dgvCursos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCursos.Rows.Count > 0)
            {
                int index = dgvCursos.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvCursos.Rows.Count - 1)
                {
                    N_Curso Curso = new N_Curso{

                        CodCurso = dgvCursos.Rows[index].Cells[0].Value.ToString(),
                        Nombre = dgvCursos.Rows[index].Cells[1].Value.ToString(),
                        Creditos = Int32.Parse(dgvCursos.Rows[index].Cells[2].Value.ToString()),
                        Categoria = dgvCursos.Rows[index].Cells[3].Value.ToString(),
                    };
                    Frm_AddCurso AddCurso = new Frm_AddCurso(Curso);
                    AddCurso.ShowDialog();
                    MostrarCursos();
                }
            }
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            if(tbBuscar.Text == "")
                MostrarCursos();
            else if (tbBuscar.Text != "Buscar")
                MostrarCursos(tbBuscar.Text);
        }

        private void tbBuscar_Leave(object sender, EventArgs e)
        {
            if (tbBuscar.Text == "")
                tbBuscar.Text = "Buscar";
            if (tbBuscar.Text == "Buscar")
                tbBuscar.ForeColor = Color.FromArgb(100, 100, 100);
        }

        private void tbBuscar_Click(object sender, EventArgs e)
        {
            tbBuscar.SelectAll();
            tbBuscar.ForeColor = Color.Black;
        }
    }
}
