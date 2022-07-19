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
    public partial class TablaUsuariosGlobal : Form
    {

        private ConexionEncriptada.LIBRERIA.AES aes = new ConexionEncriptada.LIBRERIA.AES();
        private static string nombreServidor = "";
        private string cadenaConexion;
        private SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adaptador;
        DataSet ds;
        BindingSource source;
        SqlCommandBuilder cb;

        PrincipalForm principalform = new PrincipalForm();


        public TablaUsuariosGlobal()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);
        }

        private void TablaUsuariosGlobal_Load(object sender, EventArgs e)
        {
            //Establace conexion con el servidor
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


            dgbTodoUsuario.Refresh();


            //Cargar tabla de todos los usuarios.
            conexion = new SqlConnection(cadenaConexion);
            conexion.Open();
            source = new BindingSource();


            string consultaTodo = "SELECT * FROM USUARIOS";

            adaptador = new SqlDataAdapter(consultaTodo, conexion);

            //Definicion de conjunto de datos
            ds = new DataSet();


            //LLeno el conjunto con lo que tengo en el adaptador
            adaptador.Fill(ds, "USUARIOS");

            source.DataSource = ds;
            source.DataMember = "USUARIOS";

            dgbTodoUsuario.DataSource = source;
            cb = new SqlCommandBuilder(adaptador);
            bindingNavigator1.BindingSource = source;

            //Coge los datos y los coloca en la tabla debajo de su respectiva posicion.
            dgbTodoUsuario.Columns["ID"].HeaderText = "ID";
            dgbTodoUsuario.Columns["ROL"].HeaderText = "Nivel";
            dgbTodoUsuario.Columns["NOMBRE"].HeaderText = "Nombre";
            dgbTodoUsuario.Columns["APELLIDO1"].HeaderText = "Apellido 1";
            dgbTodoUsuario.Columns["APELLIDO2"].HeaderText = "Apellido 2";
            dgbTodoUsuario.Columns["EDAD"].HeaderText = "Edad";
            dgbTodoUsuario.Columns["USUARIO"].HeaderText = "Usuario";
            dgbTodoUsuario.Columns["CONTRASENA"].HeaderText = "Contrasena";
            dgbTodoUsuario.Columns["REPCONTRASENA"].HeaderText = "Provincia";
            dgbTodoUsuario.Columns["TELEFONO"].HeaderText = "Telefono";
            dgbTodoUsuario.Columns["DNI"].HeaderText = "DNI";
            dgbTodoUsuario.Columns["CODIGO_POSTAL"].HeaderText = "CP";
            dgbTodoUsuario.Columns["CORREO"].HeaderText = "Correo";
        }


        //Desencriptar la cadena de conexion.
        public string desencriptar(string valor)
        {

            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));


        }

        //Vuelve a el form principal.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            principalform.Show();
        }


        //Abre el form de mensajes preguntando si quieres borrar el usuarios que esta seleccionado en el griw
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {


            MessageBoxForm eliminar = new MessageBoxForm();


            Globales.txtMessageBox = "¿Desea elimar este usuario?";

            eliminar.btnMessageBoxAceptar.Location = new Point(50, 183);
            eliminar.btnCancelar.Visible = true;

            eliminar.Show();


            eliminar.btnMessageBoxAceptar.Click += new EventHandler(button1_Click);

        }


        //Lo llama para eliminar usuarios de la tabla, escoge el ID del usuario de la linea seleccionada y lo borra de la base de datos, en el caso de error salta un mensaje.
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               

                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    SqlCommand comandoEliminar = conexion.CreateCommand();

                    Globales.idIdentificador = int.Parse(dgbTodoUsuario.CurrentRow.Cells["id"].Value.ToString());

            


                    comandoEliminar.CommandText = "DELETE  FROM USUARIOS WHERE ID = '" + Globales.idIdentificador + "'";


                    comandoEliminar.ExecuteNonQuery();

                    conexion.Close();


                    MessageBoxForm correcto = new MessageBoxForm();
                    Globales.txtMessageBox = "Usuario Eliminado Correctamente";

                    correcto.Show();

                

                    dgbTodoUsuario.Refresh();


                


            }
            catch
            {
                MessageBoxForm error = new MessageBoxForm();


                Globales.txtMessageBox = "Usuario no seleccionado para ser borrado";

                error.Show();

            }
        }

        private void dgbTodoUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Globales.valorUsuarios = dgbTodoUsuario.CurrentRow.Cells["ID"].Value.ToString();

            CrudUsuarios crudUsuarios = new CrudUsuarios();
            crudUsuarios.Show();

            this.Hide();
        }
    }
}
