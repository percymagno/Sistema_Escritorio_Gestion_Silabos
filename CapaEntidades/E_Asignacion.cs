using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Asignacion
    {
        public int ID { get; set; }
        public string Semestre { get; set; }
        public string CodDocente { get; set; }
        public string CodCurso { get; set; }
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

    }
}
