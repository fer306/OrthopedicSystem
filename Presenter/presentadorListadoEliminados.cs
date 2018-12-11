using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Presentador
{
    public class presentadorListadoEliminados
    {
        private readonly IListadoEliminadosClientes _vista;
        private DAOCliente _modelo;
        private  Cliente _cliente;

        public presentadorListadoEliminados(IListadoEliminadosClientes vista)
        {
            _vista = vista;
            _modelo = new DAOCliente();
            _cliente = new Cliente(_modelo);

        }

        public void setgridDataSourseClientes()
        {
            _vista.gridDataSourseClientes = _cliente.listadoEliminados();
        }

        
        public string restaurarCliente(long cuit)
        {
            return _cliente.recuperar(cuit);
        }

        public string eliminarDefinitivo(long p)
        {
            ClienteModel c = new ClienteModel();
            if (c.elimanarDefinitivamente(p))
            {
                return "Se elimino de la base de datos.";
            }
            else
            {
                return "No se pudo eliminar de la base de datos.";    
            }


        }
    }
}
