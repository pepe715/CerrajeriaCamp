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
    public partial class FormPedido : Form
    {

        private ConexionEncriptada.LIBRERIA.AES aes = new ConexionEncriptada.LIBRERIA.AES();
        private static string nombreServidor = "";
        private string cadenaConexion;
        private SqlConnection conexion;


        //Pasar Imagenes
        private int indice;
        String rutaImagen;
        String imagenMostrada;


        //Variables donde se guardaran los id
        int idMaterial;
        int idTipo;
        int idCristal;


        //Variable donde se guardan precios
        float precioMaterial;
        float precioTipo;
        float precioCristal;

        //PRecio final de la ventana
        float precioFinalVentana;

        //Variables donde se guardaran los id
        int idMaterialReja;
        int idTipoReja;
        int idCerradura;

        //Variable donde se guardan precios
        float precioMaterialReja;
        float precioTipoReja;

        //Precio final de la reja
        float precioFinalReja;

        MessageBoxForm messageBoxForm = new MessageBoxForm();
        PrincipalForm principalform = new PrincipalForm();

        //Establece numero de caracteres en cada input text
        public FormPedido()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);

            txtAnchuraVentana.MaxLength = 4;
            txtAlturaVentana.MaxLength = 4;

            //Pasar Imagenes inicializacion
            indice = 0;

        }

        //Establece conexion con el servidor y rellena los campos con los datos correspondientes a cada tipo de pedido.
        private void FormPedido_Load(object sender, EventArgs e)
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
                Globales.txtMessageBox = "Servidor no introducido o incorrecto";
                messageBoxForm.Show();

            }

            //Muestra en los campos correspondientes su informacion para que el usuario pueda escoger de el apartado de ventana
            try
            {
                conexion = new SqlConnection(cadenaConexion);

                //MATERIAL DE LA VENTANA ESCOGIDA
                conexion.Open();

                string sqlQueryMaterial = "SELECT * FROM material";
                SqlCommand cmd = new SqlCommand(sqlQueryMaterial, conexion);
                SqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    //*
                    cbxMaterialVentana.Items.Add(mySqlDataReader["NOMBRE_MATERIAL"].ToString());
                    
                }
                mySqlDataReader.Close();

            
                //TIPO DE VENTANA ESCOGIDA        
        
                string sqlQueryTipoVentana = "SELECT * FROM tipoVentana";
                SqlCommand cmd2 = new SqlCommand(sqlQueryTipoVentana, conexion);
                SqlDataReader mySqlDataReader2 = cmd2.ExecuteReader();
                while (mySqlDataReader2.Read())
                {
                    cbxTipoVentana.Items.Add(mySqlDataReader2["NOMBRE_VENTANA"].ToString());

                }
                mySqlDataReader2.Close();

           
                //TIPO DE CRISTAL ESCOGIDO
            
                string sqlQueryTipoCristal = "SELECT * FROM cristal";
                SqlCommand cmd3 = new SqlCommand(sqlQueryTipoCristal, conexion);
                SqlDataReader mySqlDataReader3 = cmd3.ExecuteReader();
                while (mySqlDataReader3.Read())
                {
                    cbxCristalVentana.Items.Add(mySqlDataReader3["NOMBRE_CRISTAL"].ToString());

                }
                mySqlDataReader3.Close();

                conexion.Close();



                //Valores puestos por defecto en las ventanas
                cbxMaterialVentana.SelectedIndex = 0;
                cbxTipoVentana.SelectedIndex = 0;
                cbxCristalVentana.SelectedIndex = 0;
                txtAnchuraVentana.Text = "100";
                txtAlturaVentana.Text = "100";

            }
            catch
            {
                MessageBox.Show("Tablas no creada");

            }


            //Muestra en los campos correspondientes su informacion para que el usuario pueda escoger de el apartado de reja

            try
            {
                conexion = new SqlConnection(cadenaConexion);

                //MATERIAL DE LA REJA ESCOGIDA
                conexion.Open();

                string sqlQueryMaterialReja = "SELECT * FROM materialReja";
                SqlCommand cmd = new SqlCommand(sqlQueryMaterialReja, conexion);
                SqlDataReader mySqlDataReader = cmd.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    cbxMaterialReja.Items.Add(mySqlDataReader["NOMBRE_REJA_MATERIAL"].ToString());

                }
                mySqlDataReader.Close();
        

                //TIPO DE VENTANA ESCOGIDA           

                string sqlQueryTipoReja = "SELECT * FROM tipoReja";
                SqlCommand cmd2 = new SqlCommand(sqlQueryTipoReja, conexion);
                SqlDataReader mySqlDataReader2 = cmd2.ExecuteReader();
                while (mySqlDataReader2.Read())
                {
                    cbxTipoReja.Items.Add(mySqlDataReader2["NOMBRE_REJA"].ToString());

                }
                mySqlDataReader2.Close();


                conexion.Close();

                //Valores puestos por defecto en las ventanas
                cbxMaterialReja.SelectedIndex = 0;
                cbxTipoReja.SelectedIndex = 0;
                cbxColorReja.SelectedIndex = 0;
                
                textBox2.Text = "100";
                textBox1.Text = "100";

            }
            catch
            {
                MessageBox.Show("Tablas no creada");
            }


            try
            {
                //CERRADURA 

                conexion = new SqlConnection(cadenaConexion);

                conexion.Open();

                string sqlQueryCerradura = "SELECT * FROM cerradura";
                SqlCommand cmd4 = new SqlCommand(sqlQueryCerradura, conexion);
                SqlDataReader mySqlDataReader4 = cmd4.ExecuteReader();
                while (mySqlDataReader4.Read())
                {
                    cbCerraduras.Items.Add(mySqlDataReader4["NOMBRE_CERRADURA"].ToString());

                }
                mySqlDataReader4.Close();


                conexion.Close();

                cbCerraduras.SelectedIndex = 0;

            }catch
            {
                MessageBox.Show("Tablas no creada");
            }
        }

        //Cierra la pestaña de pedido y muestra el form principal.
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            principalform.Show();

        }

     

        //Desencripta la cadena de conexion.
        public string desencriptar(string valor)
        {

            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));


        }

        //Coge los datos de los inputs correspondientes y añade la ventana creada en la base de datos.
        private void RealizarVentana_Click(object sender, EventArgs e)
        {
            conexion.Open();

            SqlCommand sqlCrearVentana = conexion.CreateCommand();


            sqlCrearVentana.CommandText = "Insert into ventanaFinal(ID_USUARIO,ID_MATERIAL,ID_TIPO_VENTANA,ID_TIPO_CRISTAL,ANCHURA,ALTURA,PRECIO_FINAL)Values('" + Globales.idIdentificador + "','" +  idMaterial + "','" + idTipo + "','" + idCristal + "','" + int.Parse(txtAnchuraVentana.Text) + "','" + int.Parse(txtAlturaVentana.Text) + "','" + txtPrecioFinalVentana.Text + "')";

            sqlCrearVentana.ExecuteNonQuery();

            conexion.Close();

            Globales.txtMessageBox = "Ventana creada con exito";

            MessageBoxForm messageBoxForm = new MessageBoxForm();
            messageBoxForm.BackColor = Color.White;

            messageBoxForm.Show();

        }

        //No permite el uso de letras en el campo.
        private void txtAnchuraVentana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //No permite el uso de letras en el campo.
        private void txtAlturaVentana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Calcula el precio final de la ventana con los datos indicados anteriormente en los inputs.
        private void btnCalcularPrecio_Click(object sender, EventArgs e)
        {
            conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            //Cogiendo el id de aquel material con ese nombre seleccionado

            string sqlQueryIdMaterial = "SELECT ID_MATERIAL FROM material where NOMBRE_MATERIAL = '" + cbxMaterialVentana.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlQueryIdMaterial, conexion);
            SqlDataReader mySqlDataReader = cmd.ExecuteReader();
            while (mySqlDataReader.Read())
            {

                idMaterial = int.Parse(mySqlDataReader["ID_MATERIAL"].ToString());

            }
            mySqlDataReader.Close();


            //Coger el precio al metro del material seleccionado a traves del id de ese material.

                string sqlQueryMaterialPrecio = "Select PRECIO_EL_METRO FROM material where ID_MATERIAL = '" + idMaterial + "'";
                SqlCommand cmdMaterialPrecio = new SqlCommand(sqlQueryMaterialPrecio, conexion);
                SqlDataReader sqlDataReaderMaterialPrecio = cmdMaterialPrecio.ExecuteReader();
                while(sqlDataReaderMaterialPrecio.Read())
                {
                    precioMaterial = float.Parse(sqlDataReaderMaterialPrecio["PRECIO_EL_METRO"].ToString());
                }


            conexion.Close();





            //Cogiendo el id de aquel tipo de ventana con ese nombre seleccionado.

            conexion.Open();


            string sqlQueryIdTipo = "SELECT ID_TIPO_VENTANA FROM tipoVentana where NOMBRE_VENTANA = '" + cbxTipoVentana.Text + "' ";
            SqlCommand cmd2 = new SqlCommand(sqlQueryIdTipo, conexion);
            SqlDataReader mySqlDataReader2 = cmd2.ExecuteReader();
            while (mySqlDataReader2.Read())
            {

                idTipo = int.Parse(mySqlDataReader2["ID_TIPO_VENTANA"].ToString());

            }
            mySqlDataReader2.Close();

            //Coger el precio de la ventana seleccionado a traves del id de ese tipo de ventana.

            string sqlQueryVentanaPrecio = "Select PRECIO_TIPO_VENTANA FROM tipoVentana where ID_TIPO_VENTANA = '" + idTipo + "'";
            SqlCommand cmdVentanaPrecio = new SqlCommand(sqlQueryVentanaPrecio, conexion);
            SqlDataReader sqlDataReaderVentanaPrecio = cmdVentanaPrecio.ExecuteReader();
            while (sqlDataReaderVentanaPrecio.Read())
            {
                precioTipo = float.Parse(sqlDataReaderVentanaPrecio["PRECIO_TIPO_VENTANA"].ToString());
            }

            conexion.Close();


            //Cogiendo el id de aquel cristal con ese nombre seleccionado.

            conexion.Open();


            string sqlQueryIdCristal = "SELECT ID_CRISTAL FROM cristal where NOMBRE_CRISTAL = '" + cbxCristalVentana.Text + "' ";
            SqlCommand cmd3 = new SqlCommand(sqlQueryIdCristal, conexion);
            SqlDataReader mySqlDataReader3 = cmd3.ExecuteReader();
            while (mySqlDataReader3.Read())
            {
                idCristal = int.Parse(mySqlDataReader3["ID_CRISTAL"].ToString());
            }
            mySqlDataReader3.Close();


            //Coger el precio de la ventana seleccionado a traves del id de ese tipo de ventana.

            string sqlQueryCristalPrecio = "Select PRECIO_CRISTAL FROM cristal where ID_CRISTAL = '" + idCristal + "'";
            SqlCommand cmdCristalPrecio = new SqlCommand(sqlQueryCristalPrecio, conexion);
            SqlDataReader sqlDataReaderCristalPrecio = cmdCristalPrecio.ExecuteReader();
            while (sqlDataReaderCristalPrecio.Read())
            {
                precioCristal = float.Parse(sqlDataReaderCristalPrecio["PRECIO_CRISTAL"].ToString());
            }

            conexion.Close();

            //Calculo de precio total de la ventana con la formula.


            precioFinalVentana = (((float.Parse(txtAlturaVentana.Text) + float.Parse(txtAnchuraVentana.Text)) / 100) * precioMaterial + precioCristal + precioTipo);

            
            txtPrecioFinalVentana.Text = precioFinalVentana.ToString();

            RealizarVentana.Enabled = true;

        }

        //No permite escribir letras.
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //No permite escribir letras.
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Coge los datos indicados de la reja y calcula el precio final mediante una formula.
        private void btnCalcularPrecioReja_Click(object sender, EventArgs e)
        {
            conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            //Cogiendo el id de aquel material con ese nombre seleccionado

            string sqlQueryIdMaterialReja = "SELECT ID_MATERIAL_REJA FROM materialReja where NOMBRE_REJA_MATERIAL = '" + cbxMaterialReja.Text + "' ";
            SqlCommand cmd = new SqlCommand(sqlQueryIdMaterialReja, conexion);
            SqlDataReader mySqlDataReader = cmd.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                idMaterialReja = int.Parse(mySqlDataReader["ID_MATERIAL_REJA"].ToString());
            }
            mySqlDataReader.Close();


            //Coger el precio al metro del material seleccionado a traves del id de ese material

            string sqlQueryMaterialPrecioReja = "Select PRECIO_REJA FROM materialReja where ID_MATERIAL_REJA = '" + idMaterialReja + "'";
            SqlCommand cmdMaterialPrecioReja = new SqlCommand(sqlQueryMaterialPrecioReja, conexion);
            SqlDataReader sqlDataReaderMaterialPrecioReja = cmdMaterialPrecioReja.ExecuteReader();
            while (sqlDataReaderMaterialPrecioReja.Read())
            {
                precioMaterialReja = float.Parse(sqlDataReaderMaterialPrecioReja["PRECIO_REJA"].ToString());
            }


            sqlDataReaderMaterialPrecioReja.Close();


            //Cogiendo el id de aquel tipo de reja con ese nombre seleccionado


            string sqlQueryIdTipoReja = "SELECT ID_TIPO_REJA FROM tipoReja where NOMBRE_REJA = '" + cbxTipoReja.Text + "' ";
            SqlCommand cmd2 = new SqlCommand(sqlQueryIdTipoReja, conexion);
            SqlDataReader mySqlDataReader2 = cmd2.ExecuteReader();
            while (mySqlDataReader2.Read())
            {

                idTipoReja = int.Parse(mySqlDataReader2["ID_TIPO_REJA"].ToString());

            }
            mySqlDataReader2.Close();

            //Coger el precio de la reja seleccionada a traves del id de ese tipo de reja

            string sqlQueryRejaPrecio = "Select PRECIO_TIPO_REJA FROM tipoReja where ID_TIPO_REJA = '" + idTipoReja + "'";
            SqlCommand cmdRejaPrecio = new SqlCommand(sqlQueryRejaPrecio, conexion);
            SqlDataReader sqlDataReaderRejaPrecio = cmdRejaPrecio.ExecuteReader();
            while (sqlDataReaderRejaPrecio.Read())
            {
                precioTipoReja = float.Parse(sqlDataReaderRejaPrecio["PRECIO_TIPO_REJA"].ToString());
            }

            conexion.Close();


            //Calculo de precio total de la Reja


            precioFinalReja = (((float.Parse(textBox1.Text) + float.Parse(textBox2.Text)) / 100) * precioMaterialReja + precioTipoReja);


            txtPrecioFinalReja.Text = precioFinalReja.ToString();

            btnRealizarReja.Enabled = true;
        }

        //Añade a la base de datos la nueva reja con sus datos y el precio final de la misma.
        private void btnRealizarReja_Click(object sender, EventArgs e)
        {
            conexion.Open();

            SqlCommand sqlCrearReja = conexion.CreateCommand();

            sqlCrearReja.CommandText = "Insert into rejaFinal(ID_USUARIO,ID_MATERIAL_REJA,ID_TIPO_REJA,ANCHURA_REJA,ALTURA_REJA,COLOR_REJA,PRECIO_FINAL_REJA)Values('" + Globales.idIdentificador + "','" + idMaterialReja + "','" + idTipoReja + "','" + int.Parse(textBox1.Text) + "','" + int.Parse(textBox2.Text) + "','"+cbxColorReja.Text+"','" + txtPrecioFinalReja.Text + "')";

            sqlCrearReja.ExecuteNonQuery();

            conexion.Close();

            Globales.txtMessageBox = "Reja creada con exito";

            MessageBoxForm messageBoxForm = new MessageBoxForm();
            messageBoxForm.BackColor = Color.White;

            messageBoxForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        //Muestra la informacion de la cerradura seleccionada.
        private void btnMostrarCerradura_Click(object sender, EventArgs e)
        {
          
            conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            string sqlQueryCerradura = "SELECT * FROM cerradura where NOMBRE_CERRADURA = '" +cbCerraduras.SelectedItem +"' ";
            SqlCommand cmd4 = new SqlCommand(sqlQueryCerradura, conexion);
            SqlDataReader mySqlDataReader4 = cmd4.ExecuteReader();
            while (mySqlDataReader4.Read())
            {
                idCerradura = int.Parse(mySqlDataReader4["ID_CERRADURA"].ToString());
                rtbCerradura.Text = mySqlDataReader4["DESCRIPCION_CERRADURA"].ToString();
                txtPrecioCerradura.Text = mySqlDataReader4["PRECIO_CERRADURA"].ToString();
                imagenMostrada = mySqlDataReader4["IMAGEN_CERRADURA"].ToString();


            }
            mySqlDataReader4.Close();


            conexion.Close();

            //Colocar la foto de la cerradura seleccionada.

            rutaImagen = Path.GetFullPath(@"../tipoCerradura/" + imagenMostrada );

                pbCerraduras.Image = Image.FromFile(rutaImagen);
                pbCerraduras.SizeMode = PictureBoxSizeMode.StretchImage;


            btnPedirCerradura.Enabled = true;
            
        }

        //Coge los datos indicados y añade una nueva cerradura a la base de datos.
        private void btnPedirCerradura_Click(object sender, EventArgs e)
        {
            conexion.Open();

            SqlCommand sqlPedirCerradura = conexion.CreateCommand();

            sqlPedirCerradura.CommandText = "Insert into cerraduraFinal(ID_USUARIO,ID_CERRADURA,PRECIO_FINAL_CERRADURA)Values('" + Globales.idIdentificador + "','" + idCerradura + "','" + decimal.Parse(txtPrecioCerradura.Text) + "')";

            sqlPedirCerradura.ExecuteNonQuery();

            conexion.Close();

            Globales.txtMessageBox = "Cerradura pedida con exito";

            MessageBoxForm messageBoxForm = new MessageBoxForm();
            messageBoxForm.BackColor = Color.White;

            messageBoxForm.Show();
        }
    }
}
