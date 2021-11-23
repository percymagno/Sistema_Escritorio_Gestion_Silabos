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
            dgvCarga.DataSource = null;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                Excel excel = new Excel(file, 1);

                //MessageBox.Show(excel.nroRows().ToString() + " filas leidas");

                Frm_Cargando frm_Cargando = new Frm_Cargando();
                frm_Cargando.Show();
                n_Asignacion.Procesar(file);
                frm_Cargando.Close();

                List<Carga> cargas = n_Asignacion.getCargas();

                dgvCarga.ColumnCount = 6;
                dgvCarga.Columns[0].Name = "#";
                dgvCarga.Columns[1].Name = "CodDocente";
                dgvCarga.Columns[2].Name = "Docente";
                dgvCarga.Columns[3].Name = "CodCurso";
                dgvCarga.Columns[4].Name = "Grupo";
                dgvCarga.Columns[5].Name = "Tipo";

                int i = 1;
                foreach (Carga carga in cargas)
                {
                    string[] row = { i.ToString(), carga.CodDocente , carga.Docente, carga.CodCurso.Substring(0,5), carga.Grupo, carga.Tipo};
                    dgvCarga.Rows.Add(row);
                    i++;
                }
                btnGuardar.Visible = true;
            }
            else
                btnGuardar.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            n_Asignacion.Guardar();
            dgvCarga.DataSource = null;
            btnGuardar.Visible = false;
        }

        private void C_Carga_Load(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
        }
    }
}
