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

namespace CapaPresentacion
{
    public partial class FormDataGridView : Form
    {
        private List<Articulo> listado;



        public FormDataGridView()
        {
            InitializeComponent();
        }

        public FormDataGridView(List<Articulo> la)
        {
            InitializeComponent();
            this.listado = la;
            this.bindingSource1.DataSource = this.listado;
            this.dataGridView1.DataSource = this.bindingSource1;
        }


    }
}
