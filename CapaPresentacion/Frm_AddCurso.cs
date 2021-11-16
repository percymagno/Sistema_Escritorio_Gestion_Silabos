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
            if (VerificarCampos())
            {
                E_Curso e_Curso = new E_Curso
                {
                    CodCurso = text_codigo.Text,
                    Nombre = text_nombre.Text,
                    Creditos = (Cb_creditos.SelectedIndex + 1),
                    Categoria = text_categoria.Text
                };
                D_Curso d_Curso = new D_Curso();

                if (this.editar)
                {
                    if (d_Curso.EditarCurso(e_Curso))
                    {
                        MessageBox.Show("Se edito correctamenete");
                    }
                    else
                    {
                        MessageBox.Show("Error. No se pudo editar curso");
                    }
                    Close();
                }
                else
                {
                    if (d_Curso.AgregarCurso(e_Curso))
                    {
                        MessageBox.Show("Se agrego correctamenete el curso");
                    }
                    else
                    {
                        MessageBox.Show("Error. No se pudo agregar curso");
                    }
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

        private void text_codigo_Enter(object sender, EventArgs e)
        {
            lblCodCurso.ForeColor = Color.Black;
        }

        private void text_nombre_Enter(object sender, EventArgs e)
        {
            lblNombre.ForeColor = Color.Black;
        }
    }
}
