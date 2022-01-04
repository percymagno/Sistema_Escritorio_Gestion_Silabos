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
    public class N_Carga
    {
        private readonly Random _random = new Random();

        Excel excel;
        int row = 0;
        int col = 0;
        List<N_Asignacion> carga = new List<N_Asignacion>();
        List<E_Docente> docentes = new List<E_Docente>();
        List<E_Curso> cursos = new List<E_Curso>();
        public int Procesar(string path)
        {
            excel = new Excel(path, 1);
            int nroRows = excel.nroRows();
            while (row != -1 && row < nroRows)
            {
                ActualizarIndexCarga();
                if (row == -1) continue;
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
            // -- Primera fila, datos de docente
            E_Docente docente = new E_Docente();
            docente.Regimen = excel.ReadCell(row, col);
            string[] nombresCompletos = excel.ReadCell(row, col+2).ToString().Split(' ');
            // separar nombresCompletos
            docente.Materno = nombresCompletos[nombresCompletos.Length - 1];
            docente.Paterno = nombresCompletos[nombresCompletos.Length - 2];
            string nombres = "";
            for(int i = 0; i < nombresCompletos.Length-2; i++)
                nombres += nombresCompletos[i] + " ";
            docente.Nombres = nombres.Trim();
            // agregar docente
            docentes.Add(docente);


            row++;
            // Carga
            N_Asignacion asignacion = new N_Asignacion();
            for (int i = row; i < excel.nroRows(); i++)
            {
                bool nuevaAsignacion = true;
                List<string> lista = new List<string>();
                if (excel.ReadCell(i, col) == "")
                    nuevaAsignacion = false;

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
                if (nuevaAsignacion)
                {
                    bool addAsig = false;
                    E_Curso curso = new E_Curso { CodCurso = lista[0].Substring(0, 5), Nombre = lista[2], Creditos = Int32.Parse(lista[3]) };
                    cursos.Add(curso);
                    if (asignacion.Docente==null || asignacion.Docente.Nombres != docente.Nombres || asignacion.Curso.CodCurso != curso.CodCurso || asignacion.Grupo != lista[0].Substring(5, 1))
                    {
                        addAsig = true;
                        asignacion = new N_Asignacion
                        {
                            Docente = docente,
                            Curso = curso,
                            Carrera = lista[1],
                            Grupo = lista[0].Substring(5, 1),
                            Aula = lista[11],
                            Matriculados = Int32.Parse(lista[12]),
                        };
                    }
                    E_Dia dia = new E_Dia
                    {
                        Dia = lista[8],
                        Tipo = lista[4],
                        HR_inicio = Int32.Parse(lista[9]),
                        HR_fin = Int32.Parse(lista[10]),
                    };
                    Console.WriteLine(dia.Dia + " - " + dia.Tipo);
                    asignacion.Dias.Add(dia);
                    if (addAsig)
                    {
                        addAsig = false;
                        carga.Add(asignacion);
                    }
                    //Console.WriteLine(dia.Asignacion);
                }
                if(i == excel.nroRows() - 1)
                    row = -1;
            }
        }
        #endregion Leer archivo
        public void Limpiar()
        {
            carga.Clear();
        }
        public List<N_Asignacion> getCarga()
        {
            return carga;
        }
        public List<E_Docente> getDocentes()
        {
            return docentes;
        }
        public List<E_Curso> getCursos()
        {
            return cursos;
        }
    }
}
