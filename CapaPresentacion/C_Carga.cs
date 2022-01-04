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
        N_Semestre n_Semestre = new N_Semestre();
        DataTable dt_Asignacion;
        string curSemestre;
        public C_Carga()
        {
            InitializeComponent();
            RellenarSemestre();
            RefrescarDGV();
            panelSemestre.Visible = true;
            panelSemestre.BringToFront();
        }

        private void RefrescarDGV(string Semestre = "")
        {
            dgvCarga.DataSource = null;
            dgvCarga.Rows.Clear();
            dgvCarga.Columns.Clear();
            dgvCarga.Refresh();

            if (Semestre == "")
                Semestre = curSemestre;

            dt_Asignacion = n_Asignacion.BuscarSemestre(Semestre);
            if (dt_Asignacion != null)
            {
                dgvCarga.DataSource = dt_Asignacion;/*
                dgvCarga.Columns["ID"].Visible = false;
                dgvCarga.Columns["Semestre"].Visible = false;
                dgvCarga.Columns["Aula"].Visible = false;
                dgvCarga.Columns["HT"].Visible = false;
                dgvCarga.Columns["HP"].Visible = false;*/
            }
        }
        private void RellenarSemestre()
        {
            DataTable dt_Semestres = n_Semestre.Mostrar();
            foreach (DataRow row in dt_Semestres.Rows)
            {
                cbSemestre.Items.Add(row[0]);
            }
            curSemestre = dt_Semestres.Rows[0][0].ToString();
            cbSemestre.SelectedItem = curSemestre;
        }
        private void RellenarHeaders()
        {
            // rellenar DGV
            dgvCarga.DataSource = null;
            dgvCarga.Rows.Clear();
            dgvCarga.Refresh();

            dgvCarga.ColumnCount = 4;
            dgvCarga.Columns[0].Name = "Docente";
            dgvCarga.Columns[1].Name = "Curso";
            dgvCarga.Columns[2].Name = "Grupo";
            dgvCarga.Columns[3].Name = "Semestre";
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
                foreach (N_Asignacion asignacion in carga.getCarga())
                {
                    string[] row = {asignacion.Docente.Nombres, asignacion.Curso.Nombre, asignacion.Grupo, asignacion.Carrera};
                    dgvCarga.Rows.Add(row);
                }
                MessageBox.Show(nroFilas + " filas leidas", "Sistema de Gestion de Sílabos");
            }
            if(carga.getCarga().Count() > 0)
            {
                panelGuardar.Visible = true;
                panelCrud.Visible = false;
            }
            if (carga.getCarga().Count() == 0)
            {
                RefrescarDGV();
                MessageBox.Show("Error! Elegir otro archivo", "Sistema de Gestion de Sílabos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }

        public string buscarDocente(E_Docente doc, DataTable dt)
        {
            if (dt == null) return "";
            foreach (DataRow row in dt.Rows)
            {
                string Nombres = (row["Nombres"].ToString() + " " + row["Paterno"].ToString() + " " + row["Materno"].ToString()).Trim();
                if (doc.Nombres + " " + doc.Paterno + " " + doc.Materno == Nombres)
                    return row["CodDocente"].ToString();
            }
            return "";
        }
        public string buscarCurso(E_Curso cur, DataTable dt)
        {
            if (dt == null) return "";
            foreach (DataRow row in dt.Rows)
            {
                string CodCurso = row["CodCurso"].ToString();
                if (cur.CodCurso == CodCurso)
                    return CodCurso;
            }
            return "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            N_Docente n_Docente = new N_Docente();
            DataTable dt_Docentes = n_Docente.ObtenerDocentes();

            N_Curso n_Curso = new N_Curso();
            DataTable dt_Cursos = n_Curso.ObtenerCursos();
            List<N_Asignacion> noGuardados = new List<N_Asignacion>();
            // Guardar docentes no existentes
            foreach (E_Docente docente in carga.getDocentes())
            {
                if (buscarDocente(docente, dt_Docentes) == "")
                {
                    Frm_AddDocente frmDocente = new Frm_AddDocente(docente);
                    frmDocente.ShowDialog();
                    dt_Docentes = n_Docente.ObtenerDocentes();
                }
            }
            // guardar cursos no existentes
            foreach (E_Curso curso in carga.getCursos())
            {
                if (buscarCurso(curso, dt_Cursos) == "")
                {
                    Frm_AddCurso frmCurso = new Frm_AddCurso(curso);
                    frmCurso.ShowDialog();
                }
            }

            dt_Docentes = n_Docente.ObtenerDocentes();
            dt_Cursos = n_Curso.ObtenerCursos();
            // Guardar asignaciones no existentes
            foreach (N_Asignacion asignacion in carga.getCarga())
            {
                asignacion.Semestre = curSemestre;
                if (asignacion.Guardar(dt_Docentes, dt_Cursos, dt_Asignacion) == -1)
                    noGuardados.Add(asignacion);
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

            panelGuardar.Visible = false;
            panelCrud.Visible = true;
            RefrescarDGV();
        }

        private void C_Carga_Load(object sender, EventArgs e)
        {
            panelGuardar.Visible = false;
            panelCrud.Visible = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_AddAsignacion AddAsignacion = new Frm_AddAsignacion();
            AddAsignacion.ShowDialog();
            RefrescarDGV();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCarga.Rows.Count > 0)
            {
                int index = dgvCarga.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvCarga.Rows.Count - 1)
                {
                    E_Asignacion e_Asignacion = new E_Asignacion
                    {
                        ID = Int32.Parse(dgvCarga.Rows[index].Cells[0].Value.ToString()),
                        Semestre = dgvCarga.Rows[index].Cells[1].Value.ToString(),
                        CodDocente = dgvCarga.Rows[index].Cells[2].Value.ToString(),
                        CodCurso = dgvCarga.Rows[index].Cells[3].Value.ToString(),
                        Grupo = dgvCarga.Rows[index].Cells[5].Value.ToString(),
                        Aula = dgvCarga.Rows[index].Cells[11].Value.ToString(),
                    };
                    N_Dia n_Dia = new N_Dia();
                    List<E_Dia> tmpDias = n_Dia.BuscarAsignacion(dgvCarga.Rows[index].Cells[0].Value.ToString());
                    e_Asignacion.Dias = tmpDias;
                    Frm_AddAsignacion AddAsignacion = new Frm_AddAsignacion(e_Asignacion, true);
                    AddAsignacion.ShowDialog();
                    RefrescarDGV();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvCarga.Rows.Count > 0)
            {
                int index = dgvCarga.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvCarga.Rows.Count - 1)
                {
                    String ID = dgvCarga.Rows[index].Cells[0].Value.ToString();
                    DialogResult confirm = MessageBox.Show("¿Realmente desea eliminar el curso " + ID + "?", "Sistema de Silabos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (confirm == DialogResult.OK)
                    {
                        if (new N_Asignacion().Eliminar(ID))
                            MessageBox.Show("Curso " + ID + " eliminado!");
                        else
                            MessageBox.Show("No se pudo eliminar Curso " + ID + "!");
                        RefrescarDGV();
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            carga = null;
            RefrescarDGV();
        }

        private void cbSemestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarDGV(cbSemestre.SelectedItem.ToString());
        }
    }
}
