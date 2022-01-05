using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
namespace CapaDatos
{
    public class D_ServicioDocente
    {
        Conexion conexion = new Conexion();
        public DataTable BuscarCurso(String CodDocente)
        {
            string sql = "select C.CodCurso, C.Nombre, C.Creditos, C.Categoria, A.Grupo from (Dbo.TAsignacion A inner join Dbo.TDocente B  ON (A.CodDocente = B.CodDocente )) inner join Dbo.TCurso C ON (A.CodCurso = C.CodCurso) Where (B.CodDocente = @CodDocente)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodDocente", CodDocente);

            return conexion.executeReader();
        }
        public DataTable BuscarAsignaciones(String CodDocente)
        {
            string sql = "select TA.ID as ID, TA.CodCurso as CodCurso, TA.Grupo as Grupo,"+
                    " TA.Carrera as Carrera, TC.Nombre as Nombre, TC.Creditos as Creditos "+
                    "from TAsignacion TA inner join TCurso TC on TA.CodCurso = TC.CodCurso "+
                    "where TA.CodDocente = @CodDocente and TA.Semestre = '2021-II'";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodDocente", CodDocente);

            return conexion.executeReader();
        }
    }
}
