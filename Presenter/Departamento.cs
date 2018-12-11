using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace Presentador
{
    public class Departamento
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

        public Departamento(ILocalidadesDepartamento _model)
        {
            _modelo = _model;
            this.ListaLocalidades = new Localidad(_model).listar(0);
        }

        public Departamento(ILocalidadesDepartamento _model, int id, string nombre)
        {
            _modelo = _model;
            this._id = id;
            this._nombre = nombre;
        }



        private List<Localidad> _listaLocalidades;

        public List<Localidad> ListaLocalidades
        {
            get 
            {
                this.ListaLocalidades = new Localidad(new DAOLocalidad()).listar(this._id);

                return _listaLocalidades; 
            }
            set { _listaLocalidades = value; }
        }

        public List<Departamento> listar(int idProvincia)
        {
            _validador.comprobarIntNoNegativo(idProvincia, "Seleccione una provincia");
            List<Departamento> listado = new List<Departamento>();
            foreach (DataRow dr in _modelo.listar(idProvincia).Rows)
            {

                listado.Add(new Departamento(_modelo, Convert.ToInt32(dr[0].ToString()), dr[1].ToString()));
               

            }

            return listado;
        }
       

        public string agregar(string nombre, int idProvincia)
        {
            _validador.StringNoNullVacio(nombre, "El departamento debe tener un nombre");
            _validador.comprobarIntNoNegativo(idProvincia, "Verifique que una Provincia ha sido seleccionado");

            if (_modelo.agregar(nombre, idProvincia))
                 return "Se guardo su información satisfactoriamente.";
            else
                return "No se logro guardar su información.";
               
        }

        public string modificar(Departamento departamento, int idProvincia)
        {
            _validador.comprobarIntNoNegativo(idProvincia, "Verifique que una Provincia  ha sido seleccionado");

            if (_modelo.modificar(departamento.Id, departamento.Nombre, idProvincia))
                return "Se modifico su información satisfactoriamente.";
            else
                return "No se logro modificar su información.";
        }

        public int buscarIdProvincia(int idDepartamento)
        {
            _validador.comprobarIntNoNegativo(idDepartamento, "Verifique que el Departamento ha sido seleccionado");

            return _modelo.buscarIDDepartamento(idDepartamento);
        }
     
    }
}
