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
    public partial class AB : Form
    {
        public AB()
        {
            InitializeComponent();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            string wow = textBox9.Text;
            
            moverDato("■" + wow + "■");
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

                richTextBox1.Text += textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text +"\n";
            }
            else
            {
                MessageBox.Show("Ingrese una expresión válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox9.Clear();
            }
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
            while (estado != 4)
            {
                switch (numero[i] + "")
                {
                    case "1":
                        if (estado == 0)
                        {
                            estado = 0;
                            numero[i] = "1";
                            i++;
                        }
                        else if (estado == 1)
                        {
                            estado = 2;
                            numero[i] = "0";
                            i--;

                        }
                        else if (estado == 2)
                        {
                            estado = 2;
                            numero[i] = "1";
                            i--;
                        }
                        else if (estado == 3)
                        {

                            estado = 4;
                            numero[i] = "1";
                        }
                        break;
                    case "0":
                        if (estado == 0)
                        {
                            estado = 0;
                            numero[i] = "0";
                            i++;

                        }
                        else if (estado == 1)
                        {
                            estado = 1;
                            numero[i] = "1";
                            i--;

                        }
                        else if (estado == 2)
                        {
                            estado = 2;
                            numero[i] = "0";
                            i--;

                        }
                        else if (estado == 3)
                        {
                            estado = 4;
                            numero[i] = "■";
                            i++;

                        }
                        break;
                    case "■":
                        if (estado == 0)
                        {
                            estado = 1;
                            numero[i] = "■";
                            i--;

                        }
                        else if (estado == 2)
                        {
                            estado = 3;
                            numero[i] = "■";
                            i++;

                        }
                        break;
                    default:
                        timer1.Stop();
                        MessageBox.Show("An error ocurred, restart the app");

                        break;
                }
                richTextBox1.Text += leerVector(numero) + "\n";
            }

            if (estado == 4)
            {
                timer1.Stop();

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

        private void AB_Load(object sender, EventArgs e)
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

        private string leerVector(string[] u)
        {
            string perro = "";
            for (int i = 0; i < u.Length; i++)
            {
                perro += u[i];
            }
            return perro;
        }
    }
}
