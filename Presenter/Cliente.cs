using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using System.Data;

namespace Presentador
{
    public class Cliente
    {
        private ICliente _modelo;

        public Localidad localidad { get; set; }

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

        private Validador _validador = new Validador();


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

        public Cliente(long cuit, string tel, string cel, string email, string direccion, string razonSocial, ICliente modelo)
        {
            this.cuit = cuit;
            this.celular = cel;
            this.telefono = tel;
            this.email = email;
            this.direccion = direccion;
            this.razonSocial = razonSocial;
            this._modelo = modelo;
        }

        public Cliente(ICliente modelo)
        {
            this._modelo = modelo;
            this.cuit = 99999999;
            this.celular = null;
            this.telefono = null;
            this.email = null;
            this.direccion = null;
            this.razonSocial = "Cliente generico";
        }

        public String agregar(int idLocalidad)
        {
           
            if (_modelo.agregar(this.cuit, this.telefono, this.celular, this.email, this.direccion, this.razonSocial, idLocalidad))
                    return "Se guardo su información satisfactoriamente.";
                else
                    return "No se logro guardar su información.";
         }

        public bool exiteCuit(long cuit)
        {
            return _modelo.exiteCuit(cuit);
        }

        public String modificar(long cuit, string tel, string cel, string email, string direccion, string razonSocial, int idLocalidad)
        {
            if (_modelo.modificar(cuit, tel, cel, email, direccion, razonSocial, idLocalidad))
                return "Se modifico su información satisfactoriamente.";
            else
                return "No se logro modificar su información.";

        }


        public DataTable ListadoDataTable()
        {
            return (_modelo.listadoClientesActivos()); 
        }

        public List<Cliente> listadoActivos()
        {
            DataTable tabla = this.ListadoDataTable();
          
            List<Cliente> listadoClientes = new List<Cliente>();
            
            foreach (DataRow dr in tabla.Rows)
            {
                Localidad unaLocalidad = new Localidad(new DAOLocalidad());

                unaLocalidad.Id = int.Parse(dr[7].ToString());
                unaLocalidad.Nombre = dr[6].ToString();
                
                listadoClientes.Add(new Cliente(_modelo) { cuit = Convert.ToInt64(dr[0].ToString()), telefono = dr[1].ToString(), celular = dr[2].ToString(), email = dr[3].ToString(), direccion = dr[4].ToString(), razonSocial = dr[5].ToString(), localidad = unaLocalidad });
              
              

            }

            return listadoClientes;
        }
        public DataTable listadoEliminados()
        {
            return (_modelo.listadoClientesEliminados());
        }


        public List<Cliente> buscarPorNombre(string razonSocial, List<Cliente> listadoClientes)
        {
            List<Cliente> listadoResultado = listadoClientes.Where(s => s.razonSocial.ToUpper().Contains(razonSocial.ToUpper())).ToList();
              
            return listadoResultado;
        }

        public Cliente buscarPorCuit(long cuit, List<Cliente> listadoClientes)
        {
            Cliente Resultado = listadoClientes.Where(s => s.cuit == cuit).Single();

            return Resultado;
        }

        public string eliminar(long cuit)
        {
             if (_modelo.eliminar(cuit))     
             {
               return "Se ha eliminado correctamente. Si quiere restaurarlo, busque en listado de clientes eliminados.";
             }
            return "No se pudo eliminar.";
        }

        public string eliminarDefinitivo(long cuit)
        {
            if (_modelo.eliminarDefinitivo(cuit))
            {
                return "Se ha eliminado definitivamente.";
            }
            return "No se pudo eliminar.";
        }
        public string recuperar(long cuit)
        {
            if (_modelo.recuperar(cuit))
            {
                return "Se ha recuperado correctamente.";
            }
            return "No se pudo recuperar.";
        }

    }
}
