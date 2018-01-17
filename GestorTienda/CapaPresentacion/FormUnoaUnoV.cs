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

namespace CapaPresentacion
{
    public partial class FormUnoaUnoV : Form
    {
        private List<Venta> listado;

        public FormUnoaUnoV()
        {
            InitializeComponent();
        }

        public FormUnoaUnoV(List<Venta> lv)
        {
            InitializeComponent();
            this.listado = lv;
            this.bindingSource1.DataSource = this.listado;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = ((Venta)this.bindingSource1.Current).Codigo;
            this.textBox2.Text = ((Venta)this.bindingSource1.Current).Dependiente.NSS;
            this.textBox3.Text = ((Venta)this.bindingSource1.Current).FechaVenta.ToString();
            this.listBox1.Items.Clear();
            foreach (LineaVenta l in ((Venta)this.bindingSource1.Current).Lineas)
            {
                this.listBox1.Items.Add(new Label().Text = l.ToString());
            }
            VentaTarjeta vtaux = (Venta)this.bindingSource1.Current as VentaTarjeta; //Si se consigue castear, entonces será una VentaTarjeta, si no será una VentaContado
            if (vtaux == null)
            {
                this.checkBox1.Checked = false;

            }
            else
            {
                this.checkBox1.Checked = true;
                this.textBox4.Text = vtaux.NumTarjeta;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
