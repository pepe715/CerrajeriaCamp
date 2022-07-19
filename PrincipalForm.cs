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
    public partial class PrincipalForm : Form
    {
        
        private ConexionEncriptada.LIBRERIA.AES aes = new ConexionEncriptada.LIBRERIA.AES();
        private static string nombreServidor = "";
        private string cadenaConexion;
        private SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;
        String usuarioEncontrado;
        String usuarioNick;
        MessageBoxForm messageBoxForm = new MessageBoxForm();
        String rutaGif;

        public PrincipalForm()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);
        }

        //Al cargar coge el gif indicandole la ruta y lo muestra en pantalla, establece la conexion con la base de datos desencriptando la cadena xml, y muestra en pantalla el nombre del usuario que inicio sesion y compruba segun su rol que opciones puede visualizar.
        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            rutaGif = Path.GetFullPath(@"llave.gif");       
            pictureBox2.Image = Image.FromFile(rutaGif);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

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
                Globales.txtMessageBox = "Servidor no introducido o incorrecto";
                messageBoxForm.Show();
            }

            try
            {
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                usuarioEncontrado = "Select * from USUARIOS WHERE id = '" + Globales.idIdentificador + "' and rol = '" + Globales.rolIdentificador + "'";
                cmd = new SqlCommand(usuarioEncontrado, conexion);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    usuarioNick = reader["USUARIO"].ToString();
                }

                reader.Close();
                conexion.Close();
            }catch
            {

            }

            //Comprueba el rol de usuario que inicio sesion y de mostrara o dejara de moestrar una serie de campos quue pertenecer a un rol en especifico.

            switch (Globales.rolIdentificador)
            {
                case 0: // Rol Super

                    lblNombreNick.Text = usuarioNick;
                     
                    break;

                case 1: // Rol normal

                    mantenimientoToolStripMenuItem.Visible = false;
                    lblNombreNick.Text = usuarioNick;
                    datosGlobalesToolStripMenuItem.Visible = false;

                    break;

                default:
                    Console.WriteLine("Error de rol");
                    break;
            }
        }


        //Cierra la aplicacion al completo.
        private void btnDesconectar_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        //Se conecta con la base de datos unicamente sin crear ninguna tabla(Unicamente para establecer conexion).
        private void btnConexion_Click(object sender, EventArgs e)
        {
            ConexionEncriptada.CONEXION.ConexionManual conexion = new ConexionEncriptada.CONEXION.ConexionManual();
            conexion.Show();
        }

        //Crear la base de datos asignandole un nombre y comprando que no hay ninguna ya establecida para no pisarla, tambien se indica la manera en la que hay que operar en este campo, en el caso de una mala conexion al pulsar salta error.
        private void btnCrearBBDD_Click(object sender, EventArgs e)
        {
            try
            {
                conexion = new SqlConnection(cadenaConexion);

                conexion.Open();

                SqlCommand bdCrear = conexion.CreateCommand();

                bdCrear.CommandText = "IF NOT EXISTS(SELECT name FROM sys.sysdatabases WHERE name = 'cerrajeriacamp') BEGIN  CREATE DATABASE cerrajeriacamp;END;";

                bdCrear.ExecuteNonQuery();
            
                MessageBox.Show("La base de datos creada: \n Modifique la cadena añadiendo DATABASE= 'cerrajeriacamp'. \n \n A continuacion de cerrara el programa, vuelvalo a abrir y tendras la conexion creada.");

                ConexionEncriptada.CONEXION.ConexionManual conexion2 = new ConexionEncriptada.CONEXION.ConexionManual();
                conexion2.Show();

            }
            catch
            {

                Globales.txtMessageBox = "La base de datos ya existente o Base de datos no establecida correctamente.";
                messageBoxForm.Show();

            }
        }


        //Crea todas las tablas asignandole datos por defecto de la empresa cerrajeria camp
        private void btnCrearTablas_Click(object sender, EventArgs e)
        {
            try
            {

                conexion = new SqlConnection(cadenaConexion);

                conexion.Open();

                //Tabla de usuarios.
                SqlCommand tablaUsuario = conexion.CreateCommand();

                tablaUsuario.CommandText = "Create table usuarios(ID int IDENTITY(1,1) PRIMARY KEY,ROL int,  NOMBRE varchar(30) not null,APELLIDO1 varchar(30) not null,APELLIDO2 varchar(30),EDAD int not null,USUARIO varchar(30) not null,CONTRASENA varchar(30) not null,REPCONTRASENA varchar(30) not null,TELEFONO varchar(9) not null,DNI varchar(9) not null,CODIGO_POSTAL int not null, CORREO varchar(50) not null)";

                tablaUsuario.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla usuario.

                SqlCommand insertarDefecto = conexion.CreateCommand();
            insertarDefecto.CommandText = "Insert into usuarios(rol,nombre,apellido1,apellido2,edad,usuario,contrasena,repcontrasena,telefono,dni,codigo_postal,correo)Values(0,'Superadmin','super','admin',20,'Superadmin','Superadmin','Superadmin','111111111','11111111A','11111','cerrajericamp@gmail.com'),(1, 'Pepe', 'prieto', 'moreno', 21, 'Pepe', 'pepe', 'pepe', '111111112', '11111111B', '11112','pepeprieto2016@gmail.com')";
                insertarDefecto.ExecuteNonQuery();



                //Tabla de cristal de las ventanas.
                SqlCommand tablaCristal = conexion.CreateCommand();

                tablaCristal.CommandText = "create table cristal(ID_CRISTAL int IDENTITY(1,1) PRIMARY KEY,NOMBRE_CRISTAL VARCHAR(50) not null,DESCRIPCION VARCHAR(300) not null,PRECIO_CRISTAL DECIMAL(6,2) not null)";

                tablaCristal.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla cristal.

                SqlCommand insertarDefectoCristal = conexion.CreateCommand();
                insertarDefectoCristal.CommandText = "Insert into cristal(NOMBRE_CRISTAL,DESCRIPCION,PRECIO_CRISTAL)Values" +
                    "('Vidrio flotado', 'Vidrio sobre  una capa de estaño fundido', 10.0)," +
                    "('Vidrio templado', 'Vidrio de seguridad procesado por tratamientos termicos', 15.0)," +
                    "('Vidrio laminado', 'Vidrio de seguridad compuesto por dos o mas vidrios unidos por varias laminas', 20.0)," +
                    "('Vidrio doble acristalamiento', 'Vidrio compuesto por dos o mas hojas separasas por una camara sellada', 25.0)," +
                    "('Vidrio decorativos', 'Vidrio decorado', 30.0)," +
                    "('Vidrio tintado', 'Vidrio coloreado para reducir efecto de la radiacion solar', 35.0)," +
                    "('Vidrio reflectivo', 'Vidrio de control solar', 40.0)";

                insertarDefectoCristal.ExecuteNonQuery();



                //Tabla de material de cristal.
                SqlCommand tablaMaterialCristal = conexion.CreateCommand();

                tablaMaterialCristal.CommandText = "Create table material(ID_MATERIAL int IDENTITY(1,1) PRIMARY KEY,NOMBRE_MATERIAL varchar(30) not null,PRECIO_EL_METRO decimal(5, 2) not null)";

                tablaMaterialCristal.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla material de las ventanas.

                SqlCommand insertarDefectoMaterialCristal = conexion.CreateCommand();
                insertarDefectoMaterialCristal.CommandText = "Insert into material(NOMBRE_MATERIAL,PRECIO_EL_METRO)Values" +
                    "('PVC', 5.0)," +
                    "('Aluminio', 10.0)," +
                    "('Madera', 15.0)," +
                    "('Imitacion', 20.0)," +
                    "('Acero', 25.0)," +
                    "('Hierro', 30.0)," +
                    "('Metal', 35.0)";

                insertarDefectoMaterialCristal.ExecuteNonQuery();




                //Tabla de tipo de ventana.
                SqlCommand tablaTipoVentana = conexion.CreateCommand();

                tablaTipoVentana.CommandText = "Create table tipoVentana(ID_TIPO_VENTANA int IDENTITY(1,1) PRIMARY KEY,NOMBRE_VENTANA varchar(70) not null,PRECIO_TIPO_VENTANA decimal(6, 2) not null)";

                tablaTipoVentana.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla de tipos de ventana.

                SqlCommand insertarDefectoTipoVentana = conexion.CreateCommand();
                insertarDefectoTipoVentana.CommandText = "Insert into tipoVentana(NOMBRE_VENTANA,PRECIO_TIPO_VENTANA)Values" +
                    "('Ventana fija', 10.0)," +
                    "('Ventana una hoja', 15.0)," +
                    "('Ventana dos hojas', 20.0)," +
                    "('Ventana tres hoja', 25.0)," +
                    "('Ventana corredera dos hojas', 30.0)," +
                    "('Ventana balconera una hoja ', 35.0)," +
                    "('Ventana balconera dos hojas', 40.0)," +
                    "('Ventana una hoja fijo interior', 45.0)," +
                    "('Ventana dos hojas fijo interior', 50.0)," +
                    "('Ventana tres hojas fijo interior', 55.0)";

                insertarDefectoTipoVentana.ExecuteNonQuery();





                //Tabla Ventana final
                SqlCommand tablaVentanaFinal = conexion.CreateCommand();

                tablaVentanaFinal.CommandText = "create table ventanaFinal(ID_VENTANA_FINAL int IDENTITY(1,1) PRIMARY KEY, ID_USUARIO int not null,ID_MATERIAL int not null,ID_TIPO_VENTANA int not null,ID_TIPO_CRISTAL int not null,ANCHURA decimal(6,2) not null,ALTURA decimal(6,2) not null,PRECIO_FINAL varchar(10) not null,CONSTRAINT FK_VENTANAFINAL_USUARIO FOREIGN KEY (ID_USUARIO) REFERENCES USUARIOS(ID),CONSTRAINT FK_VENTANAFINAL_MATERIAL FOREIGN KEY (ID_MATERIAL) REFERENCES MATERIAL(ID_MATERIAL),CONSTRAINT FK_VENTANAFINAL_TIPO_VENTANA FOREIGN KEY (ID_TIPO_VENTANA) REFERENCES TIPOVENTANA(ID_TIPO_VENTANA),CONSTRAINT FK_VENTANAFINAL_TIPO_CRISTAL FOREIGN KEY (ID_TIPO_CRISTAL) REFERENCES CRISTAL(ID_CRISTAL))";

                tablaVentanaFinal.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla ventana final.

                SqlCommand insertarDefectoVentanaFinal= conexion.CreateCommand();
                insertarDefectoVentanaFinal.CommandText = "Insert into ventanaFinal(ID_USUARIO,ID_MATERIAL,ID_TIPO_VENTANA,ID_TIPO_CRISTAL,ANCHURA,ALTURA,PRECIO_FINAL)Values" +
                    "(1, 1, 1, 1, 500, 600, '700')," +
                    "(1, 2, 4, 3, 550, 660, '500')," +
                    "(1, 5, 3, 4, 600, 700, '900')";

                insertarDefectoVentanaFinal.ExecuteNonQuery();




                //Tabla material reja.
                SqlCommand tablaReja = conexion.CreateCommand();

                tablaReja.CommandText = "Create table materialReja(ID_MATERIAL_REJA int IDENTITY(1,1) PRIMARY KEY,NOMBRE_REJA_MATERIAL varchar(50) not null,PRECIO_REJA decimal(5, 2) not null)";

                tablaReja.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla material reja.

                SqlCommand insertarDefectoReja = conexion.CreateCommand();
                insertarDefectoReja.CommandText = "Insert into materialReja(NOMBRE_REJA_MATERIAL,PRECIO_REJA)Values" +
                    "('Aluminio', 10.0)," +
                    "('Acero', 25.0)," +
                    "('Hierro forjado', 35.0)";

                insertarDefectoReja.ExecuteNonQuery();




                //Tabla tipo de reja.
                SqlCommand tipoReja = conexion.CreateCommand();

                tipoReja.CommandText = "Create table tipoReja(ID_TIPO_REJA int IDENTITY(1,1) PRIMARY KEY,NOMBRE_REJA varchar(70) not null,DESCRIPCION_REJA varchar(500) not null,PRECIO_TIPO_REJA decimal(6, 2) not null)";

                tipoReja.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla tipoReja.

                SqlCommand insertarDefectoTipoReja = conexion.CreateCommand();
                insertarDefectoTipoReja.CommandText = "Insert into tipoReja(NOMBRE_REJA,DESCRIPCION_REJA,PRECIO_TIPO_REJA)Values('Reja fija', 'Reja fija a la pared que rodea el hueco de la ventana', 20.0),('Reja plegables', 'Reja que suelen colocarse para la apertura de la misma en un momento determinado', 30.0),('Reja embutida', 'Reja que se fija con tornillos y se ajusta al edificio', 40.0),('Reja abatible', 'Reja que tiene la posibilidad de abrirse con facilidad', 50.0),('Reja desmontable', 'Reja que se puede desmontar para evitar que los niños caigan al asomarse a la ventana', 60.0)";

                insertarDefectoTipoReja.ExecuteNonQuery();



                //Tabla reja final.
                SqlCommand rejaFinal = conexion.CreateCommand();

                rejaFinal.CommandText = "create table rejaFinal(ID_REJA_FINAL int IDENTITY(1,1) PRIMARY KEY,ID_USUARIO int not null,ID_MATERIAL_REJA int not null,ID_TIPO_REJA int not null,ANCHURA_REJA decimal(6, 2) not null,ALTURA_REJA decimal(6, 2) not null,COLOR_REJA varchar(30) not null,PRECIO_FINAL_REJA varchar(10) not null,CONSTRAINT FK_REJAFINAL_USUARIO FOREIGN KEY(ID_USUARIO) REFERENCES USUARIOS(ID),CONSTRAINT FK_REJAFINAL_MATERIAL_REJA FOREIGN KEY(ID_MATERIAL_REJA) REFERENCES MATERIALREJA(ID_MATERIAL_REJA),CONSTRAINT FK_REJAFINAL_TIPO_REJA FOREIGN KEY(ID_TIPO_REJA) REFERENCES TIPOREJA(ID_TIPO_REJA))";

                rejaFinal.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla reja final.

                SqlCommand insertarDefectoRejaFinal = conexion.CreateCommand();
                insertarDefectoRejaFinal.CommandText = "Insert into rejaFinal(ID_USUARIO,ID_MATERIAL_REJA,ID_TIPO_REJA,ANCHURA_REJA,ALTURA_REJA,COLOR_REJA,PRECIO_FINAL_REJA)Values" +
                    "(1, 1, 1, 500, 600, 'Rojo', '1000')," +
                    "(1, 2, 2, 550, 660, 'Material', '1500')," +
                    "(1, 3, 2, 600, 700, 'Negro', '1900')";

                insertarDefectoRejaFinal.ExecuteNonQuery();


                //Tabla cerradura.
                SqlCommand cerradura = conexion.CreateCommand();

                cerradura.CommandText = "Create table cerradura(ID_CERRADURA int IDENTITY(1,1) PRIMARY KEY,NOMBRE_CERRADURA varchar(70) not null,DESCRIPCION_CERRADURA varchar(500) not null,IMAGEN_CERRADURA varchar(500) not null,PRECIO_CERRADURA decimal(5, 2) not null)";

                cerradura.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla cerradura.

                SqlCommand insertarDefectoCerradura = conexion.CreateCommand();
                insertarDefectoCerradura.CommandText = "Insert into cerradura(NOMBRE_CERRADURA,DESCRIPCION_CERRADURA,IMAGEN_CERRADURA,PRECIO_CERRADURA)Values('Cerradura normal', 'Cerradura normal para puertas de casa', 'cerradura1.jpg', 10),('Cerradura de leva', 'Cerradura de leva que se suele usar para muebles.', 'Cerradura_de_Leva.jpg', 20),('Cerradura de sobreposicion', 'Cerradura de puerta con varios pernos que permiten una mejor seguridad.', 'Cerradura_de_Sobreponer.jpg', 30),('Cerradura Jis ', 'Cerradura de puerta con varios pernos que permiten una mejor seguridad y apertura mediante rueda.', 'Cerradura-jis-243.jpg', 40),('Cerradura Electrica', 'Cerradura de puerta con boton que permirte la apertuda.', 'Cerradura_Electrica_Fac.jpg', 50)";

                insertarDefectoCerradura.ExecuteNonQuery();




                //Tabla de cerradura final.
                SqlCommand cerraduraFinal = conexion.CreateCommand();

                cerraduraFinal.CommandText = "create table cerraduraFinal(ID_CERRADURA_FINAL int IDENTITY(1,1) PRIMARY KEY,ID_USUARIO int not null,ID_CERRADURA int not null,PRECIO_FINAL_CERRADURA varchar(10) not null,CONSTRAINT FK_CERRADURAFINAL_USUARIO FOREIGN KEY(ID_USUARIO) REFERENCES USUARIOS(ID),CONSTRAINT FK_CERRADURAFINAL_CERRADURA FOREIGN KEY(ID_CERRADURA) REFERENCES CERRADURA(ID_CERRADURA))";

                cerraduraFinal.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla de cerradura final.

                SqlCommand insertarDefectoCerraduraFinal = conexion.CreateCommand();
                insertarDefectoCerraduraFinal.CommandText = "Insert into cerraduraFinal(ID_USUARIO,ID_CERRADURA,PRECIO_FINAL_CERRADURA)Values(1, 1, 20.0),(1, 2, 30.0),(1, 3, 40.0)";

                insertarDefectoCerraduraFinal.ExecuteNonQuery();



                //Tabla de galeria.
                SqlCommand galeria = conexion.CreateCommand();

                galeria.CommandText = "create table galeria(ID_GALERIA int IDENTITY(1,1) PRIMARY KEY,NOMBRE_IMAGEN varchar(500) not null)";

                galeria.ExecuteNonQuery();

                //Datos insertados por defecto para la tabla de galeria.

                SqlCommand insertarDefectoGaleria = conexion.CreateCommand();
                insertarDefectoGaleria.CommandText = "Insert into galeria(NOMBRE_IMAGEN)Values('1hoja.jpg'),('aluminio.jpg'),('aluminio_normal.jpg'),('compacta.jpg'),('corredera.jpg'),('desmontable.jpg'),('oscilobatiente.jpg'),('reja_acero.jpg'),('reja_completa.jpg'),('reja_fundicion.jpg'),('reja_hierro.jpg')";

                insertarDefectoGaleria.ExecuteNonQuery();

                

                MessageBox.Show("Servidor actualizado, Reiniciando aplicacion.");
                Application.Exit();
            }
            catch
            {
                Globales.txtMessageBox = "Tabla ya existente o Base de datos no establecida.";
                messageBoxForm.Show();
            }     
        }


        //Lleva a la pestaña de pedidos y oculta el form principal
        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPedido formPedido = new FormPedido();
            formPedido.Show();

            this.Hide();
        }

        //Desencripta la cadena de conexion para establacer conexion.
        public string desencriptar(string valor)
        {
            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));

        }


        //Lleva a la pestaña de datos personales y oculta el form principal(Tiene acceso todos los usuarios).
        private void datosPersonalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Area_personal area_Personal = new Area_personal();
            area_Personal.Show();

            this.Hide();      
        }

        //Lleva a la pestaña de datos globales y oculta el form principal(Solo tiene acceso el administrador).
        private void datosGlobalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TablaUsuariosGlobal tablaUsuariosGlobal = new TablaUsuariosGlobal();

            tablaUsuariosGlobal.Show();

            this.Hide();
        }

        //Lleva a la pestaña de mis pedidos y oculta el form principal.
        private void misPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mis_Pedidos mis_Pedidos = new Mis_Pedidos();
            mis_Pedidos.Show();

            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //Lleva a la pestaña de galeria y oculta el form principal.
        private void galeriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Galeria galeria = new Galeria();
            galeria.Show();

            this.Hide();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
