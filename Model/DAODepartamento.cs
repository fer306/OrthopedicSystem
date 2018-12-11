using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public class DAODepartamento : ILocalidadesDepartamento
    {

        public DataTable listar(int idProvincia)
        {
            DataTable departamento = new DataTable();
            departamento.Columns.Add("ID", typeof(int));
            departamento.Columns.Add("Nombre", typeof(string));

            using (var db = new dbDataContext())
            {
                foreach (listarDepartamentoResult resultado in db.listarDepartamento(idProvincia))
                {
                    departamento.Rows.Add(resultado.ID, resultado.Nombre);
                }
            }

            return departamento;
        }

        public bool agregar(string nombre, int idProvincia)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.agregarDepartamento(idProvincia, nombre.ToUpper());
                bandera = true;
            }
            return bandera;
        }

        public bool modificar(int idDepartamento, string nombre, int idProvincia)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.modificarDepartamento(idProvincia, idDepartamento, nombre.ToUpper());
                bandera = true;
            }
            return bandera;
        }


        public DataTable buscarLocalidad(int idLocalidad)
        {
            DataTable departamento = new DataTable();
            departamento.Columns.Add("ID", typeof(int));
            departamento.Columns.Add("Nombre", typeof(string));

            using (var db = new dbDataContext())
            {
                foreach (listarDepartamentoResult resultado in db.listarDepartamento(idLocalidad))
                {
                    departamento.Rows.Add(resultado.ID, resultado.Nombre);
                }
            }

            return departamento;
        }


        //public int buscarIDDepartamento(int idLocalidad)
        //{
        //    //using (var db = new dbDataContext())
        //    //{
        //    //    return departamento;
        //    //}
        //}


        public int buscarIDDepartamento(int idLocalidad)
        {
            using (var db = new dbDataContext())
            {
                return db.buscarIDProvincia(idLocalidad).Single().idProvincia;

            }
        }
    }
}
