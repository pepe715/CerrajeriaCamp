using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CerrajeriaCamp
{
    public partial class Area_personal : Form
    {
        private ConexionEncriptada.LIBRERIA.AES aes = new ConexionEncriptada.LIBRERIA.AES();

        private static string nombreServidor = "";
        private string cadenaConexion;
        private SqlConnection conexion;

        PrincipalForm principalform = new PrincipalForm();


        //Establece el numero de caracteres permitidos en los input especificados
        public Area_personal()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);

            //Telefono
            txtTelefonoArea.MaxLength = 9;

            //CodPostal
            txtCpArea.MaxLength = 5;

           
        }

        private void Area_personal_Load(object sender, EventArgs e)
        {
            //Establacemos la conexion.
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

            }
            catch
            {
                MessageBox.Show("Nombre del servidor no introducido o invalido");
            }

            //Muestra en los campos el contenido indicado de la base de datos.
            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sqlQuery = "SELECT * FROM USUARIOS WHERE ID='" + Globales.idIdentificador + "'";

                SqlCommand cmd = new SqlCommand(sqlQuery, conexion);

                SqlDataReader mySqlDataReader = cmd.ExecuteReader();

                while (mySqlDataReader.Read())
                {                 
                    txtNombreArea.Text = mySqlDataReader["NOMBRE"].ToString();
                    txtApellido1Area.Text = mySqlDataReader["APELLIDO1"].ToString();
                    txtApellido2Area.Text = mySqlDataReader["APELLIDO2"].ToString();
                    txtUsuarioArea.Text = mySqlDataReader["USUARIO"].ToString();
                    txtContraArea.Text = mySqlDataReader["CONTRASENA"].ToString();
                    txtRepetirContraArea.Text = mySqlDataReader["REPCONTRASENA"].ToString();
                    txtTelefonoArea.Text = mySqlDataReader["TELEFONO"].ToString();
                    txtCpArea.Text = mySqlDataReader["CODIGO_POSTAL"].ToString();
                   
                }

                mySqlDataReader.Close();

                conexion.Close();
            }
            catch
            {
                MessageBox.Show("Tablas no creada");
            }
        }

        //Cierra el form de area_personal y muestra el form principal.
        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            principalform.Show();       
        }

        //Desencripta la cadena de conexion para establecer conexion.
        public string desencriptar(string valor)
        {
            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));
        }


        //Comprueba que no se pueda escribir letras en el campo de texto.
        private void txtTelefonoArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        //Comprueba que ambas contraseñas son iguales y se guardan los cambios realizados.
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //Contraseña
            if (txtContraArea.Text == "" && txtRepetirContraArea.Text == "")
            {
                ErrorContra.Text = "Los campos de contraseña estan en blanco, rellenelos.";
                
                ErrorContra.Visible = true;     
            }

            //Comprobacion contraseñas
            if (txtContraArea.Text != "" && txtRepetirContraArea.Text != "")
            {

                if (txtContraArea.Text != txtRepetirContraArea.Text)
                {
                    ErrorContra.Text = "Las contraseña son distintas.Intentlo de nuevo.";
                   
                    ErrorContra.Visible = true;
                }
                else
                {
                    ErrorContra.Visible = false;

                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    SqlCommand comandoActualizar = conexion.CreateCommand();


                    comandoActualizar.CommandText = "UPDATE usuarios SET NOMBRE = '" + txtNombreArea.Text + "',APELLIDO1 = '" + txtApellido1Area.Text + "',APELLIDO2 = '" + txtApellido2Area.Text + "',USUARIO = '" + txtUsuarioArea.Text + "',CONTRASENA ='" + txtContraArea.Text + "',REPCONTRASENA ='" + txtRepetirContraArea.Text + "',TELEFONO ='" + txtTelefonoArea.Text + "',CODIGO_POSTAL ='" + txtCpArea.Text + "' where ID = '" + Globales.idIdentificador + "'";

                    comandoActualizar.ExecuteNonQuery();

                    conexion.Close();


                    MessageBoxForm exito = new MessageBoxForm();

                    Globales.txtMessageBox = "Cambiados realizados con exito.";

                    exito.Show();
                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
