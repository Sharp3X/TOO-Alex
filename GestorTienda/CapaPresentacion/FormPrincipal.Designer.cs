namespace CapaPresentacion
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dependientersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.búsquedaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.búsquedaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.búsquedaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dependientersToolStripMenuItem,
            this.articulosToolStripMenuItem,
            this.ventasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dependientersToolStripMenuItem
            // 
            this.dependientersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem,
            this.bajaToolStripMenuItem,
            this.búsquedaToolStripMenuItem});
            this.dependientersToolStripMenuItem.Name = "dependientersToolStripMenuItem";
            this.dependientersToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.dependientersToolStripMenuItem.Text = "Dependientes";
            // 
            // altaToolStripMenuItem
            // 
            this.altaToolStripMenuItem.Name = "altaToolStripMenuItem";
            this.altaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.altaToolStripMenuItem.Text = "Alta";
            this.altaToolStripMenuItem.Click += new System.EventHandler(this.altaToolStripMenuItem_Click);
            // 
            // bajaToolStripMenuItem
            // 
            this.bajaToolStripMenuItem.Name = "bajaToolStripMenuItem";
            this.bajaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bajaToolStripMenuItem.Text = "Baja";
            // 
            // búsquedaToolStripMenuItem
            // 
            this.búsquedaToolStripMenuItem.Name = "búsquedaToolStripMenuItem";
            this.búsquedaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.búsquedaToolStripMenuItem.Text = "Búsqueda";
            this.búsquedaToolStripMenuItem.Click += new System.EventHandler(this.búsquedaToolStripMenuItem_Click);
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem1,
            this.bajaToolStripMenuItem1,
            this.búsquedaToolStripMenuItem1});
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.articulosToolStripMenuItem.Text = "Artículos";
            // 
            // altaToolStripMenuItem1
            // 
            this.altaToolStripMenuItem1.Name = "altaToolStripMenuItem1";
            this.altaToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.altaToolStripMenuItem1.Text = "Alta";
            // 
            // bajaToolStripMenuItem1
            // 
            this.bajaToolStripMenuItem1.Name = "bajaToolStripMenuItem1";
            this.bajaToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.bajaToolStripMenuItem1.Text = "Baja";
            // 
            // búsquedaToolStripMenuItem1
            // 
            this.búsquedaToolStripMenuItem1.Name = "búsquedaToolStripMenuItem1";
            this.búsquedaToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.búsquedaToolStripMenuItem1.Text = "Búsqueda";
            this.búsquedaToolStripMenuItem1.Click += new System.EventHandler(this.búsquedaToolStripMenuItem1_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem2,
            this.bajaToolStripMenuItem2,
            this.búsquedaToolStripMenuItem2});
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ventasToolStripMenuItem.Text = "Ventas";
            // 
            // altaToolStripMenuItem2
            // 
            this.altaToolStripMenuItem2.Name = "altaToolStripMenuItem2";
            this.altaToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.altaToolStripMenuItem2.Text = "Alta";
            // 
            // bajaToolStripMenuItem2
            // 
            this.bajaToolStripMenuItem2.Name = "bajaToolStripMenuItem2";
            this.bajaToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.bajaToolStripMenuItem2.Text = "Baja";
            // 
            // búsquedaToolStripMenuItem2
            // 
            this.búsquedaToolStripMenuItem2.Name = "búsquedaToolStripMenuItem2";
            this.búsquedaToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.búsquedaToolStripMenuItem2.Text = "Búsqueda";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Gestión de ventas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dependientersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem búsquedaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem búsquedaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem búsquedaToolStripMenuItem2;
    }
}

