using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentador
{
    class PPresupuesto
    {
        private readonly IVistaOperaciones _vista;
        private ModeloOperaciones _modelo;
        public PresentadorOperaciones(IVistaOperaciones vista)
        {
            _vista = vista;
            _modelo = new ModeloOperaciones();
        }
        public void IniciarVista()
        {
            _vista.Num1 = 0;
            _vista.Num2 = 0;
            _vista.Resultado = 0;
        }
        public void ActualizarVista()
        {
            _vista.Resultado = _modelo.Sumar(_vista.Num1, _vista.Num2);
        }
    }
}
