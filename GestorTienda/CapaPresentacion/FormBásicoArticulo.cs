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
    public partial class FormBásicoArticulo : Form
    {
        private ServicioArticulo sa;
        private List<Articulo> listado;
        private BindingSource bs;

        public FormBásicoArticulo()
        {
            InitializeComponent();
        }

        public FormBásicoArticulo(ServicioArticulo sa)
        {
            InitializeComponent();
            this.bs = new BindingSource();
            this.sa = sa;
            this.listado = sa.DatosCatalogoTienda().ToList();
            limpiarCuadros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCuadros();
            List<Articulo> aux = new List<Articulo>();
            aux = sa.ArticulosPorIva(tipoIva.normal);
            this.bs.DataSource = aux;
            this.listBox1.DataSource = bs;
            this.listBox1.DisplayMember = "codigo";
            this.bs.ResetBindings(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiarCuadros();
            List<Articulo> aux = new List<Articulo>();
            aux = sa.ArticulosPorIva(tipoIva.reducido);
            this.bs.DataSource = aux;
            this.listBox1.DataSource = bs;
            this.listBox1.DisplayMember = "codigo";
            this.bs.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiarCuadros();
            List<Articulo> aux = new List<Articulo>();
            aux = sa.ArticulosPorIva(tipoIva.superReducido);
            this.bs.DataSource = aux;
            this.listBox1.DataSource = bs;
            this.listBox1.DisplayMember = "codigo";
            this.bs.ResetBindings(false);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItem != null)
            {
                Articulo aux = (Articulo)this.listBox1.SelectedItem;
                this.textBox1.Text = aux.Codigo;
                this.textBox2.Text = aux.Iva.ToString();
                this.textBox3.Text = aux.Descripcion;
                this.textBox4.Text = aux.PrecioVenta.ToString();
            }
            else
            {
                limpiarCuadros();
            }
        }

        private void limpiarCuadros()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            
        }
    }
}
