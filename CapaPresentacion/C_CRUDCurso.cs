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

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
