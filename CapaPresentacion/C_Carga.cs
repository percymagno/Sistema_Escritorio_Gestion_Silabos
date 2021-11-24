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

                Frm_Cargando frm_Cargando = new Frm_Cargando("Leyendo Archivo...");
                frm_Cargando.Show();
                int nroFilas = n_Asignacion.Procesar(file);
                frm_Cargando.Close();
                MessageBox.Show(nroFilas + " filas leidas");


                List<Carga> cargas = n_Asignacion.getCargas();

                int i = 1;
                foreach (Carga carga in cargas)
                {
                    string[] row = {
                        i.ToString(), carga.Docente, carga.NombreCurso,
                        carga.Grupo, carga.Tipo, carga.Dia, carga.HR_inicio.ToString(),
                        carga.HR_fin.ToString()};
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
            Frm_Cargando frm = new Frm_Cargando("Configurando...");

            frm.Show();
            n_Asignacion.ActualizarDocentes();
            n_Asignacion.ActualizarCursos();
            n_Asignacion.Guardar();
            frm.Close();
            MessageBox.Show("Se guardó carga académica");

            dgvCarga.Rows.Clear();
            dgvCarga.Refresh();
        }

        private void C_Carga_Load(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
        }
    }
}
