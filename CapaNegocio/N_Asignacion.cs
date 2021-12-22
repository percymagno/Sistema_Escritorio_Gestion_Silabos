using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Asignacion
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Semestre requerido")]
        public string Semestre { get; set; }
        public E_Docente Docente { get; set; }
        public E_Curso Curso { get; set; }
        public string Carrera { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tipo es requerido")]
        public string Tipo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Grupo es requerido")]
        public string Grupo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "HT(Horas teoricas) es requerido")]
        public int HT { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "HP(Horas Practicas) es requerido")]
        public int HP { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Dia es requerido")]
        public string Dia { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "HR_inicio es requerido")]
        public int HR_inicio { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "HR_fin es requerido")]
        public int HR_fin { get; set; }
        public string Aula { get; set; }
        public int Matriculados { get; set; }

        D_Asignacion d_Asignacion = new D_Asignacion();

        public override string ToString()
        {
            return "CodCurso: " + Curso.CodCurso.Substring(0,5) + ", Docente: " + Docente.CodDocente + ", Tipo: " + Tipo + ", Grupo: " + Grupo + ", Semestre: "+ Semestre;
        }
        public int Guardar(DataTable dt_docente, DataTable dt_curso, DataTable dt_Asignacion=null)
        {
            if (dt_Asignacion == null)
                dt_Asignacion = Mostrar();
            // buscar docente
            Docente.CodDocente = buscarDocente(dt_docente);
            Curso.CodCurso = buscarCurso(dt_curso);
            if (Docente.CodDocente == "")
                return -1;
            if (Curso.CodCurso == "")
                return -1;
            E_Asignacion e_Asignacion = new E_Asignacion
            {
                Semestre = this.Semestre,
                CodDocente = Docente.CodDocente,
                CodCurso = Curso.CodCurso,
                Tipo = this.Tipo,
                Grupo = this.Grupo,
                HT = this.HT,
                HP = this.HP,
                Dia = this.Dia,
                HR_inicio = this.HR_inicio,
                HR_fin = this.HR_fin,
                Aula = this.Aula,
            };
            if (buscar(dt_Asignacion)) return 0;

            Console.WriteLine("Guardando: " + this.ToString());
            d_Asignacion.Agregar(e_Asignacion);
            return 1;
        }
        public DataTable Mostrar()
        {
            return d_Asignacion.Mostrar();
        }
        public DataTable BuscarSemestre(string texto)
        {
            return d_Asignacion.BuscarSemestre(texto);
        }
        public bool Editar()
        {
            return d_Asignacion.Editar(new E_Asignacion {
                ID = this.ID,
                Semestre = this.Semestre,
                CodDocente = Docente.CodDocente,
                CodCurso = Curso.CodCurso,
                Tipo = this.Tipo,
                Grupo = this.Grupo,
                HT = this.HT,
                HP = this.HP,
                Dia = this.Dia,
                HR_inicio = this.HR_inicio,
                HR_fin = this.HR_fin,
                Aula = this.Aula,
            });
        }
        public bool Eliminar(string ID)
        {
            return d_Asignacion.Eliminar(ID);
        }
        public string buscarDocente(DataTable dt)
        {
            if (dt == null) return "";
            foreach (DataRow row in dt.Rows)
            {
                string Nombres = (row["Nombres"].ToString() + " " + row["Paterno"].ToString() + " " + row["Materno"].ToString()).Trim();
                if (this.Docente.Nombres + " " + this.Docente.Paterno + " " + this.Docente.Materno == Nombres)
                    return row["CodDocente"].ToString();
            }
            return "";
        }
        public string buscarCurso(DataTable dt)
        {
            if (dt == null) return "";
            foreach (DataRow row in dt.Rows)
            {
                string CodCurso = row["CodCurso"].ToString();
                if (this.Curso.CodCurso == CodCurso)
                    return CodCurso;
            }
            return "";
        }
        public bool buscar(DataTable dt)
        {
            if (dt == null) return false;
            foreach (DataRow row in dt.Rows)
            {
                string tmpCodDocente = row["CodDocente"].ToString();
                string tmpCodCurso = row["CodCurso"].ToString();
                string tmpGrupo = row["Grupo"].ToString();
                string tmpDia = row["Dia"].ToString();
                string tmpHR_inicio = row["HR_inicio"].ToString();
                string tmpHr_fin = row["HR_fin"].ToString();
                if (Curso.CodCurso == tmpCodCurso && Docente.CodDocente == tmpCodDocente && Grupo == tmpGrupo &&
                    Dia == tmpDia && HR_inicio.ToString() == tmpHR_inicio && HR_fin.ToString() == tmpHr_fin)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
