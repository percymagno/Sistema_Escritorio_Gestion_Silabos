using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class D_Alumno
    {
        Conexion conexion = new Conexion();
        // Metodos CRUD
        public bool Agregar(E_Alumno pAlumno)
        {
            string sql = "INSERT INTO dbo.TAlumno (Asignacion, NRO, CodAlumno, Paterno, Materno, Nombres)" +
                                    "VALUES (@Asignacion, @NRO, @CodAlumno, @Paterno, @Materno, @Nombres)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", pAlumno.Asignacion);
            conexion.cmd.Parameters.AddWithValue("@NRO", pAlumno.NRO);
            conexion.cmd.Parameters.AddWithValue("@CodAlumno", pAlumno.CodAlumno);
            conexion.cmd.Parameters.AddWithValue("@Paterno", pAlumno.Paterno);
            conexion.cmd.Parameters.AddWithValue("@Materno", pAlumno.Materno);
            conexion.cmd.Parameters.AddWithValue("@Nombres", pAlumno.Nombres);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable MostrarCursoSemestre(string Semestre, int ID)
        {
            string sql = "SELECT * FROM TAlumno WHERE Asignacion = @Asignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", ID);
            return conexion.executeReader();
        }
        public DataTable Buscar(String Texto)
        {
            string sql = "SELECT * FROM TAlumno WHERE ID LIKE (@Texto + '%') OR Semestre LIKE (@Texto + '%') " +
                "OR CodCurso LIKE (@Texto + '%')";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public bool Editar(E_Alumno pAlumno)
        {
            string sql = "UPDATE dbo.TAlumno SET NRO = @NRO, Paterno = @Paterno, " +
                              "Materno = @Materno, Nombres = @Nombres WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", pAlumno.ID);
            conexion.cmd.Parameters.AddWithValue("@NRO", pAlumno.NRO);
            conexion.cmd.Parameters.AddWithValue("@Paterno", pAlumno.Paterno);
            conexion.cmd.Parameters.AddWithValue("@Materno", pAlumno.Materno);
            conexion.cmd.Parameters.AddWithValue("@Nombres", pAlumno.Nombres);
            return conexion.executeNonQuery() == 1;
        }
        public bool Eliminar(string ID)
        {
            string sql = "DELETE FROM TAlumno WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", ID);

            return conexion.executeNonQuery() == 1;
        }
        public bool ElminarCodCursoSemestre(int ID)
        {
            string sql = "DELETE FROM TAlumno WHERE Asignacion = @Asignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", ID);

            return conexion.executeNonQuery() >= 0;
        }
    }
}
