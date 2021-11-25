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
        Conexion conexion = new Conexion();
        // Metodos CRUD
        // Metodo para mostrar la tabla de docentes 
        public DataTable MostrarDocentes()
        {
            //Cadena de texto de Consulta a la BD
            string query = "SELECT * FROM TDocente";

            // Ejecutar la consulta
            conexion.setComando(query);

            return conexion.executeReader();
        }

        // Metodo para mostrar la tabla de docentes de un determinado docente con algun filtro
        public DataTable BuscarDocentes(string Texto)
        {
            //Cadena de texto de Consulta a la BD
            string query = "SELECT * FROM TDocente WHERE CodDocente LIKE (@Texto + '%') OR Paterno LIKE (@Texto + '%') OR Materno LIKE(@Texto +'%') OR Nombres LIKE(@Texto +'%')";

            // Ejecutar la consulta
            conexion.setComando(query);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);
            
            return conexion.executeReader();
        }

        // Metodo para insertar un registro de docente
        public bool AgregarDocente(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "INSERT INTO TDocente VALUES(@CodDocente, @APaterno, @AMaterno, @Nombres, @Regimen, @Correo, @Telefono)";

            // Ejecutar la consulta
            conexion.setComando(query);

            // Agregar los parametros necesarios para el procedimiento
            conexion.cmd.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            conexion.cmd.Parameters.AddWithValue("@APaterno", Docente.Paterno);
            conexion.cmd.Parameters.AddWithValue("@AMaterno", Docente.Materno);
            conexion.cmd.Parameters.AddWithValue("@Nombres", Docente.Nombres);
            conexion.cmd.Parameters.AddWithValue("@Regimen", Docente.Regimen);
            conexion.cmd.Parameters.AddWithValue("@Correo", Docente.Correo);
            conexion.cmd.Parameters.AddWithValue("@Telefono", Docente.Telefono);

            return conexion.executeNonQuery() == 1;
        }
        // Agregar docente mediante carga
        public bool AgregarDocenteCarga(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "INSERT INTO TDocente (CodDocente, Nombres, Regimen) VALUES(@CodDocente, @Nombres, @Regimen)";

            // Ejecutar la consulta
            conexion.setComando(query);

            // Agregar los parametros necesarios para el procedimiento
            conexion.cmd.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            conexion.cmd.Parameters.AddWithValue("@Nombres", Docente.Nombres);
            conexion.cmd.Parameters.AddWithValue("@Regimen", Docente.Regimen);
            
            return conexion.executeNonQuery()==1;
        }
        // Metodo para editar un registro de docente
        public bool EditarDocente(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "UPDATE TDocente SET Paterno = @APaterno, Materno = @AMaterno, Nombres = @Nombres, " +
                "Regimen = @Regimen, Correo = @Correo, Telefono = @Telefono WHERE CodDocente = @CodDocente";

            // Ejecutar la consulta"
            conexion.setComando(query);

            // Agregar los parametros necesarios para el procedimiento

            conexion.cmd.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            conexion.cmd.Parameters.AddWithValue("@APaterno", Docente.Paterno);
            conexion.cmd.Parameters.AddWithValue("@AMaterno", Docente.Materno);
            conexion.cmd.Parameters.AddWithValue("@Nombres", Docente.Nombres);
            conexion.cmd.Parameters.AddWithValue("@Regimen", Docente.Regimen);
            conexion.cmd.Parameters.AddWithValue("@Correo", Docente.Correo);
            conexion.cmd.Parameters.AddWithValue("@Telefono", Docente.Telefono);
            
            return conexion.executeNonQuery() == 1;
        }

        // Metodo para eliminar un registro de docente
        public bool EliminarDocente(E_Docente Docente)
        {
            //Cadena de texto de Consulta a la BD
            string query = "DELETE FROM TDocente WHERE CodDocente = @CodDocente";

            // Ejecutar la consulta
            conexion.setComando(query);

            // Agregar los parametros necesarios para el procedimiento
            conexion.cmd.Parameters.AddWithValue("@CodDocente", Docente.CodDocente);
            
            return conexion.executeNonQuery()==1;
        }
    }
}
