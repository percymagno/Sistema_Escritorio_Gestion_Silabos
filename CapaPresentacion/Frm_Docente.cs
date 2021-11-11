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
    public partial class Frm_Docente : Form
    {
        public Frm_Docente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_AddDocente AddDocente = new Frm_AddDocente();
            this.Visible=false;
            AddDocente.Show();

        }
    }
}
