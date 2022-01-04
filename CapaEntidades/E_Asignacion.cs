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
        public string Grupo { get; set; }
        public string Aula { get; set; }
        public int Matriculados { get; set; }
        public List<E_Dia> Dias { get; set; }

    }
}
