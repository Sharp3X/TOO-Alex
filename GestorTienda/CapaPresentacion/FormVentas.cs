﻿using System;
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
        private ServicioDependiente sd;

        public FormVentas()
        {
            InitializeComponent();
            
        }

        public FormVentas(String cadena, String codigo ,ServicioArticulo sa,ServicioVenta sv, ServicioDependiente sd)
        {
            InitializeComponent();
            this.Text = cadena + this.Text;
            this.sa = sa;
            this.sv = sv;
            this.sd = sd;
            this.v = new VentaContado(codigo, null);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validacion()) //Si cumple las condiciones, da de alta la venta adecuada,
            {


                if (this.checkBox1.Checked == true)
                {
                    VentaTarjeta vaux = (VentaTarjeta)this.v;
                    vaux.NumTarjeta = this.textBox4.Text;

                }
                this.sv.DarAltaVenta(v);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }
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
                Venta vn = new VentaTarjeta("",this.v.Codigo, this.v.Dependiente);
                vn.Lineas = v.Lineas;
                sv.DarBajaVenta(v);
                this.v = vn;
                sv.DarAltaVenta(v);
            }
            else
            {
                this.textBox4.ReadOnly = true;
                this.textBox4.Text = "";
                Venta vn = new VentaContado(this.v.Codigo, this.v.Dependiente);
                vn.Lineas = v.Lineas;
                sv.DarBajaVenta(v);
                this.v = vn;
                sv.DarAltaVenta(v);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAniadirLinea fal = new FormAniadirLinea();
            fal.ShowDialog();
            DialogResult dr = fal.DialogResult;
            while (dr == DialogResult.Abort)
            {
                fal.Dispose();
                fal = new FormAniadirLinea();
                dr = fal.ShowDialog();
            }
            if (dr == DialogResult.OK)
            {
                //Añado a la venta base, que empieza como vacia (v) un articulo, el cual busco en nuestro servicio articulos.
                sv.DarAltaVenta(v);
                //Para ello necesito construir un articulo envoltorio del codigo
                
                if (sa.ObtenerInfoArticulo(new Articulo(fal.textBox1.Text, tipoIva.normal, 0)) != null) //Si el articulo esta en nuestra base de datos
                {
                    string codigoArticulo = fal.textBox1.Text;
                    int numeroArticulos = int.Parse(fal.textBox2.Text);
                    sv.AnadirLineaVenta(v, sa.ObtenerInfoArticulo(new Articulo(codigoArticulo, tipoIva.normal, 0)), numeroArticulos);
                    this.listBox1.Items.Clear();
                    foreach(LineaVenta l in v.Lineas)
                    {
                        this.listBox1.Items.Add(new Label().Text=l.ToString());
                    }
                    
                    
                }
                else
                {
                    DialogResult drDelay = MessageBox.Show(this, "El articulo no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else {
                fal.Dispose();
            }
        }

        private bool validacion()
        {
            Dependiente aux = new Dependiente(this.textBox3.Text, "", ""); //Envolvemos el nss del dependiente que se quiere incluir en la venta
            if((sd.ObtenerInfoDependiente(aux)!= null)&(v.Lineas.Count > 0)) //Si el dependiente está dado de alta en la base, y al menos ha añadido un articulo a la venta, devuelve true
            {
                if(this.checkBox1.Checked==true & this.textBox4.Text == "")//Lo pongo aquí para mejor visibilidad
                {                                                              //Si tiene activada la opción de tarjeta, pero no mete una cadena (no compruebo numerica), devolverá falso
                    return false;                                                //Si no la tiene activada, devuelve true tambien
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return false;
            }

        }
    }
}
