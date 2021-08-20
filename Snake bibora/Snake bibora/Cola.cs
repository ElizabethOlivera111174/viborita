using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_bibora
{
    class Cola : Objeto
    {
        Cola sigiente;

        public Cola(int x, int y)
        {
            this.x = x;
            this.y = y;
            sigiente = null;
            
        }

        public void Dibujar(Graphics g)
        {
            if (sigiente != null)
            {
                sigiente.Dibujar(g);
            }
             g.FillRectangle(new SolidBrush(Color.Black), this.x, this.y, this.ancho, this.ancho);
        }

        public void meter()
        {
            if (sigiente == null)
            {
                sigiente = new Cola(this.x, this.y);
            }
            else
            {
                sigiente.meter();
            }
                
        }

        public void setxy(int x, int y)
        {
            if(sigiente != null)
            {
                sigiente.setxy(this.x,this.y);
            }
            this.x = x;
            this.y = y;
        }
        
        public int verx()
        {
            return this.x;
        }

        public int very()
        {
            return this.y;
        }
        public Cola VerSiguiente()
        {
            return sigiente;
        }
    }
}


