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
    public partial class FormUnoaUnoA : Form
    {
        private List<Articulo> listado;

        public FormUnoaUnoA()
        {
            InitializeComponent();
        }
        public FormUnoaUnoA(List<Articulo> la)
        {
            InitializeComponent();
            this.listado = la;
            this.bindingSource1.DataSource = this.listado;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = ((Articulo)this.bindingSource1.Current).Codigo;
            this.textBox2.Text = ((Articulo)this.bindingSource1.Current).Descripcion;
            this.textBox3.Text = ((Articulo)this.bindingSource1.Current).PrecioVenta+"";
            this.textBox4.Text = ((Articulo)this.bindingSource1.Current).Iva.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
