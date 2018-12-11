using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using Presentador;
using System.Data;

namespace TDD
{
    [TestClass]
    public class UnitTestLocalidad
    {
        ILocalidadesDepartamento _MockDAOLocalidad;
        ILocalidadesDepartamento _modelo;

        DataTable localidades = new DataTable();

        [TestMethod]
        public void agregarLocalidad()
        {
            SetUp();

            Localidad loc = new Localidad(_MockDAOLocalidad);

            try
            {

                loc.agregar(string.Empty, 2);

            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("La localidad debe tener un nombre", ae.Message.ToString());
            }

            try
            {

                loc.agregar("Ctes", -5);

            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Verifique que el Departamento ha sido seleccionado", ae.Message.ToString());
            }

            try
            {

                Localidad localidad = new Localidad(_MockDAOLocalidad);
                localidad.Nombre = string.Empty;
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("El nombre de la localidad no puede estar vacia, por favor indique un nombre.", ae.Message.ToString());
            }

            try
            {

                Localidad localidad = new Localidad(_MockDAOLocalidad);
                localidad.Nombre = "La segunda";
                localidad.Id = -5;
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("Ocurrio un problema: El id  no puede ser negativo. Consulte servicio tecnico.", ae.Message.ToString());
            }




        }

        private void SetUp()
        {
           
            localidades.Columns.Add("ID", typeof(int));
            localidades.Columns.Add("Nombre", typeof(string));

            localidades.Rows.Add(1, "Ctes");
            localidades.Rows.Add(2, "Paso de la patria");
            localidades.Rows.Add(3, "Goya");

            DataTable unaLocalidad = new DataTable();
            unaLocalidad.Columns.Add("ID", typeof(int));
            unaLocalidad.Columns.Add("Nombre", typeof(string));
            unaLocalidad.Rows.Add(4, "Resistencia");
         

            Mock<ILocalidadesDepartamento> mockDAOLocalidad = new Mock<ILocalidadesDepartamento>();
            mockDAOLocalidad.Setup(m => m.listar(5)).Returns(localidades);
            mockDAOLocalidad.Setup(m => m.buscarLocalidad(4)).Returns(unaLocalidad);
            mockDAOLocalidad.Setup(m => m.buscarIDDepartamento(4)).Returns(5);

            this._MockDAOLocalidad = mockDAOLocalidad.Object;

        }

        [TestMethod]
        public void comprobarListarLocalidades()
        {
            SetUp();

            Localidad loc = new Localidad(_MockDAOLocalidad);

            Assert.AreEqual(loc.listar(5).Count, 3);



        }

        //[TestMethod]
        //public void TestIntegracionListar()
        //{
        //     _modelo = new DAOLocalidad();
        //     Localidad loc = new Localidad(_modelo);


        // //   loc.agregar("Test",5);

        //    Assert.AreEqual(loc.listar(5).Count, 17);

        //    Localidad localidad = new Localidad(_modelo);
        //    localidad.Nombre = "Test 2";
        //    localidad.Id = 5442;
        //    loc.modificar(localidad,10);



        //}

        [TestMethod]
        //public void TestIntegracionListarDepartamento()
        //{
        //    _modelo = new DAODepartamento();
        //    Departamento departamento = new Departamento(_modelo);


        //    //departamento.agregar("Test", 5);

        //    Assert.AreEqual(departamento.listar(5).Count, 34);

        //    int dep = departamento.listar(5).Find(x => x.Id == 203).ListaLocalidades.Count;

        //    Assert.AreEqual(55, dep);

        //    //Departamento d = new Departamento(_modelo, 576, "Test de modificar");

        //    //d.modificar(d, 5);

        ////    static void Main(string[] args)
        ////{
        ////    string sqlConnectionString = "Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=True";
        ////    FileInfo file = new FileInfo("C:\\myscript.sql");
        ////    string script = file.OpenText().ReadToEnd();
        ////    SqlConnection conn = new SqlConnection(sqlConnectionString);
        ////    Server server = new Server(new ServerConnection(conn));
        ////    server.ConnectionContext.ExecuteNonQuery(script);
        ////}


        //}


        //public void agregarDepartamento()
        //{
        //    DataTable departamento = new DataTable();
        //    departamento.Columns.Add("ID", typeof(int));
        //    departamento.Columns.Add("Nombre", typeof(string));

        //    departamento.Rows.Add(1, "Ctes");
        //    departamento.Rows.Add(2, "Paso de la patria");
        //    departamento.Rows.Add(3, "Goya");


        //    Mock<ILocalidadesDepartamento> mockDAOLocalidad = new Mock<ILocalidadesDepartamento>();
        //    mockDAOLocalidad.Setup(m => m.listar(5)).Returns(departamento);

        //    this._MockDAOLocalidad = mockDAOLocalidad.Object;

        //    Departamento depart = new Departamento(_MockDAOLocalidad);

        //    try
        //    {

        //        depart.agregar(string.Empty, 2);

        //    }
        //    catch (ArgumentException ae)
        //    {
        //        Assert.AreEqual("El departamento debe tener un nombre", ae.Message.ToString());
        //    }

        //    try
        //    {

        //        depart.agregar("Ctes", -5);

        //    }
        //    catch (ArgumentException ae)
        //    {
        //        Assert.AreEqual("Verifique que una Provincia ha sido seleccionado", ae.Message.ToString());
        //    }

        //    try
        //    {

        //        Departamento dep = new Departamento(_MockDAOLocalidad);
        //        dep.Nombre = string.Empty;
        //    }
        //    catch (ArgumentException ae)
        //    {
        //        Assert.AreEqual("El nombre del departamento no puede estar vacio, por favor indique un nombre.", ae.Message.ToString());
        //    }

        //    try
        //    {

        //        Departamento departamento2 = new Departamento(_MockDAOLocalidad);
        //        departamento2.Nombre = "La segunda";
        //        departamento2.Id = -5;
        //    }
        //    catch (ArgumentException ae)
        //    {
        //        Assert.AreEqual("Ocurrio un problema: El id  no puede ser negativo. Consulte servicio tecnico.", ae.Message.ToString());
        //    }

        //}


        public void buscarLocalidad()
        {
            
            // Arrange 
            SetUp();
            Localidad loc = new Localidad(_MockDAOLocalidad);

            // Act 
            loc =  loc.buscarLocalidad(4);
            
            // Assert 
            Assert.AreEqual("Resistencia", loc.Nombre);
            Assert.AreEqual(4,loc.Id);
        }

        [TestMethod]
        public void buscarIDDepartamento()
        {

            // Arrange 
            SetUp();
            Localidad loc = new Localidad(_MockDAOLocalidad);

            // Act 
            var i  = loc.buscarIdDepartamento(4);

            // Assert 
            Assert.AreEqual(5, i);
        }

    }
}
