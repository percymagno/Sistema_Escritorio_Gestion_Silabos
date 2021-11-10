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
    public class D_Docente
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

        // Metodo para mostrar la tabla de docentes de un determinado docente con algun filtro
        public DataTable BuscarDocentes(string Texto)
        {
            //Cadena de texto de Consulta a la BD
            string query = "SELECT * FROM TDocente WHERE CodDocente LIKE (@Texto + '%') OR Paterno LIKE (@Texto + '%') OR Materno LIKE(@Texto +'%') OR Nombres LIKE(@Texto +'%')";

            // Ejecutar la consulta
            SqlCommand Comando = new SqlCommand(query, Conectar);
            Comando.Parameters.AddWithValue("@Texto", Texto);
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
                Console.WriteLine("R. Error al tratar de conectar con la base de datos", ex.Message);
                return null;
            }
        }

        // Metodo para insertar un registro de docente
        public bool AgregarDocente(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "INSERT INTO TDocente VALUES(@CodDocente, @APaterno, @AMaterno, @Nombres, @Departamento, @Condicion, @Correo, @Telefono)";

            // Ejecutar la consulta
            SqlCommand Comando = new SqlCommand(query, Conectar);

            // Agregar los parametros necesarios para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.Paterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.Materno);
            Comando.Parameters.AddWithValue("@Nombres", Docente.Nombres);
            Comando.Parameters.AddWithValue("@Departamento", Docente.Departamento);
            Comando.Parameters.AddWithValue("@Condicion", Docente.Condicion);
            Comando.Parameters.AddWithValue("@Correo", Docente.Correo);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("C. Error al tratar de conectar con la base de datos", ex.Message);
                return false;
            }
        }

        // Metodo para editar un registro de docente
        public bool EditarDocente(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "UPDATE TDocente SET CodDocente = @CodDocente, Paterno = @APaterno, Materno = @AMaterno, Nombres = @Nombres, " +
                "Departamento = @Departamento, Condicion = @Condicion, Correo = @Correo, Telefono = @Telefono";

            // Ejecutar la consulta"
            SqlCommand Comando = new SqlCommand(query, Conectar);

            // Agregar los parametros necesarios para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.Paterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.Materno);
            Comando.Parameters.AddWithValue("@Nombres", Docente.Nombres);
            Comando.Parameters.AddWithValue("@Departamento", Docente.Departamento);
            Comando.Parameters.AddWithValue("@Condicion", Docente.Condicion);
            Comando.Parameters.AddWithValue("@Correo", Docente.Correo);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("U. Error al tratar de conectar con la base de datos", ex.Message);
                return false;
            }
        }

        // Metodo para eliminar un registro de docente
        public bool EliminarDocente(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "DELETE FROM TDocente WHERE CodDocente = @CodDocente";

            // Ejecutar la consulta
            SqlCommand Comando = new SqlCommand(query, Conectar);

            // Agregar los parametros necesarios para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("D. Error al tratar de conectar con la base de datos", ex.Message);
                return false;
            }
        }
    }
}
