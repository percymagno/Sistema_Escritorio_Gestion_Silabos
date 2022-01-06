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
        private readonly string _button;
        public TarjetaClickSilaboEventArgs(E_Asignacion asignacion, string button = "")
        {
            _asignacionObject = asignacion;
            _button = button;
        }
        public E_Asignacion CursoObject { get { return _asignacionObject; } }
        public string Button { get { return _button; } }
    }
}
