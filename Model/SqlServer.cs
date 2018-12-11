using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class SqlServer
    {
        private string connecion;

        public string Connecion
        {
            get { return "Data Source=LOCALHOST;Initial Catalog=test;Integrated Security=True"; }
            set { connecion = value; }
        }
        

    }
}
