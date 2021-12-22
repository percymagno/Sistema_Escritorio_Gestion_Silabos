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
        private List<E_Curso> cursos;
        private List<Panel> paneles = new List<Panel>();
        private int panelWidth = 280;
        private int panelHeight = 150;
        private C_Silabo csilabo;
        public C_CajaTarjetas(List<E_Curso> pCursos)
        {
            cursos = pCursos;
            InitializeComponent();
        }
        private void crearCSilabo(E_Curso curso)
        {
            csilabo = new C_Silabo(curso.CodCurso);
            csilabo.Location = new Point(5, 5);
            csilabo.Name = "Silabo";
            csilabo.Size = new Size(600, 300);
            csilabo.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom)
            | AnchorStyles.Left)
            | AnchorStyles.Right)));
            csilabo.TabIndex = 0;
            Controls.Add(csilabo);
        }
        private void borrarCSilabo()
        {
            csilabo = null;
        }
        private void customControl_OnUpdateStatus(object sender, SilaboClickEventArgs e)
        {
            E_Curso _curso = e.CursoObject as E_Curso;
            if (_curso != null)
            {
                //C_Silabo SSilabo = new C_Silabo(_curso.CodCurso);
                crearCSilabo(_curso);
                flowLayoutPanel.Visible = false;
            }
        }
        private void agregarPanel(E_Curso curso, Color colorFondo)
        {
            // Crear C_Tarjeta
            C_Tarjeta tarjeta = new C_Tarjeta(curso, colorFondo);
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
            foreach (E_Curso curso in cursos)
            { 
                int r = rnd.Next(90, 180), g = rnd.Next(90, 180), b = rnd.Next(90, 180);
                Color colorFondo = Color.FromArgb(r, g, b);
                // crear y agregar paneles a lista de paneles
                agregarPanel(curso, colorFondo);
            }
            // agregar paneles a flowLayoutPanel
            mostrarPaneles();
        }
    }
}
