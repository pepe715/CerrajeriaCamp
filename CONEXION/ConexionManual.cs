using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace ConexionEncriptada.CONEXION
{
    public partial class ConexionManual : Form
    {
        //Libreria cifrar y descifrar datos
        private LIBRERIA.AES aes = new LIBRERIA.AES();

      

        public ConexionManual()
        {
            InitializeComponent();
        }
        public void SavetoXML(Object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }
        string dbcnString;


        //Desencripta la cadena del xml para poder establecer la conexion correctamente.
        public void ReadfromXML()
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[0].Value;
                txtCnString.Text = (aes.Decrypt(dbcnString, LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256")));
            }
            catch (System.Security.Cryptography.CryptographicException ex)
            {

            }
        }

        private void ConexionManual_Load(object sender, EventArgs e)
        {
            ReadfromXML();
        }


        //Guarda la nueva cadena de conexion encriptada. 
        private void btnGuadar_Click_1(object sender, EventArgs e)
        {
            SavetoXML(aes.Encrypt(txtCnString.Text, LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256")));
            MessageBox.Show("Servidor actualizado, Reiniciando aplicacion.");


            Application.Exit();
        }

        //Cierra la pestaña de conexion.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
