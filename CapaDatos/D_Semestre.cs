using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class D_Semestre
    {
        Conexion conexion = new Conexion();
        public DataTable Mostrar()
        {
            string sql = "SELECT Semestre, Fecha_inicio = Fecha_inicio, Fecha_fin  FROM TSemestre ORDER by Fecha_inicio DESC";
            conexion.setComando(sql);

            return conexion.executeReader();
        }
        public bool Agregar(E_Semestre semestre)
        {
            string sql = "INSERT INTO TSemestre (Semestre, Fecha_inicio, Fecha_fin) VALUES (@Semestre, CONVERT(DATE,@Fecha_inicio,105), CONVERT(DATE,@Fecha_fin,105))";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Semestre", semestre.Semestre);
            conexion.cmd.Parameters.AddWithValue("@Fecha_inicio", semestre.Fecha_inicio);
            conexion.cmd.Parameters.AddWithValue("@Fecha_fin", semestre.Fecha_fin);

            return conexion.executeNonQuery() == 1;
        }
        public bool Editar(E_Semestre semestre)
        {
            string sql = "UPDATE TSemestre SET Fecha_inicio=CONVERT(DATE,@Fecha_inicio,105), Fecha_fin=CONVERT(DATE,@Fecha_fin,105) WHERE Semestre=@Semestre";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Semestre", semestre.Semestre);
            conexion.cmd.Parameters.AddWithValue("@Fecha_inicio", semestre.Fecha_inicio);
            conexion.cmd.Parameters.AddWithValue("@Fecha_fin", semestre.Fecha_fin);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable Buscar(string texto)
        {
            string sql = "SELECT * FROM TSemestre WHERE Semestre LIKE (@texto + '%')";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@texto", texto);

            return conexion.executeReader();
        }
    }
}
