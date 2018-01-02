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
    public partial class FormBúsqueda2 : Form
    {
        private List<Dependiente> listado;
        private BindingSource bs;

        public FormBúsqueda2()
        {
            InitializeComponent();
        }

        public FormBúsqueda2(List<Dependiente> ld)
        {
            InitializeComponent();
            this.bs = new BindingSource();
            this.listado = ld;
            this.comboBox1.DataSource = bs;
            this.bs.DataSource = this.listado;
            this.comboBox1.DisplayMember = "nss";
            this.comboBox1.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex != -1)
            {
                this.textBox1.Text = this.listado.ElementAt(this.comboBox1.SelectedIndex).Nombre;
                this.textBox2.Text = this.listado.ElementAt(this.comboBox1.SelectedIndex).Apellidos;
            }
        }
    }
}
