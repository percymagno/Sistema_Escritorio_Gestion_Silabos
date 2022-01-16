using CapaDatos;
using CapaEntidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CapaNegocio
{
    public class N_RegistroAvance
    {
        public int ID { get; set; }
        public int ID_Silabo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID_Silabo requerido")]
        public DateTime Fecha { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fecha es requerido")]
        public string Observacion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Observacion es requerido")]

        D_RegistroAvance d_RegistroAvance = new D_RegistroAvance();

        public override string ToString()
        {
            return "ID_Silabo: " + ID_Silabo + ", Fecha: " + Fecha + ", Observacion: " + Observacion;
        }

        public int Guardar()
        {
            E_RegistroAvance e_RegistroAvance = new E_RegistroAvance
            {
                ID_Silabo = this.ID_Silabo,
                Fecha = this.Fecha,
                Observacion = this.Observacion,
            };

            Console.WriteLine("Guardando: " + this.ToString());
            d_RegistroAvance.Agregar(e_RegistroAvance);
            return 1;
        }
        public DataTable Mostrar(int AsignacionID)
        {
            return d_RegistroAvance.MostrarAsignacion(AsignacionID);
        }
        public DataTable Buscar(int AsignacionID, string texto)
        {
            return d_RegistroAvance.Buscar(AsignacionID, texto);
        }
        public bool Editar()
        {
            return d_RegistroAvance.Editar(new E_RegistroAvance
            {
                ID = this.ID,
                ID_Silabo = this.ID_Silabo,
                Fecha = this.Fecha,
                Observacion = this.Observacion,
            });
        }
        public bool Eliminar(string ID)
        {
            return d_RegistroAvance.Eliminar(ID);
        }
    }
}
