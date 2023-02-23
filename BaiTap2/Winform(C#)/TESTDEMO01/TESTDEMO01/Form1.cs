using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueueLibraryDemo01;
using LinkedListLibrary_Demo02;
using CalculatorLibrary01;

namespace TESTDEMO01
{
    public partial class Form1 : Form
    {
        LINKEDLIST<string> Expression = new LINKEDLIST<string>();
        bool isOperation = false;
        bool Lock = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Check()
        {
            
            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox1.Text += textBox2.Text;
                Expression.AddLast(textBox2.Text);
                textBox2.Clear();
            }
        }

        private void Error()
        {
            textBox2.Text = "Invalid input";
            Lock = true;
        }
       
        private void CanBac2_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                if (!string.IsNullOrWhiteSpace(textBox2.Text) && !Lock)
                {
                    double number = Double.Parse(textBox2.Text);
                    if (number >= 0)
                    {
                        textBox2.Text = Math.Sqrt(number).ToString();
                    }
                    else Error();

                }
            }
            catch (Exception) { Error(); }
        }

        private void PhanSo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text) && !Lock)
                {
                    double number = Double.Parse(textBox2.Text);
                    if (number != 0)
                    {
                        textBox2.Text = (1 / number).ToString();
                    }
                    else Error();
                }
            }
            catch(Exception) { Error(); }
        }

        private void DauNgoac_click(object sender, EventArgs e)
        {
            try
            {
                if (!Lock)
                {
                    Button button = (Button)sender;

                    if (button.Text.Equals(")") && !string.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        textBox1.Text += textBox2.Text;
                        Expression.AddLast(textBox2.Text);
                        textBox2.Clear();
                    }
                    textBox1.Text += button.Text;
                    Expression.AddLast(button.Text);

                }
            }
            catch (Exception) { Error(); }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text) && !Lock)
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1, 1);
        }

        private void AC_Click(object sender, EventArgs e)
        {
            Lock = false;
            textBox1.Clear();
            textBox2.Clear();
            Expression.RemoveAll();
        }

        private void PhanTichSNT_Click(object sender, EventArgs e)
        {
            // Sang so nguyen to
            bool[] prime = new bool[10000001];

            for (int i = 0; i < 10000001; i++)
                prime[i] = true;
            prime[0] = prime[1] = false;

            for (int i = 0; i < Math.Sqrt(10000001); i++)
            {
                if (prime[i])
                {
                    for (int j = i * i; j < 10000001; j += i)
                    {
                        prime[j] = false;
                    }
                }
            }

            // Phan tich thua so nguyen to 
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox2.Text) && !Lock)
                {
                    Int32.TryParse(textBox2.Text, out int number);
                    if (number > 1)
                    {
                        textBox1.Text = $"FACT({textBox2.Text})=";
                        string pact = "";
                        for (int i = 0; i <= Math.Sqrt(number); i++)
                        {
                            if (prime[i])
                            {
                                int count = 0;
                                while (number % i == 0)
                                {
                                    ++count;
                                    number /= i;
                                }
                                if (count != 0)
                                {
                                    pact += i.ToString();
                                    if (count > 1)
                                        pact += $"^{count.ToString()}";
                                    pact += "×";
                                }

                            }
                        }
                        if (number > 1) pact += number.ToString();
                        else pact = pact.Remove(pact.Length - 1, 1);

                        // Ket qua
                        textBox2.Text = pact;
                    }
                    else Error();
                    Lock = true;
                }
            }
            catch (Exception) { Error(); }
        }

        private void SoAm_Click(object sender, EventArgs e)
        {
            if (!Lock)
            {
                textBox2.Clear();
                textBox2.Text += "-";
            }
        }

        private void Number_click(object sender, EventArgs e)
        {
            if (!Lock)
            {
                Button button = (Button)sender;
                if (button.Text == "·")
                {
                    if (!textBox2.Text.Contains("."))
                        textBox2.Text += ".";
                }
                else textBox2.Text += button.Text;
                isOperation = false;
            }
        }

        private void KetQua_Click_1(object sender, EventArgs e)
        {
            if (!Lock)
            {
                Check();
                try
                {
                    LINKEDLIST<string> ex = new LINKEDLIST<string>();
                    ex.CopyTo(Expression);
                    BieuThuc bieuThuc = new BieuThuc(ex);
                    textBox1.Text += "=";
                    textBox2.Text = bieuThuc.GiaTriBieuThuc();
                }
                catch (Exception) { Error(); }
                Lock = true;
            }
        }

        private void Operator_click(object sender, EventArgs e)
        {
            if (!Lock && !isOperation)
            {
                Button button = (Button)sender;
                Check();
                textBox1.Text += button.Text;
                Expression.AddLast(button.Text);
                isOperation = true;
            }
        }
    }
}
