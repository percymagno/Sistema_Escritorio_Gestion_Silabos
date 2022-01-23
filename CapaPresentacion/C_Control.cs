using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaDatos;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class C_Control : UserControl
    {
        protected Conexion aConexion;
        N_Asistencia n_Asistencia = new N_Asistencia();
        N_RegistroAvance n_RegistroAvance = new N_RegistroAvance();
        DataTable dt;
        //Declarar un delegate y Event. StatusUpdate
        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;

        int asignacionID;
        public C_Control(int pAsignacionID)
        {
            asignacionID = pAsignacionID;
            InitializeComponent();
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
        private void C_Control_Load(object sender, EventArgs e)
        {
           
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private List<string> ObtenerCapitulo(DataTable dt)
        {
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                if (!list.Contains(dr["Capitulo"]))
                {
                    list.Add(dr["Capitulo"].ToString());
                }
            }
            return list;
        }
        private List<string> ObtenerUnidad(DataTable dt)
        {
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                if (!list.Contains(dr["Unidad"]))
                {
                    list.Add(dr["Unidad"].ToString());
                }
            }
            return list;
        }
        private void C_Control_Load_1(object sender, EventArgs e)
        {
            dt = n_RegistroAvance.TemasSinAvanzar(asignacionID);
            if(dt != null)
            {
                List<string> list = ObtenerUnidad(dt);
                List<string> vs = ObtenerCapitulo(dt);
                foreach (string item in list)
                {
                    cbUnidad.Items.Add(item);
                }
                foreach (string item in vs)
                {
                    cbCapitulo.Items.Add(item);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    cbTema.Items.Add(dr["Tema"]);
                }
            }
            // rellenar lista de alumnos
            N_AlumnoCurso n_AlumnoCurso = new N_AlumnoCurso();
            DataTable dt_SubirAlumnosCurso = n_AlumnoCurso.Mostrar(asignacionID);
            if (dt_SubirAlumnosCurso != null)
            {
                dgvAlumnos.DataSource = dt_SubirAlumnosCurso;
            }
        }
        private int idSilabo(DataTable dt1)
        {
            var value = cbTema.SelectedItem;
            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["Tema"] == value)
                {
                    return Convert.ToInt32(dr["Id"]);
                }
            }
            return -1;
        }

        private int nroHoras(DataTable dt1)
        {
            var value = cbTema.SelectedItem;
            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["Tema"] == value)
                {
                    return Convert.ToInt32(dr["NroHoras"]);
                }
            }
            return -1;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(cbUnidad.SelectedIndex > -1 && cbCapitulo.SelectedIndex > -1 && cbTema.SelectedIndex > -1)
            {
                int IdSilabo = idSilabo(dt);
                if (IdSilabo == -1)
                {
                    MessageBox.Show("Error al seleccionar");
                }
                else
                {
                    n_RegistroAvance.ID_Silabo = IdSilabo;
                    n_RegistroAvance.Fecha = DateTime.Now;
                    n_RegistroAvance.Observacion = textBoxObservacion.Text;
                    n_RegistroAvance.NroHoras = nroHoras(dt);
                    n_RegistroAvance.Guardar();
                    int IdAvance = n_RegistroAvance.IdRegistro(IdSilabo);
                    foreach (DataGridViewRow fila in dgvAlumnos.Rows)
                    {
                        DataGridViewCheckBoxCell b = (DataGridViewCheckBoxCell)fila.Cells["Asistencia"];
                        n_Asistencia.ID_Registro = IdAvance;
                        n_Asistencia.CodAlumno = fila.Cells[2].Value.ToString();
                        n_Asistencia.Asistio = Convert.ToBoolean(b.Value);
                        n_Asistencia.Guardar();
                        MessageBox.Show("Guardado Correctamente");
                    }
                }
            }
            else
            {
                MessageBox.Show("un item (Unidad, Capitulo o Tema) no esta seleccionado");
            }
        }

        private void cbTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cbTema.SelectedItem;
            foreach (DataRow dr in dt.Rows)
            {
                if(dr["Tema"] == value)
                {
                    cbCapitulo.SelectedItem = dr["Capitulo"];
                    cbUnidad.SelectedItem = dr["Unidad"];
                }
            }
        }
    }
}
