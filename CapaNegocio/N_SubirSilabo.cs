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
    public class N_SubirSilabo
    {
        readonly string CodCurso;
        readonly string Semestre;
        public N_SubirSilabo(string pCodCurso, string pSemestre)
        {
            CodCurso = pCodCurso;
            Semestre = pSemestre;
        }

        Excel excel;
        int row = 0;
        int col = 0;
        List<N_Silabo> SSilabo = new List<N_Silabo>();
        public int Procesar(string path)
        {
            excel = new Excel(path, 1);
            int nroRows = excel.nroRows();
            int nroCols = excel.nroCols();
            int prow = 0;
            int pcol = 0;
            while (prow < nroRows)
            {
                while (pcol < nroCols)
                {
                    if (excel.ReadCell(prow, pcol).ToUpper() == "UNIDAD")
                    {
                        row = prow + 1;
                        col = pcol;
                        ProcesarCarga();
                        break;
                    }
                    pcol += 1;
                }
                prow += 1;
            }

            excel.closeExcel();
            excel = null;
            return nroRows;
        }
        #region Leer archivo
        private void ProcesarCarga()
        {
            int nroRows = excel.nroRows();
            int nroCols = excel.nroCols();
            // Carga
            for (int i = row; i < nroRows; i++)
            {
                List<string> lista = new List<string>();
                for (int j = col; j < nroCols; j++)
                {
                    string cell = excel.ReadCell(i, j);
                    lista.Add(cell);
                }
                N_Silabo Silabo = new N_Silabo
                {
                    Semestre = Semestre,
                    CodCurso = CodCurso,
                    Unidad = lista[0],
                    Capitulo = lista[1],
                    Tema = lista[2],
                    NroHoras = Int32.Parse(lista[3]),
                };
                SSilabo.Add(Silabo);
            }
        }
        #endregion Leer archivo
        public void Limpiar()
        {
            SSilabo.Clear();
        }
        public List<N_Silabo> getSilabo()
        {
            return SSilabo;
        }
    }
}
