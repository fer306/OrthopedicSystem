using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace Presentador
{
    public class Provincia
    {
        private IProvincia _modelo;
        private Validador _validador = new Validador();
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _validador.comprobarIntNoNegativo(value,("Ocurrio un problema: El id  no puede ser negativo. Consulte servicio tecnico."));
                _id = value; 
            }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _validador.StringNoNullVacio(value, "El nombre del departamento no puede estar vacio, por favor indique un nombre.");
                _nombre = value; 
            }
        }

        public Provincia(IProvincia _model)
        {
            _modelo = _model;
        }

        public Provincia(IProvincia _model, int id, string nombre)
        {
            _modelo = _model;
            this._id = id;
            this._nombre = nombre;
        }

        private List<Departamento> _listaDepartamento;

        public List<Departamento> ListaDepartamento
        {
            get { return _listaDepartamento; }
            set { _listaDepartamento = value; }
        }

        public List<Provincia> listar()
        {
            List<Provincia> listado = new List<Provincia>();
            foreach (DataRow dr in _modelo.listar().Rows)
            {

                listado.Add(new Provincia(_modelo, Convert.ToInt32(dr[0].ToString()), dr[1].ToString()));
               

            }

            return listado;
        }
       

        public string agregar(string nombre)
        {
            _validador.StringNoNullVacio(nombre, "La Provincia debe tener un nombre");

            if (_modelo.agregar(nombre))
                 return "Se guardo su información satisfactoriamente.";
            else
                return "No se logro guardar su información.";
               
        }

        public string modificar(Provincia Provincia)
        {
            if (_modelo.modificar(Provincia.Id, Provincia.Nombre))
                return "Se modifico su información satisfactoriamente.";
            else
                return "No se logro modificar su información.";
        }
     
    }
}
