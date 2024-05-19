using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gralab6wizualne
{
    public partial class Form3 : Form
    {
        private Form1 form1;
        public int x = 4;
        public int y = 4;
        public int krokodyl = 1;
        public int dydelf = 2;
        public int aktualnieKrokodyl1 = 1;
        public int aktualnieDydelf1 = 2;
        public int czas = 30;
        private int pozostalyczas = 4;
       public List <int> boardinfo=new List<int>();
        Random random1 = new Random();
        //string krokodylImage = "C:\\Users\\48531\\Downloads\\Bazoule_sacred_crocodiles_MS_6709cropped.jpeg";
        //Image Image1 = "pobrane.jpeg";

        //  string dydelfImage = "C:\\Users\\48531\\Downloads\\pobrane.jpeg";
        string dydelfImage = "pobrane.jpeg";
        string krokodylImage = "Bazoule_sacred_crocodiles_MS_6709cropped.jpeg";
       // Image krokodylzdj = Bazoule_sacred_crocodiles_MS_6709cropped.jpeg;
        public Form3(Form1 form1,int x,int y, int dydelf, int krokodyl,int czas)
        {
            InitializeComponent();

            this.form1 = form1;
            this.x = x;
            this.y = y;
            this.krokodyl = krokodyl;
            aktualnieKrokodyl1 =(int)krokodyl;

            this.czas = czas;
            pozostalyczas = czas;
            this.dydelf = dydelf;
            aktualnieDydelf1 =(int)dydelf;
            CreateGameBoard(x,y);
            timer1.Interval = 1000; 
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            createBoardInfo();
           // MessageBox.Show(this.krokodyl.ToString());
        }

       

        private void CreateGameBoard(int rows, int columns)
        {
            int panelIndex = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Panel panel = new Panel();
                    panel.Size = new Size(50, 50);
                    panel.Location = new Point(j * 50, i * 50);
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.BackColor = Color.Gray; 
                    panel.MouseClick += Panel_MouseClick;
                    panel.Tag = panelIndex++;
                    Controls.Add(panel);
                }
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            pozostalyczas--;
            UpdateTime();
            if (pozostalyczas <= 0)
            {
                timer1.Stop(); 
                MessageBox.Show("koniec czasu!");
                this.Close(); 
            }
        }
        private void UpdateTime()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(pozostalyczas);
            string timeString = timeSpan.ToString(@"mm\:ss");
            label1.Text = "Czas: " + timeString;
        }

        private void Panel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                int panelIndex = (int)panel.Tag;
                if (boardinfo[panelIndex] == 0)
                {
                    panel.BackColor = Color.Red;
                }
                if (boardinfo[panelIndex] == 1)
                {
                    panel.BackgroundImage = Image.FromFile(dydelfImage);
                    panel.BackgroundImageLayout = ImageLayout.Stretch;
                    aktualnieDydelf1--;
                    if (aktualnieDydelf1 == 0)
                    {
                        MessageBox.Show("Wygrałeś");
                        this.Close();
                    }
                }
                if (boardinfo[panelIndex] == 2)
                {
                    panel.BackgroundImage = Image.FromFile(krokodylImage);
                    panel.BackgroundImageLayout = ImageLayout.Stretch;
                    aktualnieKrokodyl1--;
                    MessageBox.Show("Trafiles krokodyla! przegrywasz");
                    this.Close();
                }
            }
        }
        private void createBoardInfo()
        {
            // 0=puste pole, 1=dydelf, 2=krokodyl
           // boardinfo = new List<int>();
            for (int i = 0; i < x*y; i++) { boardinfo.Add(0); }
            var aktualnieDydelf = dydelf;
            var aktualnieKrokodyl=krokodyl;
            while(aktualnieDydelf!=0)
            {
               // var random1=new Random() ;
                int random = random1.Next(x*y);
                if (boardinfo[random]==0)
                {
                    boardinfo[random] = 1;
                    aktualnieDydelf--;
                }
            }
            while (aktualnieKrokodyl != 0)
            {
               // var random1 = new Random();
                int random = random1.Next(x * y);
                if (boardinfo[random] == 0)
                {
                    boardinfo[random] = 2;
                    aktualnieKrokodyl--;

                }
            }
        }
    }
}
