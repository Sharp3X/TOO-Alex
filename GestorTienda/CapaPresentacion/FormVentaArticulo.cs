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
    public partial class FormVentaArticulo : Form
    {
        private ServicioArticulo sa;
        private ServicioVenta sv;
        private List<Articulo> listado;
        private BindingSource bs;
        private BindingSource bs2;


        public FormVentaArticulo()
        {
            InitializeComponent();
        }

        public FormVentaArticulo(ServicioArticulo sa, ServicioVenta sv)
        {
            InitializeComponent();
            this.bs = new BindingSource();
            this.bs2 = new BindingSource();
            this.sa = sa;
            this.sv = sv;
            this.listado = sa.DatosCatalogoTienda().ToList();
            this.bs.DataSource = this.listado;
            this.listBox1.DataSource = this.bs;
            this.listBox1.DisplayMember = "codigo";
            limpiarCuadros();

        }

        private void limpiarCuadros()
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.listBox3.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            List<Venta> laux = new List<Venta>();
            if (this.listBox1.SelectedItem != null)
            {
                Articulo aux = (Articulo) this.listBox1.SelectedItem;
                foreach(Venta v in this.sv.DatosVentas().ToList())
                {
                    foreach(LineaVenta lv in v.Lineas)
                    {
                        if (lv.Articulo.Codigo == aux.Codigo)
                        {
                            if (!laux.Contains(v))
                            {
                                laux.Add(v);
                            }
                        }
                    }
                }
                this.bs2.DataSource = laux;
                this.listBox2.DataSource = bs2;
                this.listBox2.DisplayMember = "codigo";
                this.bs2.ResetBindings(false);
                limpiarCuadros();

            }
            else
            {
                limpiarCuadros();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<LineaVenta> laux = new List<LineaVenta>();
            Venta v = (Venta)this.listBox2.SelectedItem;
            if (v != null)
            {
                this.textBox1.Text = v.Codigo;
                this.textBox2.Text = v.Dependiente.NSS;
                this.textBox3.Text = v.FechaVenta.ToString();
                if (v is VentaTarjeta)
                {
                    VentaTarjeta v2 = (VentaTarjeta)v;
                    this.textBox4.Text = v2.NumTarjeta;
                }
                else
                {
                    this.textBox4.Text = "No tarjeta";
                }
                this.listBox3.Items.Clear();
                foreach (LineaVenta l in v.Lineas)
                {
                    this.listBox3.Items.Add(new Label().Text = l.ToString());
                }
            }

        }


    }
}
