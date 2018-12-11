using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentador;

namespace View
{
	public partial class listadoClientesEliminados : MetroFramework.Forms.MetroForm, IListadoEliminadosClientes
	{
        public presentadorListadoEliminados _presentador { get; set; }
        public frmPrincipal formularioPrincipal { get; set; }

		public listadoClientesEliminados(frmPrincipal formularioPrincipal)
		{
            _presentador = new presentadorListadoEliminados(this);
            this.formularioPrincipal = formularioPrincipal;
			InitializeComponent();
		}

		private void listadoClientesEliminados_Load(object sender, EventArgs e)
		{
            _presentador.setgridDataSourseClientes();


		}

        public object gridDataSourseClientes
        {
            get { return DGClientes.DataSource; }
            set { DGClientes.DataSource = value; }
        }

        //private void txtFiltroCliente_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtFiltroCliente.Text.ToString() == String.Empty)
        //        _presentador.setgridDataSourseClientes();
        //    else
        //        _presentador.clientesBusquedas(txtFiltroCliente.Text.ToString());

        //}

        private void btnModCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_presentador.restaurarCliente((long.Parse(this.DGClientes.CurrentRow.Cells[0].Value.ToString()))));
            _presentador.setgridDataSourseClientes();
        }

        private void listadoClientesEliminados_FormClosed(object sender, FormClosedEventArgs e)
        {
            formularioPrincipal.actualizarDGClientes();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_presentador.eliminarDefinitivo((long.Parse(this.DGClientes.CurrentRow.Cells[0].Value.ToString()))));
            _presentador.setgridDataSourseClientes();
        }

      
    }
}
