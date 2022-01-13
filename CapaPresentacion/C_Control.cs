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

        private void C_Control_Load_1(object sender, EventArgs e)
        {
            D_Silabo registro = new D_Silabo();
            DataTable silabo = registro.Lista(asignacionID);

            var unidades = new BindingList<string>();
            var capitulos = new BindingList<string>();
            var temas = new BindingList<string>();


            if (silabo != null)
            {
                // separar temas, capitulos y unidades
                foreach (DataRow row in silabo.Rows)
                {
                    string tmpUni = row["Unidad"].ToString();
                    string tmpCap = row["Capitulo"].ToString();
                    string tmpTem = row["Tema"].ToString();

                    if (!unidades.Contains(tmpUni))
                        unidades.Add(tmpUni);
                    if (!capitulos.Contains(tmpCap))
                        capitulos.Add(tmpCap);
                    if (!temas.Contains(tmpTem))
                        temas.Add(tmpTem);
                }

                // Rellenar tema
                comboBox3.DataSource = temas;

                // Rellenar capitulos
                comboBox2.DataSource = capitulos;

                // Rellenar unidades
                comboBox1.DataSource = unidades;

                // seleccionados - por defecto segunda fila
                DataRow frsRow = silabo.Rows[1];
                comboBox3.SelectedItem = frsRow["Tema"];
                comboBox2.SelectedItem = frsRow["Capitulo"];
                comboBox3.SelectedItem = frsRow["Unidad"];
            }
            else
            {
                Console.WriteLine("silabo vacio " + asignacionID.ToString());
            }
            // rellenar lista de alumnos
            N_AlumnoCurso n_AlumnoCurso = new N_AlumnoCurso();
            DataTable dt_SubirAlumnosCurso = n_AlumnoCurso.Mostrar(asignacionID);
            if (dt_SubirAlumnosCurso != null)
            {
                dgvAlumnos.DataSource = dt_SubirAlumnosCurso;
            }
        }
    }
}
