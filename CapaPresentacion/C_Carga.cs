using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class C_Carga : UserControl
    {

        N_Asignacion n_Asignacion = new N_Asignacion();
        public C_Carga()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                Excel excel = new Excel(file, 1);

                MessageBox.Show(excel.nroRows().ToString() + " filas leidas");

                n_Asignacion.Procesar(file);
                List<Carga> cargas = n_Asignacion.getCargas();
                listBoxCarga.DataSource = cargas;
            }
        }
    }
}
