using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class P_Director : Form
    {
        // controles
        private C_CRUDDocente c_CRUDDocente1;
        private C_CRUDCurso c_CRUDCurso1;
        private C_Carga c_Carga1;
        public P_Director()
        {
            InitializeComponent();
            Init_C_CRUD_Docente();
            Init_C_CRUD_Curso();
            Init_C_Carga();
        }

        #region funciones para abrir, cerrar, minimizar mover y cambiar tamaño de form
        // hacer el form movible
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        #endregion
        #region min,max, close
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region movimiento de ventanas
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        #endregion
        #region CONTROLES
        private void Init_C_CRUD_Docente()
        {
            this.c_CRUDDocente1 = new CapaPresentacion.C_CRUDDocente();
            this.panelMain.Controls.Add(this.c_CRUDDocente1);

            // 
            // c_CRUDDocente1
            // 
            this.c_CRUDDocente1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_CRUDDocente1.Location = new System.Drawing.Point(0, 0);
            this.c_CRUDDocente1.Name = "c_CRUDDocente1";
            this.c_CRUDDocente1.Size = new System.Drawing.Size(600, 420);
            this.c_CRUDDocente1.TabIndex = 0;
        }
        private void Init_C_CRUD_Curso()
        {
            this.c_CRUDCurso1 = new CapaPresentacion.C_CRUDCurso();
            this.panelMain.Controls.Add(this.c_CRUDCurso1);

            // 
            // c_CRUDCurso1
            // 
            this.c_CRUDCurso1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_CRUDCurso1.Location = new System.Drawing.Point(0, 0);
            this.c_CRUDCurso1.Name = "c_CRUDCurso1";
            this.c_CRUDCurso1.Size = new System.Drawing.Size(600, 420);
            this.c_CRUDCurso1.TabIndex = 1;
            this.c_CRUDCurso1.SendToBack();
        }
        private void Init_C_Carga()
        {
            this.c_Carga1 = new CapaPresentacion.C_Carga();
            this.panelMain.Controls.Add(this.c_Carga1);

            // 
            // c_Carga1
            //
            this.c_Carga1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_Carga1.Location = new System.Drawing.Point(0, 0);
            this.c_Carga1.Name = "c_Carga1";
            this.c_Carga1.Size = new System.Drawing.Size(600, 420);
            this.c_Carga1.TabIndex = 2;
            this.c_Carga1.SendToBack();
        }
        #endregion
        private void btnDocentes_Click(object sender, EventArgs e)
        {
            this.c_CRUDDocente1.BringToFront();
            this.c_CRUDDocente1.Enabled = true;
            this.btnDocentes.BackColor = Color.White;
            this.btnCarga.BackColor = Color.FromArgb(68, 170, 211);
            this.btnCursos.BackColor = Color.FromArgb(68, 170, 211);
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            this.c_CRUDCurso1.BringToFront();
            this.c_CRUDCurso1.Enabled = true;
            this.btnCursos.BackColor = Color.White;
            this.btnCarga.BackColor = Color.FromArgb(68, 170, 211);
            this.btnDocentes.BackColor = Color.FromArgb(68, 170, 211);
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            this.c_Carga1.BringToFront();
            this.c_CRUDCurso1.Enabled = false;
            this.c_CRUDDocente1.Enabled = false;
            this.btnCarga.BackColor = Color.White;
            this.btnCursos.BackColor = Color.FromArgb(68, 170, 211);
            this.btnDocentes.BackColor = Color.FromArgb(68, 170, 211);
        }
    }
}
