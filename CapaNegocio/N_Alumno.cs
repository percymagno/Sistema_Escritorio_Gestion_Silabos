using CapaDatos;
using CapaEntidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CapaNegocio
{
    public class N_Alumno
    {
        public string CodAlumno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "CodAlumno es requerido")]
        public string Nombres { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombres es requerido")]


        D_Alumno d_Alumno = new D_Alumno();

        public override string ToString()
        {
            return "CodAlumno: " + CodAlumno + ", Tema: " + Nombres;
        }

        public int Guardar()
        {
            E_Alumno e_Alumno = new E_Alumno
            {
                CodAlumno = this.CodAlumno,
                Nombres = this.Nombres,
            };

            Console.WriteLine("Guardando: " + this.ToString());
            d_Alumno.Agregar(e_Alumno);
            return 1;
        }
        public DataTable Mostrar()
        {
            return d_Alumno.Mostrar();
        }
        public DataTable Buscar(string texto)
        {
            return d_Alumno.Buscar(texto);
        }
        public bool Editar()
        {
            return d_Alumno.Editar(new E_Alumno
            {
                CodAlumno = this.CodAlumno,
                Nombres = this.Nombres,
            });
        }
        public bool Eliminar(string CodAlumno)
        {
            return d_Alumno.Eliminar(CodAlumno);
        }
    }
}
