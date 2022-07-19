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
    public partial class Mis_Pedidos : Form
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
        
        
        public Mis_Pedidos()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);
        }

        private void Mis_Pedidos_Load(object sender, EventArgs e)
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

                //MessageBox.Show(cadenaConexion);

            }
            catch
            {
                MessageBox.Show("Nombre del servidor no introducido o invalido");

            }

            dgbMisPedidos.Refresh();

            try
            {
                //Si el rol del usuario es 0 podra ver la informacion de todos los pedidos de todos los usuarios incluidos los suyos, si es 1 solo podra ver la informacion suya
                if (Globales.rolIdentificador == 0)
                {
                    dgbPedidosVentana.Refresh();

                    //Cargar tabla ventanaFinal
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    source = new BindingSource();

                    string consultaVentanas = "SELECT * FROM ventanaFinal";

                    adaptador = new SqlDataAdapter(consultaVentanas, conexion);

                    //Definicion de conjunto de datos
                    ds = new DataSet();


                    //LLeno el cnjunto con lo que tengo en el adaptador
                    adaptador.Fill(ds, "ventanaFinal");

                    source.DataSource = ds;
                    source.DataMember = "ventanaFinal";

                    dgbPedidosVentana.DataSource = source;
                    //bindingNavigator1.BindingSource = source;
                    cb = new SqlCommandBuilder(adaptador);

                    //Barrar de navegacion
                    //dgbMisPedidos.BindingSource = source;


                    dgbPedidosVentana.Columns["ID_VENTANA_FINAL"].HeaderText = "ID";
                    dgbPedidosVentana.Columns["ID_USUARIO"].HeaderText = "Usuario";
                    dgbPedidosVentana.Columns["ID_MATERIAL"].HeaderText = "Material";
                    dgbPedidosVentana.Columns["ID_TIPO_VENTANA"].HeaderText = "Tipo";
                    dgbPedidosVentana.Columns["ID_TIPO_CRISTAL"].HeaderText = "Color";
                    dgbPedidosVentana.Columns["ANCHURA"].HeaderText = "Anchura";
                    dgbPedidosVentana.Columns["ALTURA"].HeaderText = "Altura";
                    dgbPedidosVentana.Columns["PRECIO_FINAL"].HeaderText = "Precio";

                    conexion.Close();


                    //Cargar tabla REJAFINAL para admin
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    source = new BindingSource();

                    string consultaTodo = "SELECT * FROM rejaFinal";

                    adaptador = new SqlDataAdapter(consultaTodo, conexion);

                    //Definicion de conjunto de datos
                    ds = new DataSet();

                    //LLeno el conjunto con lo que tengo en el adaptador
                    adaptador.Fill(ds, "rejaFInal");

                    source.DataSource = ds;
                    source.DataMember = "rejaFinal";

                    dgbMisPedidos.DataSource = source;

                    //bindingNavigator1.BindingSource = source;
                    cb = new SqlCommandBuilder(adaptador);

                    //Barrar de navegacion
                    //dgbMisPedidos.BindingSource = source;

                    dgbMisPedidos.Columns["ID_REJA_FINAL"].HeaderText = "ID";
                    dgbMisPedidos.Columns["ID_USUARIO"].HeaderText = "Usuario";
                    dgbMisPedidos.Columns["ID_MATERIAL_REJA"].HeaderText = "Material";
                    dgbMisPedidos.Columns["ID_TIPO_REJA"].HeaderText = "Tipo";
                    dgbMisPedidos.Columns["ANCHURA_REJA"].HeaderText = "Anchura";
                    dgbMisPedidos.Columns["ALTURA_REJA"].HeaderText = "Altura";
                    dgbMisPedidos.Columns["COLOR_REJA"].HeaderText = "Color";
                    dgbMisPedidos.Columns["PRECIO_FINAL_REJA"].HeaderText = "Precio";

                    conexion.Close();


                    //**************************************************++
                    //Cargar tabla CERRADURAFINAL para admin
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    source = new BindingSource();

                    string consultaCerradura = "SELECT * FROM cerraduraFinal";

                    adaptador = new SqlDataAdapter(consultaCerradura, conexion);

                    //Definicion de conjunto de datos
                    ds = new DataSet();

                    //LLeno el conjunto con lo que tengo en el adaptador
                    adaptador.Fill(ds, "cerraduraFinal");

                    source.DataSource = ds;
                    source.DataMember = "cerraduraFinal";

                    dgbMisCerraduras.DataSource = source;


                    cb = new SqlCommandBuilder(adaptador);

                    dgbMisCerraduras.Columns["ID_CERRADURA_FINAL"].HeaderText = "ID";
                    dgbMisCerraduras.Columns["ID_USUARIO"].HeaderText = "Usuario";
                    dgbMisCerraduras.Columns["ID_CERRADURA"].HeaderText = "Cerradura";
                    dgbMisCerraduras.Columns["PRECIO_FINAL_CERRADURA"].HeaderText = "Precio";


                    conexion.Close();

                }
                else
                {

                    btnCrearFactura.Visible = false;
                    btnCrearFacturaReja.Visible = false;
                    btnCrearFacturaCerradura.Visible = false;

                    dgbPedidosVentana.Refresh();

                    //Cargar tabla ventanaFinal
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    source = new BindingSource();

                    string consultaVentanas = "SELECT * FROM ventanaFinal where ID_USUARIO = '" + Globales.idIdentificador + "'";

                    adaptador = new SqlDataAdapter(consultaVentanas, conexion);

                    //Definicion de conjunto de datos
                    ds = new DataSet();


                    //LLeno el conjunto con lo que tengo en el adaptador
                    adaptador.Fill(ds, "ventanaFinal");

                    source.DataSource = ds;
                    source.DataMember = "ventanaFinal";

                    dgbPedidosVentana.DataSource = source;
                    //bindingNavigator1.BindingSource = source;
                    cb = new SqlCommandBuilder(adaptador);

                    //Barrar de navegacion
                    //dgbMisPedidos.BindingSource = source;


                    dgbPedidosVentana.Columns["ID_VENTANA_FINAL"].Visible = false;
                    dgbPedidosVentana.Columns["ID_USUARIO"].Visible = false;
                    dgbPedidosVentana.Columns["ID_MATERIAL"].HeaderText = "Material";
                    dgbPedidosVentana.Columns["ID_TIPO_VENTANA"].HeaderText = "Tipo";
                    dgbPedidosVentana.Columns["ID_TIPO_CRISTAL"].HeaderText = "Color";
                    dgbPedidosVentana.Columns["ANCHURA"].HeaderText = "Anchura";
                    dgbPedidosVentana.Columns["ALTURA"].HeaderText = "Altura";
                    dgbPedidosVentana.Columns["PRECIO_FINAL"].HeaderText = "Precio";

                    conexion.Close();


                    //Cargar tabla REJAFINAL 
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    source = new BindingSource();

                    string consultaTodo = "SELECT * FROM rejaFinal where ID_USUARIO = '" + Globales.idIdentificador + "'";

                    adaptador = new SqlDataAdapter(consultaTodo, conexion);

                    //Definicion de conjunto de datos
                    ds = new DataSet();

                    //LLeno el conjunto con lo que tengo en el adaptador
                    adaptador.Fill(ds, "rejaFInal");

                    source.DataSource = ds;
                    source.DataMember = "rejaFinal";

                    dgbMisPedidos.DataSource = source;

                    cb = new SqlCommandBuilder(adaptador);

                    //Barrar de navegacion

                    dgbMisPedidos.Columns["ID_REJA_FINAL"].Visible = false;
                    dgbMisPedidos.Columns["ID_USUARIO"].Visible = false;
                    dgbMisPedidos.Columns["ID_MATERIAL_REJA"].HeaderText = "Material";
                    dgbMisPedidos.Columns["ID_TIPO_REJA"].HeaderText = "Tipo";
                    dgbMisPedidos.Columns["ANCHURA_REJA"].HeaderText = "Anchura";
                    dgbMisPedidos.Columns["ALTURA_REJA"].HeaderText = "Altura";
                    dgbMisPedidos.Columns["COLOR_REJA"].HeaderText = "Color";
                    dgbMisPedidos.Columns["PRECIO_FINAL_REJA"].HeaderText = "Precio";

                    conexion.Close();

                    //Cargar tabla Cerradura
                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();
                    source = new BindingSource();

                    string consultaCerradura = "SELECT * FROM cerraduraFinal where ID_USUARIO = '" + Globales.idIdentificador + "'";

                    adaptador = new SqlDataAdapter(consultaCerradura, conexion);

                    //Definicion de conjunto de datos
                    ds = new DataSet();

                    //LLeno el conjunto con lo que tengo en el adaptador
                    adaptador.Fill(ds, "cerraduraFinal");

                    source.DataSource = ds;
                    source.DataMember = "cerraduraFinal";

                    dgbMisCerraduras.DataSource = source;

                    cb = new SqlCommandBuilder(adaptador);

                    //Barrar de navegacion  

                    dgbMisCerraduras.Columns["ID_CERRADURA_FINAL"].Visible = false;
                    dgbMisCerraduras.Columns["ID_USUARIO"].Visible = false;
                    dgbMisCerraduras.Columns["ID_CERRADURA"].HeaderText = "Id cerradura";
                    dgbMisCerraduras.Columns["PRECIO_FINAL_CERRADURA"].HeaderText = "Precio";

                    conexion.Close();

                }
            }catch
            {
                MessageBox.Show("Error");
            }

        }


        //Desencripta la cadena de conexion
        public string desencriptar(string valor)
        {

            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Cierra el form de mis_pedidos y muestra el form principal
        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            principalform.Show();
        }

        //Crea la factura del pedido selecionado en ventana
        private void btnCrearFactura_Click(object sender, EventArgs e)
        {
            Imprimir imprimir = new Imprimir();
            
            imprimir.lblTipoImpresion.Text = "Ventana";

            imprimir.Show();
            
            this.Hide();
        }

        //Crea la factura del pedido selecionado en reja
        private void btnCrearFacturaReja_Click(object sender, EventArgs e)
        {
            Imprimir imprimir = new Imprimir();

            imprimir.lblTipoImpresion.Text = "Reja";

            imprimir.Show();
            this.Hide();
        }

        //Crea la factura del pedido selecionado en cerradura
        private void btnCrearFacturaCerradura_Click(object sender, EventArgs e)
        {
            Imprimir imprimir = new Imprimir();

            imprimir.lblTipoImpresion.Text = "Cerradura";

            imprimir.Show();
            this.Hide();
        }

        //Selecciono la fila y obtengo el id
        private void dgbPedidosVentana_Click(object sender, EventArgs e)
        {
            try
            {
                //cojo el id de cada tabla
                Globales.id_factura = dgbPedidosVentana.CurrentRow.Cells[0].Value.ToString();
            }catch
            {
                MessageBox.Show("Error");
            }

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }


        //Selecciono la fila y obtengo el id
        private void dgbMisPedidos_Click(object sender, EventArgs e)
        {
            Globales.id_factura_reja = dgbMisPedidos.CurrentRow.Cells[0].Value.ToString();
        }

        //Selecciono la fila y obtengo el id
        private void dgbMisCerraduras_Click(object sender, EventArgs e)
        {
            Globales.id_factura_cerradura = dgbMisCerraduras.CurrentRow.Cells[0].Value.ToString();
        }


        //Al hacer doble click muestra la informacion del campo seleccionado y va modificando el form donde se muestra dependiendo del tipo de producto seleccinado

        //Al hacer doble clik muestra los datos del campo seleccionado Ventana
        private void dgbPedidosVentana_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Informacion info = new Informacion();

                Globales.id_factura = dgbPedidosVentana.CurrentRow.Cells[0].Value.ToString();

                //Ventana
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                String ventanaInfo = "Select usuarios.NOMBRE, material.NOMBRE_MATERIAL, tipoVentana.NOMBRE_VENTANA, cristal.NOMBRE_CRISTAL, ventanaFinal.ANCHURA, ventanaFinal.ALTURA, ventanaFinal.PRECIO_FINAL from usuarios, material, tipoVentana, cristal, ventanaFinal where usuarios.ID = ventanaFinal.ID_USUARIO and material.ID_MATERIAL = ventanaFinal.ID_MATERIAL and tipoVentana.ID_TIPO_VENTANA = ventanaFinal.ID_TIPO_VENTANA and cristal.ID_CRISTAL = ventanaFinal.ID_TIPO_CRISTAL and ventanaFinal.ID_VENTANA_FINAL = '" + int.Parse(Globales.id_factura) + "'";
                cmd = new SqlCommand(ventanaInfo, conexion);

                reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    info.lblNombre.Text = reader["NOMBRE"].ToString();
                    info.lblmaterial.Text = reader["NOMBRE_MATERIAL"].ToString();
                    info.lblTipo.Text = reader["NOMBRE_VENTANA"].ToString();
                    info.lblCristal.Text = reader["NOMBRE_CRISTAL"].ToString();
                    info.lblAncho.Text = reader["ANCHURA"].ToString();
                    info.lblAlto.Text = reader["ALTURA"].ToString();
                    info.lblPrecio.Text = reader["PRECIO_FINAL"].ToString();

                }

                reader.Close();
                conexion.Close();

                info.Show();

            }
            catch
            {

            }
        }

        private void dgbMisPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //Al hacer doble clik muestra los datos del campo seleccionado Reja
        private void dgbMisPedidos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Informacion info = new Informacion();

                Globales.id_factura_reja = dgbMisPedidos.CurrentRow.Cells[0].Value.ToString();

                //Reja
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                String rejaInfo = "Select usuarios.NOMBRE, materialReja.NOMBRE_REJA_MATERIAL, tipoReja.NOMBRE_REJA, rejaFinal.ANCHURA_REJA, rejaFinal.ALTURA_REJA, rejaFinal.COLOR_REJA, rejaFinal.PRECIO_FINAL_REJA from usuarios, materialReja, tipoReja, rejaFinal where usuarios.ID = rejaFinal.ID_USUARIO and materialReja.ID_MATERIAL_REJA = rejaFinal.ID_MATERIAL_REJA and tipoReja.ID_TIPO_REJA = rejaFinal.ID_TIPO_REJA and rejaFinal.ID_REJA_FINAL = '" + int.Parse(Globales.id_factura_reja) + "'";
                cmd = new SqlCommand(rejaInfo, conexion);

                reader = cmd.ExecuteReader();

                info.lblTcristal.Text = "Color:";

                while (reader.Read())
                {
                    info.lblNombre.Text = reader["NOMBRE"].ToString();
                    info.lblmaterial.Text = reader["NOMBRE_REJA_MATERIAL"].ToString();
                    info.lblTipo.Text = reader["NOMBRE_REJA"].ToString();

                    info.lblCristal.Text = reader["COLOR_REJA"].ToString();
                    info.lblAncho.Text = reader["ANCHURA_REJA"].ToString();
                    info.lblAlto.Text = reader["ALTURA_REJA"].ToString();
                    info.lblPrecio.Text = reader["PRECIO_FINAL_REJA"].ToString();

                }

                reader.Close();
                conexion.Close();

                info.Show();
            }
            catch
            {

            }

        }


        //Al hacer doble clik muestra los datos del campo seleccionado Cerradura
        private void dgbMisCerraduras_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                Informacion info = new Informacion();

                Globales.id_factura_cerradura = dgbMisCerraduras.CurrentRow.Cells[0].Value.ToString();

                //Reja
                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();
                String cerraduraInfo = "Select usuarios.NOMBRE,cerradura.NOMBRE_CERRADURA, cerraduraFinal.PRECIO_FINAL_CERRADURA from usuarios, cerradura, cerraduraFinal where usuarios.ID = cerraduraFinal.ID_USUARIO and cerradura.ID_CERRADURA = cerraduraFinal.ID_CERRADURA and cerraduraFinal.ID_CERRADURA_FINAL = '" + int.Parse(Globales.id_factura_cerradura) + "'";

                cmd = new SqlCommand(cerraduraInfo, conexion);

                reader = cmd.ExecuteReader();

                //Ocultamos material
                info.lblmaterial.Visible = false;
                info.lblTmaterial.Visible = false;

                //Ocultamos cristal
                info.lblTcristal.Visible = false;
                info.lblCristal.Visible = false;

                //Ocultamos ancho y alto

                info.lblTancho.Visible = false;
                info.lblAncho.Visible = false;

                info.lblTalto.Visible = false;
                info.lblAlto.Visible = false;

                //Movemos elementos
                info.lblTtipo.Location = new Point(26, 154);
                info.lblTipo.Location = new Point(157, 158);

                info.lblTprecio.Location = new Point(26, 208);
                info.lblPrecio.Location = new Point(157, 212);

                info.simbolo.Location = new Point(265, 213);


                while (reader.Read())
                {
                    info.lblNombre.Text = reader["NOMBRE"].ToString();
                    info.lblTipo.Text = reader["NOMBRE_CERRADURA"].ToString();                
                    info.lblPrecio.Text = reader["PRECIO_FINAL_CERRADURA"].ToString();
                }

                reader.Close();
                conexion.Close();
                info.Show();
            }
            catch
            {
                
            }
        }
    }
}
