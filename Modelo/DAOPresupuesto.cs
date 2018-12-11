using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class DAOPresupuesto
    {
       public int  ultimoID() 
       {
           int i;
           if (db.Presupuesto.Count > 0)
	        {
		         i= (From p In db.Presupuesto _
                     Select p.Id).Max
	        }
           else
                 {
                 return i;
                 }


   
       }    
    }
}
