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

        // Definir una llave de cifrado para descifrar la informacion personal del estudiante
        private readonly string Key = "key_estudiante";

        // Metodo para buscar un determinado docente (tabla de datos)
        public DataTable BuscarDocente(string CodDocente)
        {
            // Declarar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuBuscarDocente"
            SqlCommand Comando = new SqlCommand("spuBuscarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar el parametro necesario para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);

            // Obtener los resultados del procedimiento almacenado la base de datos
            SqlDataAdapter Data = new SqlDataAdapter(Comando);

            // Asignar los resultados a la tabla de datos
            Data.Fill(Resultado);

            // Retornar la tabla de datos con los datos del docente buscado
            return Resultado;
        }

        // Metodo para mostrar la tabla de docentes de un determinado director de escuela con algun filtro
        public DataTable BuscarRegistros(string CodDocente, string Texto)
        {
            // Declar una tabla de datos para los docentes
            DataTable Resultado = new DataTable();

            // Ejecutar el procedimiento almacenado "spuBuscarDocentes"
            SqlCommand Comando = new SqlCommand("spuBuscarDocentes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
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
            // Ejecutar el procedimiento almacenado "spuInsertarDocente"
            SqlCommand Comando = new SqlCommand("spuInsertarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.Paterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.Materno);
            Comando.Parameters.AddWithValue("@Nombre", Docente.Nombres);
            Comando.Parameters.AddWithValue("@Direccion", Docente.Correo);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            Comando.Parameters.AddWithValue("@Categoria", Docente.Condicion);
            Comando.Parameters.AddWithValue("@Subcategoria", Docente.Departamento);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        // Metodo para editar un registro de docente
        public void EditarDocente(E_Docente Docente)
        {
            // Ejecutar el procedimiento almacenado "spuActualizarDocente"
            SqlCommand Comando = new SqlCommand("spuActualizarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.Parameters.AddWithValue("@APaterno", Docente.Paterno);
            Comando.Parameters.AddWithValue("@AMaterno", Docente.Materno);
            Comando.Parameters.AddWithValue("@Nombre", Docente.Nombres);
            Comando.Parameters.AddWithValue("@Direccion", Docente.Correo);
            Comando.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            Comando.Parameters.AddWithValue("@Categoria", Docente.Condicion);
            Comando.Parameters.AddWithValue("@Subcategoria", Docente.Departamento);
            Conectar.Close();
        }

        // Metodo para eliminar un registro de docente
        public void EliminarDocente(E_Docente Docente)
        {
            // Ejecutar el procedimiento almacenado "spuEliminarDocente"
            SqlCommand Comando = new SqlCommand("spuEliminarDocente", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            // Agregar los parametros necesarios para el procedimiento
            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
