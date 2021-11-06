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

        // Metodo para insertar un registro de curso
        //public void CreateCurso(E_Curso Curso)
        public void CreateCurso()
        {
            // Ejecutar el procedimiento almacenado "spuCreateCurso"
            SqlCommand Comando = new SqlCommand("spuCreateCurso", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodCurso", "IF614AIN");
            Comando.Parameters.AddWithValue("@Nombre", "Ingenieria de Software I");
            Comando.Parameters.AddWithValue("@CodDocente", "");
            Comando.Parameters.AddWithValue("@Creditos", "4");
            Comando.Parameters.AddWithValue("@Categoria", "OEES");
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
        // Metodo para buscar un determinado curso (tabla de datos)
        public DataTable ReadCurso(string CodCurso)
        {
            // Declar una tabla de datos para los cursos
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuReadCurso"
            SqlCommand Comando = new SqlCommand("spuReadCurso", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar el parametro necesario para el procedimiento
            Comando.Parameters.AddWithValue("@CodCurso", CodCurso);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);

            // Retornar la tabla de datos con los datos del curso buscado
            return Resultado;
        }
        // Metodo para editar un registro de curso
        //public void EditarRegistro(E_Curso Curso)
        public void UpdateCurso()
        {
            // Ejecutar el procedimiento almacenado "spuUpdateCurso"
            SqlCommand Comando = new SqlCommand("spuUpdateCurso", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodCurso", "IF614AIN");
            Comando.Parameters.AddWithValue("@Nombre", "Ingenieria de Software");
            Comando.Parameters.AddWithValue("@CodDocente", "");
            Comando.Parameters.AddWithValue("@Creditos", "4");
            Comando.Parameters.AddWithValue("@Categoria", "OEES");
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Metodo para eliminar un registro de curso
        //public void EliminarCurso(E_Curso Curso)
        public void DeleteCurso()
        {
            // Ejecutar el procedimiento almacenado "spuDeleteCurso"
            SqlCommand Comando = new SqlCommand("spuDeleteCurso", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodCurso", "IF614AIN");
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
