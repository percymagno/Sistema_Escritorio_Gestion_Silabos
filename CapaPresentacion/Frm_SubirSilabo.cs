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
using CapaEntidades;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class Frm_SubirSilabo : Form
    {
        string CodCurso;
        string Semestre = "2021-I";
        N_SubirSilabo Subir_Silabo;
        N_Silabo n_Silabo = new N_Silabo();
        DataTable dt_SubirSilabo;
        public Frm_SubirSilabo(string pCodCurso)
        {
            CodCurso = pCodCurso;
            InitializeComponent();
            btnSubirSilabo.Visible = false;
            btnGuardar.Visible = false;
            RefrescarDGV();
        }
        private void RefrescarDGV()
        {
            dgvSubirSilabo.DataSource = null;
            dgvSubirSilabo.Rows.Clear();
            dgvSubirSilabo.Columns.Clear();
            dgvSubirSilabo.Refresh();

            dt_SubirSilabo = n_Silabo.Mostrar(Semestre, CodCurso);
            if (dt_SubirSilabo != null)
            {
                btnSubirSilabo.Visible = false;
                dgvSubirSilabo.DataSource = dt_SubirSilabo;
                dgvSubirSilabo.Columns["ID"].Visible = false;
                dgvSubirSilabo.Columns["Semestre"].Visible = false;
                dgvSubirSilabo.Columns["CodCurso"].Visible = false;
            }
            else
            {
                btnSubirSilabo.Visible = true;
            }
        }
        private void RellenarHeaders()
        {
            // rellenar DGV
            dgvSubirSilabo.DataSource = null;
            dgvSubirSilabo.Rows.Clear();
            dgvSubirSilabo.Refresh();

            dgvSubirSilabo.ColumnCount = 4;
            dgvSubirSilabo.Columns[0].Name = "Unidad";
            dgvSubirSilabo.Columns[1].Name = "Capítulo";
            dgvSubirSilabo.Columns[2].Name = "Tema";
            dgvSubirSilabo.Columns[3].Name = "NroHoras";
        }

        private void btnSubirSilabo_Click(object sender, EventArgs e)
        {
            Subir_Silabo = new N_SubirSilabo(CodCurso, Semestre);
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                int nroFilas = Subir_Silabo.Procesar(file);

                RellenarHeaders();
                Console.WriteLine(dgvSubirSilabo.Columns[0].Name);
                foreach (N_Silabo SSilabo in Subir_Silabo.getSilabo())
                {
                    string[] row = {
                        SSilabo.Unidad,  SSilabo.Capitulo, SSilabo.Tema, SSilabo.NroHoras.ToString()};
                    dgvSubirSilabo.Rows.Add(row);
                }
                MessageBox.Show(nroFilas + " filas leidas", "Sistema de Gestion de Sílabos");
            }
            if (Subir_Silabo.getSilabo().Count() > 0)
            {
                btnGuardar.Visible = true;
            }
            if (Subir_Silabo.getSilabo().Count() == 0)
            {
                RefrescarDGV();
                MessageBox.Show("Error! Elegir otro archivo", "Sistema de Gestion de Sílabos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            foreach (N_Silabo SSilabo in Subir_Silabo.getSilabo())
            {
                SSilabo.Guardar();
                //MessageBox.Show("Se guardó carga correctamente", "Sistema de Gestión de Silabos");
            }
                

            btnGuardar.Visible = false;
            RefrescarDGV();
        }
    }
}
