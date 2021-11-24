using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Docente
    {
        // Definir los atributos o campos que tiene un docente
        public string ID { get; set; }
        public string CodDocente { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Condicion { get; set; }
        public string Regimen { get; set; }
        public string Departamento { get; set; }
        public int NroHoras { get; set; }
    }
}
