
namespace CerrajeriaCamp
{
    partial class PanelConexion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCCCBD = new System.Windows.Forms.Button();
            this.txtCCCBD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuarioLoguin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnCCCBD);
            this.panel1.Controls.Add(this.txtCCCBD);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblUsuarioLoguin);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 366);
            this.panel1.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Orange;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(736, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(40, 27);
            this.btnSalir.TabIndex = 55;
            this.btnSalir.Text = "X";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCCCBD
            // 
            this.btnCCCBD.BackColor = System.Drawing.Color.Orange;
            this.btnCCCBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCCCBD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCCCBD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCCCBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCCCBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCCBD.ForeColor = System.Drawing.Color.Black;
            this.btnCCCBD.Location = new System.Drawing.Point(199, 288);
            this.btnCCCBD.Name = "btnCCCBD";
            this.btnCCCBD.Size = new System.Drawing.Size(342, 31);
            this.btnCCCBD.TabIndex = 50;
            this.btnCCCBD.Text = "Crear cadena de conexion";
            this.btnCCCBD.UseVisualStyleBackColor = false;
            this.btnCCCBD.Click += new System.EventHandler(this.btnCCCBD_Click);
            // 
            // txtCCCBD
            // 
            this.txtCCCBD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCCCBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCCBD.Location = new System.Drawing.Point(54, 160);
            this.txtCCCBD.Multiline = true;
            this.txtCCCBD.Name = "txtCCCBD";
            this.txtCCCBD.Size = new System.Drawing.Size(649, 81);
            this.txtCCCBD.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(50, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(653, 19);
            this.label2.TabIndex = 46;
            this.label2.Text = "SERVER=XXX.X.X.X;PORT=XXXX;DATABASE=XXX;UID=XXX;PASSWORDS=XXX;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(50, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 19);
            this.label1.TabIndex = 45;
            this.label1.Text = "Para acceder a la base de datos debes indicarlo de esta manera:";
            // 
            // lblUsuarioLoguin
            // 
            this.lblUsuarioLoguin.AutoSize = true;
            this.lblUsuarioLoguin.BackColor = System.Drawing.Color.Black;
            this.lblUsuarioLoguin.Font = new System.Drawing.Font("Bell MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioLoguin.ForeColor = System.Drawing.Color.Orange;
            this.lblUsuarioLoguin.Location = new System.Drawing.Point(7, 11);
            this.lblUsuarioLoguin.Name = "lblUsuarioLoguin";
            this.lblUsuarioLoguin.Size = new System.Drawing.Size(500, 29);
            this.lblUsuarioLoguin.TabIndex = 44;
            this.lblUsuarioLoguin.Text = "Ingrese cadena de conexion a la base de datos:";
            // 
            // PanelConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(800, 390);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PanelConexion";
            this.Text = "PanelConexion";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUsuarioLoguin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCCCBD;
        private System.Windows.Forms.Button btnCCCBD;
        private System.Windows.Forms.Button btnSalir;
    }
}