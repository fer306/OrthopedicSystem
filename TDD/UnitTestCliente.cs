using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Presentador;
using Model;
using System.Transactions;
namespace TDD
{
    /// <summary>
    /// Descripción resumida de UnitTestCliente
    /// </summary>
    [TestClass]
    public class UnitTestCliente
    {
        
        ICliente _MockDAOCliente;

        [TestCleanup]
        public void testClean()
        {
            Cliente c = new Cliente(new DAOCliente());
            c.eliminarDefinitivo(30303030);
        }  


        [TestMethod]
        public void agregarCliente()
        {
            Mock<ICliente> mockDAOCliente = new Mock<ICliente>();
            mockDAOCliente.Setup(mr => mr.agregar(120, "123", "123", "cliente@gmail.com", "Avenida Libertad", "La segura",2)).Returns(true);
            this._MockDAOCliente = mockDAOCliente.Object;

            Cliente cliente = new Cliente(120, "123", "123", "cliente@gmail.com", "Avenida Libertad", "La segura", _MockDAOCliente);
          
            Assert.AreEqual(cliente.agregar(2), "Se guardo su información satisfactoriamente.");
          
 
        }

        [TestMethod]
        public void comprobarValidaciones()
        {
            Mock<ICliente> mockDAOCliente = new Mock<ICliente>();
            this._MockDAOCliente = mockDAOCliente.Object;


            try
            {
                Cliente cliente = new Cliente(-5, "123", "123", "cliente@gmail.com", "Avenida Libertad", "La segura", _MockDAOCliente);
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("El cuit no puede ser negativo.", ae.Message);
            }

            try
            {
                Cliente cliente = new Cliente(5, "123", "123", "cliente@gmail.com", "Avenida Libertad", string.Empty, _MockDAOCliente);
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("El nombre de la razon social no puede estar vacia, por favor indique un nombre.", ae.Message);
            }

            try
            {
                Cliente cliente = new Cliente(5, "123", "123", "cliente@gmail.com", "Avenida Libertad",null, _MockDAOCliente);
            }
            catch (ArgumentException ae)
            {
                Assert.AreEqual("El nombre de la razon social no puede estar vacia, por favor indique un nombre.", ae.Message);
            }
           

        }



        [TestMethod]
        public void eliminarLogicamenteCliente()
        {
            Mock<ICliente> mockDAOCliente = new Mock<ICliente>();
            mockDAOCliente.Setup(mr => mr.eliminar(120)).Returns(true);
            this._MockDAOCliente = mockDAOCliente.Object;

            Cliente cliente = new Cliente(_MockDAOCliente);

            Assert.AreEqual(cliente.eliminar(120), "Se ha eliminado correctamente. Si quiere restaurarlo, busque en listado de clientes eliminados.");


        }

        [TestMethod]
        public void comprobarListadoCliente()
        {
            this.SetUp();
            Cliente cliente = new Cliente(_MockDAOCliente);

            Assert.AreEqual(cliente.listadoActivos().Count, 4);

        }

        private void SetUp()
        {
            DataTable tableCliente = new DataTable();
            tableCliente.Columns.Add("Cuit", typeof(int));
            tableCliente.Columns.Add("Telefono", typeof(string));
            tableCliente.Columns.Add("Celular", typeof(string));
            tableCliente.Columns.Add("email", typeof(string));
            tableCliente.Columns.Add("direccion", typeof(string));
            tableCliente.Columns.Add("razonSocial", typeof(string));
            tableCliente.Columns.Add("Localidad", typeof(String));
            tableCliente.Columns.Add("idLocalidad", typeof(int));

            tableCliente.Rows.Add(120, "123", "123", "cliente@gmail.com", "Avenida Libertad", "La segura","una localidad",1);
            tableCliente.Rows.Add(60, "123", "123", "cliente@gmail.com", "Avenida Libertad", "La segunda","una localidad",1);
            tableCliente.Rows.Add(50, "321", "321", "cliente@gmail.com", "Avenida Libertad", "IOSCOR","una localidad",1);
            tableCliente.Rows.Add(10, "123", "123", "cliente@gmail.com", "Avenida Libertad", "PAMI","una localidad",1);

            Mock<ICliente> mockDAOCliente = new Mock<ICliente>();
            mockDAOCliente.Setup(mr => mr.listadoClientesActivos()).Returns(tableCliente);
            this._MockDAOCliente = mockDAOCliente.Object;
        }

