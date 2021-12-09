using CapaDatos;
using CapaEntidades;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CapaNegocio
{
    public class N_Silabo
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID requerido")]
        public string Semestre { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID requerido")]
        public string CodCurso { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID requerido")]
        public string Unidad { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unidad es requerido")]
        public string Capitulo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Capitulo es requerido")]
        public string Tema { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tema es requerido")]
        public int NroHoras { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "NroHoras es requerido")]

        D_Silabo d_Silabo = new D_Silabo();

        public override string ToString()
        {
            return "CodCurso: " + CodCurso + ", Unidad: " + Unidad + ", Capitulo: " + Capitulo + ", Tema: " + Tema;
        }
        public int Guardar()
        {
            E_Silabo e_Silabo = new E_Silabo
            {
                Semestre = this.Semestre,
                CodCurso = this.CodCurso,
                Unidad = this.Unidad,
                Capitulo = this.Capitulo,
                Tema = this.Tema,
                NroHoras = this.NroHoras,
            };

            Console.WriteLine("Guardando: " + this.ToString());
            d_Silabo.Agregar(e_Silabo);
            return 1;
        }
        public DataTable Mostrar(string Semestre, string CodCurso)
        {
            return d_Silabo.MostrarCursoSemestre(Semestre, CodCurso);
        }
        public DataTable BuscarSemestre(string texto)
        {
            return d_Silabo.Buscar(texto);
        }
        public bool Editar()
        {
            return d_Silabo.Editar(new E_Silabo
            {
                ID = this.ID,
                Semestre = this.Semestre,
                CodCurso = CodCurso,
                Unidad = this.Unidad,
                Capitulo = this.Capitulo,
                Tema = this.Tema,
                NroHoras = this.NroHoras,
            });
        }
        public bool Eliminar(string ID)
        {
            return d_Silabo.Eliminar(ID);
        }
        public string buscarCurso(DataTable dt)
        {
            if (dt == null) return "";
            foreach (DataRow row in dt.Rows)
            {
                string CodCurso = row["CodCurso"].ToString();
                if (this.CodCurso == CodCurso)
                    return CodCurso;
            }
            return "";
        }
    }
}
