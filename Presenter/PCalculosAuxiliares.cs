using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace Presentador
{
    public class PCalculosAuxiliares
    {
        private readonly ICalculosAux _vista;
        private DAOCalculosAuxiliares _modelo;
        public PCalculosAuxiliares(ICalculosAux vista)
        {
            _vista = vista;
            _modelo = new DAOCalculosAuxiliares();
       
        }

        public void setcalculosAux (int idPrespuesto)
        {
            _vista.calculosAux = _modelo.obtenercalculosAux(idPrespuesto);
        }
    }
}
