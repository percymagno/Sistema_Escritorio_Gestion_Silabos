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
    class D_Curso
    {
        // Definir la conexion a la base de datos
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        // Metodos abrir y cerrar la conexion
        public void Abrir()
        {
            if (Conectar.State == ConnectionState.Open)
                    Conectar.Close();
        }
        public void Cerrar()
        {
            if (Conectar.State == ConnectionState.Closed)
                Conectar.Open();
        }
        
        // Metodos para ejecutar sql
        public SqlDataReader Consulta_Sql_ans_datareader(string sql)
        {
            try
            {
                SqlCommand Comando = new SqlCommand(sql, Conectar);
                Abrir();
                SqlDataReader dr = Comando.ExecuteReader(CommandBehavior.CloseConnection);
                Cerrar();
                return dr;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al tratar de conectar con la base de datos", ex.Message);
                return null;
            }
        }
        // Metodos CRUD
        public bool Guardar(E_Curso Curso)
        {
            string sql = "INSERT INTO TCurso (CodCurso, Nombre, CodDocente, Creditos, Categoria) VALUES (@CodCurso, @Nombre, @CodDocente, @Creditos, @Categoria)";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@CodCurso", Curso.CodCurso);
            Comando.Parameters.AddWithValue("@Nombre", Curso.Nombre);
            Comando.Parameters.AddWithValue("@CodDocente", Curso.CodDocente);
            Comando.Parameters.AddWithValue("@Creditos", Curso.Creditos);
            Comando.Parameters.AddWithValue("@Categoria", Curso.Categoria);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res==1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al tratar de conectar con la base de datos", ex.Message);
                return false;
            }
        }
        public DataTable Leer()
        {
            string sql = "SELECT * FROM TCurso";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            DataTable dt = new DataTable();
            try
            {
                
                Abrir();
                SqlDataReader dr = Comando.ExecuteReader(CommandBehavior.CloseConnection);
                Cerrar();
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al tratar de conectar con la base de datos", ex.Message);
                return null;
            }

        }
        public DataTable Buscar(E_Curso Curso)
        {
            string sql = "SELECT * FROM TCurso WHERE CodCurso = @CodCurso OR Nombre LIKE @Nombre";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@CodCurso", Curso.CodCurso);
            Comando.Parameters.AddWithValue("@Nombre", Curso.Nombre);
            DataTable dt = new DataTable();
            try
            {
                Abrir();
                SqlDataReader dr = Comando.ExecuteReader(CommandBehavior.CloseConnection);
                Cerrar();
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al tratar de conectar con la base de datos", ex.Message);
                return null;
            }
        }
        public bool Actualizar(E_Curso Curso)
        {
            string sql = "UPDATE TCurso SET (Nombre = @Nombre, CodDocente = @CodDocente, Creditos = @Creditos, Categoria = @Categoria) WHERE CodCurso = @CodCurso";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@CodCurso", Curso.CodCurso);
            Comando.Parameters.AddWithValue("@Nombre", Curso.Nombre);
            Comando.Parameters.AddWithValue("@CodDocente", Curso.CodDocente);
            Comando.Parameters.AddWithValue("@Creditos", Curso.Creditos);
            Comando.Parameters.AddWithValue("@Categoria", Curso.Categoria);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al tratar de conectar con la base de datos", ex.Message);
                return false;
            }
        }
        public bool Borrar(E_Curso Curso)
        {
            string sql = "DELETE FROM TCurso WHERE CodCurso = @CodCurso";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@CodCurso", Curso.CodCurso);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al tratar de conectar con la base de datos", ex.Message);
                return false;
            }
        }
    }
}
