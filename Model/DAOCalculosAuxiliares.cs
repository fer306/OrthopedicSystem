using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DAOCalculosAuxiliares
    {
        public string obtenercalculosAux(int idPrespuesto)
        {
            StringBuilder CalculosAux = new StringBuilder();

            using (var db = new dbDataContext())
            {

                foreach (obtenerCalculosAuxiliaresResult listaCalculosAuxiliares in db.obtenerCalculosAuxiliares(idPrespuesto))
                {
                    CalculosAux.AppendLine();
                    CalculosAux.Append("Honorario: " + listaCalculosAuxiliares.Honorario).AppendLine();
                    CalculosAux.Append("Precio costo: " + listaCalculosAuxiliares.PrecioCosto).AppendLine();
                    CalculosAux.Append("Gastos varios: " + listaCalculosAuxiliares.GastosVarios).AppendLine();
                    CalculosAux.Append("Ganancia: " + listaCalculosAuxiliares.Ganancia).AppendLine();
                    CalculosAux.Append("Total: " + listaCalculosAuxiliares.Subtotal).AppendLine();
                    CalculosAux.Append("Comentario: " + listaCalculosAuxiliares.Comentario).AppendLine();
                    CalculosAux.Append("__________________________________________________").AppendLine();

                }
            }

            return CalculosAux.ToString();

        }
            
    }
}
