using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo_de_dominio;
using LogicaNegocio;

namespace CapaPresentacion
{
    public partial class FormDataGridViewVenta : Form
    {
        private List<Venta> listado;
        private ServicioVenta sv;
        public FormDataGridViewVenta()
        {
            InitializeComponent();
        }
        public FormDataGridViewVenta(List<Venta> lv, ServicioVenta sv)
        {
            InitializeComponent();
            this.sv = sv;
            this.listado = lv;
            this.dataGridView1.Columns.Add("Código", "Código");
            this.dataGridView1.Columns.Add("Dependiente", "Dependiente");
            this.dataGridView1.Columns.Add("Fecha de venta", "Fecha de venta");
            this.dataGridView1.Columns.Add("Tarjeta", "Tarjeta");
            foreach(Venta v in this.listado)
            {
                VentaTarjeta vtaux = v as VentaTarjeta;
                string[] row = new string[] { v.Codigo, v.Dependiente.NSS, v.FechaVenta.ToString(), vtaux==null ? "No tarjeta" : vtaux.NumTarjeta };
                this.dataGridView1.Rows.Add(row);
            }
            if (this.dataGridView1.Rows.Count == 1)
            {
                this.dataGridView1.Rows.RemoveAt(this.dataGridView1.Rows.Count);

                this.dataGridView1.ClearSelection();
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count != 0 )
            {
                if (this.dataGridView1.SelectedRows[0].Cells[0].Value != null) {
                    string codigo = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    Venta vaux = new VentaContado(codigo, null);
                    Venta v = sv.ObtenerInfoVenta(vaux);
                    this.bindingSource1.DataSource = v.Lineas;
                    this.dataGridView2.DataSource = this.bindingSource1;
                }
            }

        }

    }
}
