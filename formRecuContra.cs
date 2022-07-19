using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CerrajeriaCamp
{
    public partial class formRecuContra : Form
    {

        private ConexionEncriptada.LIBRERIA.AES aes = new ConexionEncriptada.LIBRERIA.AES();

        private static string nombreServidor = "";
        private string cadenaConexion;
        private SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        MessageBoxForm messageBoxForm = new MessageBoxForm();
        PrincipalForm principalForm = new PrincipalForm();

        string contraRecu="";

        public formRecuContra()
        {
            InitializeComponent();
        }

        //Establece conexion con la base datos desencriptando la cadena guardada.
        private void formRecuContra_Load(object sender, EventArgs e)
        {

            try
            {
                XmlDocument xDoc = new XmlDocument();

                xDoc.Load("ConnectionString.xml");

                XmlNodeList lista = xDoc.GetElementsByTagName("database");

                for (int i = 0; i < lista.Count; i++)
                {
                    nombreServidor = lista[i].Attributes["DBcnString"].Value;
                }

                nombreServidor = desencriptar(nombreServidor);

                cadenaConexion = @"" + nombreServidor + "";

                Globales.conexionElegida = cadenaConexion;

            }
            catch
            {
                Globales.txtMessageBox = "Nombre del servidor no introducido o incorrecto";
                messageBoxForm.Show();

            }
        }

        //Busca en la base de datos un correo como el indicado en el input text y si esta te envia un correo al susodicho con la contraseña.
        private void btnEnviarRecu_Click(object sender, EventArgs e)
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                String contrasena = "Select * from USUARIOS WHERE CORREO = '" + txtCorreoRecu.Text + "'";
                cmd = new SqlCommand(contrasena, conexion);

                reader = cmd.ExecuteReader();
            
                while (reader.Read())
                {

                    contraRecu = reader["CONTRASENA"].ToString();

                }

                enviarCorreo();


                reader.Close();
                conexion.Close();
            }
            catch
            {
                Globales.txtMessageBox = "Correo de usuario no existente.";
                messageBoxForm.Show();

            }

        }


        //Envia el correo al usuario indicado con la contraseña que le corresponde si encuentra ese correo proporcionado en la base de datos.
        private void enviarCorreo()
        {
            string textoMensaje="Su contraseña es: ";

            try
            {
                MailMessage mensaje = new MailMessage("cerrajericamp@gmail.com", txtCorreoRecu.Text, "Recuperacion contraseña", "Su contraseña es:");
                mensaje.Body = textoMensaje + contraRecu;


                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("cerrajericamp@gmail.com", "cerrajeriaCampCamp1"),
                    EnableSsl = true,
                };

                smtp.Send(mensaje);

                Globales.txtMessageBox = "Correo enviado correctamente.";
                messageBoxForm.Show();
            }
            catch
            {

                Globales.txtMessageBox = "Correo de usuario no existente.";

                messageBoxForm.Show();
            }
        }

        //Desencriptra la cadena de conexion
        public string desencriptar(string valor)
        {

            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));

        }

        //Cierra la pestaña de recuperar contraseña y muestra de nuevo el login
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
