Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Lan

<TestClass()> Public Class TestProviciaDepartamentoLocalidad


    <TestMethod()> Public Sub numLocalidadPorIdProvinciaExistente()
        Dim loc As New Localidad
        Dim depar As New Departamento
        Dim idProvincia As Integer = 6
        Dim listaIdDepartamento As List(Of Integer)

        listaIdDepartamento = depar.listarIdDepartamentePorProvincia(idProvincia)
        Dim numeroLocalidades As Integer = (loc.listar(listaIdDepartamento)).Count

        Assert.AreEqual(205, numeroLocalidades)

    End Sub
    <TestMethod()> Public Sub numLocalidadPorIdProvinciaNoExistente()
        Dim loc As New Localidad
        Dim depar As New Departamento
        Dim idProvincia As Integer = 24
        Dim listaIdDepartamento As List(Of Integer)

        listaIdDepartamento = depar.listarIdDepartamentePorProvincia(idProvincia)
        Dim numeroLocalidades As Integer = (loc.listar(listaIdDepartamento)).Count

        Assert.AreEqual(0, numeroLocalidades)

    End Sub
    

End Class