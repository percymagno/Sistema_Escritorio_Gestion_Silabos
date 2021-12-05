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
    public partial class C_Tarjeta : UserControl
    {
        private string Nombre = "";
        private string CodCurso = "";
        public C_Tarjeta(string pCodCurso, string pNombre = "Titulo")
        {
            CodCurso = pCodCurso;
            Nombre = pNombre;

            InitializeComponent();
        }

        private void C_Tarjeta_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = Nombre;
        }
    }
}
