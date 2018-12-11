using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Xml;
using Presentador;

namespace TDD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
             PPresupuesto _presentador;
             _presentador = new PPresupuesto();

             DataTable dt = new DataTable();
             dt.Columns.Add("Número de presupuesto");
             dt.Columns.Add("Fecha");
             dt.Columns.Add("Vencimiento");
             dt.Columns.Add("Cliente");
             dt.Columns.Add("Paciente");
             dt.Columns.Add("Médico");
             dt.Columns.Add("Estado");
             dt.Columns.Add("Fecha de cirugía");
             dt.Columns.Add("Fecha de Autorización");
             dt.Columns.Add("Consumo");

             dt.Columns[0].DataType = typeof(int);
             dt.Columns[1].DataType = typeof(DateTime);
             dt.Columns[2].DataType = typeof(DateTime);
             dt.Columns[3].DataType = typeof(string);
             dt.Columns[4].DataType = typeof(string);
             dt.Columns[5].DataType = typeof(string);
             dt.Columns[6].DataType = typeof(string);
             dt.Columns[7].DataType = typeof(DateTime);
             dt.Columns[8].DataType = typeof(DateTime);
             dt.Columns[9].DataType = typeof(string);

             dt.Rows.Add(1, DateTime.Now, DateTime.Now, "Ejemplo Cliente", "Ejemplo Paciente", "Ejemplo Medico", "En espera", DateTime.Now, DateTime.Now, "true");
             dt.Rows.Add(5, DateTime.Now, DateTime.Now, "Ejemplo Cliente", "Ejemplo Paciente", "Ejemplo Medico", "En espera", DateTime.Now, DateTime.Now, "true");
             dt.Rows.Add(2, DateTime.Now, DateTime.Now, "Ejemplo Cliente", "Ejemplo Paciente", "Ejemplo Medico", "Realizado", DateTime.Now, DateTime.Now, "true");
             dt.Rows.Add(3, DateTime.Now, DateTime.Now, "Ejemplo Cliente", "Ejemplo Paciente", "Ejemplo Medico", "Cancelado", DateTime.Now, DateTime.Now, "true");
             dt.Rows.Add(4, DateTime.Now, DateTime.Now, "Ejemplo Cliente", "Ejemplo Paciente", "Ejemplo Medico", "Confirmado", DateTime.Now, DateTime.Now, "true");
                                
             DataView dv= new DataView(dt);

             DataView dv2 = _presentador.filtroPorEstados(dv,"'En Espera'");
             Assert.AreEqual(2, dv.Count);


             dv2 = _presentador.filtroPorEstados(dv, "'Realizado'");
             Assert.AreEqual(1, dv.Count);
        }
    }
}
