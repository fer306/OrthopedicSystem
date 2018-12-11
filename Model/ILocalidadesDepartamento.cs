using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Model
{
    public interface ILocalidadesDepartamento
    {
        DataTable listar(int idDepartamento);

        bool agregar(string nombreLocalidad, int idDepartamento);
        
        bool modificar(int idLocalidad, string nombre, int idDepartamento);

        DataTable buscarLocalidad(int idLocalidad);

        int buscarIDDepartamento(int idLocalidad);
    }
}
