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
using CapaEntidades;
namespace CapaPresentacion
{
    public partial class Frm_AddCurso : Form
    {
        bool editar = false;
        public Frm_AddCurso()
        {
            InitializeComponent();
            RellenarDocentes();
        }
        public Frm_AddCurso(E_Curso Curso)
        {

            editar = true;
            InitializeComponent();
            text_codigo.Text = Curso.CodCurso;
            text_nombre.Text = Curso.Nombre;
            Cb_creditos.Text = Curso.Creditos.ToString();
            text_categoria.Text = Curso.Categoria.ToString();

            text_codigo.Enabled = false;

        }
        #region Validacion
        private bool Validar()
        {
            return (VerificarCampos() && VerificarHorarios());
        }
        private bool VerificarCampos()
        {
            bool valido = true;
            if (text_codigo.Text == "")
            {
                lblCodCurso.ForeColor = Color.Red;
                valido = false;
            }
            else if (text_nombre.Text == "")
            {
                lblNombre.ForeColor = Color.Red;
                valido = false;
            }
            if (!valido) MessageBox.Show("Campo vacío!!!");
            return valido;
        }
        private bool VerificarHorarios()
        {
            bool valido = true;
            // Check Lunes
            if (checkLunes.Checked && numLunesIni.Value >= numLunesFin.Value)
            {
                valido = false;
                numLunesFin.ForeColor = Color.Red;
            }
            else if (checkMartes.Checked && numMartesIni.Value >= numMartesFin.Value)
            {
                valido = false;
                numMartesFin.ForeColor = Color.Red;
            }
            else if(checkMiercoles.Checked && numMiercolesIni.Value >= numMiercolesFin.Value)
            {
                valido = false;
                numMiercolesFin.ForeColor = Color.Red;
            }
            else if(checkJueves.Checked && numJuevesIni.Value >= numJuevesFin.Value)
            {
                valido = false;
                numJuevesFin.ForeColor =  Color.Red;
            }
            else if(checkViernes.Checked && numViernesIni.Value >= numViernesFin.Value)
            {
                valido = false;
                numViernesFin.ForeColor = Color.Red;
            }
            else if(checkSabado.Checked && numSabadoIni.Value >= numSabadoFin.Value)
            {
                valido = false;
                numSabadoFin.ForeColor = Color.Red;
            }
            if (!valido) MessageBox.Show("Error! La hora de inicio debe ser menor a la hora de fin");
            return valido;
        }
        #endregion validacion
        private void RellenarDocentes()
        {
            DataTable dt = new D_Docente().MostrarDocentes();
            cbDocente.DataSource = dt;
            cbDocente.DisplayMember = "CodDocente";
            cbDocente.ValueMember = "CodDocente";
            cbDocente.Enabled = true;
        }

        private void btn_agregarCurso_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                E_Curso e_Curso = new E_Curso
                {
                    CodCurso = text_codigo.Text,
                    Nombre = text_nombre.Text,
                    Creditos = Int32.Parse(Cb_creditos.SelectedItem.ToString()),
                    Categoria = text_categoria.Text
                };
                D_Curso d_Curso = new D_Curso();

                if (this.editar)
                {
                    if (d_Curso.EditarCurso(e_Curso))
                        MessageBox.Show("Se edito correctamenete");
                    else
                        MessageBox.Show("Error. Curso no editado");
                    Close();
                }
                else
                {
                    if (d_Curso.AgregarCurso(e_Curso))
                        MessageBox.Show("Se agrego correctamente");
                    else
                        MessageBox.Show("Error. Curso no agregado");
                    reestablecer();
                }
            }
        }
        #region Checkbox
        private void checkLunes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLunes.Checked) pnlLunes.Enabled = true;
            else pnlLunes.Enabled = false;
        }

        private void checkMartes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMartes.Checked) pnlMartes.Enabled = true;
            else pnlMartes.Enabled = false;
        }

        private void checkMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMiercoles.Checked) pnlMiercoles.Enabled = true;
            else pnlMiercoles.Enabled = false;
        }

        private void checkJueves_CheckedChanged(object sender, EventArgs e)
        {
            if (checkJueves.Checked) pnlJueves.Enabled = true;
            else pnlJueves.Enabled = false;
        }

        private void checkViernes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkViernes.Checked) pnlViernes.Enabled = true;
            else pnlViernes.Enabled = false;
        }

        private void checkSabado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSabado.Checked) pnlSabado.Enabled = true;
            else pnlSabado.Enabled = false;
        }
        #endregion Checkbox

        #region restablecer
        private void reestablecer()
        {
            // texbox
            text_codigo.Text = "";
            text_nombre.Text = "";
            Cb_creditos.SelectedItem = "4";
            text_categoria.Text = "";
            cbDocente.SelectedItem = "";
            // checkbox
            checkLunes.Checked = false;
            checkMartes.Checked = false;
            checkMiercoles.Checked = false;
            checkJueves.Checked = false;
            checkViernes.Checked = false;
            checkSabado.Checked = false;
        }
        private void text_codigo_Enter(object sender, EventArgs e)
        {
            lblCodCurso.ForeColor = Color.Black;
        }

        private void text_nombre_Enter(object sender, EventArgs e)
        {
            lblNombre.ForeColor = Color.Black;
        }

        private void numLunesFin_Enter(object sender, EventArgs e)
        {
            numLunesFin.ForeColor = Color.Black;        
        }

        private void numMartesFin_Enter(object sender, EventArgs e)
        {
            numMartesFin.ForeColor = Color.Black;
        }

        private void numMiercolesFin_Enter(object sender, EventArgs e)
        {
            numMiercolesFin.ForeColor = Color.Black;
        }

        private void numJuevesFin_Enter(object sender, EventArgs e)
        {
            numJuevesFin.ForeColor = Color.Black;
        }

        private void numViernesFin_Enter(object sender, EventArgs e)
        {
            numViernesFin.ForeColor = Color.Black;
        }

        private void numSabadoFin_Enter(object sender, EventArgs e)
        {
            numSabadoFin.ForeColor = Color.Black;
        }
        #endregion reestablecer
    }
}
