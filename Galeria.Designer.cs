
namespace CerrajeriaCamp
{
    partial class Galeria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Galeria));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDetenerGaleria = new System.Windows.Forms.Button();
            this.btnArrancarGaleria = new System.Windows.Forms.Button();
            this.pbGaleria = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.volverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotacionTimer = new System.Windows.Forms.Timer(this.components);
            this.lblUsuarioLoguin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGaleria)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblUsuarioLoguin);
            this.panel1.Controls.Add(this.btnDetenerGaleria);
            this.panel1.Controls.Add(this.btnArrancarGaleria);
            this.panel1.Controls.Add(this.pbGaleria);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1125, 669);
            this.panel1.TabIndex = 0;
            // 
            // btnDetenerGaleria
            // 
            this.btnDetenerGaleria.BackColor = System.Drawing.Color.Orange;
            this.btnDetenerGaleria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetenerGaleria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDetenerGaleria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDetenerGaleria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetenerGaleria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetenerGaleria.ForeColor = System.Drawing.Color.White;
            this.btnDetenerGaleria.Location = new System.Drawing.Point(811, 565);
            this.btnDetenerGaleria.Name = "btnDetenerGaleria";
            this.btnDetenerGaleria.Size = new System.Drawing.Size(169, 31);
            this.btnDetenerGaleria.TabIndex = 51;
            this.btnDetenerGaleria.Text = "Detener";
            this.btnDetenerGaleria.UseVisualStyleBackColor = false;
            this.btnDetenerGaleria.Click += new System.EventHandler(this.btnDetenerGaleria_Click);
            // 
            // btnArrancarGaleria
            // 
            this.btnArrancarGaleria.BackColor = System.Drawing.Color.Orange;
            this.btnArrancarGaleria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArrancarGaleria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnArrancarGaleria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnArrancarGaleria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArrancarGaleria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArrancarGaleria.ForeColor = System.Drawing.Color.White;
            this.btnArrancarGaleria.Location = new System.Drawing.Point(169, 565);
            this.btnArrancarGaleria.Name = "btnArrancarGaleria";
            this.btnArrancarGaleria.Size = new System.Drawing.Size(169, 31);
            this.btnArrancarGaleria.TabIndex = 50;
            this.btnArrancarGaleria.Text = "Arrancar";
            this.btnArrancarGaleria.UseVisualStyleBackColor = false;
            this.btnArrancarGaleria.Click += new System.EventHandler(this.btnArrancarGaleria_Click);
            // 
            // pbGaleria
            // 
            this.pbGaleria.BackColor = System.Drawing.Color.Orange;
            this.pbGaleria.Location = new System.Drawing.Point(169, 134);
            this.pbGaleria.Name = "pbGaleria";
            this.pbGaleria.Size = new System.Drawing.Size(811, 377);
            this.pbGaleria.TabIndex = 0;
            this.pbGaleria.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Orange;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.volverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1125, 24);
            this.menuStrip1.TabIndex = 1;
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
            // rotacionTimer
            // 
            this.rotacionTimer.Interval = 900;
            this.rotacionTimer.Tick += new System.EventHandler(this.rotacionTimer_Tick);
            // 
            // lblUsuarioLoguin
            // 
            this.lblUsuarioLoguin.AutoSize = true;
            this.lblUsuarioLoguin.BackColor = System.Drawing.Color.Black;
            this.lblUsuarioLoguin.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioLoguin.ForeColor = System.Drawing.Color.Orange;
            this.lblUsuarioLoguin.Location = new System.Drawing.Point(164, 95);
            this.lblUsuarioLoguin.Name = "lblUsuarioLoguin";
            this.lblUsuarioLoguin.Size = new System.Drawing.Size(485, 25);
            this.lblUsuarioLoguin.TabIndex = 52;
            this.lblUsuarioLoguin.Text = "Aqui puedes ver una serie de trabajos ya realizados.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Bell MT", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(19, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 37);
            this.label1.TabIndex = 53;
            this.label1.Text = "Galería";
            // 
            // Galeria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(1150, 694);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Galeria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Galeria";
            this.Load += new System.EventHandler(this.Galeria_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGaleria)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbGaleria;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem volverToolStripMenuItem;
        private System.Windows.Forms.Timer rotacionTimer;
        private System.Windows.Forms.Button btnDetenerGaleria;
        private System.Windows.Forms.Button btnArrancarGaleria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsuarioLoguin;
    }
}