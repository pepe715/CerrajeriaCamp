
namespace CerrajeriaCamp
{
    partial class MessageBoxForm
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnMessageBoxAceptar = new System.Windows.Forms.Button();
            this.lblMessageBoxTexto = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnMessageBoxAceptar);
            this.panel1.Controls.Add(this.lblMessageBoxTexto);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 235);
            this.panel1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Orange;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(324, 183);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(137, 30);
            this.btnCancelar.TabIndex = 61;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnMessageBoxAceptar
            // 
            this.btnMessageBoxAceptar.BackColor = System.Drawing.Color.Orange;
            this.btnMessageBoxAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMessageBoxAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnMessageBoxAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnMessageBoxAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessageBoxAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessageBoxAceptar.ForeColor = System.Drawing.Color.White;
            this.btnMessageBoxAceptar.Location = new System.Drawing.Point(181, 183);
            this.btnMessageBoxAceptar.Name = "btnMessageBoxAceptar";
            this.btnMessageBoxAceptar.Size = new System.Drawing.Size(137, 30);
            this.btnMessageBoxAceptar.TabIndex = 60;
            this.btnMessageBoxAceptar.Text = "Aceptar";
            this.btnMessageBoxAceptar.UseVisualStyleBackColor = false;
            this.btnMessageBoxAceptar.Click += new System.EventHandler(this.btnResgitrarUsuarioRegistro_Click);
            // 
            // lblMessageBoxTexto
            // 
            this.lblMessageBoxTexto.AutoSize = true;
            this.lblMessageBoxTexto.Font = new System.Drawing.Font("Bell MT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageBoxTexto.ForeColor = System.Drawing.Color.Orange;
            this.lblMessageBoxTexto.Location = new System.Drawing.Point(3, 57);
            this.lblMessageBoxTexto.Name = "lblMessageBoxTexto";
            this.lblMessageBoxTexto.Size = new System.Drawing.Size(142, 25);
            this.lblMessageBoxTexto.TabIndex = 0;
            this.lblMessageBoxTexto.Text = "Texto Definido";
            // 
            // MessageBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(516, 263);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBoxForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBoxForm";
            this.Load += new System.EventHandler(this.MessageBoxForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblMessageBoxTexto;
        public System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnMessageBoxAceptar;
    }
}