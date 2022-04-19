using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiLibro.basevisual;
using WindowsFormsApp1.clientews;
using WindowsFormsApp1.servicio;

namespace WindowsFormsApp1.formularios
{
    public partial class FormInsertarLibro2 : Form
    {
        public FormInsertarLibro2()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Libro libro = LibroSrv.Crear(numericUpDown1.Value, textBox1.Text, comboBox1.SelectedValue);

            var errores = LibroSrv.Validar(libro);
            if (errores == "")
            {
                await LibroClienteWS.Insertar(libro);
                label4.Text = "";
            } else
            {
                label4.Text= errores; 
            }
        }

        private async void FormInsertarLibro2_Load(object sender, EventArgs e)
        {
            label4.Text = "";
            panel1.Enabled = false;
            var listaCategorias = await CategoriaClienteWS.LeerAsync();
            comboBox1.DataSource = listaCategorias;
            panel1.Enabled = true;

        }
    }
}
