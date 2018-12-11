using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public class DAOProvincia : IProvincia
    {

        public DataTable listar()
        {
            DataTable Provincia = new DataTable();
            Provincia.Columns.Add("ID", typeof(int));
            Provincia.Columns.Add("Nombre", typeof(string));

            using (var db = new dbDataContext())
            {
                foreach (listarProvinciasResult resultado in db.listarProvincias())
                {
                    Provincia.Rows.Add(resultado.ID, resultado.Nombre);
                }
            }

            return Provincia;
        }

        public bool agregar(string nombre)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.agregarProvincia(nombre.ToUpper());
                bandera = true;
            }
            return bandera;
        }

        public bool modificar(int id, string nombre)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.modificarProvincia(id, nombre.ToUpper());
                bandera = true;
            }
            return bandera;
        }
    }
}
