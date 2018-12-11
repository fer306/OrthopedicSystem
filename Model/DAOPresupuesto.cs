using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace Model
{
   public class DAOPresupuesto
    {
        private SqlServer stringConnetion  = new SqlServer();
   
        public DataView listarPresupuestos() 
        {
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

            using (var db = new dbDataContext ())
	                {
                        foreach (listarPresupuestosResult listarPresupuestos in db.listarPresupuestos())
                        {
                            string consumo= " ";
                            if (listarPresupuestos.consumoTiene.Value)
                            { 
                                consumo = "✓";
                            }
                            dt.Rows.Add(listarPresupuestos.Número_de_presupuesto, listarPresupuestos.Fecha, listarPresupuestos.Vencimiento, listarPresupuestos.Cliente, listarPresupuestos.Paciente, listarPresupuestos.Medico, listarPresupuestos.Estado, listarPresupuestos.Fecha_de_cirugía, listarPresupuestos.Fecha_de_Autorización, consumo);

                        }
	                }
                    DataView dv= new DataView(dt);

        return dv;
        }
            
       } 


}

