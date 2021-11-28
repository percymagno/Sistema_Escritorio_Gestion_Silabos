using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Curso
    {
        // Definir los atributos o campos que tiene un docente
        [Required(AllowEmptyStrings = false, ErrorMessage = "Codigo de Curso es requerido")]
        public string CodCurso { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre de Curso es requerido")]
        public string Nombre { get; set; }
        [Range(2, 5, ErrorMessage = "El rango de Creditos es [2, 5]")]
        public int Creditos { get; set; }
        public string Categoria { get; set; }
        // objeto capa de datos
        D_Curso d_Curso = new D_Curso();

        public bool AgregarCurso()
        {
            E_Curso e_Curso = new E_Curso
            {
                CodCurso = this.CodCurso,
                Nombre = this.Nombre,
                Creditos = this.Creditos,
                Categoria = this.Categoria
            };
            return d_Curso.AgregarCurso(e_Curso);
        }
        public DataTable ObtenerCursos()
        {
            return d_Curso.ObtenerCursos();
        }
        public DataTable BuscarCurso(String Texto)
        {
            return d_Curso.BuscarCurso(Texto);
        }
        public bool EditarCurso()
        {
            E_Curso e_Curso = new E_Curso
            { 
                CodCurso = this.CodCurso, 
                Nombre = this.Nombre, 
                Creditos = this.Creditos, 
                Categoria = this.Categoria 
            };
            return d_Curso.EditarCurso(e_Curso);
        }
        public bool EliminarCurso()
        {
            if (new D_Asignacion().ElminarCodDocenteCurso(CodCurso))
                return d_Curso.EliminarCurso(CodCurso);
            else
                Console.WriteLine("No se pudo borrar asignaciones");
            return false;
        }
    }
}
