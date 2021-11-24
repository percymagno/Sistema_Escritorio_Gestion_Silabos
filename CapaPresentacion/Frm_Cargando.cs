using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Frm_Cargando : Form
    {
        string mensaje = "";
        public Frm_Cargando(string str = "Cargando")
        {
            InitializeComponent();
            mensaje = str;
        }

        private void Frm_Cargando_Load(object sender, EventArgs e)
        {
            lblMensaje.Text = mensaje;
        }
    }
}
