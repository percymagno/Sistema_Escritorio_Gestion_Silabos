using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Dia
    {
        D_Dia d_Dia = new D_Dia();
        public List<E_Dia> BuscarAsignacion(string Texto)
        {
            List<E_Dia> Dias = new List<E_Dia>();
            DataTable dt = d_Dia.BuscarAsignacion(Texto);
            if(dt == null)
            {
                return Dias;
            }
            foreach (DataRow dr in dt.Rows)
            {
                E_Dia tmpDia = new E_Dia();
                tmpDia.Dia = dr["Dia"].ToString();
                tmpDia.Tipo = dr["Tipo"].ToString();
                tmpDia.Asignacion = Int32.Parse(dr["Asignacion"].ToString());
                tmpDia.HR_inicio = Int32.Parse(dr["HR_inicio"].ToString());
                tmpDia.HR_fin = Int32.Parse(dr["HR_fin"].ToString());
                tmpDia.Id = Int32.Parse(dr["ID"].ToString());
                Dias.Add(tmpDia);
            }
            return Dias;
        }
    }
}
