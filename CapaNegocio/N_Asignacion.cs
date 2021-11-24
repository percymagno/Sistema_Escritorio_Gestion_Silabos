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
    public class N_Asignacion
    {
        public E_Docente Docente { get; set; }
        public E_Curso Curso { get; set; }
        public string Carrera { get; set; }
        public string Tipo { get; set; }
        public string Grupo { get; set; }
        public int HT { get; set; }
        public int HP { get; set; }
        public string Dia { get; set; }
        public int HR_inicio { get; set; }
        public int HR_fin { get; set; }
        public string Aula { get; set; }
        public int Matriculados { get; set; }

        public override string ToString()
        {
            return "CodCurso: " + Curso.CodCurso.Substring(0,5) + ", Docente: " + Docente.CodDocente + ", Tipo: " + Tipo + ", Grupo: " + Grupo;
        }
        public bool Guardar()
        {
            Console.WriteLine("Guardando: "+this.ToString());
            return true;
        }
        public bool existeDocente(DataTable dt)
        {
            if (dt == null) return false;
            foreach (DataRow row in dt.Rows)
            {
                string Nombres = (row["Nombres"].ToString() + " " + row["Paterno"].ToString() + " " + row["Materno"].ToString()).Trim();
                if (this.Docente.Nombres == Nombres)
                    return true;
            }
            return false;
        }
        public bool existeCurso(DataTable dt)
        {
            if (dt == null) return false;
            foreach (DataRow row in dt.Rows)
            {
                string CodCurso = row["CodCurso"].ToString();
                if (this.Curso.CodCurso == CodCurso)
                    return true;
            }
            return false;
        }
    }
}
