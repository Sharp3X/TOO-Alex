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
        ServicioArticulo sa;
        ServicioDependiente sd;

        public FormPrincipal()
        {
            InitializeComponent();
            this.sa = new ServicioArticulo();
            this.sd = new ServicioDependiente();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("NºSS");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;
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
                    FormsDependientes fd = new FormsDependientes();
                    fd.label4.Dispose();
                    fd.textBox4.Dispose();
                    String nss = daux.NSS;
                    fd.textBox1.Text = nss; //nss que hemos buscado que no existía
                    DialogResult dr3 = fd.ShowDialog();
                    if (dr3 == DialogResult.OK)
                    {
                        //hacer que vuelva a dejar meter datos
                        while(fd.textBox2.Text==""| fd.textBox3.Text == "")
                        {
                            DialogResult drDelay=MessageBox.Show(this, "Debe introducir un nombre y unos apellidos para el dependiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fd.Dispose();
                            fd = new FormsDependientes();
                            fd.label4.Dispose();
                            fd.textBox4.Dispose();
                            fd.textBox1.Text = nss; //nss que hemos buscado que no existía
                            dr3 = fd.ShowDialog();
                        }
                        String nombre = fd.textBox2.Text;
                        String apellidos = fd.textBox3.Text;
                        sd.DarAltaDependiente(new Dependiente(nss, nombre, apellidos));
                    }
                    else
                    {
                        fd.Dispose();
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
                    FormsDependientes fd = new FormsDependientes();
                    fd.button2.Dispose();
                    fd.button1.Location= new System.Drawing.Point(108, 232); //movemos el boton aceptar



                    fd.Text = "Búsqueda" + fd.Text;
                    fd.textBox1.Text = d.NSS;
                    fd.textBox2.Text = d.Nombre;
                    fd.textBox3.Text = d.Apellidos;
                    fd.textBox4.Text = ""+d.Comision;
                    fd.ShowDialog();
                    //mostrar uno con los datos
                }
                
            }
            fi.Dispose();
        }

        private void búsquedaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("Código");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;
            fi.Dispose();
        }

        private void búsquedaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormIntroducir fi = new FormIntroducir("Código");
            fi.ShowDialog();
            DialogResult dr = fi.DialogResult;
            fi.Dispose();
        }

    }
}
