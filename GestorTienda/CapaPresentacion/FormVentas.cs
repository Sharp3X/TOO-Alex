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
    public partial class FormVentas : Form
    {
        private Venta v;
        private List<LineaVenta> lista;
        private ServicioArticulo sa;
        private ServicioVenta sv;

        public FormVentas()
        {
            InitializeComponent();
            
        }

        public FormVentas(String cadena, ServicioArticulo sa,ServicioVenta sv)
        {
            InitializeComponent();
            this.Text = cadena + this.Text;
            this.sa = sa;
            this.v = new VentaContado(cadena, null);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.textBox4.ReadOnly = false;
            }
            else
            {
                this.textBox4.ReadOnly = true;
                this.textBox4.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAniadirLinea fal = new FormAniadirLinea();
            fal.ShowDialog();
            DialogResult dr = fal.DialogResult;
            if (dr == DialogResult.OK)
            {
                //Añado a la venta base, que empieza como vacia (v) un articulo, el cual busco en nuestro servicio articulos.
                //Para ello necesito construir un articulo envoltorio del codigo
                if (sa.ObtenerInfoArticulo(new Articulo(fal.textBox1.Text, tipoIva.normal, 0)) != null) //Si el articulo esta en nuestra base de datos
                {
                    sv.AnadirLineaVenta(v, sa.ObtenerInfoArticulo(new Articulo(fal.textBox1.Text, tipoIva.normal, 0)), int.Parse(fal.textBox2.Text));
                    // En esta instruccion hay que añadir la linea de venta en concreto, porque no se puede hacer un .items= a algo    --  (Prueba) listBox1.Items.Add("Hola");
                }
                else
                {
                    DialogResult drDelay = MessageBox.Show(this, "El articulo no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (dr == DialogResult.Abort) //No saldrá hasta que introduzcamos un codigo o cantidad validaos o pulsemos en cerrar
            {
                while (dr == DialogResult.Abort)
                {
                    fal.Dispose();
                    fal = new FormAniadirLinea();
                    dr = fal.ShowDialog();
                }
            }
            else {
                fal.Dispose();
            }
        }
    }
}