        [TestMethod]
        public void comprobarBuscarPorNombre()
        {
            this.SetUp();

            Cliente cliente = new Cliente(_MockDAOCliente);
            Assert.AreEqual(cliente.buscarPorNombre("La s",cliente.listadoActivos()).Count, 2);

            Assert.AreEqual(cliente.buscarPorNombre("PA", cliente.listadoActivos()).Count, 1);

            Assert.AreEqual(cliente.buscarPorNombre("Hola", cliente.listadoActivos()).Count, 0);

            Assert.AreEqual(cliente.buscarPorNombre("ioscor", cliente.listadoActivos()).Count, 1);
            
        }

        //[TestMethod]
        //public void comprobarBuscarCuit()
        //{
        //    //Arrange
        //    this.SetUp();
        //    Cliente cliente = new Cliente(_MockDAOCliente);
        //    cliente.cuit = 120;
        //    cliente.telefono = "123";
        //    cliente.celular = "123"; 
        //    cliente.email = "cliente@gmail.com"; 
        //    cliente.direccion = "Avenida Libertad";
        //    cliente.razonSocial = "La segura"; 
            
        //    Localidad unaLocalidad = new Localidad(new DAOLocalidad());
        //    unaLocalidad.Id = 1;
        //    unaLocalidad.Nombre = "una localidad";
            
        //    cliente.localidad = unaLocalidad;

        //    //Act
        //    Cliente clienteResultado = cliente.buscarPorCuit(120, cliente.listadoActivos());
           
              
        //    //Assert
        //    Assert.AreEqual(cliente,clienteResultado);
              

        //}

        //Testing de integracion
       
         [TestMethod]
        public void agregarClienteTestIntegracion()
        {
         
            //Arrange
            DAOCliente modelCliente = new DAOCliente();
            Cliente c = new Cliente(30303030, "123", "123", "cliente@gmail.com", "Avenida Libertad", "La segura", modelCliente);

      
           //Act
           var mensaje = c.agregar(2);

           //Assert
           Assert.AreEqual("Se guardo su información satisfactoriamente.", mensaje);

        }

         [TestMethod]
         public void eliminarClienteTestIntegracion()
         {

             //Arrange
             DAOCliente modelCliente = new DAOCliente();
             Cliente cliente = new Cliente(modelCliente);

             //Act
             var mensaje = cliente.eliminar(120);

             //Assert
             Assert.AreEqual("Se ha eliminado correctamente. Si quiere restaurarlo, busque en listado de clientes eliminados.", mensaje);

         }

            //Cliente c = new Cliente(120, "123", "123", "cliente@gmail.com", "Avenida Libertad", "La segura", modelCliente);

            //Assert.AreEqual(c.agregar(2), "El cuit ya exite, por favor verifique si es correcto el cuit ingresado.");

            //Cliente c2 = new Cliente(113, "123", "123", "cliente@gmail.com", "Avenida Libertad", "La segura", modelCliente);

            ////  Assert.AreEqual(c2.agregar(2), "El cuit ya exite, por favor verifique si es correcto el cuit ingresado.");

            //Assert.AreEqual(c2.modificar(123, "555", "555", "555@gmail.com", "Avenida 555", "La 555", 2), "Se modifico su información satisfactoriamente.");

            //// Assert.AreEqual(c.modificar(123, "La segunda", string.Empty, string.Empty, string.Empty, string.Empty, 2), "Se modifico su información satisfactoriamente.");

            //Assert.AreEqual(c2.agregar(2), "El cuit ya exite, por favor verifique si es correcto el cuit ingresado.");

            //Assert.AreEqual(c2.Listado().Count, 38);

            //Assert.AreEqual(c2.listadoEliminados().Count, 3);

        
    }
}
