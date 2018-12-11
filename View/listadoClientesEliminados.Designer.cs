namespace View
{
    partial class listadoClientesEliminados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(listadoClientesEliminados));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DGClientes = new MetroFramework.Controls.MetroGrid();
            this.TableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.PictureBox5 = new System.Windows.Forms.PictureBox();
            this.MetroLabel29 = new MetroFramework.Controls.MetroLabel();
            this.txtFiltroCliente = new MetroFramework.Controls.MetroTextBox();
            this.btnModCliente = new MetroFramework.Controls.MetroButton();
            this.btnEliminar = new MetroFramework.Controls.MetroButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGClientes)).BeginInit();
            this.TableLayoutPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DGClientes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TableLayoutPanel21, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1067, 439);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DGClientes
            // 
            this.DGClientes.AllowUserToAddRows = false;
            this.DGClientes.AllowUserToDeleteRows = false;
            this.DGClientes.AllowUserToOrderColumns = true;
            this.DGClientes.AllowUserToResizeRows = false;
            this.DGClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGClientes.BackgroundColor = System.Drawing.Color.LightGray;
            this.DGClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGClientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGClientes.EnableHeadersVisualStyles = false;
            this.DGClientes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.DGClientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DGClientes.Location = new System.Drawing.Point(0, 39);
            this.DGClientes.Margin = new System.Windows.Forms.Padding(0);
            this.DGClientes.Name = "DGClientes";
            this.DGClientes.ReadOnly = true;
            this.DGClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGClientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGClientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGClientes.Size = new System.Drawing.Size(1067, 400);
            this.DGClientes.TabIndex = 6;
            // 
            // TableLayoutPanel21
            // 
            this.TableLayoutPanel21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel21.BackColor = System.Drawing.Color.DarkGray;
            this.TableLayoutPanel21.ColumnCount = 5;
            this.TableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.61807F));
            this.TableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.810496F));
            this.TableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            this.TableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TableLayoutPanel21.Controls.Add(this.PictureBox5, 0, 0);
            this.TableLayoutPanel21.Controls.Add(this.MetroLabel29, 0, 0);
            this.TableLayoutPanel21.Controls.Add(this.txtFiltroCliente, 2, 0);
            this.TableLayoutPanel21.Controls.Add(this.btnModCliente, 3, 0);
            this.TableLayoutPanel21.Controls.Add(this.btnEliminar, 4, 0);
            this.TableLayoutPanel21.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel21.Margin = new System.Windows.Forms.Padding(0);
            this.TableLayoutPanel21.Name = "TableLayoutPanel21";
            this.TableLayoutPanel21.RowCount = 1;
            this.TableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel21.Size = new System.Drawing.Size(1067, 39);
            this.TableLayoutPanel21.TabIndex = 5;
            // 
            // PictureBox5
            // 
            this.PictureBox5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox5.Image")));
            this.PictureBox5.InitialImage = ((System.Drawing.Image)(resources.GetObject("PictureBox5.InitialImage")));
            this.PictureBox5.Location = new System.Drawing.Point(504, 5);
            this.PictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.PictureBox5.Name = "PictureBox5";
            this.PictureBox5.Size = new System.Drawing.Size(33, 29);
            this.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox5.TabIndex = 6;
            this.PictureBox5.TabStop = false;
            // 
            // MetroLabel29
            // 
            this.MetroLabel29.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MetroLabel29.AutoSize = true;
            this.MetroLabel29.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.MetroLabel29.Location = new System.Drawing.Point(3, 10);
            this.MetroLabel29.Name = "MetroLabel29";
            this.MetroLabel29.Size = new System.Drawing.Size(53, 19);
            this.MetroLabel29.TabIndex = 4;
            this.MetroLabel29.Text = "Buscar";
            this.MetroLabel29.UseCustomBackColor = true;
            // 
            // txtFiltroCliente
            // 
            this.txtFiltroCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltroCliente.Lines = new string[0];
            this.txtFiltroCliente.Location = new System.Drawing.Point(540, 8);
            this.txtFiltroCliente.MaxLength = 32767;
            this.txtFiltroCliente.Name = "txtFiltroCliente";
            this.txtFiltroCliente.PasswordChar = '\0';
            this.txtFiltroCliente.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFiltroCliente.SelectedText = "";
            this.txtFiltroCliente.Size = new System.Drawing.Size(308, 23);
            this.txtFiltroCliente.TabIndex = 5;
            this.txtFiltroCliente.UseSelectable = true;
            // 
            // btnModCliente
            // 
            this.btnModCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModCliente.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnModCliente.Location = new System.Drawing.Point(854, 8);
            this.btnModCliente.Name = "btnModCliente";
            this.btnModCliente.Size = new System.Drawing.Size(101, 23);
            this.btnModCliente.TabIndex = 3;
            this.btnModCliente.Text = "Restaurar";
            this.btnModCliente.UseCustomBackColor = true;
            this.btnModCliente.UseSelectable = true;
            this.btnModCliente.Click += new System.EventHandler(this.btnModCliente_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnEliminar.Location = new System.Drawing.Point(961, 8);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(103, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar ";
            this.btnEliminar.UseCustomBackColor = true;
            this.btnEliminar.UseSelectable = true;
            this.btnEliminar.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // listadoClientesEliminados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 531);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "listadoClientesEliminados";
            this.Text = "Listado de clientes eliminados";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.listadoClientesEliminados_FormClosed);
            this.Load += new System.EventHandler(this.listadoClientesEliminados_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGClientes)).EndInit();
            this.TableLayoutPanel21.ResumeLayout(false);
            this.TableLayoutPanel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal MetroFramework.Controls.MetroGrid DGClientes;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel21;
        internal System.Windows.Forms.PictureBox PictureBox5;
        internal MetroFramework.Controls.MetroLabel MetroLabel29;
        internal MetroFramework.Controls.MetroButton btnModCliente;
        internal MetroFramework.Controls.MetroTextBox txtFiltroCliente;
        internal MetroFramework.Controls.MetroButton btnEliminar;

    }
}