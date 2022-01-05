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
        private readonly E_Asignacion _asignacionObject;
        public TarjetaClickSilaboEventArgs(E_Asignacion asignacion)
        {
            _asignacionObject = asignacion;
        }
        public E_Asignacion CursoObject { get { return _asignacionObject; } }
    }
}
