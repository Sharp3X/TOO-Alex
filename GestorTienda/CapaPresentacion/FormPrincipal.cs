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
    public partial class FormPrincipal : Form
    {
        private ServicioArticulo sa;
        private ServicioDependiente sd;
        private ServicioVenta sv;

        public FormPrincipal()
        {
            InitializeComponent();
            this.sa = new ServicioArticulo();
            this.sd = new ServicioDependiente();
            this.sv = new ServicioVenta();
        }

        //Métodos correspondientes a los botones de Dependiente
        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("NºSS");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;

            if (dr == DialogResult.OK)
            {
                while (fi.textBox1.Text == "" & dr==DialogResult.OK)
                {
                    DialogResult drDelay = MessageBox.Show(this, "Debe introducir un nss para el nuevo Dependiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fi.Dispose();
                    fi = new FormIntroducir("NºSS");
                    dr = fi.ShowDialog();
                }
                if (dr == DialogResult.OK)
                {
                    Dependiente daux = new Dependiente(fi.textBox1.Text, null, null);
                    Dependiente d = sd.ObtenerInfoDependiente(daux);
                    if (d != null)
                    {
                        DialogResult dr2 = MessageBox.Show(this, "¿Quieres introducir otro?", "Ya existe un dependiente con ese NºSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr2 == DialogResult.Yes)
                        {
                            fi.Dispose();
                            this.altaToolStripMenuItem.PerformClick();
                        }
                        else
                        {
                            fi.Dispose();
                        }
                    }
                    else //le dejaremos crear uno al no haber ninguno aun
                    {
                        fi.Dispose();
                        FormDependientes fd = new FormDependientes("Alta");
                        fd.label4.Dispose();
                        fd.textBox4.Dispose();
                        fd.textBox1.Text = daux.NSS; //nss que hemos buscado que no existía
                        DialogResult dr3 = fd.ShowDialog();
                        if (dr3 == DialogResult.OK)
                        {
                            //hacer que vuelva a dejar meter datos
                            while ((fd.textBox2.Text == "" | fd.textBox3.Text == "") & dr3 == DialogResult.OK)
                            {
                                DialogResult drDelay = MessageBox.Show(this, "Debe introducir un nombre y unos apellidos para el dependiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                fd.Dispose();
                                fd = new FormDependientes("Alta");
                                fd.label4.Dispose();
                                fd.textBox4.Dispose();
                                fd.textBox1.Text = daux.NSS; //nss que hemos buscado que no existía
                                dr3 = fd.ShowDialog();
                            }
                            if (dr3 == DialogResult.OK)
                            {
                                String nombre = fd.textBox2.Text;
                                String apellidos = fd.textBox3.Text;
                                sd.DarAltaDependiente(new Dependiente(daux.NSS, nombre, apellidos));
                            }
                        }
                        else
                        {
                            fd.Dispose();
                        }
                    }
                }
            }     
            fi.Dispose();
            
       }

        

        private void búsquedaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("NºSS");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;
            if (dr == DialogResult.OK)
            {
                Dependiente daux = new Dependiente(fi.textBox1.Text, null, null);
                Dependiente d = sd.ObtenerInfoDependiente(daux);
                if (d == null)
                {
                    DialogResult dr2=MessageBox.Show(this, "¿Quieres introducir otro dato?", "No existe un dependiente con ese NºSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr2 == DialogResult.Yes)
                    {
                        fi.Dispose();
                        this.búsquedaToolStripMenuItem.PerformClick();
                    }
                    else
                    {
                        fi.Dispose();
                    }
                }
                else
                {
                    FormDependientes fd = new FormDependientes("Búsqueda");
                    fd.button2.Dispose();
                    fd.button1.Location= new System.Drawing.Point(108, 232); //movemos el boton aceptar



                    fd.textBox1.Text = d.NSS;
                    fd.textBox2.Text = d.Nombre;
                    fd.textBox2.ReadOnly = fd.textBox3.ReadOnly = fd.textBox4.ReadOnly = true;
                    fd.textBox3.Text = d.Apellidos;
                    fd.textBox4.Text = ""+d.Comision;
                    fd.ShowDialog();
                    //mostrar uno con los datos
                }
                
            }
            fi.Dispose();
        }




        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("NºSS");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;
            if (dr == DialogResult.OK)
            {
                Dependiente daux = new Dependiente(fi.textBox1.Text, null, null);
                Dependiente d = sd.ObtenerInfoDependiente(daux);
                if (d == null) //No está
                {
                    DialogResult dr2 = MessageBox.Show(this, "¿Quieres introducir otro?", "No existe un dependiente con ese NºSS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr2 == DialogResult.Yes)
                    {
                        fi.Dispose();
                        this.bajaToolStripMenuItem.PerformClick();
                    }
                    else
                    {
                        fi.Dispose();
                    }
                }
                else //le enseñamos los datos y le damos la opcion de dar de baja
                {
                    fi.Dispose();
                    FormDependientes fd = new FormDependientes("Baja");                    
                    fd.textBox1.Text = d.NSS;
                    fd.textBox1.ReadOnly = true;
                    fd.textBox2.Text = d.Nombre;
                    fd.textBox2.ReadOnly = true;
                    fd.textBox3.Text = d.Apellidos;
                    fd.textBox3.ReadOnly = true;
                    fd.textBox4.Text = d.Comision+"";
                    fd.textBox4.ReadOnly = true;
                    fd.button1.Text = "Dar baja";

                    DialogResult dr3 = fd.ShowDialog();
                    if (dr3 == DialogResult.OK)
                    {
                        DialogResult dr4 = MessageBox.Show(this, "¿Está seguro que desea dar de baja al dependiente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr4 == DialogResult.Yes)
                        {
                            sd.DarBajaDependiente(d);
                            MessageBox.Show(this, "Dependiente eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            fd.Dispose();
                        }
                    }
                    else
                    {
                        fd.Dispose();
                    }
                }
            }
            fi.Dispose();

       }

        //Métodos correspondientes a los botones de Artículos

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("Código");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;

            if (dr == DialogResult.OK)
            {
                while (fi.textBox1.Text == "" & dr == DialogResult.OK)
                {
                    DialogResult drDelay = MessageBox.Show(this, "Debe introducir un código para el nuevo Articulo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fi.Dispose();
                    fi = new FormIntroducir("Código");
                    dr = fi.ShowDialog();
                }
                if (dr == DialogResult.OK)
                {
                    Articulo aaux= new Articulo(fi.textBox1.Text, tipoIva.normal, 0);
                    Articulo a = sa.ObtenerInfoArticulo(aaux);
                    if (a != null)
                    {
                        DialogResult dr2 = MessageBox.Show(this, "¿Quieres introducir otro?", "Ya existe un artículo con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr2 == DialogResult.Yes)
                        {
                            fi.Dispose();
                            this.altaToolStripMenuItem1.PerformClick();
                        }
                        else
                        {
                            fi.Dispose();
                        }
                    }
                    else //le dejaremos crear uno al no haber ninguno aun
                    {
                        fi.Dispose();
                        FormArticulos fa = new FormArticulos("Alta");
                        fa.textBox1.Text = aaux.Codigo; //nss que hemos buscado que no existía
                        DialogResult dr3 = fa.ShowDialog();


                        if (dr3 == DialogResult.OK)
                        {
                            //hacer que vuelva a dejar meter datos
                            while ((fa.textBox2.Text == "" | fa.textBox3.Text == "") & dr3 == DialogResult.OK)
                            {
                                fa.Dispose();
                                fa = new FormArticulos("Alta");
                                fa.textBox1.Text = aaux.Codigo; //codigo que hemos buscado que no existía
                                dr3 = fa.ShowDialog();
                            }
                            if (dr3 == DialogResult.OK)
                            {
                                String descripcion = fa.textBox2.Text;
                                Double precioCoste = Double.Parse(fa.textBox3.Text);                               
                                tipoIva iva;
                                if (fa.radioButton1.Checked)
                                {
                                    iva = tipoIva.normal;
                                }
                                else if(fa.radioButton2.Checked)
                                {
                                    iva = tipoIva.reducido;
                                }
                                else
                                {
                                    iva = tipoIva.superReducido;
                                }
                                Articulo a2 = new Articulo(aaux.Codigo, iva, precioCoste);
                                a2.Descripcion = descripcion;
                                sa.DarAltaArticulo(a2);
                            }
                        

                        }
                        if (dr3 == DialogResult.Abort) //No saldrá hasta que introduzcamos un precio coste valido o seleccionemos cancelar
                        {
                            while (dr3 == DialogResult.Abort)
                            {
                                fa.Dispose();
                                fa = new FormArticulos("Alta");
                                fa.textBox1.Text = aaux.Codigo; //codigo que hemos buscado que no existía
                                dr3 = fa.ShowDialog();
                            }
                        }
                        else
                        {
                            fa.Dispose();
                        }
                    }
                }
            }
            fi.Dispose();

     }

        private void bajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("Código");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;
            if (dr == DialogResult.OK)
            {
                Articulo aaux = new Articulo(fi.textBox1.Text, tipoIva.normal, 0);
                Articulo a = sa.ObtenerInfoArticulo(aaux);
                if (a == null) //No está
                {
                    DialogResult dr2 = MessageBox.Show(this, "¿Quieres introducir otro?", "No existe un articulo con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr2 == DialogResult.Yes)
                    {
                        fi.Dispose();
                        this.bajaToolStripMenuItem1.PerformClick();
                    }
                    else
                    {
                        fi.Dispose();
                    }
                }
                else //le enseñamos los datos y le damos la opcion de dar de baja
                {
                    fi.Dispose();
                    FormArticulos fa = new FormArticulos("Baja");
                    fa.textBox1.Text = a.Codigo;
                    fa.textBox1.ReadOnly = true;
                    fa.textBox2.Text = a.Descripcion;
                    fa.textBox2.ReadOnly = true;
                    fa.label3.Text = "Precio venta";
                    fa.textBox3.Text = a.PrecioVenta+"";
                    fa.textBox3.ReadOnly = true;

                    fa.radioButton1.Enabled = fa.radioButton2.Enabled = fa.radioButton3.Enabled = false;

                    DialogResult dr3 = fa.ShowDialog();

                    if (dr3 == DialogResult.OK)
                    {
                        DialogResult dr4 = MessageBox.Show(this, "¿Está seguro que desea dar de baja el articulo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr4 == DialogResult.Yes)
                        {
                            sa.DarBajaArticulo(a);
                            MessageBox.Show(this, "Articulo eliminado", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            fa.Dispose();
                        }
                    }
                    else
                    {
                        fa.Dispose();
                    }
                }
            }
            fi.Dispose();
        }

        private void búsquedaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("NºSS");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;
            if (dr == DialogResult.OK)
            {
                Articulo aaux = new Articulo(fi.textBox1.Text, tipoIva.normal, 0);
                Articulo a = sa.ObtenerInfoArticulo(aaux);
                if (a == null)
                {
                    DialogResult dr2 = MessageBox.Show(this, "¿Quieres introducir otro dato?", "No existe un articulo con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr2 == DialogResult.Yes)
                    {
                        fi.Dispose();
                        this.búsquedaToolStripMenuItem1.PerformClick();
                    }
                    else
                    {
                        fi.Dispose();
                    }
                }
                else
                {
                    FormArticulos fa = new FormArticulos("Búsqueda");
                    fa.button2.Dispose();
                    fa.button1.Location = new System.Drawing.Point(108, 232); //movemos el boton aceptar



                    fa.textBox1.Text = a.Codigo;
                    fa.textBox2.Text = a.Descripcion;
                    fa.textBox2.ReadOnly = fa.textBox3.ReadOnly = true;
                    fa.textBox3.Text = a.PrecioVenta+"";
                    fa.radioButton1.Enabled = fa.radioButton2.Enabled = fa.radioButton3.Enabled = false;

                    fa.ShowDialog();
                    //mostrar uno con los datos
                }

            }
            fi.Dispose();
        }

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("Código");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;

            if (dr == DialogResult.OK)
            {
                while (fi.textBox1.Text == "" & dr == DialogResult.OK)
                {
                    DialogResult drDelay = MessageBox.Show(this, "Debe introducir un código para la nueva Venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fi.Dispose();
                    fi = new FormIntroducir("Código");
                    dr = fi.ShowDialog();
                }
                if (dr == DialogResult.OK)
                {
                    Venta vaux = new VentaContado(fi.textBox1.Text, null);
                    Venta v = sv.ObtenerInfoVenta(vaux);
                    if (v != null)
                    {
                        DialogResult dr2 = MessageBox.Show(this, "¿Quieres introducir otro?", "Ya existe una venta con ese código", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr2 == DialogResult.Yes)
                        {
                            fi.Dispose();
                            this.altaToolStripMenuItem2.PerformClick();
                        }
                        else
                        {
                            fi.Dispose();
                        }
                    }
                    else //le dejaremos crear una al no haber ninguno aun
                    {
                        fi.Dispose();
                        FormVentas fv = new FormVentas("Alta",sa,sv);
                        fv.textBox1.Text = vaux.Codigo; //nss que hemos buscado que no existía
                        fv.textBox2.Text = vaux.FechaVenta.ToString();
                        DialogResult dr3 = fv.ShowDialog();


                        if (dr3 == DialogResult.OK)
                        {
                            //hacer que vuelva a dejar meter datos
                            while ((fv.textBox3.Text == "" ) & dr3 == DialogResult.OK)
                            {
                                fv.Dispose();
                                fv = new FormVentas("Alta",sa,sv);
                                fv.textBox1.Text = vaux.Codigo; //codigo que hemos buscado que no existía
                                fv.textBox2.Text = vaux.FechaVenta.ToString();
                                dr3 = fv.ShowDialog();
                            }
                            if (dr3 == DialogResult.OK)
                            {
                                //Aquí comprobaremos que el dependiente ya existe y que hemos añadido al menos un articulo a la venta, tranqui que ya lo hace papi
                                Dependiente daux = new Dependiente(fv.textBox3.Text, null, null);
                                Dependiente d = sd.ObtenerInfoDependiente(daux);
                                if (d != null)
                                {
                                    sd.AnadirVentaADependiente(v, d);
                                    sv.DarAltaVenta(v);
                                    
                                }


                                
                            }


                        }

                        else
                        {
                            fv.Dispose();
                        }
                    }
                }
            }
            fi.Dispose();
        }
    }

}
