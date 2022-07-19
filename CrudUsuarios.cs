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
    public partial class CrudUsuarios : Form
    {

        private ConexionEncriptada.LIBRERIA.AES aes = new ConexionEncriptada.LIBRERIA.AES();
        private static string nombreServidor = "";
        private string cadenaConexion;
        private SqlConnection conexion;
      
        PrincipalForm principalform = new PrincipalForm();


        TablaUsuariosGlobal tablaUsuariosGlobal = new TablaUsuariosGlobal();

        public CrudUsuarios()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);
        }


        //Establace conexion con el servidor, desencriptar la cadena de conexion y rellena los input  con todos los datos del usuario clicado anteriormente.
        private void CrudUsuarios_Load(object sender, EventArgs e)
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


            }
            catch
            {
                MessageBox.Show("Nombre del servidor no introducido o invalido");

            }


            conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sqlQuery = "SELECT * FROM USUARIOS where ID = '" + int.Parse(Globales.valorUsuarios) + "'";


            SqlCommand cmd = new SqlCommand(sqlQuery, conexion);

            SqlDataReader mySqlDataReader = cmd.ExecuteReader();

            while (mySqlDataReader.Read())
            {
                txtIDCrud.Text = mySqlDataReader["ID"].ToString();
                txtNombreCrud.Text = mySqlDataReader["NOMBRE"].ToString();
                txtDNICrud.Text = mySqlDataReader["DNI"].ToString();
                txtEdadCrud.Text = mySqlDataReader["EDAD"].ToString();
                txtCorreoCrud.Text = mySqlDataReader["CORREO"].ToString();
                txtApellido1Crud.Text = mySqlDataReader["APELLIDO1"].ToString();
                txtApellido2Crud.Text = mySqlDataReader["APELLIDO2"].ToString();
                txtUsuarioCrud.Text = mySqlDataReader["USUARIO"].ToString();
                txtContrasenaCrud.Text = mySqlDataReader["CONTRASENA"].ToString();
                txtRepContrasenaCrud.Text = mySqlDataReader["REPCONTRASENA"].ToString();
                txtTelefonoCrud.Text = mySqlDataReader["TELEFONO"].ToString();
                txtCodPostalCrud.Text = mySqlDataReader["CODIGO_POSTAL"].ToString();

            }

            mySqlDataReader.Close();

            conexion.Close();
        }

        //Vuelve al form de todos los usuarios
        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            tablaUsuariosGlobal.Show();
        }


        //Desencripta la cadena de conexion
        public string desencriptar(string valor)
        {

            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));


        }


        //Cambia los datos en la base de datos de aquellos campos modificados.
        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            SqlCommand comandoActualizar = conexion.CreateCommand();


            comandoActualizar.CommandText = "UPDATE USUARIOS SET NOMBRE = '" + txtNombreCrud.Text + "',APELLIDO1 = '" + txtApellido1Crud.Text + "',APELLIDO2 = '" + txtApellido2Crud.Text + "',EDAD = '" + txtEdadCrud.Text + "',USUARIO ='" + txtUsuarioCrud.Text + "',CONTRASENA ='" + txtContrasenaCrud.Text + "',REPCONTRASENA ='" + txtRepContrasenaCrud.Text + "',TELEFONO ='" + txtTelefonoCrud.Text + "',DNI ='" + txtDNICrud.Text + "',CODIGO_POSTAL ='" + txtCodPostalCrud.Text + "' where id = '" + txtIDCrud.Text + "'";

            comandoActualizar.ExecuteNonQuery();

            MessageBoxForm message = new MessageBoxForm();
            Globales.txtMessageBox = "Modificacion completada";

            message.Show();

            

            conexion.Close();
        }


        //Limpia todos los input para que no aparezcan datos.
        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            txtNombreCrud.Clear();
            txtApellido1Crud.Clear();
            txtApellido2Crud.Clear();
            txtEdadCrud.Clear();
            txtUsuarioCrud.Clear();
            txtContrasenaCrud.Clear();
            txtRepContrasenaCrud.Clear();
            txtTelefonoCrud.Clear();
            txtDNICrud.Clear();
            txtCodPostalCrud.Clear();
            txtCorreoCrud.Clear();

        }
    }
}
