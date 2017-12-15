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
    public partial class FormIntroducir : Form
    {
        public FormIntroducir()
        {
            InitializeComponent();
        }

        public FormIntroducir(String texto)
        {
            InitializeComponent();
            this.label1.Text = texto;
            this.Text += texto.ToLower();
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            
        }
    }
}
