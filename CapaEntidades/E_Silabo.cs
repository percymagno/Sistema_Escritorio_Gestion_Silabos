using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Silabo
    {
        public int ID { get; set; }
        public string Semestre { get; set; }
        public string CodCurso { get; set; }
        public string Unidad { get; set; }
        public string Capitulo { get; set; }
        public string Tema { get; set; }
        public int NroHoras { get; set; }
    }
}
