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
        P_Director p_Director;
        P_Docente p_Docente;
        public P_Login()
        {
            InitializeComponent();
        }
        private void textUsuario_Enter(object sender, EventArgs e)
        {
            if(textUsuario.Text == "USUARIO")
            {
                textUsuario.Text = "";
                textUsuario.ForeColor = Color.Black;
            }
        }

        private void textUsuario_Leave(object sender, EventArgs e)
        {
            if (textUsuario.Text == "")
            {
                textUsuario.Text = "USUARIO";
                textUsuario.ForeColor = Color.DarkGray ;
            }
        }

        private void textContraseña_Enter(object sender, EventArgs e)
        {
            if (textContraseña.Text == " CONTRASEÑA")
            {
                textContraseña.Text = "";
                textContraseña.ForeColor = Color.Black;
                textContraseña.UseSystemPasswordChar = true;
            }
        }

        private void textContraseña_Leave(object sender, EventArgs e)
        {
            if (textContraseña.Text == "")
            {
                textContraseña.Text = " CONTRASEÑA";
                textContraseña.ForeColor = Color.DarkGray;
                textContraseña.UseSystemPasswordChar = false;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string Usuario = textUsuario.Text;
            string Contrasenia = textContraseña.Text;
            N_Usuario n_Usuario = new N_Usuario();
            usuario = n_Usuario.BuscarUsuario(Usuario, Contrasenia);
            if(usuario == null)
            {
                MessageBox.Show("Usuario o Contraseña incorrectos");
            }
            else
            {
                if (usuario.Acceso == "Administrador")
                {
                    this.Visible = false;
                    p_Director = new P_Director();
                    p_Director.FormClosing += frm_FormClosing;
                    p_Director.Show();
                }
                else
                {
                    if(usuario.Acceso == "Docente")
                    {
                        this.Visible = false;
                        p_Docente = new P_Docente(usuario.Usuario);
                        p_Docente.FormClosing += frm_FormClosing;
                        p_Docente.Show();
                    }
                }

                textUsuario.Text = "USUARIO";
                textUsuario.ForeColor = Color.DarkGray;
                textContraseña.Text = "CONTRASEÑA";
                textContraseña.ForeColor = Color.DarkGray;
                textContraseña.UseSystemPasswordChar = false;
            }
        }

        void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = true;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
