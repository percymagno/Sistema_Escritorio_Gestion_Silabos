using CapaDatos;
using CapaEntidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CapaNegocio
{
    class N_Alumno
    {
        public int ID { get; set; }
        public int Asignacion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID requerido")]
        public int NRO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "NRO requerido")]
        public string CodAlumno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unidad es requerido")]
        public string Paterno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "APaterno es requerido")]
        public string Materno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "AMaterno es requerido")]
        public string Nombres { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nombres es requerido")]


        D_Alumno d_Alumno = new D_Alumno();

        public override string ToString()
        {
            return "AsignacionID: " + Asignacion + ", Unidad: " + Paterno + ", Capitulo: " + Materno + ", Tema: " + Nombres;
        }

        public int Guardar()
        {
            E_Alumno e_Alumno = new E_Alumno
            {
                Asignacion = this.Asignacion,
                NRO = this.NRO,
                CodAlumno = this.CodAlumno,
                Paterno = this.Paterno,
                Materno = this.Materno,
                Nombres = this.Nombres,
            };

            Console.WriteLine("Guardando: " + this.ToString());
            d_Alumno.Agregar(e_Alumno);
            return 1;
        }
        public DataTable Mostrar(string Semestre, int ID)
        {
            return d_Alumno.MostrarCursoSemestre(Semestre, ID);
        }
        public DataTable BuscarSemestre(string texto)
        {
            return d_Alumno.Buscar(texto);
        }
        public bool Editar()
        {
            return d_Alumno.Editar(new E_Alumno
            {
                ID = this.ID,
                Asignacion = this.Asignacion,
                NRO = this.NRO,
                CodAlumno = this.CodAlumno,
                Paterno = this.Paterno,
                Materno = this.Materno,
                Nombres = this.Nombres,
            });
        }
        public bool Eliminar(string ID)
        {
            return d_Alumno.Eliminar(ID);
        }
        public int buscarCurso(DataTable dt)
        {
            if (dt == null) return -1;
            foreach (DataRow row in dt.Rows)
            {
                int Asignacion = Int32.Parse(row["Asignacion"].ToString());
                if (this.Asignacion == Asignacion)
                    return this.Asignacion;
            }
            return -1;
        }
    }
}
