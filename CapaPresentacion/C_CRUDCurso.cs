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
    public partial class C_CRUDCurso : UserControl
    {
        public C_CRUDCurso()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_AddCurso AddCurso = new Frm_AddCurso();
            AddCurso.Show();
        }
    }
}
