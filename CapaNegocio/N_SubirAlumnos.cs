using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class N_SubirAlumnos
    {
        readonly int asignacion;
        readonly string[] Words;
        public N_SubirAlumnos(int pAsignacion, string[] pWords)
        {
            asignacion = pAsignacion;
            Words = pWords;
        }
        List<N_Alumno> LAlumnos = new List<N_Alumno>();
        List<N_AlumnoCurso> LAlumnosCurso = new List<N_AlumnoCurso>();
        #region Leer archivo
        public void ProcesarCarga()
        {
            int n = Words.Length;

            for (int i = 0; i < n; i = i + 3)
            {
                N_Alumno Alumno = new N_Alumno
                {
                    CodAlumno = Words[i + 1],
                    Nombres = Words[i + 2],
                };
                LAlumnos.Add(Alumno);
                N_AlumnoCurso AlumnoCurso = new N_AlumnoCurso
                {
                    Asignacion = asignacion,
                    NRO = Int32.Parse(Words[i]),
                    CodAlumno = Words[i + 1],
                    
                };
                LAlumnosCurso.Add(AlumnoCurso);
            }
        }
        #endregion Leer archivo
        public List<N_Alumno> GetAlumnos()
        {
            return LAlumnos;
        }
        public List<N_AlumnoCurso> GetAlumnosCurso()
        {
            return LAlumnosCurso;
        }
    }
}
