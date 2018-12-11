using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public class ClienteModel
    {

        private Validador _validador = new Validador();
        
        private long Cuit;

        public long cuit
        {
            get { return Cuit; }
            set
            {
                if (value < 0) throw new ArgumentException("El cuit no puede ser negativo.");
                //   if (this._modelo.exiteCuit(value)) throw new ArgumentException("El cuit ya existe.");
                Cuit = value;
            }
        }
        private string RazonSocial;

        public string razonSocial
        {
            get { return RazonSocial; }
            set
            {
                _validador.StringNoNullVacio(value, "El nombre de la razon social no puede estar vacia, por favor indique un nombre.");
                RazonSocial = value;
            }
        }

       private string Direccion;

        public string direccion
        {
            get { return Direccion; }
            set
            {
                Direccion = _validador.stringVacioNullColocarSinInformacion(value);
            }
        }

        private string Email;

        public string email
        {
            get { return Email; }
            set
            {
                Email = _validador.stringVacioNullColocarSinInformacion(value);
            }
        }
        private string Telefono;

        public string telefono
        {
            get { return Telefono; }
            set
            {
                Telefono = _validador.stringVacioNullColocarSinInformacion(value);
            }
        }
        private string Celular;

        public string celular
        {
            get { return Celular; }
            set
            {
                Celular = _validador.stringVacioNullColocarSinInformacion(value);
            }
        }

        private int idLocalidad;

        public int IdLocalidad
        {
            get { return idLocalidad; }
            set
            {
                if (value < 0) throw new ArgumentException("Debe seleccionar una localidad.");
                idLocalidad = value;
            }
        }
       

        public bool agregar()
        {
            bool bandera = false;

            using (var db = new dbDataContext())
            {
                Clientes aux = new Clientes();
                aux.Cuit = this.cuit;
                aux.RazonSocial = this.razonSocial;
                aux.Domicilio = this.direccion;
                aux.Cel = this.celular;
                aux.Tel = this.telefono;
                aux.IdLocalidad = this.idLocalidad;
                aux.Estado = 1;

                if (!this.existeCuit(this.cuit))
                {
                    db.Clientes.InsertOnSubmit(aux);
                    db.SubmitChanges();

                    bandera = true;
                }
                else 
                {
                    throw new ArgumentException("El cuit ya exite en la base de datos.");
                }
            }
            
            return bandera;


        }

        private bool existeCuit(long p)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                bandera =  (from cliente in db.Clientes
                         where cliente.Cuit == cuit
                         select cliente).SingleOrDefault() != null;
            }
            return bandera;
        }

      
        public DataTable mostrar()
        {
            DataTable tableCliente = new DataTable();
            tableCliente.Columns.Add("CUIT", typeof(Int64));
            tableCliente.Columns.Add("RAZON SOCIAL", typeof(string));
            tableCliente.Columns.Add("TELEFONO", typeof(string));
            tableCliente.Columns.Add("CELULAR", typeof(string));
            tableCliente.Columns.Add("EMAIL", typeof(string));
            tableCliente.Columns.Add("DIRECCION", typeof(string));
            tableCliente.Columns.Add("CIUDAD", typeof(string));

          
            using (var db = new dbDataContext())
            {
                var resultado = from clientes in db.Clientes
                                where clientes.Estado == 1
                                select clientes; 
                
                foreach (var cliente in resultado)
                {
                    tableCliente.Rows.Add(cliente.Cuit, cliente.RazonSocial, cliente.Tel, cliente.Cel, cliente.Email, cliente.Domicilio,
                         cliente.Localidades.Nombre + ", " + cliente.Localidades.Departamentos.Provincias.Nombre);

                    
                }

            }

            return tableCliente;
        }

        public DataTable buscarPorNombre(string nombreCliente)
        {
            DataTable tableCliente = new DataTable();
            tableCliente.Columns.Add("CUIT", typeof(Int64));
            tableCliente.Columns.Add("RAZON SOCIAL", typeof(string));
            tableCliente.Columns.Add("TELEFONO", typeof(string));
            tableCliente.Columns.Add("CELULAR", typeof(string));
            tableCliente.Columns.Add("EMAIL", typeof(string));
            tableCliente.Columns.Add("DIRECCION", typeof(string));
            tableCliente.Columns.Add("CIUDAD", typeof(string));

            using (var db = new dbDataContext())
            {
                var resultado = from clientes in db.Clientes
                                where clientes.RazonSocial.ToUpper().StartsWith(nombreCliente.ToUpper()) && clientes.Estado == 1
                                select clientes;

                foreach (var cliente in resultado)
                {
                    tableCliente.Rows.Add(cliente.Cuit, cliente.RazonSocial, cliente.Tel, cliente.Cel, cliente.Email, cliente.Domicilio,
                         cliente.Localidades.Nombre + ", " + cliente.Localidades.Departamentos.Provincias.Nombre);

                }

            }

            return tableCliente;
        }

        public Clientes buscarPorCuit(long cuit)
        {
            Clientes resultado;
            using (var db = new dbDataContext())
            {
                resultado = (from clientes in db.Clientes
                                where clientes.Cuit ==cuit
                                select clientes).Single();

                resultado.Localidades.Departamentos.Provincias = (from clientes in db.Clientes
                                         where clientes.Cuit == cuit
                                         select clientes.Localidades.Departamentos.Provincias).Single();

                resultado.Localidades.Departamentos = (from clientes in db.Clientes
                                         where clientes.Cuit == cuit
                                         select clientes.Localidades.Departamentos).Single();

            }
            return resultado;
            
        }

        public bool elimanarDefinitivamente(long p)
        {
            bool bandera = false;
            using (var db = new dbDataContext())
            {
                var c =  from cliente in db.Clientes
                         where cliente.Cuit == p
                         select cliente;

                foreach (var cli in c)
                {
                   
                    db.Clientes.DeleteOnSubmit(cli);
                }

                try
                {
                    db.SubmitChanges();
                    bandera = true;
                }
                catch (Exception e)
                {
                    bandera = false;
                    
                }

                 
            }
            return bandera;
        }
    }
}
