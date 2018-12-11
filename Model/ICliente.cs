using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Model
{
    public interface ICliente
    {
        bool agregar(Int64 cuit, string tel, string cel, string email, string direccion, string razonSocial, int idLocalidad);
        DataTable listadoClientesActivos();
        DataTable listadoClientesEliminados();
        bool modificar(long cuit, string tel, string cel, string email, string direccion, string razonSocial, int idLocalidad);
        bool eliminar(long cuit);
        bool eliminarDefinitivo(long cuit);
        bool exiteCuit(long cuit);
        bool recuperar(long cuit);
    }
}
