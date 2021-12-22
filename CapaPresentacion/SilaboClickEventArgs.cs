using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaPresentacion
{
    public class SilaboClickEventArgs : EventArgs
    {
        private readonly E_Curso _cursoObject;
        public SilaboClickEventArgs(E_Curso curso)
        {
            _cursoObject = curso;
        }
        public E_Curso CursoObject { get { return _cursoObject; } }
    }
}
