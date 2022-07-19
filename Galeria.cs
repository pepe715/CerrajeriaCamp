using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CerrajeriaCamp
{
    public partial class Galeria : Form
    {

        private ConexionEncriptada.LIBRERIA.AES aes = new ConexionEncriptada.LIBRERIA.AES();
        private static string nombreServidor = "";
        private string cadenaConexion;
        private SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        MessageBoxForm messageBoxForm = new MessageBoxForm();

        String imagenMostrada;
        String rutaImagen;


        int numeroDeImagenes = 1;

        int contador =1; 

        public Galeria()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);
        }

        //Cierra el form de galeria y te muestra el form principal
        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrincipalForm principalForm = new PrincipalForm();

            principalForm.Show();
            this.Close();
        }

        //Establece conexion con al bdd y mira el numero de imagenes que se encuentra en la bdd
        private void Galeria_Load(object sender, EventArgs e)
        {
            try
            {

                btnArrancarGaleria.Enabled = true;
                btnDetenerGaleria.Enabled = true;

                XmlDocument xDoc = new XmlDocument();

                xDoc.Load("ConnectionString.xml");

                XmlNodeList lista = xDoc.GetElementsByTagName("database");

                for (int i = 0; i < lista.Count; i++)
                {
                    nombreServidor = lista[i].Attributes["DBcnString"].Value;
                }

                nombreServidor = desencriptar(nombreServidor);

                cadenaConexion = @"" + nombreServidor + "";


            }
            catch
            {
                Globales.txtMessageBox = "Servidor no introducido o incorrecto";
                messageBoxForm.Show();

            }

            try
            {

                //Numero de imagenes en la base de datos 
                conexion = new SqlConnection(cadenaConexion);

                conexion.Open();

                SqlCommand cmd = conexion.CreateCommand();

                cmd.CommandText = "SELECT count(NOMBRE_IMAGEN) FROM galeria";

                numeroDeImagenes = ((int)cmd.ExecuteScalar());


                conexion.Close();
            }
            catch
            {
                MessageBox.Show("Base de datos aun no establecida");

                btnArrancarGaleria.Enabled = false;
                btnDetenerGaleria.Enabled = false;
            }

        
        }


        //Desencripta la cadena de conexion
        public string desencriptar(string valor)
        {

            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));


        }


        //Timer que va aumentando cada segundo y indica un id de imagen a mostrar
        private void rotacionTimer_Tick(object sender, EventArgs e)
        {

            conexion = new SqlConnection(cadenaConexion);

            conexion.Open();


            if(contador <= numeroDeImagenes)
            {
                string sqlQueryImagen = "SELECT * FROM galeria where ID_GALERIA = '" + contador + "' ";
                SqlCommand cmd = new SqlCommand(sqlQueryImagen, conexion);
                SqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {

                    imagenMostrada = mySqlDataReader["NOMBRE_IMAGEN"].ToString();

                }
                mySqlDataReader.Close();

                rutaImagen = Path.GetFullPath(@"../galeria/" + imagenMostrada);

                pbGaleria.Image = Image.FromFile(rutaImagen);
                pbGaleria.SizeMode = PictureBoxSizeMode.StretchImage;

                contador++;
            }
            else if(contador == numeroDeImagenes+1)
            {
                contador = 1;
            }
        }

        //Enciende el timer para ver la galeria
        private void btnArrancarGaleria_Click(object sender, EventArgs e)
        {
            rotacionTimer.Enabled = true;
        }

        //Detiene el timer 
        private void btnDetenerGaleria_Click(object sender, EventArgs e)
        {
            rotacionTimer.Stop();
        }
    }
}
