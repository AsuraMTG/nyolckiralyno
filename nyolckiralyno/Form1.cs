using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nyolckiralyno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int[] statusz = new int[8];
        public int aktOszlop;
        public int[,] tabla = new int[8, 8];
        
        

        //GetLength(matrix.eleme)

        public void Kezd()
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    tabla[i,j] = 0;
                }
            }

            for (int i = 0; i < statusz.Length; i++)
            {
                statusz[i] = 8;
            }

            aktOszlop = 0;
            statusz[0] = 0;
            tabla[0, 0] = 1;
        }
        public void Kiir() 
        {
            label1.Text = "";
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    label1.Text += $"{tabla[i,j]}  ";
                }
                label1.Text += "\n";
            }
        }

        public bool Joe(Point javaslat) 
        {
            for (int i = 0; i < 8; i++)
            {
                if (tabla[i, javaslat.Y] != 0)
                {
                    return false;
                }

                if (tabla[javaslat.X, i] != 0)
                {
                    return false;
                }
            }

            int fo = javaslat.X - javaslat.Y;
            // átlo
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if ((i - j) == fo && tabla[i,j] != 0)
                    {
                        return false;
                    }
                }
            }

            int mellek = javaslat.X + javaslat.Y;

            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if ((i + j) == mellek && tabla[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kezd();
            Kiir();
            Point javaslat = new Point(1, 1);
            Joe(javaslat);


        }
    }
}
