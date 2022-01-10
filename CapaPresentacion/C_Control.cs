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
            DataTable aux = registro.Lista_por_tema();
            for (int i = 0; i < aux.Rows.Count; i++)
            {
                comboBox3.Items.Add(aux.Rows[i]["Tema"].ToString());
            }
            DataTable aux1 = registro.Lista_por_capitulo();
            for (int i = 0; i < aux1.Rows.Count; i++)
            {
                comboBox2.Items.Add(aux1.Rows[i]["Capitulo"].ToString());
            }
            DataTable aux2 = registro.Lista_por_unidad();
            for (int i = 0; i < aux2.Rows.Count; i++)
            {
                comboBox1.Items.Add(aux2.Rows[i]["Unidad"].ToString());
            }
            D_Alumno d_Alumno = new D_Alumno();
            dgvAlumnos.DataSource = d_Alumno.MostrarPorCurso(52);
        }
    }
}
