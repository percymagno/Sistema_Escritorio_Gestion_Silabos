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
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Frm_AddCurso : Form
    {
        bool Editar;
        public Frm_AddCurso(N_Curso Curso=null)
        {
            InitializeComponent();
            RellenarDocentes();
            if (Curso != null)
            {
                text_codigo.Text = Curso.CodCurso;
                text_nombre.Text = Curso.Nombre;
                Cb_creditos.Text = Curso.Creditos.ToString();
                text_categoria.Text = Curso.Categoria.ToString();

                text_codigo.Enabled = false;

                btn_agregarCurso.Text = "EDITAR";

                Editar = true;
            }
            else
            {
                this.Cb_creditos.SelectedItem = "4";
                Editar &= false;
            }
        }
        private void RellenarDocentes(String CodDocente = "")
        {
            DataTable dt = new D_Docente().MostrarDocentes();
            if (dt != null)
            {
                DataRow row = dt.NewRow();
                row["CodDocente"] = "";
                row["Paterno"] = "";
                row["Materno"] = "";
                row["Nombres"] = "-- Vacio --";
                row["Departamento"] = "";
                row["Correo"] = "";
                dt.Rows.InsertAt(row, 0);
            }
            cbDocente.DataSource = dt;
            cbDocente.DisplayMember = "Nombres";
            cbDocente.ValueMember = "CodDocente";
            cbDocente.SelectedValue = CodDocente;
        }

        private void btn_agregarCurso_Click(object sender, EventArgs e)
        {
            N_Curso n_Curso = new N_Curso
            {
                CodCurso = text_codigo.Text,
                Nombre = text_nombre.Text,
                Creditos = Int32.Parse(Cb_creditos.SelectedItem.ToString()),
                Categoria = text_categoria.Text
            };
            ValidationContext context = new ValidationContext(n_Curso, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if(!Validator.TryValidateObject(n_Curso, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);
            }
            else
            {
                D_Curso d_Curso = new D_Curso();

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
                    reestablecer();
                }
            }
        }

        #region restablecer
        private void reestablecer()
        {
            // texbox
            text_codigo.Text = "";
            text_nombre.Text = "";
            Cb_creditos.SelectedItem = "4";
            text_categoria.Text = "";
            cbDocente.SelectedItem = "";
        }
        #endregion reestablecer
    }
}
