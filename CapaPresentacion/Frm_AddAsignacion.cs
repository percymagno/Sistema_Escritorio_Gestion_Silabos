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
using System.ComponentModel.DataAnnotations;

namespace CapaPresentacion
{
    public partial class Frm_AddAsignacion : Form
    {
        E_Asignacion Asignacion;
        bool Editar = false;
        DataTable dt_docente;
        DataTable dt_curso;

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
            D_Docente d_Docente = new D_Docente();
            dt_docente = d_Docente.MostrarDocentes();
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
            N_Curso n_Curso = new N_Curso();
            dt_curso = n_Curso.ObtenerCursos();
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
            N_Semestre n_Semestre = new N_Semestre();
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
        }
        private void Frm_AddAsignacion_Load()
        {
            defaultComboBoxItems();
            if (Asignacion != null)
            {
                
                tbID.Text = Asignacion.ID.ToString();
                tbSemestre.Text = Asignacion.Semestre;
                cboxDocente.SelectedItem = Asignacion.CodDocente;
                cboxCurso.SelectedItem = Asignacion.CodCurso;
                cboxTipo.SelectedItem = Asignacion.Tipo;
                cboxGrupo.SelectedItem = Asignacion.Grupo;
                numHT.Value = Asignacion.HT;
                numHP.Value = Asignacion.HP;
                List<string> list = new List<string> { "LUNES", "MARTES", "MIERCOLES", "JUEVES", "VIERNES", "SABADO", "DOMINGO" };
                checkedListDia.SetItemChecked(list.IndexOf(Asignacion.Dia), true);
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

        private void btnAgregarAsignacion_Click(object sender, EventArgs e)
        {
            foreach (string item in checkedListDia.CheckedItems)
            {
                N_Asignacion n_Asignacion = new N_Asignacion();
                n_Asignacion.ID = Int32.Parse(tbID != null && tbID.Text != "" ? tbID.Text : "-1");
                n_Asignacion.Docente = new E_Docente { CodDocente = cboxDocente.SelectedValue.ToString() };
                n_Asignacion.Curso = new E_Curso { CodCurso = cboxCurso.SelectedValue.ToString() };
                n_Asignacion.Semestre = tbSemestre.Text;
                n_Asignacion.Tipo = cboxTipo.SelectedItem.ToString();
                n_Asignacion.Grupo = cboxGrupo.SelectedItem.ToString();
                n_Asignacion.HT = (int)numHT.Value;
                n_Asignacion.HP = (int)numHP.Value;
                n_Asignacion.Dia = item.ToString();
                n_Asignacion.Aula = tbAula.Text.Trim();
                n_Asignacion.HR_inicio = (int)numHR_inicio.Value;
                n_Asignacion.HR_fin = (int)numHR_fin.Value;

                ValidationContext context = new ValidationContext(n_Asignacion, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();
                if (!Validator.TryValidateObject(n_Asignacion, context, errors, true))
                {
                    foreach (ValidationResult result in errors)
                        MessageBox.Show(result.ErrorMessage);
                }
                else
                {
                    if (this.Editar)
                    {
                        if (n_Asignacion.Editar())
                            MessageBox.Show("Se edito correctamenete");
                        else
                            MessageBox.Show("Error. Curso no editado");
                        Close();
                    }
                    else
                    {
                        int ans = n_Asignacion.Guardar(dt_docente, dt_curso);
                        if (ans == 1)
                            MessageBox.Show("Se agrego correctamente");
                        else if (ans == 0)
                            MessageBox.Show("Curso ya existe en la base de datos");
                        else
                            MessageBox.Show("Error. Curso no agregado");
                        if (btnAgregarAsignacion.Text == "GUARDAR")
                            Close();
                        defaultComboBoxItems();
                    }
                }
            }
        }
    }
}
