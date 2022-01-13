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
        protected Conexion aConexion;
        // Metodos CRUD
        public bool Agregar(E_Silabo pSilabo)
        {
            string sql = "INSERT INTO dbo.TSilabo (Asignacion, Unidad, Capitulo, Tema, NroHoras)" +
                                    "VALUES (@Asignacion, @Unidad, @Capitulo, @Tema, @NroHoras)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", pSilabo.Asignacion);
            conexion.cmd.Parameters.AddWithValue("@Unidad", pSilabo.Unidad);
            conexion.cmd.Parameters.AddWithValue("@Capitulo", pSilabo.Capitulo);
            conexion.cmd.Parameters.AddWithValue("@Tema", pSilabo.Tema);
            conexion.cmd.Parameters.AddWithValue("@NroHoras", pSilabo.NroHoras);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable MostrarCursoSemestre(string Semestre, int ID)
        {
            string sql = "SELECT * FROM TSilabo WHERE Asignacion = @Asignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", ID);
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
            string sql = "UPDATE dbo.TSilabo SET Unidad = @Unidad, Capitulo = @Capitulo, " +
                              "Tema = @Tema, NroHoras = @NroHoras WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", pSilabo.ID);
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
        public DataTable Lista(int Asignacion)
        {
            string query = "SELECT * FROM TSilabo WHERE Asignacion = @Asignacion";

            // Ejecutar la consulta
            conexion.setComando(query);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", Asignacion);

            return conexion.executeReader();
        }
        public DataTable Lista_por_tema()
        { //-- lista los ejemplares que le corresponden a un x determinado
            //Cadena de texto de Consulta a la BD
            string query = "SELECT Unidad,Capitulo,Tema FROM TSilabo ";

            // Ejecutar la consulta
            conexion.setComando(query);

            return conexion.executeReader();
        }
        public DataTable Lista_por_capitulo()
        { //-- lista los ejemplares que le corresponden a un x determinado
            //Cadena de texto de Consulta a la BD
            string query = "SELECT DISTINCT Capitulo FROM TSilabo ";

            // Ejecutar la consulta
            conexion.setComando(query);

            return conexion.executeReader();
        }
        public DataTable Lista_por_unidad()
        { //-- lista los ejemplares que le corresponden a un x determinado
            //Cadena de texto de Consulta a la BD
            string query = "SELECT  DISTINCT Unidad FROM TSilabo ";

            // Ejecutar la consulta
            conexion.setComando(query);

            return conexion.executeReader();
        }
    }
}
