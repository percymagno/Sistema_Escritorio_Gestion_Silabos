using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaPresentacion
{
    public class TarjetaClickSilaboEventArgs : EventArgs
    {
        private readonly E_Curso _cursoObject;
        public TarjetaClickSilaboEventArgs(E_Curso curso)
        {
            _cursoObject = curso;
        }
        public E_Curso CursoObject { get { return _cursoObject; } }
    }
}
