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
    public partial class FormDataGridViewArt : Form
    {
        private List<Articulo> listado;



        public FormDataGridViewArt()
        {
            InitializeComponent();
        }

        public FormDataGridViewArt(List<Articulo> la)
        {
            InitializeComponent();
            this.listado = la;
            this.bindingSource1.DataSource = this.listado;
            this.dataGridView1.DataSource = this.bindingSource1;
        }


    }
}
