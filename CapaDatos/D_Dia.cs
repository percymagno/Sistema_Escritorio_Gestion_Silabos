using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class D_Dia
    {
        Conexion conexion = new Conexion();
        public bool Agregar(E_Dia Dia)
        {
            string sql = "INSERT INTO dbo.TDia (Dia, Asignacion, HR_inicio, HR_fin, Tipo)" +
                                    "VALUES (@Dia, @Asignacion, @HR_inicio, @HR_fin, @Tipo)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Dia", Dia.Dia);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", Dia.Asignacion);
            conexion.cmd.Parameters.AddWithValue("@HR_inicio", Dia.HR_inicio);
            conexion.cmd.Parameters.AddWithValue("@HR_fin", Dia.HR_fin);
            conexion.cmd.Parameters.AddWithValue("@Tipo", Dia.Tipo);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable BuscarAsignacion(string Texto)
        {
            //Cadena de texto de Consulta a la BD
            string query = "SELECT * FROM TDia WHERE Asignacion = @Texto";

            // Ejecutar la consulta
            conexion.setComando(query);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public bool Elminar(string Id)
        {
            string sql = "DELETE FROM TDia WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", Id);

            return conexion.executeNonQuery() >= 0;
        }
        public bool EliminarAsignacion(int Asignacion)
        {
            string sql = "DELETE FROM TDia WHERE Asignacion = @Asignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", Asignacion);

            return conexion.executeNonQuery() >= 0;
        }
    }
}
