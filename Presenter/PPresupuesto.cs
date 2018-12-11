using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Model;
using Presentador;

namespace Presentador
{
    public class PPresupuesto
    {
        private readonly IPresupuesto _vista;
        private DAOPresupuesto _modelo;
        private Cliente _cliente = new Cliente(new DAOCliente());
        private Provincia _provincia;
        private Departamento _departamento;
        private Localidad _localidad;

        public PPresupuesto(IPresupuesto vista)
        {
            _vista = vista;
            _modelo = new DAOPresupuesto();


        }
        public PPresupuesto()
        {
            _modelo = new DAOPresupuesto();
        }

        public void setgridDataSoursePresupuesto (object value)
        {
             _vista.gridDataSoursePresupuesto = value;
        }


        public DataView filtroPorEstados(DataView dv, string p)
        {
            dv.RowFilter = "Estado = " + p;
           return dv;
        }

        public DataView getgridDataSoursePresupuesto()
        {
            return _modelo.listarPresupuestos();
        }

        public void cargarCB()
        {
            _vista.CBDisplayMember = "Nombre";
            _vista.CBValueMember="ID";
        }
       
        public string registrarCliente (int idLocalidad)
        {
            try
            {
              
                ClienteModel clientes = new ClienteModel();
                clientes.cuit = long.Parse(_vista.Cuit);
                clientes.razonSocial = _vista.RazonSocial;
                clientes.telefono = _vista.Telefono;
                clientes.celular = _vista.Celular;
                clientes.email = _vista.Direccion;
                clientes.IdLocalidad = idLocalidad;

                if (clientes.agregar())
                {
                    this.setgridDataSourseClientes();
                    this.limpiarTextboxCliente();
                    this.setCBProvincias();
                    return "Se guardo exitosamente el cliente";
                }

                return "No se guardo exitosamente el cliente";
                   
                    
                }
            
            catch (ArgumentException e)
            {
                return e.Message.ToString();
            }
            
        }


        public void setgridDataSourseClientes()
        {
            ClienteModel cliente = new ClienteModel();

            _vista.gridDataSourseClientes = cliente.mostrar();

            
        }

        public void clientesBusquedas(string nombreCliente)
        {
            ClienteModel cliente = new ClienteModel();

            _vista.gridDataSourseClientes = cliente.buscarPorNombre(nombreCliente);

        }
        public void cargarCliente(long cuit)
        {
           
            ClienteModel clientes = new ClienteModel();
            Clientes c = clientes.buscarPorCuit(cuit);

            _vista.Cuit = c.Cuit.ToString();
            _vista.Email = c.Email;
            _vista.Direccion = c.Domicilio;
            _vista.Celular = c.Cel;
            _vista.RazonSocial = c.RazonSocial;
            _vista.Telefono = c.Tel;
            _vista.botonModificar = true;

            _vista.CBProvinciaIndex = c.Localidades.Departamentos.Provincias.ID-1;
           
            
        }

        public void limpiarTextboxCliente()
        {
            _vista.Cuit = string.Empty;
            _vista.Email = string.Empty;
            _vista.Direccion = string.Empty;
            _vista.Celular = string.Empty;
            _vista.RazonSocial = string.Empty;
            _vista.Telefono = string.Empty;
            _vista.botonModificar = false;

        }

        public string eliminarCliente(long cuit) 
        {
            return _cliente.eliminar(cuit);
        }

        public void setCBProvincias()
        {
            this._provincia = new Provincia (new DAOProvincia());
            _vista.CBProvincias = this._provincia.listar();

        }

        public void setCBDepartamento(int idProvincia)
        {
            this._departamento = new Departamento(new DAODepartamento());
            _vista.CBDepartamento = this._departamento.listar(idProvincia).OrderBy(o => o.Nombre).ToList();
        }

        public void setCBLocalidades(int idDepartamento)
        {
            this._localidad = new Localidad(new DAOLocalidad());
            _vista.CBLocalidades = this._localidad.listar(idDepartamento).OrderBy(o => o.Nombre).ToList();
            
        }

        
        public string modificar(int idLocalidad)
        {
            try
            {

                if (!_cliente.exiteCuit(long.Parse(_vista.Cuit)))
                    return "El cuit no exite, por favor verifique si es correcto el cuit ingresado.";
                else
                {
                    string mensaje = _cliente.modificar(long.Parse(_vista.Cuit), _vista.Telefono, _vista.Celular,
                                                _vista.Email, _vista.Direccion, _vista.RazonSocial, idLocalidad);


                    this.setgridDataSourseClientes();
                    this.limpiarTextboxCliente();
                    this.setCBProvincias();

                    return (mensaje);
                }
            }
            catch (ArgumentException e)
            {
                return e.Message.ToString();
            }
        }
    }
}
