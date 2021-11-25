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
        Conexion conexion = new Conexion();
        // Metodos CRUD
        public DataTable ObtenerRegimen()
        {
            string sql = "SELECT * FROM TRegimen";
            conexion.setComando(sql);

            return conexion.executeReader();
        }
        public DataTable BuscarRegimen(String Texto)
        {
            string sql = "SELECT * FROM TRegimen WHERE CodRegimen LIKE (@Texto + '%')";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
    }
}
