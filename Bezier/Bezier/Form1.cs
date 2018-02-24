using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezier
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen lapiz1,lapiz2;
        List<Point> lista = new List<Point>();
        List<Point> lista_auxiliar = new List<Point>();
        bool first = true;
        int x_origen,y_origen;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            lapiz1 = new Pen(Color.Green,3);
            lapiz2 = new Pen(Color.Black, 1);
            this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrearPuntos();
            DibujarCurva();
        }

        private void DibujarCurva()
        {

            
            for (int i = 1; i < lista_auxiliar.Count; i++)
                g.DrawLine(lapiz2, lista_auxiliar[i - 1], lista_auxiliar[i]);
            

                for (int i = 1; i < lista.Count; i++) {

if (checkBox1.Checked)g.DrawLine(lapiz2, lista[i - 1], lista[i]);
}
            for (int i =0; i < lista.Count; i++)
            {
                g.DrawRectangle(lapiz1, lista[i].X, lista[i].Y, 5, 5);
              
            }
        }

        void CrearPuntos()
        {
            int n = lista.Count;

            lista_auxiliar.Clear();
            double paso = 1 / 50.0;

            for (double t = 0.01; t < 1; t += paso)
            {
                double x = 0;
                double y = 0;
                for (int i = 0; i < n; i++) {
                    double f = funcion(n, i);
                    int n_ = n - 1 - i;
                    double z_ = (Math.Pow(1 - t, n_));

                    double _t = (Math.Pow(t, i));
                    x += f * lista[i].X * z_ * _t ;
                    y += f * lista[i].Y * z_ * _t ;
                    
                }
                lista_auxiliar.Add(new Point((int)x,(int)y));
            }

            DibujarCurva();
        }

        int factorial(int numero) {
            int resultado = 1;
            for (int i = 1; i <= numero; i++)
                resultado *= i;
            return resultado;
        }

        double funcion(int n, int i) {
            n = n - 1;
            int n_ = (factorial(n));
            int i_ = (factorial(i));
            int n_i= factorial(n - i);
            int resultado = (n_)/ (i_*n_i);
            return (double)resultado;
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            lista.Clear();
            first = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            g.Clear(Color.White);
            int tx = 0;
            int ty = 0;

            if (e.KeyCode == Keys.S)
                ty += 10;
            if (e.KeyCode == Keys.W)
                ty -= 10;
            if (e.KeyCode == Keys.A)
                tx -= 10;
            if (e.KeyCode == Keys.D)
                tx += 10;

            if (e.KeyCode == Keys.S || e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    var p = lista[i];
                    p.X += tx;
                    p.Y += ty;
                    lista[i] = p;
                }

                for (int i = 0; i < lista_auxiliar.Count; i++)
                {
                    var p = lista_auxiliar[i];
                    p.X += tx;
                    p.Y += ty;
                    lista_auxiliar[i] = p;
                }

               
            }


            if (e.KeyCode == Keys.I)
            {
                lapiz2.Color = (Color.Green);

                for (int i = 0; i < lista.Count; i++)
                {
                    double angulo = -45 * (Math.PI / 180);

                    var p = lista[i];
                    double x_p = 0;
                    double y_p = 0;
                    double sen = Math.Sin(angulo);
                    double cos = Math.Cos(angulo);
                    x_p = x_origen + ((p.X - x_origen) * cos) - ((p.Y - y_origen) * sen);
                    y_p = y_origen + ((p.Y - y_origen) * cos) + ((p.X - x_origen) * sen);

                    x_p = Math.Ceiling(x_p) - x_p <= x_p - Math.Floor(x_p) ? Math.Ceiling(x_p) : Math.Floor(x_p);
                    y_p = Math.Ceiling(y_p) - y_p <= y_p - Math.Floor(y_p) ? Math.Ceiling(y_p) : Math.Floor(y_p);

                    p.X = (int)(x_p);
                    p.Y = (int)(y_p);
                    lista[i] = p;

                }

                for (int i = 0; i < lista_auxiliar.Count; i++)
                {
                    double angulo = -45 * (Math.PI / 180);

                    var p = lista_auxiliar[i];
                    double x_p = 0;
                    double y_p = 0;
                    double sen = Math.Sin(angulo);
                    double cos = Math.Cos(angulo);
                    x_p = x_origen + ((p.X - x_origen) * cos) - ((p.Y - y_origen) * sen);
                    y_p = y_origen + ((p.Y - y_origen) * cos) + ((p.X - x_origen) * sen);

                    x_p = Math.Ceiling(x_p) - x_p <= x_p - Math.Floor(x_p) ? Math.Ceiling(x_p) : Math.Floor(x_p);
                    y_p = Math.Ceiling(y_p) - y_p <= y_p - Math.Floor(y_p) ? Math.Ceiling(y_p) : Math.Floor(y_p);

                    p.X = (int)(x_p);
                    p.Y = (int)(y_p);
                    lista_auxiliar[i] = p;

                }

            }
            if (e.KeyCode == Keys.K)
            {
                lapiz2.Color = (Color.Green);
                for (int i = 0; i < lista.Count; i++)
                {
                    double angulo = 45 * (Math.PI / 180);

                    var p = lista[i];
                    double x_p = 0;
                    double y_p = 0;
                    double sen = Math.Sin(angulo);
                    double cos = Math.Cos(angulo);
                    x_p = x_origen + ((p.X - x_origen) * cos) - ((p.Y - y_origen) * sen);
                    y_p = y_origen + ((p.Y - y_origen) * cos) + ((p.X - x_origen) * sen);

                    x_p = Math.Ceiling(x_p) - x_p <= x_p - Math.Floor(x_p) ? Math.Ceiling(x_p) : Math.Floor(x_p);
                    y_p = Math.Ceiling(y_p) - y_p <= y_p - Math.Floor(y_p) ? Math.Ceiling(y_p) : Math.Floor(y_p);

                    p.X = (int)(x_p);
                    p.Y = (int)(y_p);
                    lista[i] = p;
                }
                for (int i = 0; i < lista_auxiliar.Count; i++)
                {
                    double angulo = 45 * (Math.PI / 180);

                    var p = lista_auxiliar[i];
                    double x_p = 0;
                    double y_p = 0;
                    double sen = Math.Sin(angulo);
                    double cos = Math.Cos(angulo);
                    x_p = x_origen + ((p.X - x_origen) * cos) - ((p.Y - y_origen) * sen);
                    y_p = y_origen + ((p.Y - y_origen) * cos) + ((p.X - x_origen) * sen);

                    x_p = Math.Ceiling(x_p) - x_p <= x_p - Math.Floor(x_p) ? Math.Ceiling(x_p) : Math.Floor(x_p);
                    y_p = Math.Ceiling(y_p) - y_p <= y_p - Math.Floor(y_p) ? Math.Ceiling(y_p) : Math.Floor(y_p);

                    p.X = (int)(x_p);
                    p.Y = (int)(y_p);
                    lista_auxiliar[i] = p;
                }
            }

            if (e.KeyCode == Keys.J)
            {
                lapiz2.Color = (Color.Blue);
                double magnitud = 1.2;
                double xr = x_origen;
                double yr = y_origen;
                for (int i = 0; i < lista.Count; i++)
                {
                    var p = lista[i];
                    p.X = (int)(p.X * magnitud + (1 - magnitud) * xr);
                    p.Y = (int)(p.Y * magnitud + (1 - magnitud) * yr);
                    lista[i] = p;
                }
                for (int i = 0; i < lista_auxiliar.Count; i++)
                {
                    var p = lista_auxiliar[i];
                    p.X = (int)(p.X * magnitud + (1 - magnitud) * xr);
                    p.Y = (int)(p.Y * magnitud + (1 - magnitud) * yr);
                    lista_auxiliar[i] = p;
                }
            }

            if (e.KeyCode == Keys.L)
            {
                lapiz2.Color = (Color.Blue);
                double magnitud = 0.8;
                double xr = x_origen;
                double yr = y_origen;
                for (int i = 0; i < lista.Count; i++)
                {
                    var p = lista[i];
                    p.X = (int)(p.X * magnitud + (1 - magnitud) * xr);
                    p.Y = (int)(p.Y * magnitud + (1 - magnitud) * yr);
                    lista[i] = p;
                }
                for (int i = 0; i < lista_auxiliar.Count; i++)
                {
                    var p = lista_auxiliar[i];
                    p.X = (int)(p.X * magnitud + (1 - magnitud) * xr);
                    p.Y = (int)(p.Y * magnitud + (1 - magnitud) * yr);
                    lista_auxiliar[i] = p;
                }
            }

            DibujarCurva();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (first == true) { x_origen = e.X; y_origen = e.Y; }

            g.DrawRectangle(lapiz1, e.X,e.Y,5, 5);
            lista.Add(new Point(e.X, e.Y));
        }

    }
}
