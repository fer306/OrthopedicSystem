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
    public partial class frmPrincipal : MetroFramework.Forms.MetroForm, IPresupuesto, ICalculosAux
    {
        private PPresupuesto _presentador;
        private PCalculosAuxiliares _presentadorCalAux;
        private BindingSource source = new BindingSource();


        public frmPrincipal()
        {
            _presentador = new PPresupuesto(this);
            _presentadorCalAux = new PCalculosAuxiliares(this);
            InitializeComponent();
        }

        public object gridDataSoursePresupuesto
        {
            get { return DGPresupuesto.DataSource; }
            set
            { 
                DGPresupuesto.DataSource = value;
            }
        }

        //public void cambiarCabeceraDGClientes()
        //{
        //    this.DGClientes.Columns["cuit"].HeaderText = "CUIT";
        //    this.DGClientes.Columns["razonSocial"].HeaderText = "RAZÓN SOCIAL";
        //    this.DGClientes.Columns["celular"].HeaderText = "CELULAR";
        //    this.DGClientes.Columns["telefono"].HeaderText = "TELEFONO";
        //    this.DGClientes.Columns["email"].HeaderText = "CORREO ELECTRONICO";
        //    this.DGClientes.Columns["Nombre"].HeaderText = "LOCALIDAD";
        //}


        public string calculosAux
        {
            get { return txtDescripCalcuAux.Text.ToString(); }
            set { txtDescripCalcuAux.Text = value; }
        }

        public object CBProvincias
        {
            set { cbProvincias.DataSource = value; }
        }

        public object CBDepartamento
        {
            set { cbDepartamento.DataSource = value; }
        }

        public object CBLocalidades
        {
            set { cbLocalidad.DataSource = value; }
        }
        private void cbProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProvincias.SelectedItem != null)
            {
                _presentador.setCBDepartamento(int.Parse(cbProvincias.SelectedValue.ToString()));
            }
        }
        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDepartamento.SelectedItem != null)
            {
                _presentador.setCBLocalidades(int.Parse(cbDepartamento.SelectedValue.ToString()));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            SetUp();

        }

        private void SetUp()
        {

            _presentador.setgridDataSoursePresupuesto(_presentador.filtroPorEstados(_presentador.getgridDataSoursePresupuesto(), "'En Espera'"));

            _presentador.setgridDataSourseClientes();

             _presentador.cargarCB();

            _presentador.setCBProvincias();

           


        }

        private void DGPresupuesto_Click(object sender, EventArgs e)
        {
            int idPresupuesto = Convert.ToInt32(this.DGPresupuesto.CurrentRow.Cells[0].Value.ToString());
            _presentadorCalAux.setcalculosAux(idPresupuesto);
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_presentador.registrarCliente(int.Parse(cbLocalidad.SelectedValue.ToString())));
        }

        public String Cuit
        {
            get
            {
                if (string.IsNullOrEmpty(txtCuitCliente.Text))
                    throw new ArgumentOutOfRangeException("CUIT - CLIENTE",
                    "El CUIT no puede estar vacio."); ;
                return txtCuitCliente.Text.ToString();

            }
            set { txtCuitCliente.Text = value.ToString(); }
        }
        public string Telefono
        {
            get { return txtTelCliente.Text.ToString(); }
            set { txtTelCliente.Text = value; }

        }
        public string Celular
        {
            get { return txtCelCliente.Text.ToString(); }
            set { txtCelCliente.Text = value; }

        }
        public string Email
        {
            get { return txtEmailCliente.Text.ToString().ToUpper(); }
            set { txtEmailCliente.Text = value; }

        }
        public string Direccion
        {
            get { return txtDireccionCliente.Text.ToString().ToUpper(); }
            set { txtDireccionCliente.Text = value; }

        }
        public string RazonSocial
        {
            get { return txtRZcliente.Text.ToString().ToUpper(); }
            set { txtRZcliente.Text = value; }
        }



        public object gridDataSourseClientes
        {

            get { return DGClientes.DataSource; }
            set
            {
                DGClientes.DataSource = value;
            }
        }

        public bool botonModificar
        {
            set
            {
                btnModCliente.Enabled = value;
            }
        }

        public string CBValueMember
        { 
            set 
            { 
                cbLocalidad.ValueMember = cbDepartamento.ValueMember = cbProvincias.ValueMember = value; 
            }
        }
        public string CBDisplayMember 
        { 
            set 
            { 
                cbLocalidad.DisplayMember = cbDepartamento.DisplayMember = cbProvincias.DisplayMember = value; 
            } 
        }


        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_presentador.eliminarCliente(long.Parse(this.DGClientes.CurrentRow.Cells[0].Value.ToString())));
            _presentador.setgridDataSourseClientes();
        }

        private void txtFiltroCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtFiltroCliente.Text.ToString() == String.Empty)
                _presentador.setgridDataSourseClientes();
            else
                _presentador.clientesBusquedas(txtFiltroCliente.Text.ToString());

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            listadoClientesEliminados form2 = new listadoClientesEliminados(this);
            form2.Show();

        }

        public void actualizarDGClientes ()
        {
            _presentador.setgridDataSourseClientes();
        }
        
        private void DGClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _presentador.cargarCliente(long.Parse(this.DGClientes.CurrentRow.Cells[0].Value.ToString()));

        }

        private void btnLimpiarCliente_Click(object sender, EventArgs e)
        {
            _presentador.limpiarTextboxCliente();

        }

        private void btnModCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_presentador.modificar(int.Parse(cbLocalidad.SelectedValue.ToString())));

        }






        public object bindGridCliente
        {
            get { return source; }
            set { source.DataSource = value; }
        }


        public int CBProvinciaIndex
        {
            set { cbProvincias.SelectedIndex = value;  }
        }


        public int CBDepartamentoIndex
        {
            set { }
        }
    }
}
