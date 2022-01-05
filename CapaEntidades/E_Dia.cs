using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Dia
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public int Asignacion { get; set; }
        public int HR_inicio { get; set; }
        public int HR_fin { get; set; }
        public string Tipo { get; set; }
    }
}
