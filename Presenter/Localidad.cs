using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace Presentador
{
    public class Localidad
    {
        private ILocalidadesDepartamento _modelo;
        private Validador _validador = new Validador();
        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _validador.comprobarIntNoNegativo(value,("Ocurrio un problema: El id  no puede ser negativo. Consulte servicio tecnico."));
                //if (this._modelo.exiteCuit(value)) throw new ArgumentException("El cuit ya existe.");
                _id = value; 
            }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _validador.StringNoNullVacio(value, "El nombre de la localidad no puede estar vacia, por favor indique un nombre.");
                _nombre = value; 
            }
        }

        public Localidad(ILocalidadesDepartamento _model)
        {
            _modelo = _model;
        }

        public List<Localidad> listar(int idDepartamento)
        {
            _validador.comprobarIntNoNegativo(idDepartamento, "Verifique que el Departamento ha sido seleccionado");
            List<Localidad> listadoLocalidades = new List<Localidad>();
            foreach (DataRow dr in _modelo.listar(idDepartamento).Rows)
            {

                listadoLocalidades.Add(new Localidad(_modelo) {Id = Convert.ToInt32(dr[0].ToString()),Nombre =dr[1].ToString()});

            }

            return listadoLocalidades;
        }

        public string agregar(string nombreLocalidad, int idDepartamento)
        {
            _validador.StringNoNullVacio(nombreLocalidad, "La localidad debe tener un nombre");
            _validador.comprobarIntNoNegativo(idDepartamento, "Verifique que el Departamento ha sido seleccionado");

            if (_modelo.agregar(nombreLocalidad,idDepartamento))
                 return "Se guardo su información satisfactoriamente.";
            else
                return "No se logro guardar su información.";
               
        }

        public string modificar(Localidad loc,int idDepartamento)
        {
            _validador.comprobarIntNoNegativo(idDepartamento, "Verifique que el Departamento ha sido seleccionado");

            if (_modelo.modificar(loc.Id, loc.Nombre,idDepartamento))
                return "Se modifico su información satisfactoriamente.";
            else
                return "No se logro modificar su información.";
        }


        public Localidad buscarLocalidad(int idLocalidad)
        {
            _validador.comprobarIntNoNegativo(idLocalidad, "Verifique que el Departamento ha sido seleccionado");

            Localidad unaLocalidad = new Localidad(this._modelo);
            foreach (DataRow dr in _modelo.buscarLocalidad(idLocalidad).Rows)
            {

                unaLocalidad.Id = int.Parse(dr[0].ToString());
                unaLocalidad.Nombre= dr[1].ToString();

            }

            return unaLocalidad;
        }

        public int buscarIdDepartamento(int idLocalidad)
        {
            _validador.comprobarIntNoNegativo(idLocalidad, "Verifique que el Departamento ha sido seleccionado");

           return _modelo.buscarIDDepartamento(idLocalidad);
        }
    }
}
