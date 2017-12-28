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
    public partial class FormBajaVentas : Form
    {
        public FormBajaVentas()
        {
            InitializeComponent();
        }

        public FormBajaVentas(String cadena) //Reutilizo para búsqueda
        {
            InitializeComponent();
            this.button1.Text = "Aceptar";
            this.button2.Dispose();
            this.button1.Location = new System.Drawing.Point(132, 382);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
