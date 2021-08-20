using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Snake_bibora
{
    public partial class Form3 : Form
    {
        String Arreglo;
        int i;
        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string leer= File.ReadAllText("C:\\Users\\alumno\\source\\repos\\Snake bibora\\Snake bibora\\bin\\Debug\\Archivo.txt");
            txtLeer.Text = leer;
            txtLeer.Enabled = false;
        }
        public Form3(int ptj, string Usuario)
        {
            InitializeComponent();
            
            string leer = File.ReadAllText("C:\\Users\\alumno\\source\\repos\\Snake bibora\\Snake bibora\\bin\\Debug\\Archivo.txt");
            
            /*lstPuntaje.Items.Add(ptj +"...."+ Usuario);*/
            txtLeer.Text = leer + " " 
                          +ptj + "...." + Usuario;


                StreamWriter Archivo = new StreamWriter("C:\\Users\\alumno\\source\\repos\\Snake bibora\\Snake bibora\\bin\\Debug\\Archivo.txt");
          
                    Archivo.WriteLine(txtLeer.Text);
                    Archivo.Close();              
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea Reintentar?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                Form1 c = new Form1();
                c.Show();
                this.Hide();
            }
            if (r==DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            StreamWriter Archivo = new StreamWriter ("C:\\Users\\alumno\\source\\repos\\Snake bibora\\Snake bibora\\bin\\Debug\\Archivo.txt");
            txtLeer.Clear();
            Archivo.WriteLine("");
            Archivo.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Form2 c = new Form2();
            c.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
