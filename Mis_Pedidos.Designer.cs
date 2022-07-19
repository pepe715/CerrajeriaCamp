
namespace CerrajeriaCamp
{
    partial class Mis_Pedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mis_Pedidos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCrearFactura = new System.Windows.Forms.Button();
            this.dgbPedidosVentana = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCrearFacturaReja = new System.Windows.Forms.Button();
            this.dgbMisPedidos = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCrearFacturaCerradura = new System.Windows.Forms.Button();
            this.dgbMisCerraduras = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.volverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbPedidosVentana)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbMisPedidos)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbMisCerraduras)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 669);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CerrajeriaCamp.Properties.Resources.Logo;
            this.pictureBox3.Location = new System.Drawing.Point(900, 96);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(223, 434);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 61;
            this.pictureBox3.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(15, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(879, 632);
            this.tabControl1.TabIndex = 60;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Orange;
            this.tabPage1.Controls.Add(this.btnCrearFactura);
            this.tabPage1.Controls.Add(this.dgbPedidosVentana);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(871, 606);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ventanas";
            // 
            // btnCrearFactura
            // 
            this.btnCrearFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCrearFactura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearFactura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCrearFactura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCrearFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearFactura.ForeColor = System.Drawing.Color.Black;
            this.btnCrearFactura.Location = new System.Drawing.Point(340, 535);
            this.btnCrearFactura.Name = "btnCrearFactura";
            this.btnCrearFactura.Size = new System.Drawing.Size(167, 31);
            this.btnCrearFactura.TabIndex = 55;
            this.btnCrearFactura.Text = "Crear factura";
            this.btnCrearFactura.UseVisualStyleBackColor = false;
            this.btnCrearFactura.Click += new System.EventHandler(this.btnCrearFactura_Click);
            // 
            // dgbPedidosVentana
            // 
            this.dgbPedidosVentana.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgbPedidosVentana.BackgroundColor = System.Drawing.Color.White;
            this.dgbPedidosVentana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbPedidosVentana.Location = new System.Drawing.Point(21, 111);
            this.dgbPedidosVentana.Name = "dgbPedidosVentana";
            this.dgbPedidosVentana.ReadOnly = true;
            this.dgbPedidosVentana.Size = new System.Drawing.Size(819, 382);
            this.dgbPedidosVentana.TabIndex = 54;
            this.dgbPedidosVentana.Click += new System.EventHandler(this.dgbPedidosVentana_Click);
            this.dgbPedidosVentana.DoubleClick += new System.EventHandler(this.dgbPedidosVentana_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Orange;
            this.tabPage2.Controls.Add(this.btnCrearFacturaReja);
            this.tabPage2.Controls.Add(this.dgbMisPedidos);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(871, 606);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rejas";
            // 
            // btnCrearFacturaReja
            // 
            this.btnCrearFacturaReja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCrearFacturaReja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearFacturaReja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCrearFacturaReja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCrearFacturaReja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearFacturaReja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearFacturaReja.ForeColor = System.Drawing.Color.Black;
            this.btnCrearFacturaReja.Location = new System.Drawing.Point(352, 539);
            this.btnCrearFacturaReja.Name = "btnCrearFacturaReja";
            this.btnCrearFacturaReja.Size = new System.Drawing.Size(167, 31);
            this.btnCrearFacturaReja.TabIndex = 56;
            this.btnCrearFacturaReja.Text = "Crear factura";
            this.btnCrearFacturaReja.UseVisualStyleBackColor = false;
            this.btnCrearFacturaReja.Click += new System.EventHandler(this.btnCrearFacturaReja_Click);
            // 
            // dgbMisPedidos
            // 
            this.dgbMisPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgbMisPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgbMisPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbMisPedidos.Location = new System.Drawing.Point(21, 111);
            this.dgbMisPedidos.Name = "dgbMisPedidos";
            this.dgbMisPedidos.ReadOnly = true;
            this.dgbMisPedidos.Size = new System.Drawing.Size(819, 382);
            this.dgbMisPedidos.TabIndex = 52;
            this.dgbMisPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgbMisPedidos_CellContentClick);
            this.dgbMisPedidos.Click += new System.EventHandler(this.dgbMisPedidos_Click);
            this.dgbMisPedidos.DoubleClick += new System.EventHandler(this.dgbMisPedidos_DoubleClick);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Orange;
            this.tabPage3.Controls.Add(this.btnCrearFacturaCerradura);
            this.tabPage3.Controls.Add(this.dgbMisCerraduras);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(871, 606);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cerraduras";
            // 
            // btnCrearFacturaCerradura
            // 
            this.btnCrearFacturaCerradura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCrearFacturaCerradura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearFacturaCerradura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCrearFacturaCerradura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCrearFacturaCerradura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearFacturaCerradura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearFacturaCerradura.ForeColor = System.Drawing.Color.Black;
            this.btnCrearFacturaCerradura.Location = new System.Drawing.Point(342, 539);
            this.btnCrearFacturaCerradura.Name = "btnCrearFacturaCerradura";
            this.btnCrearFacturaCerradura.Size = new System.Drawing.Size(167, 31);
            this.btnCrearFacturaCerradura.TabIndex = 56;
            this.btnCrearFacturaCerradura.Text = "Crear factura";
            this.btnCrearFacturaCerradura.UseVisualStyleBackColor = false;
            this.btnCrearFacturaCerradura.Click += new System.EventHandler(this.btnCrearFacturaCerradura_Click);
            // 
            // dgbMisCerraduras
            // 
            this.dgbMisCerraduras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgbMisCerraduras.BackgroundColor = System.Drawing.Color.White;
            this.dgbMisCerraduras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbMisCerraduras.Location = new System.Drawing.Point(21, 111);
            this.dgbMisCerraduras.Name = "dgbMisCerraduras";
            this.dgbMisCerraduras.ReadOnly = true;
            this.dgbMisCerraduras.Size = new System.Drawing.Size(819, 382);
            this.dgbMisCerraduras.TabIndex = 52;
            this.dgbMisCerraduras.Click += new System.EventHandler(this.dgbMisCerraduras_Click);
            this.dgbMisCerraduras.DoubleClick += new System.EventHandler(this.dgbMisCerraduras_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Orange;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1125, 24);
            this.menuStrip1.TabIndex = 51;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // volverToolStripMenuItem
            // 
            this.volverToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.volverToolStripMenuItem.Name = "volverToolStripMenuItem";
            this.volverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.volverToolStripMenuItem.Text = "Volver";
            this.volverToolStripMenuItem.Click += new System.EventHandler(this.volverToolStripMenuItem_Click);
            // 
            // Mis_Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(1150, 694);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mis_Pedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mis_Pedidos";
            this.Load += new System.EventHandler(this.Mis_Pedidos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgbPedidosVentana)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgbMisPedidos)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgbMisCerraduras)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem volverToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgbMisPedidos;
        private System.Windows.Forms.DataGridView dgbPedidosVentana;
        private System.Windows.Forms.DataGridView dgbMisCerraduras;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnCrearFactura;
        private System.Windows.Forms.Button btnCrearFacturaReja;
        private System.Windows.Forms.Button btnCrearFacturaCerradura;
    }
}