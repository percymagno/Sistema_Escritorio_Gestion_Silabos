using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class C_Carga : UserControl
    {

        N_Carga carga = new N_Carga();
        public C_Carga()
        {
            InitializeComponent();
        }

        private void RefrescarDGV()
        {
            dgvCarga.Rows.Clear();
            dgvCarga.Refresh();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            dgvCarga.DataSource = null;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                Frm_Cargando frm_Cargando = new Frm_Cargando("Leyendo Archivo...");
                frm_Cargando.Show();
                int nroFilas = carga.Procesar(file);
                frm_Cargando.Close();

                int i = 1;
                foreach (N_Asignacion asignacion in carga.getCarga())
                {
                    string[] row = {
                        i.ToString(), asignacion.Docente.Nombres, asignacion.Curso.Nombre,
                        asignacion.Grupo, asignacion.Tipo, asignacion.Dia, asignacion.HR_inicio.ToString(),
                        asignacion.HR_fin.ToString()};
                    dgvCarga.Rows.Add(row);
                    i++;
                }
                MessageBox.Show(nroFilas + " filas leidas");
                btnGuardar.Visible = true;
            }
            else
                btnGuardar.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            D_Docente d_Docente = new D_Docente();
            DataTable dt_Docentes = d_Docente.MostrarDocentes();
            N_Curso n_Curso = new N_Curso();
            DataTable dt_Cursos = n_Curso.ObtenerCursos();

            foreach (N_Asignacion asignacion in carga.getCarga())
            {
                if (!asignacion.existeDocente(dt_Docentes))
                {
                    Frm_AddDocente frmDocente = new Frm_AddDocente(asignacion.Docente);
                    frmDocente.ShowDialog();
                    dt_Docentes = d_Docente.MostrarDocentes();
                }
                if (!asignacion.existeCurso(dt_Cursos))
                {
                    Frm_AddCurso frmCurso = new Frm_AddCurso(asignacion.Curso);
                    frmCurso.ShowDialog();
                    dt_Cursos = n_Curso.ObtenerCursos();
                }
            }
            carga.Limpiar();
            MessageBox.Show("Se guardó carga académica");
            RefrescarDGV();
        }

        private void C_Carga_Load(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
        }
    }
}
