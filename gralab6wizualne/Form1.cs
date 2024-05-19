namespace gralab6wizualne
{
    public partial class Form1 : Form
    {
        public int x = 4;
        public int y = 4;
        public int krokodyl = 1;
        public int dydelf = 2;
        public int czas = 30;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this,x,y,dydelf,krokodyl,czas);
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
