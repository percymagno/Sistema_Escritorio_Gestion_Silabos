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
            string sql = "INSERT INTO dbo.TAsignacion (Semestre, CodDocente, CodCurso, Tipo, Grupo, HT, HP, Dia, HR_inicio, HR_fin, Aula)"+
                                    "VALUES (@Semestre, @CodDocente, @CodCurso, @Tipo, @Grupo, @HT, @HP, @Dia, @HR_inicio, @HR_fin, @Aula)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Semestre", asignacion.Semestre);
            conexion.cmd.Parameters.AddWithValue("@CodDocente", asignacion.CodDocente);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", asignacion.CodCurso);
            conexion.cmd.Parameters.AddWithValue("@Tipo", asignacion.Tipo);
            conexion.cmd.Parameters.AddWithValue("@Grupo", asignacion.Grupo);
            conexion.cmd.Parameters.AddWithValue("@HT", asignacion.HT);
            conexion.cmd.Parameters.AddWithValue("@HP", asignacion.HP);
            conexion.cmd.Parameters.AddWithValue("@Dia", asignacion.Dia);
            conexion.cmd.Parameters.AddWithValue("@HR_inicio", asignacion.HR_inicio);
            conexion.cmd.Parameters.AddWithValue("@HR_fin", asignacion.HR_fin);
            conexion.cmd.Parameters.AddWithValue("@Aula", asignacion.Aula);

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
        public DataTable BuscarSemestre(String Texto)
        {
            string sql = "SELECT * FROM TAsignacion WHERE Semestre = @Texto";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public bool Editar(E_Asignacion asignacion)
        {
            string sql = "UPDATE dbo.TAsignacion SET Semestre = @Semestre, CodDocente = @CodDocente, CodCurso = @CodCurso, Tipo = @Tipo, Grupo = @Grupo, " +
                              "HT = @HT, HP = @HP, Dia = @Dia, HR_inicio = @HR_inicio, HR_fin = @HR_fin, Aula = @Aula WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", asignacion.ID);
            conexion.cmd.Parameters.AddWithValue("@Semestre", asignacion.Semestre);
            conexion.cmd.Parameters.AddWithValue("@CodDocente", asignacion.CodDocente);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", asignacion.CodCurso);
            conexion.cmd.Parameters.AddWithValue("@Tipo", asignacion.Tipo);
            conexion.cmd.Parameters.AddWithValue("@Grupo", asignacion.Grupo);
            conexion.cmd.Parameters.AddWithValue("@HT", asignacion.HT);
            conexion.cmd.Parameters.AddWithValue("@HP", asignacion.HP);
            conexion.cmd.Parameters.AddWithValue("@Dia", asignacion.Dia);
            conexion.cmd.Parameters.AddWithValue("@HR_inicio", asignacion.HR_inicio);
            conexion.cmd.Parameters.AddWithValue("@HR_fin", asignacion.HR_fin);
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
    }
}
