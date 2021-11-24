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
namespace CapaPresentacion
{
    public partial class Frm_AddDocente : Form
    {
        E_Docente e_Docente;
        DataTable dt = new N_Regimen().Mostrar();
        bool editar = false;
        public Frm_AddDocente()
        {
            InitializeComponent();
        }
        public Frm_AddDocente(E_Docente Docente = null)
        {
            if (Docente != null)
            {
                e_Docente = Docente;
                editar = true;
            }
            InitializeComponent();
        }
        private void btn_agregarDocente_Click(object sender, EventArgs e)
        {
            D_Docente d_Docente = new D_Docente();
            e_Docente.CodDocente = text_codigo.Text.Trim();
            e_Docente.Paterno = text_paterno.Text.Trim();
            e_Docente.Materno = text_materno.Text.Trim();
            e_Docente.Nombres = text_nombre.Text.Trim();
            e_Docente.Regimen = comboBox_regimen.SelectedItem.ToString().Trim();
            e_Docente.Correo = text_correo.Text.Trim();
            e_Docente.Telefono = text_telefono.Text.Trim();
            if (this.editar)
            {
                if (d_Docente.EditarDocente(e_Docente))
                    MessageBox.Show("Se edito correctamenete");
                else
                    MessageBox.Show("Error. Curso no editado");
                Close();
            }
            else
            {
                if (d_Docente.AgregarDocente(e_Docente))
                    MessageBox.Show("Se agrego correctamente");
                else
                    MessageBox.Show("Error. Curso no agregado");
                restablecer();
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
            if (editar)
            {
                text_codigo.Text = e_Docente.CodDocente;
                text_nombre.Text = e_Docente.Nombres;
                text_paterno.Text = e_Docente.Paterno;
                text_materno.Text = e_Docente.Materno;
                text_telefono.Text = e_Docente.Telefono;
                text_correo.Text = e_Docente.Correo;
                comboBox_regimen.SelectedItem = e_Docente.Regimen;
                btn_agregarDocente.Text = "EDITAR";
            }
        }
    }
}
