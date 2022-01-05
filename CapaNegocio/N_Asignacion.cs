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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Grupo es requerido")]
        public string Grupo { get; set; }
        public string Aula { get; set; }
        public int Matriculados { get; set; }

        public List<E_Dia> Dias = new List<E_Dia>();

        D_Asignacion d_Asignacion = new D_Asignacion();

        public override string ToString()
        {
            return "CodCurso: " + Curso.CodCurso.Substring(0,5) + ", Docente: " + Docente.CodDocente + ", Grupo: " + Grupo + ", Semestre: "+ Semestre;
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
                Grupo = this.Grupo,
                Aula = this.Aula,
                Carrera = this.Carrera
            };
            if (buscar(dt_Asignacion)) return 0;

            d_Asignacion.Agregar(e_Asignacion);
            DataTable dt = d_Asignacion.BuscarDocenteCurso(Docente.CodDocente, Curso.CodCurso);
            D_Dia d_Dia = new D_Dia();
            foreach (E_Dia Dia in Dias)
            {
                Dia.Asignacion = Int32.Parse(dt.Rows[0][0].ToString());
                d_Dia.Agregar(Dia);
            }

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
            bool ans = false;
            ans = d_Asignacion.Editar(new E_Asignacion {
                ID = this.ID,
                Semestre = this.Semestre,
                CodDocente = Docente.CodDocente,
                CodCurso = Curso.CodCurso,
                Grupo = this.Grupo,
                Aula = this.Aula,
            });
            D_Dia d_Dia = new D_Dia();
            d_Dia.EliminarAsignacion(this.ID);
            foreach (E_Dia Dia in Dias)
            {
                Dia.Asignacion = ID;
                d_Dia.Agregar(Dia);
            }
            return ans;
        }
        public bool Eliminar(string ID)
        {
            D_Dia d_Dia = new D_Dia();
            d_Dia.EliminarAsignacion(Int32.Parse(ID));
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
                if (Curso.CodCurso == tmpCodCurso && Docente.CodDocente == tmpCodDocente && Grupo == tmpGrupo)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
