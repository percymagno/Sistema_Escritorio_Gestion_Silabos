using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class Carga
    {
        public string CodCurso { get; set; }
        public string CodDocente { get; set; }
        public string Docente { get; set; }
        public string Carrera { get; set; }
        public string NombreCurso { get; set; }
        public string Creditos { get; set; }
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
            return "CodCurso: " + CodCurso.Substring(0,5) + ", Docente: " + CodDocente + ", Tipo: " + Tipo + ", Grupo: " + Grupo;
        }
        public bool Guardar()
        {
            Console.WriteLine("Guardando: "+this.ToString());
            return true;
        }
    }
}
