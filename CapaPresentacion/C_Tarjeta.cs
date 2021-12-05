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

namespace CapaPresentacion
{
    public partial class C_Tarjeta : UserControl
    {
        private E_Curso curso;
        public C_Tarjeta(E_Curso pCurso)
        {
            curso = pCurso;

            InitializeComponent();
        }

        private void C_Tarjeta_Load(object sender, EventArgs e)
        {
            // lblTitulo color de fondo
            Random rnd = new Random();
            int r = rnd.Next(90, 180), g = rnd.Next(90, 180), b = rnd.Next(90, 180);
            lblTitulo.BackColor = Color.FromArgb(r, g, b);
            // lbltitulo
            lblTitulo.Text = curso.Nombre;
        }

        private void btnSilabo_Click(object sender, EventArgs e)
        {
            // curso.CodCurso
        }
    }
}
