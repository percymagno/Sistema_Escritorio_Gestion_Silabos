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
    public partial class Frm_AddDocente : Form
    {
        E_Docente e_Docente;
        bool editar = false;
        public Frm_AddDocente()
        {
            InitializeComponent();
        }
        public Frm_AddDocente(E_Docente Docente)
        {
            editar = true;
            InitializeComponent();
            e_Docente = Docente;
            text_codigo.Text = Docente.CodDocente;
            text_nombre.Text = Docente.Nombres;
            text_paterno.Text = Docente.Paterno;
            text_materno.Text = Docente.Materno;
            text_telefono.Text = Docente.Telefono;
            text_correo.Text = Docente.Correo;
            text_departamento.Text = Docente.Departamento;
            text_condicion.Text = Docente.Condicion;
            btn_agregarDocente.Text = "EDITAR";
        }
        private void btn_agregarDocente_Click(object sender, EventArgs e)
        {
            D_Docente d_Docente = new D_Docente();
            e_Docente.CodDocente = text_codigo.Text.Trim();
            e_Docente.Paterno = text_paterno.Text.Trim();
            e_Docente.Materno = text_materno.Text.Trim();
            e_Docente.Nombres = text_nombre.Text.Trim();
            e_Docente.Departamento = text_departamento.Text.Trim();
            e_Docente.Condicion = text_condicion.Text.Trim();
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
            text_departamento.Text = "";
            text_condicion.Text = "";
            text_correo.Text = "";
            text_telefono.Text = "";
        }
        #endregion
    }
}
