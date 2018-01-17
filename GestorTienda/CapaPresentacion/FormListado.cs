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
            this.listBox3.DisplayMember = "comision";   
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listado.Sort((x,y) => String.Compare(x.NSS,y.NSS));
            this.bs.ResetBindings(false);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listado.Sort((x, y) => String.Compare(x.Nombre, y.Nombre));
            this.bs.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.listado.Sort((x, y) => x.Comision.CompareTo(y.Comision));
            this.bs.ResetBindings(false);
        }
    }
}
