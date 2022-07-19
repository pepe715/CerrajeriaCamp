using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CerrajeriaCamp
{
    public partial class PanelConexion : Form
    {

        MessageBoxForm messageBoxForm = new MessageBoxForm();


        public PanelConexion()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCCCBD_Click(object sender, EventArgs e)
        {
            Globales.conexionElegida = txtCCCBD.Text;

            TextWriter guardado = new StreamWriter("servidor.txt");
            guardado.WriteLine(Globales.conexionElegida);
            guardado.Close();


            Globales.txtMessageBox = "Conexion establecida";

            messageBoxForm.Show();

            this.Close();


        }
    }
}
