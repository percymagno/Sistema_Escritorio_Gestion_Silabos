using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;
using System.Configuration;

namespace CapaDatos
{
    public class D_Regimen
    {
        // Definir la conexion a la base de datos
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        // Metodos abrir y cerrar la conexion
        public void Abrir()
        {
            if (Conectar.State == ConnectionState.Closed)
                Conectar.Open();
        }
        public void Cerrar()
        {
            if (Conectar.State == ConnectionState.Open)
                Conectar.Close();
        }
        // Metodos CRUD
        public DataTable ObtenerRegimen()
        {
            string sql = "SELECT * FROM TRegimen";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            DataTable dt = new DataTable();
            try
            {
                Abrir();
                using (SqlDataReader dr = Comando.ExecuteReader())
                {
                    if (dr.HasRows)
                        dt.Load(dr);
                    else
                    {
                        Console.WriteLine("dr cursos vacio");
                        dt = null;
                    }
                }
                Cerrar();
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("R. Error al tratar de conectar con la base de datos", ex.Message);
                return null;
            }

        }
        public DataTable BuscarRegimen(String Texto)
        {
            string sql = "SELECT * FROM TRegimen WHERE CodRegimen LIKE (@Texto + '%')";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            DataTable dt = new DataTable();
            try
            {
                Abrir();
                using (SqlDataReader dr = Comando.ExecuteReader())
                {
                    if (dr.HasRows)
                        dt.Load(dr);
                    else
                    {
                        Console.WriteLine("dr cursos vacio");
                        dt = null;
                    }
                }
                Cerrar();
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("R. Error al tratar de conectar con la base de datos", ex.Message);
                return null;
            }
        }
    }
}
