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
using CapaNegocio;
using CapaEntidades;
using System.ComponentModel.DataAnnotations;

namespace CapaPresentacion
{
    public partial class FrmAddSilabo : Form
    {
        E_Silabo e_Silabo;
        bool Editar = false;
        public FrmAddSilabo(E_Silabo Silabo = null, bool Editar = false)
        {
            e_Silabo = Silabo;
            this.Editar = Editar;
            InitializeComponent();
        }

        private void FrmAddSilabo_Load(object sender, EventArgs e)
        {
            if(e_Silabo != null)
            {
                txtCodCurso.Text = e_Silabo.CodCurso == null ? "" : e_Silabo.CodCurso;
                txtUnidad.Text = e_Silabo.Unidad == null ? "" : e_Silabo.Unidad;
                txtCapitulo.Text = e_Silabo.Capitulo == null ? "" : e_Silabo.Capitulo;
                txtTema.Text = e_Silabo.Tema == null ? "" : e_Silabo.Tema;
                txtNroHoras.Text = e_Silabo.NroHoras.ToString() == null ? "" : e_Silabo.NroHoras.ToString();
                btn_AgregarEditarSilabo.Text = "GUARDAR";
            }
            else
                e_Silabo = new E_Silabo();
            if (Editar)
            {
                btn_AgregarEditarSilabo.Text = "EDITAR";
                txtCodCurso.Enabled = false;
            }
        }

        private void btn_AgregarEditarSilabo_Click(object sender, EventArgs e)
        {
            N_Silabo n_Silabo = new N_Silabo();
            n_Silabo.ID = e_Silabo.ID;
            n_Silabo.Semestre = e_Silabo.Semestre;
            n_Silabo.CodCurso = txtCodCurso.Text.Trim();
            n_Silabo.Unidad = txtUnidad.Text.Trim();
            n_Silabo.Capitulo = txtCapitulo.Text.Trim();
            n_Silabo.Tema = txtTema.Text.Trim();
            n_Silabo.NroHoras = Int32.Parse(txtNroHoras.Text.Trim());
            ValidationContext context = new ValidationContext(n_Silabo, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(n_Silabo, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);
            }
            else
            {
                if (Editar)
                {
                    if (n_Silabo.Editar())
                        MessageBox.Show("Se edito correctamenete");
                    else
                        MessageBox.Show("Error. Docente no editado");
                    Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
