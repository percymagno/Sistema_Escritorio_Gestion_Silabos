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

namespace CapaPresentacion
{
    public partial class C_Silabo : UserControl
    {
        //Declarar un delegate y Event. StatusUpdate
        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;

        int asignacionID;
        string Semestre = "2021-I";
        N_SubirSilabo Subir_Silabo;
        N_Silabo n_Silabo = new N_Silabo();
        DataTable dt_SubirSilabo;
        public C_Silabo (int pAsignacionID)
        {
            asignacionID = pAsignacionID;
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

            dt_SubirSilabo = n_Silabo.Mostrar(Semestre, asignacionID);
            if (dt_SubirSilabo != null)
            {
                btnSubirSilabo.Visible = false;
                dgvSubirSilabo.DataSource = dt_SubirSilabo;
                dgvSubirSilabo.Columns["ID"].Visible = false;
                dgvSubirSilabo.Columns["Asignacion"].Visible = false;
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
            Subir_Silabo = new N_SubirSilabo(asignacionID);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSubirSilabo.Rows.Count > 0)
            {
                int index = dgvSubirSilabo.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvSubirSilabo.Rows.Count - 1)
                {
                    E_Silabo Silabo = new E_Silabo();
                    Silabo.ID = Int32.Parse(dgvSubirSilabo.Rows[index].Cells[0].Value.ToString());
                    Silabo.Asignacion = Int32.Parse(dgvSubirSilabo.Rows[index].Cells[1].Value.ToString());
                    Silabo.Unidad = dgvSubirSilabo.Rows[index].Cells[2].Value.ToString();
                    Silabo.Capitulo = dgvSubirSilabo.Rows[index].Cells[3].Value.ToString();
                    Silabo.Tema = dgvSubirSilabo.Rows[index].Cells[4].Value.ToString();
                    Silabo.NroHoras = Int32.Parse(dgvSubirSilabo.Rows[index].Cells[5].Value.ToString());
                    Frm_AddSilabo AddSilabo = new Frm_AddSilabo(Silabo, true);
                    AddSilabo.ShowDialog();
                    RefrescarDGV();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvSubirSilabo.Rows.Count > 0)
            {
                int index = dgvSubirSilabo.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvSubirSilabo.Rows.Count - 1)
                {
                    E_Silabo Silabo = new E_Silabo();
                    String ID = dgvSubirSilabo.Rows[index].Cells[0].Value.ToString();
                    String tmpNombre = dgvSubirSilabo.Rows[index].Cells[1].Value.ToString();
                    tmpNombre += " - " + dgvSubirSilabo.Rows[index].Cells[2].Value.ToString();
                    tmpNombre += " " + dgvSubirSilabo.Rows[index].Cells[3].Value.ToString();
                    tmpNombre += " " + dgvSubirSilabo.Rows[index].Cells[4].Value.ToString();
                    DialogResult confirm = MessageBox.Show("¿Realmente desea eliminar silabo " + tmpNombre + "?", "Sistema de Silabos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (confirm == DialogResult.OK)
                    {

                        if (new N_Silabo { ID = Silabo.ID }.Eliminar(ID))
                            MessageBox.Show("silabo " + tmpNombre + " eliminado!");
                        else
                            MessageBox.Show("No se pudo eliminar silabo " + tmpNombre + "!");
                        RefrescarDGV();

                    }
                }
            }
        }
        private void UpdateStatus()
        {
            //Crear arguments.
            EventArgs args = new EventArgs();

            //llamar a escuchadores, padres
            OnUpdateStatus?.Invoke(this, args);

        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_AddSilabo AddCurso = new Frm_AddSilabo(null, false, asignacionID);
            AddCurso.ShowDialog();
            RefrescarDGV();
        }
    }
}
