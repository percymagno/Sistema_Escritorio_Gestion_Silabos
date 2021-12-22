using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Semestre
    {
        public string Semestre { get; set; }
        public string Fecha_inicio { get; set; }
        public string Fecha_fin { get; set; }

        D_Semestre semestre = new D_Semestre();
        public DataRow MostrarUltimo()
        {
            DataTable dt = Mostrar();
            return dt == null ? null : dt.Rows[0];
        }
        public DataTable Mostrar()
        {
            return semestre.Mostrar();
        }
        public bool Editar()
        {
            return semestre.Editar(new E_Semestre { Semestre = this.Semestre, Fecha_inicio = this.Fecha_inicio, Fecha_fin =this.Fecha_fin });
        }
        public string Agregar()
        {
            // verificar que actual semestre no terminó
            DataRow row = MostrarUltimo();
            if (row != null)
            {
                DateTime curDate = DateTime.Today;
                DateTime lastDate;
                DateTime.TryParse(row["Fecha_fin"].ToString(), out lastDate);
                if(DateTime.Compare(curDate, lastDate) <= 0)
                {
                    Console.WriteLine("Error! Semestre " + row["Semestre"] + " en curso");
                    return "Error! Semestre " + row["Semestre"] + " en curso";
                }
                    
            }
            Console.WriteLine("Agregando semestre...");
            
            bool ans = semestre.Agregar(new E_Semestre { Semestre = this.Semestre, Fecha_inicio = this.Fecha_inicio, Fecha_fin = this.Fecha_fin });
            return ans ? "Semestre agregado" : "Error! no se pudo agregar Semestre";
        }
    }
}
