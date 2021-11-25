using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class Frm_AddCurso : Form
    {
        E_Curso Curso;
        bool Editar = false;
        public Frm_AddCurso(E_Curso Curso=null, bool Editar = false)
        {
            this.Curso = Curso;
            this.Editar = Editar;
            InitializeComponent();
        }

        private void btn_agregarCurso_Click(object sender, EventArgs e)
        {
            N_Curso n_Curso = new N_Curso();
            n_Curso.CodCurso = text_codigo.Text.Trim();
            n_Curso.Nombre = text_nombre.Text.Trim();
            n_Curso.Creditos = Int32.Parse(Cb_creditos.SelectedItem.ToString().Trim());
            n_Curso.Categoria = text_categoria.Text.Trim();
            ValidationContext context = new ValidationContext(Curso, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if(!Validator.TryValidateObject(Curso, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);
            }
            else
            {
                if (this.Editar)
                {
                    if (n_Curso.EditarCurso())
                        MessageBox.Show("Se edito correctamenete");
                    else
                        MessageBox.Show("Error. Curso no editado");
                    Close();
                }
                else
                {
                    if (n_Curso.AgregarCurso())
                        MessageBox.Show("Se agrego correctamente");
                    else
                        MessageBox.Show("Error. Curso no agregado");
                    if (btn_agregarCurso.Text == "GUARDAR")
                        Close();
                    reestablecer();
                }
            }
        }

        #region restablecer
        private void reestablecer()
        {
            Curso = new E_Curso();
            // texbox
            text_codigo.Text = "";
            text_nombre.Text = "";
            Cb_creditos.SelectedItem = "4";
            text_categoria.Text = "";
        }
        #endregion reestablecer

        private void Frm_AddCurso_Load(object sender, EventArgs e)
        {
            this.Cb_creditos.SelectedItem = "4";
            if (Curso != null)
            {
                text_codigo.Text = Curso.CodCurso == null ? "" : Curso.CodCurso;
                text_nombre.Text = Curso.Nombre == null ? "" : Curso.Nombre;
                Cb_creditos.Text = Curso.Creditos == null ? "" : Curso.Creditos.ToString();
                text_categoria.Text = Curso.Categoria == null ? "" : Curso.Categoria.ToString();

                btn_agregarCurso.Text = "GUARDAR";
            }
            else
                Curso = new E_Curso();

            if (Editar)
            {
                text_codigo.Enabled = false;
                btn_agregarCurso.Text = "EDITAR";
            }

        }
    }
}
