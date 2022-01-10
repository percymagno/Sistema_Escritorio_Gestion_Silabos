using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class C_Tarjeta : UserControl
    {
        //Declarar un delegate y Event. StatusUpdate
        public delegate void StatusUpdateHandler(object sender, TarjetaClickSilaboEventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;

        private E_Asignacion asignacion;
        Color colorFondo;
        public C_Tarjeta(E_Asignacion pAsignacion)
        {
            asignacion = pAsignacion;
            colorFondo = Color.White;
            InitializeComponent();
        }
        public C_Tarjeta(E_Asignacion pAsignacion, Color pColorFondo)
        {
            asignacion = pAsignacion;
            colorFondo = pColorFondo;
            InitializeComponent();
        }

        private void C_Tarjeta_Load(object sender, EventArgs e)
        {
            // lbTitulo color de fondo
            panelTitulo.BackColor = this.colorFondo;
            // titulo
            lblTitulo.Text = asignacion.Curso.Nombre;
            lblCodigo.Text = asignacion.Curso.CodCurso + asignacion.Grupo;
        }
        private void UpdateStatusSilabo()
        {
            //Create arguments.  You should also have custom one, or else return EventArgs.Empty();
            TarjetaClickSilaboEventArgs args = new TarjetaClickSilaboEventArgs(asignacion, "silabo");

            //Call any listeners
            OnUpdateStatus?.Invoke(this, args);

        }
        private void UpdateStatusControl()
        {
            //Create arguments.  You should also have custom one, or else return EventArgs.Empty();
            TarjetaClickSilaboEventArgs args = new TarjetaClickSilaboEventArgs(asignacion, "control");

            //Call any listeners
            OnUpdateStatus?.Invoke(this, args);

        }

        private void btnSilabo_Click(object sender, EventArgs e)
        {
            UpdateStatusSilabo();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            UpdateStatusControl();
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            FrmAlumno Al = new FrmAlumno(asignacion.ID);
            Al.Show();
        }
    }
}
