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
    public partial class C_CRUDDocente : UserControl
    {
        public C_CRUDDocente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_AddDocente AddDocente = new Frm_AddDocente();
            AddDocente.Show();
        }
    }
}
