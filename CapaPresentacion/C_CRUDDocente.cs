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

namespace CapaPresentacion
{
    public partial class C_CRUDDocente : UserControl
    {
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
            DataTable Docentes = new D_Docente().MostrarDocentes();

            // Mostramos en el DataGridView los Docentes
            dgvDocentes.DataSource = Docentes;
        }

    }
}
