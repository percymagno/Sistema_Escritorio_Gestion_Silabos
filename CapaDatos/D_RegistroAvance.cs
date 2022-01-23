using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class D_RegistroAvance
    {
        Conexion conexion = new Conexion();
        protected Conexion aConexion;
        // Metodos CRUD
        public bool Agregar(E_RegistroAvance pRegistro)
        {
            string sql = "INSERT INTO dbo.TRegistroAvance (ID_Silabo, Fecha, Observacion, NroHoras)" +
                                    "VALUES (@ID_Silabo, @Fecha, @Observacion, @nroHoras)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID_Silabo", pRegistro.ID_Silabo);
            conexion.cmd.Parameters.AddWithValue("@Fecha", pRegistro.Fecha);
            conexion.cmd.Parameters.AddWithValue("@Observacion", pRegistro.Observacion);
            conexion.cmd.Parameters.AddWithValue("@nroHoras", pRegistro.NroHoras);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable MostrarAsignacion(int AsignacionID)
        {
            string sql = "SELECT Unidad,  Capitulo, Tema, NroHoras, Fecha, Observacion " +
                "FROM TRegistroAvance R INNER JOIN TSilabo S ON R.ID_Silabo = S.ID " +
                "WHERE Asignacion = @Asignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", AsignacionID);
            return conexion.executeReader();
        }
        public DataTable Buscar(int AsignacionID, String Texto)
        {
            string sql = "SELECT Unidad,  Capitulo, Tema, NroHoras, Fecha, Observacion " +
                "FROM TRegistroAvance R INNER JOIN TSilabo S ON R.ID_Silabo = S.ID " +
                "WHERE Asignacion = @Asignacion AND (Unidad LIKE (@Texto + '%') OR Capitulo LIKE (@Texto + '%') " +
                "OR Tema LIKE (@Texto + '%'))";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", AsignacionID);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public bool Editar(E_RegistroAvance pRegistro)
        {
            string sql = "UPDATE dbo.TRegistroAvance SET Fecha = @Fecha, Observacion = @Observacion WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", pRegistro.ID);
            conexion.cmd.Parameters.AddWithValue("@Fecha", pRegistro.Fecha);
            conexion.cmd.Parameters.AddWithValue("@Observacion", pRegistro.Observacion);
            return conexion.executeNonQuery() == 1;
        }
        public bool Eliminar(string ID)
        {
            string sql = "DELETE FROM TRegistroAvance WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", ID);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable TemasSinAvanzar(int IdAsignacion)
        {
            string sql = "select S.ID, S.Unidad, S.Capitulo, S.Tema, S.NroHoras from TSilabo S  Left JOIN TRegistroAvance R " +
                "ON S.Id = R.ID_Silabo  where R.ID_Silabo IS NULL and S.Asignacion = @IdAsignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@IdAsignacion", IdAsignacion);
            return conexion.executeReader();
        }
        public DataTable ObtenerRegistro(int idSilabo)
        {
            string sql = "select * from TRegistroAvance where ID_Silabo = @IdSilabo";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@IdSilabo", idSilabo);
            return conexion.executeReader();
        }
    }
}
