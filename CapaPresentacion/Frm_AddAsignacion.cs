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
            if (dt_curso != null)
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
            //cboxTipo.SelectedIndex = 0;
            cboxGrupo.SelectedIndex = 0;
        }
        private void rellenarDias(List<E_Dia> Dias)
        {
            foreach (E_Dia dia in Dias)
            {
                if (dia.Dia.ToLower() == "lunes")
                {
                    checkLunes.Checked = true;
                    cBoxLunes.SelectedItem = dia.Tipo;
                    numericLunesIni.Value = dia.HR_inicio;
                    numericLunesFin.Value = dia.HR_fin;
                }
                else if (dia.Dia.ToLower() == "martes")
                {
                    checkMartes.Checked = true;
                    cBoxMartes.SelectedItem = dia.Tipo;
                    numericMartesIni.Value = dia.HR_inicio;
                    numericMartesFin.Value = dia.HR_fin;
                }
                else if (dia.Dia.ToLower() == "miercoles")
                {
                    checkMiercoles.Checked = true;
                    cBoxMiercoles.SelectedItem = dia.Tipo;
                    numericMiercolesIni.Value = dia.HR_inicio;
                    numericMiercolesFin.Value = dia.HR_fin;
                }
                else if (dia.Dia.ToLower() == "jueves")
                {
                    checkJueves.Checked = true;
                    cBoxJueves.SelectedItem = dia.Tipo;
                    numericJuevesIni.Value = dia.HR_inicio;
                    numericJuevesFin.Value = dia.HR_fin;
                }
                else if (dia.Dia.ToLower() == "viernes")
                {
                    checkViernes.Checked = true;
                    cBoxViernes.SelectedItem = dia.Tipo;
                    numericViernesIni.Value = dia.HR_inicio;
                    numericViernesFin.Value = dia.HR_fin;
                }
                else if (dia.Dia.ToLower() == "sabado")
                {
                    checkSabado.Checked = true;
                    cBoxSabado.SelectedItem = dia.Tipo;
                    numericSabadoIni.Value = dia.HR_inicio;
                    numericSabadoFin.Value = dia.HR_fin;
                }
            }
        }
        private void Frm_AddAsignacion_Load()
        {

            defaultComboBoxItems();
            if (Asignacion != null)
            {
                tbID.Text = Asignacion.ID.ToString();
                tbSemestre.Text = Asignacion.Semestre;
                cboxDocente.SelectedValue = Asignacion.CodDocente;
                cboxCurso.SelectedValue = Asignacion.CodCurso;
                cboxGrupo.SelectedItem = Asignacion.Grupo;
                tbAula.Text = Asignacion.Aula;
                btnAgregarAsignacion.Text = "GUARDAR";
                rellenarDias(Asignacion.Dias);
            }
            else
                Asignacion = new E_Asignacion();

            if (Editar)
            {
                btnAgregarAsignacion.Text = "EDITAR";
            }
        }
        private List<E_Dia> getDias()
        {
            List<E_Dia> Dias = new List<E_Dia>();
            if (checkLunes.Checked)
            {
                E_Dia tmpDia = new E_Dia();
                tmpDia.Dia = "Lunes";
                tmpDia.HR_inicio = Decimal.ToInt32(numericLunesIni.Value);
                tmpDia.HR_fin = Decimal.ToInt32(numericLunesFin.Value);
                tmpDia.Tipo = cBoxLunes.Text;
                Dias.Add(tmpDia);
            }
            if (checkMartes.Checked)
            {
                E_Dia tmpDia = new E_Dia();
                tmpDia.Dia = "Martes";
                tmpDia.HR_inicio = Decimal.ToInt32(numericMartesIni.Value);
                tmpDia.HR_fin = Decimal.ToInt32(numericMartesFin.Value);
                tmpDia.Tipo = cBoxMartes.Text;
                Dias.Add(tmpDia);
            }
            if (checkMiercoles.Checked)
            {
                E_Dia tmpDia = new E_Dia();
                tmpDia.Dia = "Miercoles";
                tmpDia.HR_inicio = Decimal.ToInt32(numericMiercolesIni.Value);
                tmpDia.HR_fin = Decimal.ToInt32(numericMiercolesFin.Value);
                tmpDia.Tipo = cBoxMiercoles.Text;
                Dias.Add(tmpDia);
            }
            if (checkJueves.Checked)
            {
                E_Dia tmpDia = new E_Dia();
                tmpDia.Dia = "Jueves";
                tmpDia.HR_inicio = Decimal.ToInt32(numericJuevesIni.Value);
                tmpDia.HR_fin = Decimal.ToInt32(numericJuevesFin.Value);
                tmpDia.Tipo = cBoxJueves.Text;
                Dias.Add(tmpDia);
            }
            if (checkViernes.Checked)
            {
                E_Dia tmpDia = new E_Dia();
                tmpDia.Dia = "Viernes";
                tmpDia.HR_inicio = Decimal.ToInt32(numericViernesIni.Value);
                tmpDia.HR_fin = Decimal.ToInt32(numericViernesFin.Value);
                tmpDia.Tipo = cBoxViernes.Text;
                Dias.Add(tmpDia);
            }
            if (checkSabado.Checked)
            {
                E_Dia tmpDia = new E_Dia();
                tmpDia.Dia = "Sabado";
                tmpDia.HR_inicio = Decimal.ToInt32(numericSabadoIni.Value);
                tmpDia.HR_fin = Decimal.ToInt32(numericSabadoFin.Value);
                tmpDia.Tipo = cBoxSabado.Text;
                Dias.Add(tmpDia);
            }
            return Dias;
        }

        private void btnAgregarAsignacion_Click(object sender, EventArgs e)
        {
            N_Asignacion n_Asignacion = new N_Asignacion();
            n_Asignacion.ID = Int32.Parse(tbID != null && tbID.Text != "" ? tbID.Text : "-1");
            n_Asignacion.Docente = new E_Docente { CodDocente = cboxDocente.SelectedValue.ToString() };
            n_Asignacion.Curso = new E_Curso { CodCurso = cboxCurso.SelectedValue.ToString() };
            n_Asignacion.Semestre = tbSemestre.Text;
            n_Asignacion.Grupo = cboxGrupo.SelectedItem.ToString();
            n_Asignacion.Aula = tbAula.Text.Trim();

            List<E_Dia> Dias = getDias();

            if(Dias.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un día");
            }
            else
            {
                n_Asignacion.Dias = Dias;
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

            /*
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
            }*/
        }

        private void checkLunes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLunes.Checked) panelLunes.Visible = true;
            else panelLunes.Visible = false;
        }

        private void checkMartes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMartes.Checked) panelMartes.Visible = true;
            else panelMartes.Visible = false;
        }

        private void checkMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMiercoles.Checked) panelMiercoles.Visible = true;
            else panelMiercoles.Visible = false;
        }

        private void checkJueves_CheckedChanged(object sender, EventArgs e)
        {
            if (checkJueves.Checked) panelJueves.Visible = true;
            else panelJueves.Visible = false;
        }

        private void checkViernes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkViernes.Checked) panelViernes.Visible = true;
            else panelViernes.Visible = false;
        }

        private void checkSabado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSabado.Checked) panelSabado.Visible = true;
            else panelSabado.Visible = false;
        }
    }
}
