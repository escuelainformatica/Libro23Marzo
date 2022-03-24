using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiLibro.basevisual;
using WindowsFormsApp1.clientews;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e) 
        {
            button1.Enabled = false;

            LibroClienteWS libroClienteWS = new LibroClienteWS();
            var listado = await libroClienteWS.LeerLibrosAsync();
            if(listado==null)
            {
                MessageBox.Show("No hay conexion disponble. Intentelo mas adelante");
            }

            sfDataGrid1.DataSource = listado;

            button1.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            Libro libro = new Libro();
            libro.Id = 11;
            libro.Titulo = "libro #11";
            libro.IdCategoria = 2;
            
            LibroClienteWS libroClienteWS = new LibroClienteWS();
            await libroClienteWS.Insertar(libro);


            // Thread.Sleep(40000);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var catclientws = new CategoriaClienteWS();

            var categorias = await catclientws.LeerAsync();

            comboBox1.DataSource = categorias;

        }
    }
}
