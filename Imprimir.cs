using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace CerrajeriaCamp
{
    public partial class Imprimir : Form
    {
        private ConexionEncriptada.LIBRERIA.AES aes = new ConexionEncriptada.LIBRERIA.AES();
        private static string nombreServidor = "";
        private string cadenaConexion;
        private SqlConnection conexion;
        SqlCommand cmd;
        SqlDataReader reader;

        PdfWriter pdfWriter;


        public string sacarTodo = "";

        MessageBoxForm messageBoxForm = new MessageBoxForm();

        Mis_Pedidos mis_Pedidos = new Mis_Pedidos();


        public Imprimir()
        {
            InitializeComponent();
            conexion = new SqlConnection(cadenaConexion);
        }

        private void Imprimir_Load(object sender, EventArgs e)
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
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            mis_Pedidos.Show();
        }


        private void btnImprimir_Click_1(object sender, EventArgs e)
        {

            crearPDF();
            enviarCorreo();
         
        }


        private void crearPDF()
        {
            //Imagen predefinida*****************************************
            ImageData imageData = ImageDataFactory.Create("Logo.png");
            iText.Layout.Element.Image pdfImage = new iText.Layout.Element.Image(imageData);
            //Texto predefinido******************************************
            var titulo = new Paragraph("Tabla del encargo y su valor").SetFontColor(ColorConstants.ORANGE);
            var nombre = new Paragraph("Empresa: Cerrajeria Camp").SetFontColor(ColorConstants.BLACK);
            var correo = new Paragraph("Correo: cerrajeriCamp@gmail.com").SetFontColor(ColorConstants.BLACK);
            var telefono = new Paragraph("Telefono: 999-999-999").SetFontColor(ColorConstants.BLACK);

            var lema = new Paragraph("Expertos en aluminio y automatismos").SetFontColor(ColorConstants.BLACK);


            nombre.SetRelativePosition(190, -220, 0, 0);

            lema.SetRelativePosition(190, -210, 0, 0);

            correo.SetRelativePosition(190, -200, 0, 0);

            telefono.SetRelativePosition(190, -190, 0, 0);

            

            pdfImage.Scale(3, 3);
            pdfImage.SetRelativePosition(0, 0, 0, 0);



            if (lblTipoImpresion.Text == "Ventana")
            {

                if (txtPdf.Text == "")
                {
                     pdfWriter = new PdfWriter("Factura-ventana.pdf");
                }
                else
                {
                     pdfWriter = new PdfWriter(txtPdf.Text + ".pdf");
                }
                
                
                PdfDocument pdf = new PdfDocument(pdfWriter);

                Document documento = new Document(pdf, PageSize.LETTER);
                
                //Añadimos al documento
                documento.Add(pdfImage);
                documento.Add(nombre);
                documento.Add(lema);
                documento.Add(correo);
                documento.Add(telefono);
                documento.Add(titulo);
                
                //**********************************************

                documento.SetMargins(60, 20, 55, 20);

                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);



                string[] columnas = { "Usuario", "Material", "Tipo Ventana", "Tipo Cristal", "Anchura", "Altura", "Precio Final €" };

                //Tamaño de las columnas
                float[] tamanios = { 2, 2, 3, 3, 2, 2, 3 };
                Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
                //Coge el 100% de la hoja
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                foreach (string columna in columnas)
                {
                    //Pone encabezado a la columnas
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
                }




                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sqlQuery = "Select usuarios.NOMBRE, usuarios.ID, material.NOMBRE_MATERIAL, tipoVentana.NOMBRE_VENTANA, cristal.NOMBRE_CRISTAL, ventanaFinal.ANCHURA, ventanaFinal.ALTURA, ventanaFinal.PRECIO_FINAL from usuarios, material, tipoVentana, cristal, ventanaFinal where usuarios.ID = ventanaFinal.ID_USUARIO and material.ID_MATERIAL = ventanaFinal.ID_MATERIAL and tipoVentana.ID_TIPO_VENTANA = ventanaFinal.ID_TIPO_VENTANA and cristal.ID_CRISTAL = ventanaFinal.ID_TIPO_CRISTAL and ventanaFinal.ID_VENTANA_FINAL = '" + int.Parse(Globales.id_factura) + "'";



                SqlCommand cmd = new SqlCommand(sqlQuery, conexion);

                SqlDataReader mySqlDataReader = cmd.ExecuteReader();

                while (mySqlDataReader.Read())
                {

                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["NOMBRE"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["NOMBRE_MATERIAL"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["NOMBRE_VENTANA"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["NOMBRE_CRISTAL"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["ANCHURA"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["ALTURA"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["PRECIO_FINAL"].ToString()).SetFont(fontContenido)));

                    Globales.id_usuario = int.Parse(mySqlDataReader["ID"].ToString());

                }

                documento.Add(tabla);

                documento.Close();
            }
            else if (lblTipoImpresion.Text == "Reja")
            {


                if (txtPdf.Text == "")
                {
                    pdfWriter = new PdfWriter("Factura-reja.pdf");
                }
                else
                {
                    pdfWriter = new PdfWriter(txtPdf.Text + ".pdf");
                }
                PdfDocument pdf = new PdfDocument(pdfWriter);

                    Document documento = new Document(pdf, PageSize.LETTER);
                    

                    

                    //Añadimos al documento
                    documento.Add(pdfImage);
                    documento.Add(nombre);
                    documento.Add(lema);
                    documento.Add(correo);
                    documento.Add(telefono);
                    documento.Add(titulo);


                
                    //**********************************************

                    documento.SetMargins(60, 20, 55, 20);

                    PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);


                    PdfFont fontParrafos = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);


                    string[] columnas = { "Usuario", "Material", "Tipo Reja", "Anchura", "Altura", "Color","Precio Final €" };

                    //Tamaño de las columnas
                    float[] tamanios = { 2, 2, 3, 3, 2, 2, 3 };
                    Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
                    //Coge el 100% de la hoja
                    tabla.SetWidth(UnitValue.CreatePercentValue(100));

                    foreach (string columna in columnas)
                    {
                        //Pone encabezado a la columnas
                        tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
                    }




                    conexion = new SqlConnection(cadenaConexion);
                    conexion.Open();

                    string sqlQuery = "Select usuarios.NOMBRE, usuarios.ID, materialReja.NOMBRE_REJA_MATERIAL, tipoReja.NOMBRE_REJA, rejaFinal.ANCHURA_REJA, rejaFinal.ALTURA_REJA, rejaFinal.COLOR_REJA, rejaFinal.PRECIO_FINAL_REJA from usuarios, materialReja, tipoReja, rejaFinal where usuarios.ID = rejaFinal.ID_USUARIO and materialReja.ID_MATERIAL_REJA = rejaFinal.ID_MATERIAL_REJA and tipoReja.ID_TIPO_REJA = rejaFinal.ID_TIPO_REJA and rejaFinal.ID_REJA_FINAL = '" + int.Parse(Globales.id_factura_reja) + "'";



                    SqlCommand cmd = new SqlCommand(sqlQuery, conexion);

                    SqlDataReader mySqlDataReader = cmd.ExecuteReader();

                    while (mySqlDataReader.Read())
                    {

                        tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["NOMBRE"].ToString()).SetFont(fontContenido)));
                        tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["NOMBRE_REJA_MATERIAL"].ToString()).SetFont(fontContenido)));
                        tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["NOMBRE_REJA"].ToString()).SetFont(fontContenido)));
                        tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["ANCHURA_REJA"].ToString()).SetFont(fontContenido)));
                        tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["ALTURA_REJA"].ToString()).SetFont(fontContenido)));
                        tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["COLOR_REJA"].ToString()).SetFont(fontContenido)));
                        tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["PRECIO_FINAL_REJA"].ToString()).SetFont(fontContenido)));

                        Globales.id_usuario = int.Parse(mySqlDataReader["ID"].ToString());

                    }

                    documento.Add(tabla);

                    documento.Close();
                
            }
            else if(lblTipoImpresion.Text == "Cerradura")
            {
                if (txtPdf.Text == "")
                {
                    pdfWriter = new PdfWriter("Factura-cerradura.pdf");
                }
                else
                {
                    pdfWriter = new PdfWriter(txtPdf.Text + ".pdf");
                }
                PdfDocument pdf = new PdfDocument(pdfWriter);

                Document documento = new Document(pdf, PageSize.LETTER);


                //Añadimos al documento
                documento.Add(pdfImage);
                documento.Add(nombre);
                documento.Add(lema);
                documento.Add(correo);
                documento.Add(telefono);
                documento.Add(titulo);
                //**********************************************

                documento.SetMargins(60, 20, 55, 20);

                PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);



                string[] columnas = { "Usuario", "Cerradura", "Descripcion", "Precio Final €" };

                //Tamaño de las columnas
                float[] tamanios = { 2, 2, 5, 3 };
                Table tabla = new Table(UnitValue.CreatePercentArray(tamanios));
                //Coge el 100% de la hoja
                tabla.SetWidth(UnitValue.CreatePercentValue(100));

                foreach (string columna in columnas)
                {
                    //Pone encabezado a la columnas
                    tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));
                }




                conexion = new SqlConnection(cadenaConexion);
                conexion.Open();

                string sqlQuery = "Select usuarios.NOMBRE,usuarios.ID, cerradura.NOMBRE_CERRADURA, cerradura.DESCRIPCION_CERRADURA, cerraduraFinal.PRECIO_FINAL_CERRADURA from usuarios, cerradura, cerraduraFinal where usuarios.ID = cerraduraFinal.ID_USUARIO and cerradura.ID_CERRADURA = cerraduraFinal.ID_CERRADURA and cerraduraFinal.ID_CERRADURA_FINAL = '" + int.Parse(Globales.id_factura_cerradura) + "'";



                SqlCommand cmd = new SqlCommand(sqlQuery, conexion);

                SqlDataReader mySqlDataReader = cmd.ExecuteReader();

                while (mySqlDataReader.Read())
                {

                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["NOMBRE"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["NOMBRE_CERRADURA"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["DESCRIPCION_CERRADURA"].ToString()).SetFont(fontContenido)));
                    tabla.AddCell(new Cell().Add(new Paragraph(mySqlDataReader["PRECIO_FINAL_CERRADURA"].ToString()).SetFont(fontContenido)));

                    Globales.id_usuario = int.Parse(mySqlDataReader["ID"].ToString());

                }

                documento.Add(tabla);

                documento.Close();

            }



        }


        private void enviarCorreo()
        {

            

            string correoValido = "";

            conexion = new SqlConnection(cadenaConexion);
            conexion.Open();

            string sqlQuery = "Select usuarios.CORREO from usuarios where usuarios.ID = '"+Globales.id_usuario+"'";

            SqlCommand cmd = new SqlCommand(sqlQuery, conexion);

            SqlDataReader mySqlDataReader = cmd.ExecuteReader();

            while (mySqlDataReader.Read())
            {

                correoValido = mySqlDataReader["CORREO"].ToString();
                


            }



            try
            {
                MailMessage mensaje = new MailMessage("cerrajericamp@gmail.com", correoValido, "Factura", "Factura con presupuesto del pedido");
                mensaje.Attachments.Add(new Attachment(txtPdf.Text+".pdf"));


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
                
                Globales.txtMessageBox = "No se encuentra el archivo pdf.";
                messageBoxForm.Show();
            }
        }



        private void ImprimirDocumento(object sender, PrintPageEventArgs e)
        {
           


           
           
        }



        //Desencriptar la cadena encriptada
        public string desencriptar(string valor)
        {

            return aes.Decrypt(valor, ConexionEncriptada.LIBRERIA.Desencryptacion.appPwdUnique, int.Parse("256"));


        }

      
    }
}
