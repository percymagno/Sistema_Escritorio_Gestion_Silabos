using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class Frm_AddAsignacion : Form
    {
        E_Asignacion Asignacion;
        bool Editar = false;
        D_Docente d_Docente = new D_Docente();
        N_Curso n_Curso = new N_Curso();
        N_Semestre n_Semestre = new N_Semestre();

        public Frm_AddAsignacion(E_Asignacion Asignacion = null, bool Editar = false)
        {
            this.Asignacion = Asignacion;
            this.Editar = Editar;
            InitializeComponent();
            RellenarDocentes();
            RellenarCursos();
            RellenarSemestre();
            Frm_AddAsignacion_Load();
        }
        public void RellenarDocentes()
        {
            DataTable dt_docente = d_Docente.MostrarDocentes();
            if (dt_docente != null)
            {
                cboxDocente.DataSource = dt_docente;
                cboxDocente.DisplayMember = "Nombres";
                cboxDocente.ValueMember = "CodDocente";
                cboxDocente.SelectedIndex = 0;
            }
        }
        public void RellenarCursos()
        {
            DataTable dt_curso = n_Curso.ObtenerCursos();
            if(dt_curso != null)
            {
                cboxCurso.DataSource = dt_curso;
                cboxCurso.DisplayMember = "Nombre";
                cboxCurso.ValueMember = "CodCurso";
                cboxCurso.SelectedIndex = 0;
            }
        }
        public void RellenarSemestre()
        {
            DataRow dr_Semestre = n_Semestre.MostrarUltimo();
            if (dr_Semestre != null)
            {
                tbSemestre.Text = dr_Semestre[0].ToString();
            }
        }
        private void defaultComboBoxItems()
        {
            cboxTipo.SelectedIndex = 0;
            cboxGrupo.SelectedIndex = 0;
            cboxDia.SelectedIndex = 0;
        }
        private void Frm_AddAsignacion_Load()
        {
            defaultComboBoxItems();
            if (Asignacion != null)
            {
                //text_codigo.Text = Asignacion.CodCurso == null ? "" : Curso.CodCurso;
                tbID.Text = Asignacion.ID.ToString();
                tbSemestre.Text = Asignacion.Semestre;
                cboxDocente.SelectedItem = Asignacion.CodDocente;
                cboxCurso.SelectedItem = Asignacion.CodCurso;
                cboxTipo.SelectedItem = Asignacion.Tipo;
                cboxGrupo.SelectedItem = Asignacion.Grupo;
                numHT.Value = Asignacion.HT;
                numHP.Value = Asignacion.HP;
                cboxDia.SelectedItem = Asignacion.Dia;
                tbAula.Text = Asignacion.Aula;
                numHR_inicio.Value = Asignacion.HR_inicio;
                numHR_fin.Value = Asignacion.HR_fin;


                btnAgregarAsignacion.Text = "GUARDAR";
            }
            else
                Asignacion = new E_Asignacion();

            if (Editar)
            {
                btnAgregarAsignacion.Text = "EDITAR";
            }
        }
    }
}
