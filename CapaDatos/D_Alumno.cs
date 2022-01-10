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
            string sql = "INSERT INTO dbo.TAlumno (CodAlumno, Nombres)" +
                                    "VALUES (@CodAlumno, @Nombres)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodAlumno", pAlumno.CodAlumno);
            conexion.cmd.Parameters.AddWithValue("@Nombres", pAlumno.Nombres);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable Mostrar()
        {
            string sql = "SELECT * FROM TAlumno";
            conexion.setComando(sql);
            return conexion.executeReader();
        }
        public DataTable Buscar(String Texto)
        {
            string sql = "SELECT * FROM TAlumno WHERE CodAlumno LIKE (@Texto + '%') OR Nombres LIKE (@Texto + '%') " +
                "OR CodCurso LIKE (@Texto + '%')";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public bool Editar(E_Alumno pAlumno)
        {
            string sql = "UPDATE dbo.TAlumno SET Nombres = @Nombres WHERE CodAlumno = @CodAlumno";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodAlumno", pAlumno.CodAlumno);
            conexion.cmd.Parameters.AddWithValue("@Nombres", pAlumno.Nombres);
            return conexion.executeNonQuery() == 1;
        }
        public bool Eliminar(string CodAlumno)
        {
            string sql = "DELETE FROM TAlumno WHERE CodAlumno = @CodAlumno";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodAlumno", CodAlumno);

            return conexion.executeNonQuery() == 1;
        }
    }
}
