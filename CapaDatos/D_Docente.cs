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
    class D_Docente
    {
        // Definir la conexion a la base de datos
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        // Metodo para mostrar la tabla de docentes de un determinado docente con algun filtro
        public DataTable BuscarDocentes(string Texto)
        {
            // Declar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            //Cadena de texto de Consulta a la BD
            string query = "SELECT * FROM TDocente WHERE CodDocente LIKE (@Texto + '%') OR Paterno LIKE (@Texto + '%') OR Materno LIKE(@Texto +'%') OR Nombres LIKE(@Texto +'%')";

            // Ejecutar la consulta
            SqlCommand Comando = new SqlCommand(query, Conectar);

            // Agregar los parametros necesarios para el procedimiento
            Comando.Parameters.AddWithValue("@Texto", Texto);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);

            // Retornar la tabla de datos con los docentes de un determinado director de escuela con algun filtro
            return Resultado;
        }

        // Metodo para insertar un registro de docente
        public void AgregarDocente(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "INSERT INTO TDocente VALUES(@CodDocente, @APaterno, @AMaterno, @Nombres, @Departamento, @Condicion, @Correo, @Telefono)";

            // Ejecutar la consulta
            SqlCommand Comando = new SqlCommand(query, Conectar);

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.Paterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.Materno);
            Comando.Parameters.AddWithValue("@Nombres", Docente.Nombres);
            Comando.Parameters.AddWithValue("@Departamento", Docente.Departamento);
            Comando.Parameters.AddWithValue("@Condicion", Docente.Condicion);
            Comando.Parameters.AddWithValue("@Correo", Docente.Correo);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Metodo para editar un registro de docente
        public void EditarDocente(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "UPDATE TDocente SET CodDocente = @CodDocente, Paterno = @APaterno, Materno = @AMaterno, Nombres = @Nombres, " +
                "Departamento = @Departamento, Condicion = @Condicion, Correo = @Correo, Telefono = @Telefono";

            // Ejecutar la consulta"
            SqlCommand Comando = new SqlCommand(query, Conectar);

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.Paterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.Materno);
            Comando.Parameters.AddWithValue("@Nombres", Docente.Nombres);
            Comando.Parameters.AddWithValue("@Departamento", Docente.Departamento);
            Comando.Parameters.AddWithValue("@Condicion", Docente.Condicion);
            Comando.Parameters.AddWithValue("@Correo", Docente.Correo);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            Conectar.Close();
        }

        // Metodo para eliminar un registro de docente
        public void EliminarDocente(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "DELETE FROM TDocente WHERE CodDocente = @CodDocente";

            // Ejecutar la consulta
            SqlCommand Comando = new SqlCommand(query, Conectar);

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
