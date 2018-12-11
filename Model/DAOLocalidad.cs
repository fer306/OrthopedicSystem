using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public class DAOLocalidad : ILocalidadesDepartamento
    {
        public DataTable listar(int idDepartamento)
        {
            DataTable localidades = new DataTable();
            localidades.Columns.Add("ID", typeof(int));
            localidades.Columns.Add("Nombre", typeof(string));

            using (var db = new dbDataContext()) 
            {
                foreach (listarLocalidadesResult resultado in db.listarLocalidades(idDepartamento))
                {
                    localidades.Rows.Add(resultado.Id,resultado.Nombre);
                }
            }

            return localidades;
        }

        public bool agregar(string nombreLocalidad, int idDepartamento)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.agregarLocalidad(idDepartamento,nombreLocalidad.ToUpper());
                bandera = true;
            }
            return bandera;
        }

        public bool modificar(int idLocalidad, string nombre, int idDepartamento)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.modificarLocalidad(idLocalidad,idDepartamento,nombre.ToUpper());
                bandera = true;
            }
            return bandera;
        }


        public DataTable buscarLocalidad(int idLocalidad)
        {
            throw new NotImplementedException();
        }


        public int buscarIDDepartamento(int idLocalidad)
        {
            using (var db = new dbDataContext())
            {
                return db.buscarIDDepartamento(idLocalidad).Single().idDepartamento;
                
            }
        }
    }
}
