using MySql.Data.MySqlClient;
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
    public partial class Login : Form
    {

        private ConexionEncriptada.LIBRERIA.AES aes = new ConexionEncriptada.LIBRERIA.AES();
        private static string nombreServidor = "";
        private string cadenaConexion;
        private SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        MessageBoxForm messageBoxForm = new MessageBoxForm();
        private Boolean encontrado = false;
        PrincipalForm principalForm = new PrincipalForm();

        public Login()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            

            //Cuando carga el form de login busca la linea para poder conectarse a la base de datos, busca en el archivo xml donde se encuentra la cadena de conexion encriptada , la desencripta y la almacena en una variable global para poder usarla mas adelante, en el caso de que algun error suceda saltara un formulario de error indicando que ocurrio.
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
            lblErrorUsuario.Visible = false;
        }

        //Cierra la aplicacion totalmente
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Abre el form de registro y oculta el formulario de login.
        private void btnResgitrarUsuario_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            this.Hide();
            registro.Show();
        }

       
        private void btnlogin_Click(object sender, EventArgs e)
        {
            //Comprueba primero si eres un SuperAdmin si es asin te oculta el login y muestra la pagina principal, ademas limpia los campos de texto.
            if (txtUsuarioLogin.Text == "Superadmin" && txtLoginPass.Text == "Superadmin")
            {
                this.Hide();
                Globales.rolIdentificador = 0;
                Globales.idIdentificador = 1;

                principalForm.misPedidosToolStripMenuItem.Text = "Lista de pedidos";
                principalForm.Show();
                txtLoginPass.Clear();
                txtUsuarioLogin.Clear();
            }
            else
            {
                //En el caso de que no seas Superadmin comprueba que tu usuario y contraseña se encuentra en la base de datos.
                //Si consigue hacer conexion leera la base de datos y comprobara si eres un usuario normal o un admin.
                //Primero leera la base de datos al completo si encuentra un usuario con tal nombre y contraseña ademas de tener el rol indicado le permite pasar, guarda su nombre y contraseña en una variable global
                try
                {
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    String contrasena = "Select * from USUARIOS WHERE usuario = '" + txtUsuarioLogin.Text + "' and contrasena = '" + txtLoginPass.Text + "'";
                    cmd = new SqlCommand(contrasena, conexion);
                    reader = cmd.ExecuteReader();

                   
                    lblErrorUsuario.Visible = true;
                    while (reader.Read())
                    {

                        this.Hide();
  
                        Globales.rolIdentificador = int.Parse(reader["rol"].ToString());
                        Globales.idIdentificador = int.Parse(reader["id"].ToString());
                        principalForm.Show();

                        lblErrorUsuario.Visible = false;
                        

                    }
                    reader.Close();
                    conexion.Close();
                }
                catch
                {
                    //En el caso de que de error porque la base de datos no establecio conexion primero saltara este error.

                    MessageBoxForm messageBoxForm2 = new MessageBoxForm();

                    Globales.txtMessageBox = "Base de datos en mantenimiento, disculpe las molestias.";
                    messageBoxForm2.Show();
                }
            }
        }
        //Desencripta la cadena de conexion para que se pueda establecer la conexion
        public string desencriptar(string valor)
        {
            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));
        }

        //El boton de recuperar contraseña te abre el formulario para poder recuperar la contraseña
        private void btnRecuperarContrasena_Click(object sender, EventArgs e)
        {
            formRecuContra formRecu = new formRecuContra();
            formRecu.Show();
            this.Hide();
        }
    }
}
