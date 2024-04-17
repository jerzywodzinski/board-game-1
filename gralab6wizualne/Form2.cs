using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gralab6wizualne
{
    public partial class Form2 : Form
    {
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.x=int.Parse(textBox1.Text);
            form1.y = int.Parse(textBox2.Text);
            form1.dydelf = int.Parse(textBox3.Text);
            form1.krokodyl = int.Parse(textBox4.Text);
            form1.czas = int.Parse(textBox5.Text);
            if (form1.x < 3 || form1.x > 10 || form1.y < 3 || form1.y > 10 || form1.krokodyl > 1 || form1.krokodyl < 0 || form1.dydelf > 6 || form1.dydelf < 1|| form1.czas>60|| form1.czas < 10)
            { MessageBox.Show("Wprowadzono nieprawidlowe wartosci!"); }
            else { this.Close(); }


        }
    }
}
