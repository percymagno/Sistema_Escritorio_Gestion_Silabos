using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        // Definir la conexion a la base de datos
        public readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        public SqlCommand cmd;
        // Metodos abrir y cerrar la conexion
        private void Abrir()
        {
            if (Conectar.State == ConnectionState.Closed)
                Conectar.Open();
        }
        private void Cerrar()
        {
            if (Conectar.State == ConnectionState.Open)
                Conectar.Close();
        }
        public void setComando(string sql)
        {
            cmd = new SqlCommand();
            cmd.Connection = Conectar;
            cmd.CommandText = sql;
        }
        public int executeNonQuery()
        {
            try
            {
                Abrir();
                int ans = cmd.ExecuteNonQuery();
                Console.WriteLine("ExecuteNonQuery ans: " + ans);
                return ans;
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                return -1;
            }
            finally
            {
                Cerrar();
            }
        }
        public DataTable executeReader()
        {
            DataTable dt = new DataTable();
            try
            {
                Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    dt.Load(dr);
                else
                {
                    Console.WriteLine("dataReader vacio");
                    dt = null;
                }
                return dt;
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                        "Source: " + ex.Errors[i].Source + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                Console.WriteLine(errorMessages.ToString());
                return null;
            }
            finally
            {
                Cerrar();
            }
        }
    }
}
