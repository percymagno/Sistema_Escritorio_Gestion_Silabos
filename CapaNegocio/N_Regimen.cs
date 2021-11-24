using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Regimen
    {
        D_Regimen d_Regimen = new D_Regimen();
        public DataTable Mostrar()
        {
            return d_Regimen.ObtenerRegimen();
        }
        public DataTable Buscar(string txt)
        {
            return d_Regimen.BuscarRegimen(txt);
        }
    }
}
