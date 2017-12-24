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
    public partial class FormAniadirLinea : Form
    {
        public FormAniadirLinea()
        {
            InitializeComponent();
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
                MessageBox.Show(this, "Debe introducir una cantidad/codigo de articulo validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool validacion()
        {
            int cantidad;
            if (!int.TryParse(this.textBox2.Text, out cantidad) | (cantidad <= 0) | this.textBox1.Text=="" | this.textBox2.Text=="")
            {
                return false;

            }
            else
            {
                return true;
            }
        }
    }
}
