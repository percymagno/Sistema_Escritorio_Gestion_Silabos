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
            // Primera fila, datos de docente
            string docente = excel.ReadCell(row, col+2);
            string regimen = excel.ReadCell(row, col);
            row++;
            // Carga
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
                    N_Asignacion asignacion = new N_Asignacion
                    {
                        Docente = new E_Docente { Nombres = docente, Regimen =  regimen},
                        Curso = new E_Curso { CodCurso = lista[0].Substring(0, 5), Nombre = lista[2], Creditos = Int32.Parse(lista[3]) },
                        Carrera = lista[1],
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
                    carga.Add(asignacion);
                    Console.WriteLine(asignacion);
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
    }
}
