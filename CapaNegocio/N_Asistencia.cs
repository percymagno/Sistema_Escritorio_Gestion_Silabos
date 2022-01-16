using CapaDatos;
using CapaEntidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CapaNegocio
{
    public class N_Asistencia
    {
        public int ID { get; set; }
        public int ID_Registro { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID_Registro requerido")]
        public string CodAlumno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "CodAlumno es requerido")]
        public bool Asistio { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Asistio es requerido")]

        D_Asistencia d_Asistencia = new D_Asistencia();

        public override string ToString()
        {
            return "ID_Registro: " + ID_Registro + ", CodAlumno: " + CodAlumno + ", Asistio: " + Asistio;
        }

        public int Guardar()
        {
            E_Asistencia e_Asistencia = new E_Asistencia
            {
                ID_Registro = this.ID_Registro,
                CodAlumno = this.CodAlumno,
                Asistio = this.Asistio,
            };

            Console.WriteLine("Guardando: " + this.ToString());
            d_Asistencia.Agregar(e_Asistencia);
            return 1;
        }
        public DataTable Mostrar(DateTime Fecha, int AsignacionID)
        {
            return d_Asistencia.MostrarFechaAsignacion(Fecha, AsignacionID);
        }
        public DataTable Buscar(int AsignacionID, string texto)
        {
            return d_Asistencia.Buscar(AsignacionID, texto);
        }
        public bool Editar()
        {
            return d_Asistencia.Editar(new E_Asistencia
            {
                ID = this.ID,
                ID_Registro = this.ID_Registro,
                CodAlumno = this.CodAlumno,
                Asistio = this.Asistio,
            });
        }
        public bool Eliminar(string ID)
        {
            return d_Asistencia.Eliminar(ID);
        }
    }
}
