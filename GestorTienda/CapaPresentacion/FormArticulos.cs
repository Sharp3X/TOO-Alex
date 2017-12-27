using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormArticulos : Form
    {
        public FormArticulos()
        {
            InitializeComponent();

        }

        public FormArticulos(String cadena)
        {
            InitializeComponent();
            this.Text = cadena + this.Text;
            this.radioButton1.Checked=true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //valida
            if (validacion())
            {
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



        private bool validacion()
        {
            Double precioCoste;
            if (!Double.TryParse(this.textBox3.Text, out precioCoste) | precioCoste <= 0)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private void FormArticulos_Load(object sender, EventArgs e)
        {

        }
    }
}
