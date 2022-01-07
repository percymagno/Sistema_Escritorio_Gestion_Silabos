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
    public partial class C_Control : UserControl
    {
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
    }
}
