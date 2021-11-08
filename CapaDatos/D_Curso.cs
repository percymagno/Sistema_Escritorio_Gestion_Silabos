using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
        public int Consulta_Sql_ans_int(string sql)
        {
            try
            {
                SqlCommand Comando = new SqlCommand(sql, Conectar);
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al tratar de conectar con la base de datos", ex.Message);
                return -1;
            }
        }
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
        public bool Guardar()
        {
            string sql = "";
            int ans = Consulta_Sql_ans_int(sql);
            return ans == 1;
        }
        public DataTable Leer()
        {
            string sql = "SELECT * FROM TCurso";
            DataTable dt = new DataTable();
            SqlDataReader dr = Consulta_Sql_ans_datareader(sql);
            dt.Load(dr);
            return dt;
        }
        public DataTable Buscar()
        {
            string sql = "SELECT * FROM TCurso Where CodCurso = 1234";
            DataTable dt = new DataTable();
            SqlDataReader dr = Consulta_Sql_ans_datareader(sql);
            dt.Load(dr);
            return dt;
        }
        public bool Actualizar()
        {
            string sql = "";
            int ans = Consulta_Sql_ans_int(sql);
            return ans == 1;
        }
        public bool Borrar()
        {
            string sql = "";
            int ans = Consulta_Sql_ans_int(sql);
            return ans == 1;
        }
    }
}
