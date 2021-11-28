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
    public partial class Frm_Docente : Form
    {
        string cod_docente;
        N_Servicio n_Servicio=new N_Servicio();
        public Frm_Docente(string pCod_docente = null)
        {
            InitializeComponent();
            cod_docente = pCod_docente;
        }

        private void Frm_Docente_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = new N_Docente().BuscarDocente(this.cod_docente).Rows[0]["Nombres"].ToString();
            dgvCursoDocentes.DataSource = n_Servicio.BuscarCurso(this.cod_docente);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.btnMaximize.Image = global::CapaPresentacion.Properties.Resources.minimize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.btnMaximize.Image = global::CapaPresentacion.Properties.Resources.stop;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
