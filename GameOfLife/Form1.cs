using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        Board board;
        Button start;
        Button stop;
        int count = 32;
        int squareSize = 15;
        int topMargin = 40;

        bool run = false;

        Thread runner;
        public Form1()
        {
            InitializeComponent();
            int winWidth = (count + 1) * (squareSize + 1);
            this.Width = winWidth;
            int titleHeight = this.Height - this.ClientRectangle.Height;
            this.Height = count * (squareSize + 1) + topMargin + titleHeight;
            this.BackColor = Color.DarkGray;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;


  

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Board(count, squareSize, topMargin);
            for(int i = 0; i < count*count; i++)
            {
                this.Controls.Add(board.square(i).panel());
            }

            start = new Button();
            start.Text = "Start";
            start.Height = topMargin;
            start.Width = 100;
            start.Click += Start_Click;
            this.Controls.Add(start);

            stop = new Button();
            stop.Text = "Start";
            stop.Height = topMargin;
            stop.Location = new Point(100, 0);
            stop.Width = 100;
            stop.Click += Stop_Click;
            this.Controls.Add(start);

            runner = new Thread(board.run);
            

        }

        private void Start_Click(object sender, EventArgs e)
        {
            run = true;

            runner.Start();
        }

        public static void runGame(object data)
        {
            int s = 10;
            Board board = (Board)data;
            while(s > 0)
            {
                board.start();
                System.Threading.Thread.Sleep(200);
                s--;
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            run = false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
    }
}
