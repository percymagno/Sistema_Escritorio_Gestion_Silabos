using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class N_Asignacion
    {
        private readonly Random _random = new Random();

        Excel excel;
        int row = 0;
        int col = 0;
        List<Carga> cargas = new List<Carga>();
        List<E_Docente> docentes = new List<E_Docente>();
        List<E_Curso> cursos = new List<E_Curso>();
        public int Procesar(string path)
        {
            excel = new Excel(path, 1);
            int nroRows = excel.nroRows();
            while (row != -1 && row < nroRows)
            {
                ActualizarIndexCarga();
                ProcesarCarga();
                Console.WriteLine("");
            }

            excel.closeExcel();
            excel = null;
            return nroRows;
        }
        #region Leer archivo
        private void ActualizarIndexCarga()
        {
            for (int i = row; i < excel.nroRows(); i++)
            {
                for (int j = 0; j < excel.nroCols(); j++)
                {
                    string cell = excel.ReadCell(i, j);
                    if (cell != null && cell.ToUpper() == "CARRERA")
                    {

                        row = i;
                        col = j-1;
                        return;
                    }
                }
            }
            row = -1;
        }
        private void ProcesarCarga()
        {
            // Nombre de docente
            string codDocente = _random.Next(100000, 999999).ToString();
            string docente = excel.ReadCell(row, col+2);
            string regimen = excel.ReadCell(row, col);
            E_Docente e_Docente = new E_Docente 
                {
                    CodDocente = codDocente,
                    Nombres = docente,
                    Regimen = regimen,
                };
            docentes.Add(e_Docente);
            row++;
            // Carga
            for (int i = row; i < excel.nroRows(); i++)
            {
                bool nuevaCarga = true;
                List<string> lista = new List<string>();
                if (excel.ReadCell(i, col) == "")
                    nuevaCarga = false;

                for (int j = col; j < col+13; j++)
                {
                    string cell = excel.ReadCell(i, j);
                    if (cell.ToUpper() == "CARRERA")
                    {
                        row = i;
                        return;
                    }

                    lista.Add(cell);
                }
                if (nuevaCarga)
                {
                    Carga carga1 = new Carga
                    {
                        CodCurso = lista[0].Substring(0,5),
                        CodDocente = codDocente,
                        Docente = docente,
                        Carrera = lista[1],
                        NombreCurso = lista[2],
                        Creditos = lista[3],
                        Tipo = lista[4],
                        Grupo = lista[5],
                        HT = Int32.Parse(lista[6]),
                        HP = Int32.Parse(lista[7]),
                        Dia = lista[8],
                        HR_inicio = Int32.Parse(lista[9]),
                        HR_fin = Int32.Parse(lista[10]),
                        Aula = lista[11],
                        Matriculados = Int32.Parse(lista[12]),
                    };
                    cargas.Add(carga1);
                    Console.WriteLine(carga1);
                }
                if(i == excel.nroRows() - 1)
                    row = -1;
            }
        }
        #endregion Leer archivo
        public void Guardar()
        {
            GuardarCargas();
            cargas.Clear();
            docentes.Clear();
        }
        public void ActualizarDocentes()
        {
            D_Docente d_Docente = new D_Docente();
            DataTable dt_Docentes = d_Docente.MostrarDocentes();

            foreach (E_Docente docente in docentes)
            {
                if(!existeDocente(docente.Nombres, dt_Docentes))
                {
                    Console.WriteLine("Guardando docente: " + docente.Nombres + ", regimen: '" + docente.Regimen + "', codigo: " + docente.CodDocente);
                    bool ans = d_Docente.AgregarDocenteCarga(docente);
                }
            }
        }
        public void ActualizarCursos()
        {
            D_Curso d_Curso = new D_Curso();
            DataTable dt_Cursos = d_Curso.ObtenerCursos();
            foreach (Carga carga in cargas)
            {
                if (!existeCurso(carga.CodCurso, dt_Cursos))
                {
                    Console.WriteLine("Guardando curso: " + carga.NombreCurso + ", cod: '" + carga.CodCurso + "', creditos: " + carga.Creditos);
                    E_Curso e_Curso = new E_Curso
                    {
                        CodCurso = carga.CodCurso,
                        Nombre = carga.NombreCurso,
                        Creditos = Int32.Parse(carga.Creditos),
                        Categoria = "",
                    };
                    d_Curso.AgregarCurso(e_Curso);
                }
            }
        }
        public void GuardarCargas()
        {
            foreach (Carga carga in cargas)
            {
                carga.Guardar();
            }
        }
        public bool existeDocente(string pNombres, DataTable dt)
        {
            if (dt == null) return false;
            foreach (DataRow row in dt.Rows)
            {
                string Nombres = (row["Nombres"].ToString() + " " + row["Paterno"].ToString() + " " + row["Materno"].ToString()).Trim();
                if (pNombres == Nombres)
                    return true;
            }
            return false;
        }
        public bool existeCurso(string pNombres, DataTable dt)
        {
            if (dt == null) return false;
            foreach (DataRow row in dt.Rows)
            {
                string Nombres = row["CodCurso"].ToString();
                if (pNombres == Nombres)
                    return true;
            }
            return false;
        }
        public List<Carga> getCargas()
        {
            return cargas;
        }
    }
}
