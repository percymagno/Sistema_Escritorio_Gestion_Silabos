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
    public partial class C_CajaTarjetas : UserControl
    {
        // Lista de paneles
        private List<Panel> paneles = new List<Panel>();
        private int panelWidth = 200;
        private int panelHeight = 100;
        private int rows = 0;
        private int cols = 1;
        private int minMargin = 20;

        private Random rnd = new Random();
        public C_CajaTarjetas()
        {
            InitializeComponent();
        }
        private void agregarPanel()
        {
            Panel panel = new Panel();

            int r = rnd.Next(150, 230), g = rnd.Next(150, 230), b = rnd.Next(150, 230);
            panel.BackColor = Color.FromArgb(r, g, b);
            panel.BorderStyle = BorderStyle.FixedSingle;
            //panel.Controls.Add(C_Tarjeta);
            //C_Tarjeta.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Name = "panel" + paneles.Count().ToString();
            panel.Size = new System.Drawing.Size(panelWidth, panelHeight);
            panel.TabIndex = 0;
            paneles.Add(panel);
        }
        private void mostrarPaneles()
        {
            foreach (System.Windows.Forms.Panel panel in paneles)
            {
                // Agregar tarjeta
                panel.Location = new System.Drawing.Point(5, 5);
                flowLayoutPanel.Controls.Add(panel);
            }
        }
        private void C_CajaTarjetas_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                agregarPanel();
            }
            mostrarPaneles();
        }
    }
}
