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
    public class D_Asignacion
    {
        Conexion conexion = new Conexion();
        // Metodos CRUD
        public bool Agregar(E_Asignacion asignacion)
        {
            string sql = "INSERT INTO dbo.TAsignacion (Semestre, CodDocente, CodCurso, Grupo, Aula, Carrera)"+
                                    "VALUES (@Semestre, @CodDocente, @CodCurso, @Grupo, @Aula, @Carrera)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Semestre", asignacion.Semestre);
            conexion.cmd.Parameters.AddWithValue("@CodDocente", asignacion.CodDocente);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", asignacion.CodCurso);
            conexion.cmd.Parameters.AddWithValue("@Grupo", asignacion.Grupo);
            conexion.cmd.Parameters.AddWithValue("@Aula", asignacion.Aula);
            conexion.cmd.Parameters.AddWithValue("@Carrera", asignacion.Carrera);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable Mostrar()
        {
            string sql = "SELECT * FROM TAsignacion";
            conexion.setComando(sql);

            return conexion.executeReader();
        }
        public DataTable Buscar(String Texto)
        {
            string sql = "SELECT * FROM TAsignacion WHERE ID LIKE (@Texto + '%') OR Semestre LIKE (@Texto + '%') " +
                "OR CodCurso LIKE (@Texto + '%') OR CodDocente LIKE (@Texto + '%')";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public DataTable BuscarDocenteCurso(String codDocente, String codCurso)
        {
            string sql = "SELECT * FROM TAsignacion WHERE " +
                "CodCurso = @CodCurso AND CodDocente = @CodDocente";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", codCurso);
            conexion.cmd.Parameters.AddWithValue("@CodDocente", codDocente);

            return conexion.executeReader();
        }
        public DataTable BuscarSemestre(String Texto)
        {
            string sql = "SELECT * FROM TAsignacion WHERE Semestre = @Texto";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public bool Editar(E_Asignacion asignacion)
        {
            string sql = "UPDATE dbo.TAsignacion SET Semestre = @Semestre, CodDocente = @CodDocente," +
                              "CodCurso = @CodCurso, Grupo = @Grupo, Aula = @Aula WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", asignacion.ID);
            conexion.cmd.Parameters.AddWithValue("@Semestre", asignacion.Semestre);
            conexion.cmd.Parameters.AddWithValue("@CodDocente", asignacion.CodDocente);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", asignacion.CodCurso);
            conexion.cmd.Parameters.AddWithValue("@Grupo", asignacion.Grupo);
            conexion.cmd.Parameters.AddWithValue("@Aula", asignacion.Aula);
            return conexion.executeNonQuery() == 1;
        }
        public bool Eliminar(string ID)
        {
            string sql = "DELETE FROM TAsignacion WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", ID);

            return conexion.executeNonQuery() == 1;
        }
        public bool ElminarCodDocenteCurso(string Cod)
        {
            string sql = "DELETE FROM TAsignacion WHERE CodDocente = @Cod OR CodCurso = @Cod";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Cod", Cod);

            return conexion.executeNonQuery() >= 0;
        }
    }
}
