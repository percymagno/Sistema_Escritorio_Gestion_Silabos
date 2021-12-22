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
    public class D_Silabo
    {
        Conexion conexion = new Conexion();
        // Metodos CRUD
        public bool Agregar(E_Silabo pSilabo)
        {
            string sql = "INSERT INTO dbo.TSilabo (Semestre, CodCurso, Unidad, Capitulo, Tema, NroHoras)" +
                                    "VALUES (@Semestre, @CodCurso, @Unidad, @Capitulo, @Tema, @NroHoras)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Semestre", pSilabo.Semestre);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", pSilabo.CodCurso);
            conexion.cmd.Parameters.AddWithValue("@Unidad", pSilabo.Unidad);
            conexion.cmd.Parameters.AddWithValue("@Capitulo", pSilabo.Capitulo);
            conexion.cmd.Parameters.AddWithValue("@Tema", pSilabo.Tema);
            conexion.cmd.Parameters.AddWithValue("@NroHoras", pSilabo.NroHoras);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable MostrarCursoSemestre(string Semestre, string CodCurso)
        {
            string sql = "SELECT * FROM TSilabo WHERE Semestre = @Semestre AND CodCurso = @CodCurso";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Semestre", Semestre);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", CodCurso);
            return conexion.executeReader();
        }
        public DataTable Buscar(String Texto)
        {
            string sql = "SELECT * FROM TSilabo WHERE ID LIKE (@Texto + '%') OR Semestre LIKE (@Texto + '%') " +
                "OR CodCurso LIKE (@Texto + '%')";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public bool Editar(E_Silabo pSilabo)
        {
            string sql = "UPDATE dbo.TSilabo SET Semestre = @Semestre, CodCurso = @CodCurso, Unidad = @Unidad, Capitulo = @Capitulo, " +
                              "Tema = @Tema, NroHoras = @NroHoras WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", pSilabo.ID);
            conexion.cmd.Parameters.AddWithValue("@Semestre", pSilabo.Semestre);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", pSilabo.CodCurso);
            conexion.cmd.Parameters.AddWithValue("@Unidad", pSilabo.Unidad);
            conexion.cmd.Parameters.AddWithValue("@Capitulo", pSilabo.Capitulo);
            conexion.cmd.Parameters.AddWithValue("@Tema", pSilabo.Tema);
            conexion.cmd.Parameters.AddWithValue("@NroHoras", pSilabo.NroHoras);
            return conexion.executeNonQuery() == 1;
        }
        public bool Eliminar(string ID)
        {
            string sql = "DELETE FROM TSilabo WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", ID);

            return conexion.executeNonQuery() == 1;
        }
        public bool ElminarCodCursoSemestre(string Semestre, string CodCurso)
        {
            string sql = "DELETE FROM TSilabo WHERE Semestre = @Semestre AND CodCurso = @CodCurso";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Semestre", Semestre);
            conexion.cmd.Parameters.AddWithValue("@CodCurso", CodCurso);

            return conexion.executeNonQuery() >= 0;
        }
    }
}
