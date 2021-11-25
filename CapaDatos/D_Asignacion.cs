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
    public class D_Asignacion
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
        public bool Agregar(E_Asignacion asignacion)
        {
            string sql = "INSERT INTO dbo.TAsignacion (CodDocente, CodCurso, Tipo, Grupo, HT, HP, Dia, HR_inicio, HR_fin, Aula)"+
                                    "VALUES (@CodDocente, @CodCurso, @Tipo, @Grupo, @HT, @HP, @Dia, @HR_inicio, @HR_fin, @Aula)";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@CodDocente", asignacion.CodDocente);
            Comando.Parameters.AddWithValue("@CodCurso", asignacion.CodCurso);
            Comando.Parameters.AddWithValue("@Tipo", asignacion.Tipo);
            Comando.Parameters.AddWithValue("@Grupo", asignacion.Grupo);
            Comando.Parameters.AddWithValue("@HT", asignacion.HT);
            Comando.Parameters.AddWithValue("@HP", asignacion.HP);
            Comando.Parameters.AddWithValue("@Dia", asignacion.Dia);
            Comando.Parameters.AddWithValue("@HR_inicio", asignacion.HR_inicio);
            Comando.Parameters.AddWithValue("@HR_fin", asignacion.HR_fin);
            Comando.Parameters.AddWithValue("@Aula", asignacion.Aula);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine("C. Error al tratar de conectar con la base de datos", e.ToString());
                return false;
            }
            finally
            {
                Cerrar();
            }
        }
        public DataTable Mostrar()
        {
            string sql = "SELECT * FROM TAsignacion";
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
                return dt;
            }
            catch (SqlException e)
            {
                Console.WriteLine("R. Error al tratar de conectar con la base de datos", e.ToString());
                return null;
            }
            finally
            {
                Cerrar();
            }

        }
        public DataTable Buscar(String Texto)
        {
            string sql = "SELECT * FROM TAsignacion WHERE ID LIKE (@Texto + '%')";
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
                return dt;
            }
            catch (SqlException e)
            {
                Console.WriteLine("R. Error al tratar de conectar con la base de datos", e.ToString());
                return null;
            }
            finally
            {
                Cerrar();
            }
        }
        public bool Editar(E_Asignacion asignacion)
        {
            string sql = "UPDATE dbo.TAsignacion SET (CodDocente = @CodDocente, CodCurso = @CodCurso, Tipo = @Tipo, Grupo = @Grupo, " +
                              "HT = @HT, HP = @HP, Dia = @Dia, HR_inicio = @HR_inicio, HR_fin = @HR_fin, Aula = @Aula) WHERE ID = @ID";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@ID", asignacion.ID);
            Comando.Parameters.AddWithValue("@CodDocente", asignacion.CodDocente);
            Comando.Parameters.AddWithValue("@CodCurso", asignacion.CodCurso);
            Comando.Parameters.AddWithValue("@Tipo", asignacion.Tipo);
            Comando.Parameters.AddWithValue("@Grupo", asignacion.Grupo);
            Comando.Parameters.AddWithValue("@HT", asignacion.HT);
            Comando.Parameters.AddWithValue("@HP", asignacion.HP);
            Comando.Parameters.AddWithValue("@Dia", asignacion.Dia);
            Comando.Parameters.AddWithValue("@HR_inicio", asignacion.HR_inicio);
            Comando.Parameters.AddWithValue("@HR_fin", asignacion.HR_fin);
            Comando.Parameters.AddWithValue("@Aula", asignacion.Aula);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine("C. Error al tratar de conectar con la base de datos", e.ToString());
                return false;
            }
            finally
            {
                Cerrar();
            }
        }
        public bool Eliminar(string ID)
        {
            string sql = "DELETE FROM TAsignacion WHERE ID = @ID";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@ID", ID);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                return res == 1;
            }
            catch (SqlException e)
            {
                Console.WriteLine("D. Error al tratar de conectar con la base de datos", e.ToString());
                return false;
            }
            finally
            {
                Cerrar();
            }
        }
    }
}
