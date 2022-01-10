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
    public class D_AlumnoCurso
    {
        Conexion conexion = new Conexion();
        // Metodos CRUD
        public bool Agregar(E_AlumnoCurso pAlumnoCurso)
        {
            string sql = "INSERT INTO dbo.TAlumnoCurso (Asignacion, NRO, CodAlumno)" +
                                    "VALUES (@Asignacion, @NRO, @CodAlumno)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", pAlumnoCurso.Asignacion);
            conexion.cmd.Parameters.AddWithValue("@NRO", pAlumnoCurso.NRO);
            conexion.cmd.Parameters.AddWithValue("@CodAlumno", pAlumnoCurso.CodAlumno);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable MostrarAsignacion(int Asignacion)
        {
            string sql = "SELECT NRO, AC.CodAlumno, Nombres  " +
                "FROM TAlumnoCurso AC INNER JOIN TALumno A ON AC.CodAlumno = A.CodAlumno " +
                "WHERE Asignacion = @Asignacion " +
                "ORDER BY NRO";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", Asignacion);
            return conexion.executeReader();
        }
        public DataTable Buscar(int Asignacion, String Texto)
        {
            string sql = "SELECT * FROM TAlumnoCurso WHERE (Asignacion = @Asignacion) AND (NRO LIKE (@Texto + '%') OR CodAlumno LIKE (@Texto + '%'))";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", Asignacion);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);
            return conexion.executeReader();
        }
        public bool Editar(E_AlumnoCurso pAlumnoCurso)
        {
            string sql = "UPDATE dbo.TAlumnoCurso SET NRO = @NRO " +
                "WHERE Asignacion = @Asignacion AND CodAlumno = @CodAlumno";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", pAlumnoCurso.Asignacion);
            conexion.cmd.Parameters.AddWithValue("@CodAlumno", pAlumnoCurso.CodAlumno);
            conexion.cmd.Parameters.AddWithValue("@NRO", pAlumnoCurso.NRO);
            return conexion.executeNonQuery() == 1;
        }
        public bool Eliminar(int Asignacion, string CodAlumno)
        {
            string sql = "DELETE FROM TAlumnoCurso WHERE Asignacion = @Asignacion AND CodAlumno = @CodAlumno";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", Asignacion);
            conexion.cmd.Parameters.AddWithValue("@CodAlumno", CodAlumno);
            return conexion.executeNonQuery() == 1;
        }
        public bool ElminarCurso(int Asignacion)
        {
            string sql = "DELETE FROM TAlumnoCurso WHERE Asignacion = @Asignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", Asignacion);
            return conexion.executeNonQuery() >= 0;
        }
    }
}
