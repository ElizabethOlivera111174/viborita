using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_bibora
{
    public partial class Form1 : Form
    {
        Cola cabeza;
        Comida comida;
        Graphics g;
        Graphics c;
        int puntaje=0;
        int cuadro=10;
        int xdir = 0;
        int ydir = 0;
        Boolean ejex = true, ejey = true;
        public Form1()
        { 
            InitializeComponent();
            cabeza = new Cola(10, 10);
            comida = new Comida();
            g = ptvVentana.CreateGraphics();
            c = ptvVentana.CreateGraphics();
            
  
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Focus();
        }

        public void movimiento()
        { 
            cabeza.setxy(cabeza.verx() + xdir, cabeza.very()+ydir);



        }
       

        private void Tiempo_Tick(object sender, EventArgs e)
        {
           
            g.Clear(Color.White);
            comida.Dibujar(c);
            cabeza.Dibujar(g);
            movimiento();
            ChoqueCuerpo();
            ChoquePared();
            if (cabeza.interseccion(comida))
            {
                comida.colocar();
                cabeza.meter();
                
                puntaje++;
                lblPuntaje.Text=(Convert.ToString(puntaje));
            }
      

        }
        public void FindeJuego()
        {
            int ptj;
            ptj = Convert.ToInt32(lblPuntaje.Text);

            puntaje = 0;
            lblPuntaje.Text = "0";
            cabeza = new Cola(10, 10);
            comida = new Comida();
            cuadro = 0;
            xdir = 0;
            ydir = 0;
            ejex = true;
            ejey = true;

            MessageBox.Show("Perdiste");

            String Usuario;
            Usuario = Microsoft.VisualBasic.Interaction.InputBox("Ingrese nombre","Datos", "Records", 100, 0);
            Form3 c = new Form3(ptj, Usuario);
            c.Show();
            this.Hide();
        }
    
        public void ChoqueCuerpo()
        {
            Cola temp;
            try
            {
                temp = cabeza.VerSiguiente().VerSiguiente();
            }
            catch (Exception e)
            {

                temp = null;
            }
            while (temp != null)
            {
                if (cabeza.interseccion(temp))
                {
                    FindeJuego();
                }
                else
                {
                    temp = temp.VerSiguiente();
                }
            }
        }
        public void ChoquePared()
        {
          if( cabeza.verx()<0  || cabeza.verx()>580|| cabeza.very()<0|| cabeza.very() > 390)
            {
                FindeJuego();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (ejex)
            {
                if (e.KeyCode == Keys.Up)
                {
                    ydir = -cuadro;
                    xdir = 0;

                    ejex = false;
                    ejey = true;
                    
                }
                if (e.KeyCode == Keys.Down)
                {
                    ydir = cuadro;
                    xdir = 0;

                    ejex = false;
                    ejey = true;

                }
                
            }

            if (ejey)
            {
                if (e.KeyCode == Keys.Right)
                {
                    xdir = cuadro;
                    ydir = 0;

                    ejey = false;
                    ejex = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    xdir = -cuadro;
                    ydir = 0;

                    ejey = false;
                    ejex = true;

                }
                if (e.KeyCode == Keys.Escape)
                {
                    Application.Exit();
                }

            }
        }
    }
}
