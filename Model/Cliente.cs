using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public class DAOCliente : ICliente
    {
        public bool agregar(Int64 cuit, string tel, string cel, string email, string direccion, string razonSocial, int idLocalidad)
        {
            using (var db = new dbDataContext())
            {
                db.InsertarCliente(cuit, tel.ToUpper(), cel.ToUpper(), email.ToUpper(), direccion.ToUpper(), razonSocial.ToUpper(), idLocalidad);
                return true;
            }

        }

        public DataTable listadoClientesEliminados()
        {
            DataTable tableCliente = generarDataTable();

            using (var db = new dbDataContext())
            {
                foreach (ListarClientesEliminadosResult listaClientes in db.ListarClientesEliminados())
                {
                    tableCliente.Rows.Add(listaClientes.Cuit, listaClientes.Tel, listaClientes.Cel, listaClientes.Email, listaClientes.Domicilio, listaClientes.RazonSocial);
                }
            }


            return tableCliente;
        }


        public DataTable listadoClientesActivos()
        {
            DataTable tableCliente = generarDataTable();
            tableCliente.Columns.Add("Localidad", typeof(String));
            tableCliente.Columns.Add("idLocalidad", typeof(int));
          
            using (var db = new dbDataContext())
            {
                foreach (ListarClienteActivosResult listaClientes in db.ListarClienteActivos())
                {
                    tableCliente.Rows.Add(listaClientes.Cuit, listaClientes.Tel, listaClientes.Cel, listaClientes.Email, 
                        listaClientes.Domicilio, listaClientes.RazonSocial,listaClientes.Nombre, listaClientes.IdLocalidad);
                }
            }


            return tableCliente;
        }

        private static DataTable generarDataTable()
        {
            DataTable tableCliente = new DataTable();
            tableCliente.Columns.Add("Cuit", typeof(Int64));
            tableCliente.Columns.Add("Telefono", typeof(string));
            tableCliente.Columns.Add("Celular", typeof(string));
            tableCliente.Columns.Add("email", typeof(string));
            tableCliente.Columns.Add("direccion", typeof(string));
            tableCliente.Columns.Add("razonSocial", typeof(string));
            return tableCliente;
        }






        public bool exiteCuit(long p)
        {
            using (var db = new dbDataContext())
            {
                return (db.ExisteCuit(p).Count() > 0);
            }
        }


        public bool modificar(long cuit, string tel, string cel, string email, string direccion, string razonSocial, int idLocalidad)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.modificarCliente(cuit, razonSocial.ToUpper(), direccion.ToUpper(), tel, cel, email.ToUpper(), idLocalidad);
                bandera = true;
            }
            return bandera;
        }

        public bool eliminar(long cuit)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.EliminarCliente(cuit);
                bandera = true;
            }
            return bandera;
        }


        public bool recuperar(long cuit)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.RecuperarCLiente(cuit);
                bandera = true;
            }
            return bandera;
        }


        public bool eliminarDefinitivo(long cuit)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                db.eliminarClienteDefinitivo(cuit);
                bandera = true;
            }
            return bandera;
        }
    }
}
