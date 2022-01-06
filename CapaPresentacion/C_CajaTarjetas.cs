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
    public partial class C_CajaTarjetas : UserControl
    {
        // Lista de paneles
        private List<E_Asignacion> asignaciones;
        private List<Panel> paneles = new List<Panel>();
        private int panelWidth = 280;
        private int panelHeight = 150;
        private C_Silabo csilabo;
        private C_Control ccontrol;
        public C_CajaTarjetas(List<E_Asignacion> pAsignaciones)
        {
            asignaciones = pAsignaciones;
            InitializeComponent();
        }
        #region Controles
        // crear control silabo
        private void crearCSilabo(E_Asignacion asignacion)
        {
            csilabo = new C_Silabo(asignacion.ID);
            csilabo.Dock = System.Windows.Forms.DockStyle.Fill;
            csilabo.Location = new Point(0, 0);
            csilabo.Name = "Silabo";
            csilabo.Size = new Size(600, 300);
            csilabo.TabIndex = 0;
            csilabo.OnUpdateStatus += borrarCSilabo;
            // agregar silabo
            Controls.Add(csilabo);
        }
        // ocultar silabo, mostrar tarjetas
        private void borrarCSilabo(object sender, EventArgs e)
        {
            csilabo.Visible = false;
            csilabo = null;
            flowLayoutPanel.Visible = true;
        }
        private void crearCControl(E_Asignacion asignacion)
        {
            ccontrol = new C_Control(asignacion.ID);
            ccontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            ccontrol.Location = new Point(0, 0);
            ccontrol.Name = "Silabo";
            ccontrol.Size = new Size(600, 300);
            ccontrol.TabIndex = 0;
            ccontrol.OnUpdateStatus += borrarCControl;
            // agregar silabo
            Controls.Add(ccontrol);
        }
        // ocultar silabo, mostrar tarjetas
        private void borrarCControl(object sender, EventArgs e)
        {
            ccontrol.Visible = false;
            ccontrol = null;
            flowLayoutPanel.Visible = true;
        }
        #endregion
        // Mostrar silabo, ocultar tarjetas
        private void customControl_OnUpdateStatus(object sender, TarjetaClickSilaboEventArgs e)
        {
            E_Asignacion _asignacion = e.CursoObject as E_Asignacion;
            string _button = e.Button as string;
            if (_asignacion != null)
            {
                //C_Silabo SSilabo = new C_Silabo(_curso.CodCurso);
                if(_button == "silabo")
                {
                    crearCSilabo(_asignacion);
                    flowLayoutPanel.Visible = false;
                }
                else if(_button == "control")
                {
                    crearCControl(_asignacion);
                    flowLayoutPanel.Visible = false;
                }
            }
        }
        private void agregarPanel(E_Asignacion asignacion, Color colorFondo)
        {            // Crear C_Tarjeta
            C_Tarjeta tarjeta = new C_Tarjeta(asignacion, colorFondo);
            tarjeta.Dock = DockStyle.Fill;
            tarjeta.OnUpdateStatus += customControl_OnUpdateStatus;

            // Crear panel
            Panel panel = new Panel();
            panel.BackColor = Color.FromArgb(255,255,255);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Name = "panel" + paneles.Count().ToString();
            panel.Size = new Size(panelWidth, panelHeight);
            panel.TabIndex = 0;

            // Agregar tarjeta
            panel.Controls.Add(tarjeta);

            // guardar panel
            paneles.Add(panel);
        }
        private void mostrarPaneles()
        {
            foreach (Panel panel in paneles)
            {
                // Agregar tarjeta
                panel.Location = new Point(5, 5);
                flowLayoutPanel.Controls.Add(panel);
            }
        }
        private void C_CajaTarjetas_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            foreach (E_Asignacion asignacion in asignaciones)
            { 
                int r = rnd.Next(90, 180), g = rnd.Next(90, 180), b = rnd.Next(90, 180);
                Color colorFondo = Color.FromArgb(r, g, b);
                // crear y agregar paneles a lista de paneles
                agregarPanel(asignacion, colorFondo);
            }
            // agregar paneles a flowLayoutPanel
            mostrarPaneles();
        }
    }
}
