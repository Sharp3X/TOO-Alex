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
    public partial class FormListado : Form
    {

        private List<Dependiente> listado;
        private BindingSource bs;


        public FormListado(List<Dependiente> ld) 
        {
            InitializeComponent();
            this.bs = new BindingSource();
            this.listado = ld;

            this.listBox1.DataSource = bs;
            this.bs.DataSource = this.listado;
            this.listBox1.DisplayMember = "nss";

            this.listBox2.DataSource = bs;
            this.listBox2.DisplayMember = "nombre";

            this.listBox3.DataSource = bs;
            this.listBox3.DisplayMember = "apellidos";   //es por comision pero uso apellidos para probar
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listado.OrderBy(l => l.NSS);  //Esto no chuta
            this.listBox1.Refresh();
            this.listBox2.Refresh();
            this.listBox3.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listado.OrderBy(l => l.Nombre);
            this.listBox1.Refresh();
            this.listBox2.Refresh();
            this.listBox3.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.listado.OrderBy(l => l.Apellidos);
            this.listBox1.Refresh();
            this.listBox2.Refresh();
            this.listBox3.Refresh();
        }
    }
}
