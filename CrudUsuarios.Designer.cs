
namespace CerrajeriaCamp
{
    partial class CrudUsuarios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrudUsuarios));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIDCrud = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.btnModificarUsuario = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiarCampos = new System.Windows.Forms.ToolStripButton();
            this.txtCorreoCrud = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEdadCrud = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCodPostalCrud = new System.Windows.Forms.TextBox();
            this.txtDNICrud = new System.Windows.Forms.TextBox();
            this.txtTelefonoCrud = new System.Windows.Forms.TextBox();
            this.txtRepContrasenaCrud = new System.Windows.Forms.TextBox();
            this.txtContrasenaCrud = new System.Windows.Forms.TextBox();
            this.txtUsuarioCrud = new System.Windows.Forms.TextBox();
            this.txtApellido2Crud = new System.Windows.Forms.TextBox();
            this.txtApellido1Crud = new System.Windows.Forms.TextBox();
            this.txtNombreCrud = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuarioLoguin = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.volverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customInstaller1 = new MySql.Data.MySqlClient.CustomInstaller();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.txtIDCrud);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Controls.Add(this.txtCorreoCrud);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtEdadCrud);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtCodPostalCrud);
            this.panel1.Controls.Add(this.txtDNICrud);
            this.panel1.Controls.Add(this.txtTelefonoCrud);
            this.panel1.Controls.Add(this.txtRepContrasenaCrud);
            this.panel1.Controls.Add(this.txtContrasenaCrud);
            this.panel1.Controls.Add(this.txtUsuarioCrud);
            this.panel1.Controls.Add(this.txtApellido2Crud);
            this.panel1.Controls.Add(this.txtApellido1Crud);
            this.panel1.Controls.Add(this.txtNombreCrud);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblUsuarioLoguin);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 669);
            this.panel1.TabIndex = 0;
            // 
            // txtIDCrud
            // 
            this.txtIDCrud.Location = new System.Drawing.Point(268, 33);
            this.txtIDCrud.Name = "txtIDCrud";
            this.txtIDCrud.Size = new System.Drawing.Size(251, 20);
            this.txtIDCrud.TabIndex = 109;
            this.txtIDCrud.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(60, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 25);
            this.label2.TabIndex = 108;
            this.label2.Text = "ID:";
            this.label2.Visible = false;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.Color.Orange;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnModificarUsuario,
            this.btnLimpiarCampos});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 644);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(1125, 25);
            this.bindingNavigator1.TabIndex = 107;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnModificarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnModificarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarUsuario.Image")));
            this.btnModificarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(62, 22);
            this.btnModificarUsuario.Text = "Modificar";
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLimpiarCampos.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiarCampos.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarCampos.Image")));
            this.btnLimpiarCampos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(98, 22);
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // txtCorreoCrud
            // 
            this.txtCorreoCrud.Location = new System.Drawing.Point(268, 599);
            this.txtCorreoCrud.Name = "txtCorreoCrud";
            this.txtCorreoCrud.Size = new System.Drawing.Size(251, 20);
            this.txtCorreoCrud.TabIndex = 105;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Orange;
            this.label12.Location = new System.Drawing.Point(60, 594);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 25);
            this.label12.TabIndex = 104;
            this.label12.Text = "Correo:";
            // 
            // txtEdadCrud
            // 
            this.txtEdadCrud.Location = new System.Drawing.Point(268, 236);
            this.txtEdadCrud.Name = "txtEdadCrud";
            this.txtEdadCrud.Size = new System.Drawing.Size(251, 20);
            this.txtEdadCrud.TabIndex = 103;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(60, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 25);
            this.label10.TabIndex = 102;
            this.label10.Text = "Edad:";
            // 
            // txtCodPostalCrud
            // 
            this.txtCodPostalCrud.Location = new System.Drawing.Point(268, 547);
            this.txtCodPostalCrud.Name = "txtCodPostalCrud";
            this.txtCodPostalCrud.Size = new System.Drawing.Size(251, 20);
            this.txtCodPostalCrud.TabIndex = 101;
            // 
            // txtDNICrud
            // 
            this.txtDNICrud.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDNICrud.Location = new System.Drawing.Point(268, 487);
            this.txtDNICrud.Name = "txtDNICrud";
            this.txtDNICrud.Size = new System.Drawing.Size(251, 20);
            this.txtDNICrud.TabIndex = 100;
            // 
            // txtTelefonoCrud
            // 
            this.txtTelefonoCrud.Location = new System.Drawing.Point(268, 437);
            this.txtTelefonoCrud.Name = "txtTelefonoCrud";
            this.txtTelefonoCrud.Size = new System.Drawing.Size(251, 20);
            this.txtTelefonoCrud.TabIndex = 99;
            // 
            // txtRepContrasenaCrud
            // 
            this.txtRepContrasenaCrud.Location = new System.Drawing.Point(268, 384);
            this.txtRepContrasenaCrud.Name = "txtRepContrasenaCrud";
            this.txtRepContrasenaCrud.Size = new System.Drawing.Size(251, 20);
            this.txtRepContrasenaCrud.TabIndex = 98;
            // 
            // txtContrasenaCrud
            // 
            this.txtContrasenaCrud.Location = new System.Drawing.Point(268, 335);
            this.txtContrasenaCrud.Name = "txtContrasenaCrud";
            this.txtContrasenaCrud.Size = new System.Drawing.Size(251, 20);
            this.txtContrasenaCrud.TabIndex = 97;
            // 
            // txtUsuarioCrud
            // 
            this.txtUsuarioCrud.Location = new System.Drawing.Point(268, 284);
            this.txtUsuarioCrud.Name = "txtUsuarioCrud";
            this.txtUsuarioCrud.Size = new System.Drawing.Size(251, 20);
            this.txtUsuarioCrud.TabIndex = 96;
            // 
            // txtApellido2Crud
            // 
            this.txtApellido2Crud.Location = new System.Drawing.Point(268, 186);
            this.txtApellido2Crud.Name = "txtApellido2Crud";
            this.txtApellido2Crud.Size = new System.Drawing.Size(251, 20);
            this.txtApellido2Crud.TabIndex = 95;
            // 
            // txtApellido1Crud
            // 
            this.txtApellido1Crud.Location = new System.Drawing.Point(268, 137);
            this.txtApellido1Crud.Name = "txtApellido1Crud";
            this.txtApellido1Crud.Size = new System.Drawing.Size(251, 20);
            this.txtApellido1Crud.TabIndex = 94;
            // 
            // txtNombreCrud
            // 
            this.txtNombreCrud.Location = new System.Drawing.Point(268, 82);
            this.txtNombreCrud.Name = "txtNombreCrud";
            this.txtNombreCrud.Size = new System.Drawing.Size(251, 20);
            this.txtNombreCrud.TabIndex = 93;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(60, 542);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 25);
            this.label9.TabIndex = 92;
            this.label9.Text = "Codigo Postal:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Orange;
            this.label8.Location = new System.Drawing.Point(65, 482);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 25);
            this.label8.TabIndex = 91;
            this.label8.Text = "DNI:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Orange;
            this.label7.Location = new System.Drawing.Point(60, 432);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 25);
            this.label7.TabIndex = 90;
            this.label7.Text = "Telefono:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(60, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 25);
            this.label6.TabIndex = 89;
            this.label6.Text = "Repite contraseña:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Orange;
            this.label5.Location = new System.Drawing.Point(60, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 25);
            this.label5.TabIndex = 88;
            this.label5.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Orange;
            this.label4.Location = new System.Drawing.Point(60, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 25);
            this.label4.TabIndex = 87;
            this.label4.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Orange;
            this.label3.Location = new System.Drawing.Point(60, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 25);
            this.label3.TabIndex = 86;
            this.label3.Text = "Segundo Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(60, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 85;
            this.label1.Text = "Primer Apellido:";
            // 
            // lblUsuarioLoguin
            // 
            this.lblUsuarioLoguin.AutoSize = true;
            this.lblUsuarioLoguin.BackColor = System.Drawing.Color.Black;
            this.lblUsuarioLoguin.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioLoguin.ForeColor = System.Drawing.Color.Orange;
            this.lblUsuarioLoguin.Location = new System.Drawing.Point(60, 77);
            this.lblUsuarioLoguin.Name = "lblUsuarioLoguin";
            this.lblUsuarioLoguin.Size = new System.Drawing.Size(92, 25);
            this.lblUsuarioLoguin.TabIndex = 84;
            this.lblUsuarioLoguin.Text = "Nombre:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Orange;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1125, 24);
            this.menuStrip1.TabIndex = 106;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // volverToolStripMenuItem
            // 
            this.volverToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.volverToolStripMenuItem.BackColor = System.Drawing.Color.Orange;
            this.volverToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.volverToolStripMenuItem.Name = "volverToolStripMenuItem";
            this.volverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.volverToolStripMenuItem.Text = "Volver";
            this.volverToolStripMenuItem.Click += new System.EventHandler(this.volverToolStripMenuItem_Click);
            // 
            // CrudUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(1150, 694);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Orange;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CrudUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrudUsuarios";
            this.Load += new System.EventHandler(this.CrudUsuarios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCorreoCrud;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEdadCrud;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCodPostalCrud;
        private System.Windows.Forms.TextBox txtDNICrud;
        private System.Windows.Forms.TextBox txtTelefonoCrud;
        private System.Windows.Forms.TextBox txtRepContrasenaCrud;
        private System.Windows.Forms.TextBox txtContrasenaCrud;
        private System.Windows.Forms.TextBox txtUsuarioCrud;
        private System.Windows.Forms.TextBox txtApellido2Crud;
        private System.Windows.Forms.TextBox txtApellido1Crud;
        private System.Windows.Forms.TextBox txtNombreCrud;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuarioLoguin;
        private MySql.Data.MySqlClient.CustomInstaller customInstaller1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem volverToolStripMenuItem;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        public System.Windows.Forms.ToolStripButton btnModificarUsuario;
        private System.Windows.Forms.ToolStripButton btnLimpiarCampos;
        private System.Windows.Forms.TextBox txtIDCrud;
        private System.Windows.Forms.Label label2;
    }
}