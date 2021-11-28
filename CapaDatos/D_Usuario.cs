using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class D_Usuario
    {
        Conexion conexion = new Conexion();
        // Metodos CRUD
        public DataTable BuscarUsuario(String pUsuario,String pContrasenia)
        {
            string sql = "SELECT CodDocente, Usuario, Acceso FROM TUsuarios WHERE (Usuario = @pUsuario AND Contraseña = @pContrasenia)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@pUsuario", pUsuario);
            conexion.cmd.Parameters.AddWithValue("@pContrasenia", pContrasenia);
            return conexion.executeReader();
        }
        public bool EliminarCodDocente(string CodDocente)
        {
            string sql = "DELETE FROM TUsuarios WHERE CodDocente = @CodDocente";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@CodDocente", CodDocente);
            return conexion.executeNonQuery() >= 0;
        }
    }
}
