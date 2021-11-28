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
            string sql = "select distinct C.CodCurso, C.Nombre, C.Creditos, C.Categoria, A.Grupo from (Dbo.TAsignacion A inner join Dbo.TDocente B  ON (A.CodDocente = B.CodDocente AND A.Tipo != 'P')) inner join Dbo.TCurso C ON (A.CodCurso = C.CodCurso) Where (B.CodDocente = @CodDocente)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodDocente", CodDocente);

            return conexion.executeReader();
        }
    }
}
