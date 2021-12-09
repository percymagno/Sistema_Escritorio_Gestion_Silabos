using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class P_Login : Form
    {
        E_Usuario usuario;
        N_Usuario n_usuario;
        P_Director p_Director;
        Frm_Docente p_Docente;
        public P_Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd,int wsg,int wparam,int lparam);
        private void textUsuario_Enter(object sender, EventArgs e)
        {
            if(textUsuario.Text == "USUARIO")
            {
                textUsuario.Text = "";
                textUsuario.ForeColor = Color.LightGray;
            }
        }

        private void textUsuario_Leave(object sender, EventArgs e)
        {
            if (textUsuario.Text == "")
            {
                textUsuario.Text = "USUARIO";
                textUsuario.ForeColor = Color.DimGray ;
            }
        }

        private void textContraseña_Enter(object sender, EventArgs e)
        {
            if (textContraseña.Text == "CONTRASEÑA")
            {
                textContraseña.Text = "";
                textContraseña.ForeColor = Color.LightGray;
                textContraseña.UseSystemPasswordChar = true;
            }
        }

        private void textContraseña_Leave(object sender, EventArgs e)
        {
            if (textContraseña.Text == "")
            {
                textContraseña.Text = "CONTRASEÑA";
                textContraseña.ForeColor = Color.DimGray;
                textContraseña.UseSystemPasswordChar = false;
            }
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string Usuario = textUsuario.Text;
            string Contrasenia = textContraseña.Text;
            N_Usuario n_Usuario = new N_Usuario();
            usuario = n_Usuario.BuscarUsuario(Usuario, Contrasenia);
            if(usuario == null)
            {
                textUsuario.Text = "USUARIO";
                textContraseña.Text = "CONTRASEÑA";
                MessageBox.Show("Usuario o Contraseña incorrectos");
            }
            else
            {
                if(usuario.Acceso == "Administrador")
                {
                    p_Director = new P_Director();
                    p_Director.Show();
                    this.Visible = false;
                }
                else
                {
                    if(usuario.Acceso == "Docente")
                    {
                        p_Docente = new Frm_Docente(usuario.Usuario);
                        p_Docente.Show();
                        this.Visible=false;
                    }
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconoCarrera_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
