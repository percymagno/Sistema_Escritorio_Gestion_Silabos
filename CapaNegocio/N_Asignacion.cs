using System;
using System.Collections.Generic;
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
        public E_Docente Docente { get; set; }
        public E_Curso Curso { get; set; }
        public string Carrera { get; set; }
        public string Tipo { get; set; }
        public string Grupo { get; set; }
        public int HT { get; set; }
        public int HP { get; set; }
        public string Dia { get; set; }
        public int HR_inicio { get; set; }
        public int HR_fin { get; set; }
        public string Aula { get; set; }
        public int Matriculados { get; set; }

        D_Asignacion d_Asignacion = new D_Asignacion();

        public override string ToString()
        {
            return "CodCurso: " + Curso.CodCurso.Substring(0,5) + ", Docente: " + Docente.CodDocente + ", Tipo: " + Tipo + ", Grupo: " + Grupo;
        }
        public int Guardar(DataTable dt_docente, DataTable dt_curso, DataTable dt_Asignacion)
        {
            // buscar docente
            Docente.CodDocente = buscarDocente(dt_docente);
            Curso.CodCurso = buscarCurso(dt_curso);
            if (Docente.CodDocente == "")
                return -1;
            if (Curso.CodCurso == "")
                return -1;
            E_Asignacion e_Asignacion = new E_Asignacion
            {
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
        public DataTable Buscar(string ID)
        {
            return d_Asignacion.Buscar(ID);
        }
        public bool Editar(E_Asignacion ea)
        {
            return d_Asignacion.Editar(ea);
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
                if (this.Docente.Nombres == Nombres)
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
                    return true;
            }
            return false;
        }
    }
}
