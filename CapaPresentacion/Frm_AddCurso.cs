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
        public Frm_AddCurso()
        {
            InitializeComponent();
        }

        private void btn_agregarCurso_Click(object sender, EventArgs e)
        {
            E_Curso e_Curso = new E_Curso { CodCurso=text_codigo.Text,
                                            Nombre=text_nombre.Text,
                                            Creditos=(Cb_creditos.SelectedIndex+1),
                                            Categoria=text_categoria.Text};
            D_Curso d_Curso = new D_Curso();
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
