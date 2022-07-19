using MySql.Data.MySqlClient;
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
    public partial class Registro : Form
    {

        private string cadenaConexion;
        private SqlConnection conexion;    

        MessageBoxForm correcto = new MessageBoxForm();
        Login login1 = new Login();
        
        //Al inicializar indica el maximo de caracteres de algunos campos especificos para falicitar el registro.
        public Registro()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);

            //Telefono
            txtTelefonoRegistro.MaxLength = 9;

            //Edad
            txtEdadRegistro.MaxLength = 2;

            //CodPostal
            txtCodPostalRegistro.MaxLength = 5;

            //DNI
            txtDNIRegistro.MaxLength = 9;  

        }

        //Establace conexion con el servidor y en el caso de error salta un mesaje de fallo.
        private void Registro_Load(object sender, EventArgs e)
        {
           
            try
            {
                cadenaConexion = Globales.conexionElegida;
            }
            catch
            {
                MessageBox.Show("Nombre del servidor no introducido o invalido");
            }
        }

        //Vuelve a la pagina de login ocultando la de registro.
        private void btnVolverLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        //Comprueba cada uno de los campos y en el caso de que algun campo este vacio o relleno de manera incorrecta  muestra el error del campo en concreto
        private void btnResgitrarUsuarioRegistro_Click(object sender, EventArgs e)
        { 
            //Nombre
            if(txtNombreRegistro.Text == "")
            {
                ErrorNombre.Text = "Campo nombre necesario";
                ErrorNombre.Visible = true;
            }
            else
            {
                ErrorNombre.Visible = false;
            }


            //Apellido1
            if(txtApellido1Registro.Text == "")
            {
                ErrorApellido1.Text = "Campo apellido necesario";
                ErrorApellido1.Visible = true;
            }
            else
            {
                ErrorApellido1.Visible = false;
            }


            //Edad
            if (txtEdadRegistro.Text == "")
            {
                ErrorEdad.Text = "Campo edad necesario";
                ErrorEdad.Visible = true;
            }
            else
            {
                ErrorEdad.Visible = false;
            }


            //Usuario
            if (txtUsuarioRegistro.Text == "")
            {
                ErrorUsuario.Text = "Campo usuario necesario";
                ErrorUsuario.Visible = true;
            }
            else
            {
                ErrorUsuario.Visible = false;
            }


            //Contraseña
            if (txtContrasenaRegistro.Text == "" && txtRepContrasenaRegistro.Text == "")
            {
                ErrorContrasena.Text = "Campo contraseña necesario";
                ErrorRepeContrasena.Text = "Campo Repecontraseña necesario";
                ErrorContrasena.Visible = true;
                ErrorRepeContrasena.Visible = true;
            }


            //Comprobacion contraseñas
            if (txtContrasenaRegistro.Text != "" && txtRepContrasenaRegistro.Text != "")
            {

                if (txtContrasenaRegistro.Text != txtRepContrasenaRegistro.Text)
                {
                    ErrorContrasena.Text = "Contraseñas distintas";
                    ErrorRepeContrasena.Text = "Contraseñas distintas";
                    ErrorContrasena.Visible = true;
                    ErrorRepeContrasena.Visible = true;
                }
                else
                {
                    ErrorContrasena.Visible = false;
                    ErrorRepeContrasena.Visible = false;
                }
            }
           

            //Telefono
            if (txtTelefonoRegistro.Text == "")
            {
                ErrorTelefono.Text = "Campo telefono necesario";
                ErrorTelefono.Visible = true;
            }
            else
            {
                ErrorTelefono.Visible = false;
            }


            //DNI
            if (txtDNIRegistro.Text == "")
            {
                ErrorDni.Text = "Campo DNI necesario";
                ErrorDni.Visible = true;
            }
            else
            {
                //Si el campo no esta en blanco quita el error.
                ErrorDni.Visible = false;

                //Array que almacenara cada caracter del txtbox de DNI.
                string[] arrayDni = new string[9];
                int i = 0;

                //Variable que almacenara el ultimo caracter de la cadena.
                char caracterFinal ='a';

                //Bucle que ira cogiendo caracter por caracter y metiendolo en el array.
                foreach (char letras in txtDNIRegistro.Text)
                {
                    arrayDni[i] = letras.ToString();
                    //Cogemos el ultimo caracter del array para comprar que no es un numero.
                    caracterFinal = char.Parse(arrayDni[i].ToString());
                    i++;
                }


                char caracterComprobarChar;
                char ultimoCaracter = caracterFinal;
                
                //Comprueba si el DNi esta compuesto por 8 numero y una letra al final en mayusculas.
                for(int j =0;j<arrayDni.Length - 1;j++)
                {
                    caracterComprobarChar = char.Parse(arrayDni[j].ToString());

                    if(!char.IsNumber(caracterComprobarChar))
                    {
                        ErrorDni.Text = "Formato DNI incorrecto";
                        ErrorDni.Visible = true;
                        break;
                    }
                    if(!char.IsLetter(ultimoCaracter))
                    {
                        ErrorDni.Text = "Formato DNI incorrecto";
                        ErrorDni.Visible = true;
                        break;
                    }
                    else
                    {
                        ErrorDni.Visible = false;
                    }            
                }
            }


            //CodPostal
            if (txtCodPostalRegistro.Text == "")
            {
                ErrorCodPostal.Text = "Campo postal necesario";
                ErrorCodPostal.Visible = true;
            }
            else
            {
                ErrorCodPostal.Visible = false;
            }


            //Correo
            if (validarCorreo(txtCorreoRegistro.Text))
            {
                lblErrorCorreo.Visible = false;
            }
            else
            {
                lblErrorCorreo.Text = "Campo correo necesario";
                lblErrorCorreo.Visible = true;
            }




           //Comprueba que no haya ningun error en ningun campo, establece conexion y crea el numero usuario añadiendolo en a la base de datos
            if(ErrorNombre.Visible != true && ErrorApellido1.Visible != true  && ErrorEdad.Visible != true 
                && ErrorUsuario.Visible != true && ErrorContrasena.Visible != true && ErrorRepeContrasena.Visible != true && ErrorTelefono.Visible != true && ErrorDni.Visible != true && ErrorCodPostal.Visible != true && lblErrorCorreo.Visible!= true)
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                Boolean valido = true;

                string sqlQuery = "SELECT  * FROM USUARIOS";
                SqlCommand cmd = new SqlCommand(sqlQuery, conexion);

                SqlDataReader mySqlDataReader = cmd.ExecuteReader();

                //Comprueba que no haya ningun usuario ni correo parecido en la base de datos
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader["usuario"].ToString() == txtUsuarioRegistro.Text || mySqlDataReader["correo"].ToString() == txtCorreoRegistro.Text)
                    {
                        
                        if(mySqlDataReader["usuario"].ToString() == txtUsuarioRegistro.Text)
                        {
                            ErrorUsuario.Text = "Usuario ya existente";
                            ErrorUsuario.Visible = true;
                        }

                        if(mySqlDataReader["correo"].ToString() == txtCorreoRegistro.Text)
                        {
                            lblErrorCorreo.Text = "Correo ya existente";
                            lblErrorCorreo.Visible = true;
                        }

                        valido = false;
                        break;

                    }
                    else
                    {
                        ErrorUsuario.Visible = false;
                        lblErrorCorreo.Visible = false;
                    }
                }

                mySqlDataReader.Close();
                //Si ninguno de los datos es parecido la variable sale true y crea el nuevo usuario.
                if (valido)
                {
                    SqlCommand agregarUsuario = conexion.CreateCommand();
                    agregarUsuario.CommandText = "Insert into usuarios(rol,nombre,apellido1,apellido2,edad,usuario,contrasena,repcontrasena,telefono,dni,codigo_postal,correo)Values('1','" + txtNombreRegistro.Text + "','" + txtApellido1Registro.Text + "','" + txtApellido2Registro.Text + "','" + txtEdadRegistro.Text + "','" + txtUsuarioRegistro.Text + "','" + txtContrasenaRegistro.Text + "','" + txtRepContrasenaRegistro.Text + "','" + txtTelefonoRegistro.Text + "','" + txtDNIRegistro.Text + "','" + txtCodPostalRegistro.Text + "','" + txtCorreoRegistro.Text + "')";

                    agregarUsuario.ExecuteNonQuery();

                    Globales.txtMessageBox = "Usuario añadido correctamente";

                    correcto.Show();
                    correcto.TopMost = true;

                    login1.Show();
                    this.Close();

                }
            }
            conexion.Close();
        }

        //Solo te permite escribir numeros en el campo de texto.
        private void txtTelefonoRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Solo te permite escribir numeros en el campo de texto.
        private void txtEdadRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Solo te permite escribir numeros en el campo de texto.
        private void txtCodPostalRegistro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefonoRegistro_TextChanged(object sender, EventArgs e)
        {

        }

        //Funcion boolean que comprueba que los correo estan escrito de manera correcta.
        public static Boolean validarCorreo(string correo)
        {
            try
            {
                var text_correo = new System.Net.Mail.MailAddress(correo);
                return text_correo.Address == correo;
            }
            catch
            {
                return false;
            }

        }



    }
}
