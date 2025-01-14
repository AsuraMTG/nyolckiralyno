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
        public static int aktOszlop = 0;
        public int[,] tabla = new int[8, 8];
        public static int hely = 0;
        public Point javaslat = new Point(aktOszlop, hely);
        public Point aktKezd = new Point(0, 0);
        int counter = 0;
        int utolsoStatusz;

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
        public int Leptetes()
        {
            javaslat.X = aktOszlop;
            javaslat.Y = hely++;

            while (!Joe(javaslat))
            {
                if (hely < 7)
                {
                    hely++;
                    javaslat.Y = hely;
                }
                else
                {
                    aktOszlop++;
                    hely = 0;
                    javaslat.X = aktOszlop;
                    javaslat.Y = hely;
                }

                if (aktOszlop > 7)
                {
                    hiba("5","");

                    return 8;
                }
            }
            tabla[aktOszlop, hely] = 1;
            statusz[aktOszlop] = hely;
            Kiir();
            return hely;
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
        public void hiba(string hiba, string hibauzenet) 
        {
            string message = $"{hiba}. elem\n Hiba: {hibauzenet}";
            string title = "Hiba";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.No)
            {
                this.Close();
            }
        }
        
        public void Vissza()
        {
            int i = 0;
            while (statusz[i] < 8)
            {
                utolsoStatusz = i;
                i++;
            }

            button2.Text = statusz[utolsoStatusz].ToString();

            statusz[utolsoStatusz - 1] = 8;
            statusz[utolsoStatusz] = 8;

            
        }

        public void listaba()
        {
            int hossz = listBox1.Items.Count;
            int egesz = hossz / 40;
            int utolsok = hossz % 40;
            List<string> maradek = new List<string>();
            for (int i = egesz*40; i < hossz; i++)
            {
                maradek.Add(listBox1.Items[i].ToString());
            }
            listBox1.Items.Clear();
            for (int i = 0; i < maradek.Count; i++)
            {
                listBox1.Items.Add(maradek[i]);
            }
        }
        public bool Joe(Point javaslat) 
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                if (tabla[i, javaslat.Y] != 0)
                {
                    //hiba($"1", $"{i},{javaslat.Y}");

                    return false;
                }
            }

            for (int i = 0; i < tabla.GetLength(0); i++)
            {

                if (tabla[javaslat.X, i] != 0)
                {
                    //hiba("2",$"{javaslat.X},{i}");

                    return false;
                }
            }

            int fo = javaslat.X - javaslat.Y;
            
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int j = 0; j < tabla.GetLength(1); j++)
                {
                    if (((i - j) == fo) && (tabla[i,j] != 0))
                    {
                        //hiba("3", $"{i},{j}");

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
                        //hiba("4", $"{i},{j}");

                        return false;
                    }
                }
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            Kezd();
            Kiir();
            label2.Text = $"cc:{Joe(javaslat)}";

        }

        public void elorelep()
        {
            for (int i = 0; i < 10; i++)
            {
                if (Joe(aktKezd))
                {
                    listBox1.Items.Add(aktKezd.X.ToString() + aktKezd.Y.ToString() + "jó");
                }
                listaba();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Leptetes();
            label2.Text = $"cc:{Joe(javaslat)}";
            elorelep();
            label3.Text = "";
            for (int i = 0; i < statusz.Length; i++)
            {
                label3.Text += $"{i + 1}. {statusz[i]}\n";
            }
            counter++;
            //listaba();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Vissza();
        }
    }
}
