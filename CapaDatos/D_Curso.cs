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
    public class D_Curso
    {
        Conexion conexion = new Conexion();
        // Metodos CRUD
        public bool AgregarCurso(E_Curso Curso)
        {
            string sql = "INSERT INTO dbo.TCurso (CodCurso, Nombre, Creditos, Categoria) VALUES (@CodCurso, @Nombre, @Creditos, @Categoria)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", Curso.CodCurso);
            conexion.cmd.Parameters.AddWithValue("@Nombre", Curso.Nombre);
            conexion.cmd.Parameters.AddWithValue("@Creditos", Curso.Creditos);
            conexion.cmd.Parameters.AddWithValue("@Categoria", Curso.Categoria);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable ObtenerCursos()
        {
            string sql = "SELECT * FROM TCurso";
            conexion.setComando(sql);

            return conexion.executeReader();
        }
        public DataTable BuscarCurso(String Texto)
        {
            string sql = "SELECT * FROM TCurso WHERE CodCurso LIKE (@Texto + '%') OR Nombre LIKE (@Texto + '%')";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public bool EditarCurso(E_Curso Curso)
        {
            string sql = "UPDATE dbo.TCurso SET Nombre = @Nombre, Creditos = @Creditos, Categoria = @Categoria WHERE CodCurso = @CodCurso";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", Curso.CodCurso);
            conexion.cmd.Parameters.AddWithValue("@Nombre", Curso.Nombre);
            conexion.cmd.Parameters.AddWithValue("@Creditos", Curso.Creditos);
            conexion.cmd.Parameters.AddWithValue("@Categoria", Curso.Categoria);
            return conexion.executeNonQuery() == 1;
        }
        public bool EliminarCurso(string CodCurso)
        {
            string sql = "DELETE FROM TCurso WHERE CodCurso = @CodCurso";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", CodCurso);

            return conexion.executeNonQuery() == 1;
        }
    }
}
