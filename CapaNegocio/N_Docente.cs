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
    public class N_Docente
    {
        // Definir los atributos o campos que tiene un docente
        [Required(AllowEmptyStrings = false, ErrorMessage = "Codigo de Docente es requerido")]
        public string CodDocente { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Apellido paterno del Docente es requerido")]
        public string Paterno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Apellido materno del Docente es requerido")]
        public string Materno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombre de Docente es requerido")]
        public string Nombre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Regimen de Docente es requerido")]
        public string Regimen { get; set; }
        [Required(ErrorMessage = "Correo de Docente es requerido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Correo es Invalido")]
        public string Correo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Telefono de Docente es requerido")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Telefono de Docente solo debe contener numeros")]
        [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "Telefono de Docente debe tener 9 digitos")]
        public string Telefono { get; set; }
        // objeto capa de datos
        D_Docente d_Docente = new D_Docente();

        public bool AgregarDocente()
        {
            E_Docente e_Docente = new E_Docente()
            {
                CodDocente = this.CodDocente,
                Paterno = this.Paterno,
                Materno = this.Materno,
                Nombres = this.Nombre,
                Correo = this.Correo,
                Regimen = this.Regimen,
                Telefono = this.Telefono
            };
            return d_Docente.AgregarDocente(e_Docente);
        }
        public DataTable ObtenerDocentes()
        {
            return d_Docente.MostrarDocentes();
        }
        public DataTable BuscarDocente(String Texto)
        {
            return d_Docente.BuscarDocentes(Texto);
        }
        public bool EditarDocente()
        {
            E_Docente e_Docente = new E_Docente
            {
                CodDocente = this.CodDocente,
                Paterno = this.Paterno,
                Materno = this.Materno,
                Nombres = this.Nombre,
                Correo = this.Correo,
                Regimen = this.Regimen,
                Telefono = this.Telefono
            };
            return d_Docente.EditarDocente(e_Docente);
        }
        public bool EliminarDocente()
        {
            if (new D_Asignacion().ElminarCodDocenteCurso(CodDocente))
            {
                if (new D_Usuario().EliminarCodDocente(CodDocente))
                {

                    return d_Docente.EliminarDocente(CodDocente);
                }
                else
                    Console.WriteLine("usuario no borrador");
            }
            else
                Console.WriteLine("asignaciones no borradas");
            return false;
        }
    }
}
