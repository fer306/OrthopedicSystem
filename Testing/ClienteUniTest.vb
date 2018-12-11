Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Lan



<TestClass()> Public Class ClienteUniTest

    <TestMethod()> Public Sub deberia_agregar_un_cliente()

        'Arrange  
        Dim cliente As New Cliente
        cliente.RazonSocial = "Un cliente"
        cliente.Email = "uncliente@gmail.com"
        cliente.Cuit = 99999999
        cliente.Domicilio = "Av Libertad"
        cliente.Tel = 483025
        cliente.Cel = 37940020202
        cliente.IdLocalidad = 2226

        Using tran As New Transactions.TransactionScope
            'Act
            Dim resultado As Boolean = cliente.registrar()

            'Assert  
            Assert.AreEqual(True, resultado)

            resultado = cliente.existeCliente(99999999)
            Assert.AreEqual(True, resultado)

            tran.Dispose()
        End Using

        'Prebo que no registra en la BD
        Dim resultado2 = cliente.existeCliente(99999999)
        Assert.AreEqual(False, resultado2)

    End Sub

    <TestMethod()> Public Sub NO_deberia_agregar_un_cliente()

        'Arrange  
        Dim cliente As New Cliente
        cliente.RazonSocial = "Un cliente"
        cliente.Email = "uncliente@gmail.com"
        cliente.Cuit = 0
        cliente.Domicilio = "Av Libertad"
        cliente.Tel = 483025
        cliente.Cel = 37940020202
        cliente.IdLocalidad = 2226

        Using tran As New Transactions.TransactionScope
            'Act
            Dim resultado As Boolean = cliente.registrar()

            'Assert  
            Assert.AreEqual(False, resultado)

           
            tran.Dispose()
        End Using

    End Sub
    <TestMethod()> Public Sub cuit_existente()

        'Arrange  
        Dim cliente As New Cliente

        'Act
        Dim resultado As Boolean = cliente.existeCliente(0)

        'Assert  
        Assert.AreEqual(True, resultado)

    End Sub
    <TestMethod()> Public Sub cuit_NO_existente()

        'Arrange  
        Dim cliente As New Cliente

        'Act
        Dim resultado As Boolean = cliente.existeCliente(99999999)

        'Assert  
        Assert.AreEqual(False, resultado)

    End Sub

    <TestMethod()> Public Sub deberia_modificar_un_cliente()

        'Arrange  
        Dim cliente As New Cliente
        cliente.RazonSocial = "Un cliente"
        cliente.Email = "uncliente@gmail.com"
        cliente.Cuit = 0
        cliente.Domicilio = "Av Libertad"
        cliente.Tel = 483025
        cliente.Cel = 37940020202
        cliente.IdLocalidad = 2225

        Using tran As New Transactions.TransactionScope
            'Act
            Dim resultado As Boolean = cliente.modificar()

            'Assert  
            Assert.AreEqual(True, resultado)

            Dim c As Cliente = cliente.listar.FirstOrDefault(Function(x) x.Cuit = cliente.Cuit)

            Assert.AreEqual("Un cliente", c.RazonSocial)
            Assert.AreEqual("uncliente@gmail.com", c.Email)
            Assert.AreEqual("Av Libertad", c.Domicilio)
            Assert.AreEqual("483025", c.Tel)
            Assert.AreEqual("37940020202", c.Cel)
            Assert.AreEqual(2225, c.IdLocalidad)

            tran.Dispose()
        End Using

        Dim cli As New Cliente
        cli = cli.listar.FirstOrDefault(Function(x) x.Cuit = 0)

        Assert.AreNotEqual("Un cliente", cli.RazonSocial)
        Assert.AreNotEqual("uncliente@gmail.com", cli.Email)
        Assert.AreNotEqual("Av Libertad", cli.Domicilio)
        Assert.AreNotEqual("483025", cli.Tel)
        Assert.AreNotEqual("37940020202", cli.Cel)
        Assert.AreNotEqual(2225, cli.IdLocalidad)

    End Sub
    <TestMethod()> Public Sub deberia_NO_modificar_un_cliente()

        'Arrange  
        Dim cliente As New Cliente
        cliente.RazonSocial = "Un cliente"
        cliente.Email = "uncliente@gmail.com"
        cliente.Cuit = 1
        cliente.Domicilio = "Av Libertad"
        cliente.Tel = 483025
        cliente.Cel = 37940020202
        cliente.IdLocalidad = 2226

        Using tran As New Transactions.TransactionScope
            'Act
            Dim resultado As Boolean = cliente.modificar()

            'Assert  
            Assert.AreEqual(False, resultado)

            tran.Dispose()
        End Using
    End Sub
    <TestMethod()> Public Sub deberia_NO_eliminar_un_cliente()

        'Arrange  
        Dim cliente As New Cliente
        cliente.RazonSocial = "Un cliente"
        cliente.Email = "uncliente@gmail.com"
        cliente.Cuit = 99999999
        cliente.Domicilio = "Av Libertad"
        cliente.Tel = 483025
        cliente.Cel = 37940020202
        cliente.IdLocalidad = 2226

        Using tran As New Transactions.TransactionScope
            'Act
            Dim resultado As Boolean = cliente.eliminar()

            'Assert  
            Assert.AreEqual(False, resultado)

            tran.Dispose()
        End Using
    End Sub
    <TestMethod()> Public Sub deberia_eliminar_un_cliente()

        'Arrange  
        Dim cliente As New Cliente
        cliente.RazonSocial = "Un cliente"
        cliente.Email = "uncliente@gmail.com"
        cliente.Cuit = 0
        cliente.Domicilio = "Av Libertad"
        cliente.Tel = 483025
        cliente.Cel = 37940020202
        cliente.IdLocalidad = 2226

        Using tran As New Transactions.TransactionScope
            'Act
            Dim resultado As Boolean = cliente.eliminar()

            'Assert  
            Assert.AreEqual(True, resultado)

            Dim i As Integer = cliente.listar.Where(Function(x) x.Cuit = cliente.Cuit).Count()
            Assert.AreEqual(0, i)

            tran.Dispose()
        End Using
    End Sub
    




   

End Class