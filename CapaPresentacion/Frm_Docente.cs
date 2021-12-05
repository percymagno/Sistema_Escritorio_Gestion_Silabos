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
        //movimiento variables
        int mov;
        int movX, movY;

        string cod_docente;
        N_Servicio n_Servicio=new N_Servicio();
        C_CajaTarjetas caja;
        public Frm_Docente(string pCod_docente = null)
        {
            InitializeComponent();
            cod_docente = pCod_docente;
        }
        private void crearCajaTarjeta(List<E_Curso> cursos)
        {
            caja = new C_CajaTarjetas(cursos);
            caja.Location = new Point(5, 5);
            caja.Name = "cajaTarjetas";
            caja.Size = new Size(600, 300);
            caja.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            caja.TabIndex = 0;
            panelPrincipal.Controls.Add(caja);
        }
        private void Frm_Docente_Load(object sender, EventArgs e)
        {
            // form load en el monitor actual
            this.Location = Screen.AllScreens[0].WorkingArea.Location;

            DataTable dt = n_Servicio.BuscarCurso(this.cod_docente);
            List<E_Curso> cursos = new List<E_Curso>();
            foreach(DataRow dr in dt.Rows)
            {
                E_Curso curso = new E_Curso();
                curso.Nombre = dr["Nombre"].ToString();
                curso.CodCurso = dr["CodCurso"].ToString();
                curso.Grupo = dr["Grupo"].ToString();
                cursos.Add(curso);
            }
            // crear control caja_tarjetas
            crearCajaTarjeta(cursos);

            lblUsuario.Text = new N_Docente().BuscarDocente(this.cod_docente).Rows[0]["Nombres"].ToString();
            //dgvCursoDocentes.DataSource = n_Servicio.BuscarCurso(this.cod_docente);
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

        // Movimiento de ventana
        private void activarMover(MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            activarMover(e);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            activarMover(e);
        }
    }
}
