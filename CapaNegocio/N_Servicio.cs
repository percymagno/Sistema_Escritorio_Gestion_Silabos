using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{ 
    public class N_Servicio
    {
        D_ServicioDocente d_ServicioDocente = new D_ServicioDocente();
        public DataTable BuscarCurso(string CodDocente)
        {
            return d_ServicioDocente.BuscarCurso(CodDocente);
        }
    }
}
