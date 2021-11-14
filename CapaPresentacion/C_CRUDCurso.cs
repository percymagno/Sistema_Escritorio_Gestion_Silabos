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
using CapaDatos;
using CapaEntidades;

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
                dt = new D_Curso().ObtenerCursos();
            }
            else // buscar docentes
            {
                dt = new D_Curso().BuscarCurso(str);
            }
            dgvCursos.DataSource = dt;
        }
        // Eventos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_AddCurso AddCurso = new Frm_AddCurso();
            AddCurso.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.Rows.Count > 0)
            {
                int index = dgvCursos.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvCursos.Rows.Count - 1)
                {
                    String CodCurso = dgvCursos.Rows[index].Cells[0].Value.ToString();
                    E_Curso Curso = new E_Curso();
                    Curso.CodCurso = CodCurso;
                    DialogResult confirm = MessageBox.Show("¿Realmente desea eliminar el curso " + CodCurso + "?", "Sistema de Silabos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (confirm == DialogResult.OK)
                    {
                        if (new D_Curso().EliminarCurso(Curso))
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

        }
    }
}
