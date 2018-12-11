using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Presentador;



namespace Presentador
{
    public interface IPresupuesto
    {
        object gridDataSoursePresupuesto { get; set; }
        object gridDataSourseClientes { get; set; }
        object bindGridCliente { get; set; }

        object CBProvincias { set; }
        object CBDepartamento { set; }
        object CBLocalidades { set; }
        bool botonModificar { set; }


        string CBValueMember { set; }
        string CBDisplayMember { set; }

        int CBProvinciaIndex { set; }
        int CBDepartamentoIndex { set; }


        string Cuit { get; set; }
        string Telefono { get; set; }
        string Celular { get; set; }
        string Email { get; set; }
        string Direccion { get; set; }
        string RazonSocial { get; set; }

    }
}

