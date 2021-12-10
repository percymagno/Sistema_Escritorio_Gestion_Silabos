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
    public partial class Frm_AddDocente : Form
    {
        E_Docente e_Docente;
        DataTable dt = new N_Regimen().Mostrar();
        bool Editar = false;
        public Frm_AddDocente(E_Docente Docente = null, bool Editar = false)
        {
            e_Docente = Docente;
            this.Editar = Editar;
            InitializeComponent();
        }
        private void btn_agregarDocente_Click(object sender, EventArgs e)
        {
            N_Docente n_Docente = new N_Docente();
            n_Docente.CodDocente = text_codigo.Text.Trim();
            n_Docente.Paterno = text_paterno.Text.Trim();
            n_Docente.Materno = text_materno.Text.Trim();
            n_Docente.Nombre = text_nombre.Text.Trim();
            n_Docente.Regimen = comboBox_regimen.SelectedItem.ToString().Trim();
            n_Docente.Correo = text_correo.Text.Trim();
            n_Docente.Telefono = text_telefono.Text.Trim();
            ValidationContext context = new ValidationContext(n_Docente, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(n_Docente, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);
            }
            else
            {
                if (Editar)
                {
                    if (n_Docente.EditarDocente())
                        MessageBox.Show("Se edito correctamenete");
                    else
                        MessageBox.Show("Error. Docente no editado");
                    Close();
                }
                else
                {
                    if (n_Docente.AgregarDocente())
                        MessageBox.Show("Se agrego correctamente");
                    else
                        MessageBox.Show("Error. Docente no agregado");
                    if (btn_agregarDocente.Text == "GUARDAR")
                        Close();
                    restablecer();
                }
            }
        }
        #region restablecer
        private void restablecer()
        {
            text_codigo.Text = "";
            text_paterno.Text = "";
            text_materno.Text = "";
            text_nombre.Text = "";
            comboBox_regimen.SelectedItem = dt.Rows[0][0];
            text_correo.Text = "";
            text_telefono.Text = "";
        }
        #endregion

        private void Frm_AddDocente_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in dt.Rows)
            {
                comboBox_regimen.Items.Add(row[0]);
            }
            comboBox_regimen.SelectedItem = dt.Rows[0][0];

            if (e_Docente != null)
            {
                text_codigo.Text = e_Docente.CodDocente == null ? "" : e_Docente.CodDocente;
                text_nombre.Text = e_Docente.Nombres == null ? "" : e_Docente.Nombres;
                text_paterno.Text = e_Docente.Paterno == null ? "" : e_Docente.Paterno;
                text_materno.Text = e_Docente.Materno == null ? "" : e_Docente.Materno;
                text_telefono.Text = e_Docente.Telefono == null ? "" : e_Docente.Telefono;
                text_correo.Text = e_Docente.Correo == null ? "" : e_Docente.Correo;
                comboBox_regimen.SelectedItem = e_Docente.Regimen == null ? "" : dt.Rows[0][0];

                btn_agregarDocente.Text = "GUARDAR";
            }
            else
                e_Docente = new E_Docente();
            if (Editar)
            {
                btn_agregarDocente.Text = "EDITAR";
                text_codigo.Enabled = false;
            }
        }
    }
}
