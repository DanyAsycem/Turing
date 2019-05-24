using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MaquinaTuringDan
{
    public partial class SB : Form
    {
        public SB()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string bin = "";
            Regex cad = new Regex("(1|0){4}");
            if (cad.IsMatch(textBox9.Text))
            {
                bin = textBox9.Text;
                textBox3.Text = bin[0].ToString();
                textBox4.Text = bin[1].ToString();
                textBox5.Text = bin[2].ToString();
                textBox6.Text = bin[3].ToString();

                richTextBox1.Text += textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text + "\n";
            }
            else
            {
                MessageBox.Show("Ingrese una expresión válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox9.Clear();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "1 Segundo":
                    timer1.Interval = 1000;
                    break;
                case "2 Segundos":
                    timer1.Interval = 2000;
                    break;
                case "3 Segundos":
                    timer1.Interval = 3000;
                    break;
                case "4 Segundos":
                    timer1.Interval = 4000;
                    break;
            }
            
            timer1.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string wow = textBox9.Text;
            moverDato("■" + wow + "■");
        }

        private string leerVector(string[] u)
        {
            string perro = "";
            for (int i = 0; i < u.Length; i++)
            {
                perro += u[i];
            }
            return perro;
        }

        private void moverDato(string cadena)
        {
            string[] numero = new string[6];
            for (int p = 0; p <= 5; p++)
            {
                numero[p] = cadena[p].ToString();
            }

            richTextBox1.Text += leerVector(numero) + "\n";

            int estado = 0;
            int i = 1;
            pictureBox2.Visible = true;
            int numImage = 2;

            while (estado != 3)
            {
                switch (numero[i] + "")
                {
                    case "1":
                        if (estado == 0)
                        {
                            estado = 0;
                            numero[i] = "1";
                            i++;
                            imagenRight(numImage);
                            numImage++;
                            //MessageBox.Show("1");
                        }
                        else if (estado == 1)
                        {
                            estado = 4;
                            numero[i] = "0";
                            i--;
                            imagenRight(numImage);
                            numImage--;
                            //    MessageBox.Show("8");

                        }
                        else if (estado == 4)
                        {
                            estado = 4;
                            numero[i] = "0";
                            i--;
                            imagenRight(numImage);
                            numImage--;
                            //MessageBox.Show("9");
                        }
                        else if (estado == 2)
                        {
                            estado = 2;
                            numero[i] = "1";
                            i--;
                            imagenRight(numImage);
                            numImage--;
                            // MessageBox.Show("4");
                        }
                        break;
                    case "0":
                        if (estado == 0)
                        {
                            estado = 0;
                            numero[i] = "0";
                            i++;
                            imagenRight(numImage);
                            numImage++;
                            //  MessageBox.Show("2");

                        }
                        else if (estado == 1)
                        {
                            estado = 2;
                            numero[i] = "1";
                            i--;
                            imagenRight(numImage);
                            numImage--;
                            // MessageBox.Show("4");

                        }
                        else if (estado == 2)
                        {
                            estado = 2;
                            numero[i] = "0";
                            i--;
                            imagenRight(numImage);
                            numImage--;
                            //  MessageBox.Show("6");

                        }
                        else if (estado == 4)
                        {
                            estado = 2;
                            numero[i] = "1";
                            i--;
                            imagenRight(numImage);
                            numImage--;
                            //     MessageBox.Show("10");

                        }
                        break;
                    case "■":
                        if (estado == 0)
                        {
                            estado = 1;
                            numero[i] = "■";
                            i--;
                            imagenRight(numImage);
                            numImage--;
                            //      MessageBox.Show("3");

                        }
                        else if (estado == 2)
                        {
                            estado = 3;
                            numero[i] = "■";
                            i++;
                            imagenRight(numImage);
                            numImage++;
                            //      MessageBox.Show("7");

                        }
                        else if(estado == 4)
                        {
                            estado = 3;
                            numero[i] = "1";
                            imagenRight(numImage);
                            
                            //        MessageBox.Show("11");
                            //      timer1.Stop();

                        }
                        break;
                    default:
                        timer1.Stop();
                        MessageBox.Show("An error ocurred, restart the app");

                        break;
                }
                richTextBox1.Text += leerVector(numero) + "\n";
            }

            if (estado == 3)
            {
                timer1.Stop();
               // MessageBox.Show("Acabaste prro");

            }
        }

        private void SB_Load(object sender, EventArgs e)
        {
            textBox1.Text = "■";
            textBox2.Text = "■";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "■";
            textBox8.Text = "■";
            pictureBox2.Visible = true;
        }

        public void imagenRight(int img)
        {
            if(img == 1)
            {
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;

            }
            else if(img==2)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
            else if (img == 3)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
            else if (img == 4)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
            }
            else if (img == 5)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
                pictureBox6.Visible = false;
            }
            else if(img==6)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
            }
        }

        public void imagenLeft()
        {

        }
    }
}
