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
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Frm_AddAsignacion : Form
    {
        E_Asignacion Asignacion;
        bool Editar = false;
        public Frm_AddAsignacion(E_Asignacion Asignacion = null, bool Editar = false)
        {
            this.Asignacion = Asignacion;
            this.Editar = Editar;
            InitializeComponent();
        }

        private void Frm_AddAsignacion_Load(object sender, EventArgs e)
        {
            if (Asignacion != null)
            {
                //text_codigo.Text = Asignacion.CodCurso == null ? "" : Curso.CodCurso;

                btnAgregarAsignacion.Text = "GUARDAR";
            }
            else
                Asignacion = new E_Asignacion();

            if (Editar)
            {
                
            }
        }
    }
}
