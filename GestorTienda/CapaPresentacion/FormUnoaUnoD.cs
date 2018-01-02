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
    public partial class FormUnoaUnoD : Form
    {
        private List<Dependiente> listado;


        public FormUnoaUnoD()
        {
            InitializeComponent();
        }

        public FormUnoaUnoD(List<Dependiente> ld)
        {
            InitializeComponent();
            this.listado = ld;
            this.bindingSource1.DataSource = this.listado;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = ((Dependiente)this.bindingSource1.Current).NSS;
            this.textBox2.Text = ((Dependiente)this.bindingSource1.Current).Nombre;
            this.textBox3.Text = ((Dependiente)this.bindingSource1.Current).Apellidos;
            this.textBox4.Text = ((Dependiente)this.bindingSource1.Current).Comision + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
