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

        N_Carga carga;
        N_Asignacion n_Asignacion = new N_Asignacion();
        DataTable dt_Asignacion;
        public C_Carga()
        {
            InitializeComponent();
            dt_Asignacion = n_Asignacion.Mostrar();
            RefrescarDGV();
        }

        private void RefrescarDGV()
        {
            dgvCarga.Rows.Clear();
            dgvCarga.Refresh();
            dgvCarga.Columns.Clear();
            dgvCarga.DataSource = dt_Asignacion;
        }
        private void RellenarHeaders()
        {
            // rellenar DGV
            dgvCarga.DataSource = null;
            dgvCarga.Rows.Clear();
            dgvCarga.Refresh();

            dgvCarga.ColumnCount = 8;
            dgvCarga.Columns[0].Name = "#";
            dgvCarga.Columns[1].Name = "Docente";
            dgvCarga.Columns[2].Name = "Curso";
            dgvCarga.Columns[3].Name = "Grupo";
            dgvCarga.Columns[4].Name = "Tipo";
            dgvCarga.Columns[5].Name = "Dia";
            dgvCarga.Columns[6].Name = "HR_inicio";
            dgvCarga.Columns[7].Name = "HR_fin";
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            carga = new N_Carga();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                int nroFilas = carga.Procesar(file);

                RellenarHeaders();
                int i = 1;
                foreach (N_Asignacion asignacion in carga.getCarga())
                {
                    string[] row = {
                        i.ToString(), asignacion.Docente.Nombres, asignacion.Curso.Nombre, asignacion.Grupo,
                        asignacion.Tipo, asignacion.Dia, asignacion.HR_inicio.ToString(), asignacion.HR_fin.ToString()};
                    dgvCarga.Rows.Add(row);
                    i++;
                }
                MessageBox.Show(nroFilas + " filas leidas", "Sistema de Gestion de Sílabos");
            }
            btnGuardar.Visible = carga.getCarga().Count() > 0;
            if (carga.getCarga().Count() == 0)
            {
                RefrescarDGV();
                MessageBox.Show("Error! Elegir otro archivo", "Sistema de Gestion de Sílabos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            D_Docente d_Docente = new D_Docente();
            DataTable dt_Docentes = d_Docente.MostrarDocentes();

            N_Curso n_Curso = new N_Curso();
            DataTable dt_Cursos = n_Curso.ObtenerCursos();
            List<N_Asignacion> noGuardados = new List<N_Asignacion>();

            foreach (N_Asignacion asignacion in carga.getCarga())
            {
                if (asignacion.buscarDocente(dt_Docentes) == "")
                {
                    Frm_AddDocente frmDocente = new Frm_AddDocente(asignacion.Docente);
                    frmDocente.ShowDialog();
                    dt_Docentes = d_Docente.MostrarDocentes();
                }
                if (asignacion.buscarCurso(dt_Cursos) == "")
                {
                    Frm_AddCurso frmCurso = new Frm_AddCurso(asignacion.Curso);
                    frmCurso.ShowDialog();
                    dt_Cursos = n_Curso.ObtenerCursos();
                }
                if (asignacion.Guardar(dt_Docentes, dt_Cursos, dt_Asignacion) == -1)
                {
                    noGuardados.Add(asignacion);
                }
            }
            if(noGuardados.Count > 0)
            {
                string tmp = "";
                foreach (N_Asignacion asignacion in noGuardados)
                {
                    tmp += "\n" + asignacion.Curso.Nombre + ", grupo: " + asignacion.Grupo;
                }
                MessageBox.Show("Asignaciones no agregadas: " + tmp, "Sistema de Gestion de Silabos");
            }
            else
                MessageBox.Show("Se guardó carga correctamente", "Sistema de Gestión de Silabos");

            btnGuardar.Visible = false;
            RefrescarDGV();
        }

        private void C_Carga_Load(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
        }
    }
}
