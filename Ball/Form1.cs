using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Ball
{
    public partial class Form1 : Form
    {
        Graphics graphic;
        Graphics graphic2;
        Random random;
        List<ColorBall> ballList;
        Image image;
        Bitmap bitmap;

        const int SIZE = 50;
        bool PAUSE;
        
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(panel1.Width, panel1.Height);
            graphic = Graphics.FromImage(bitmap);
            graphic2 = panel1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PAUSE = false;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            random = new Random();
            PAUSE = false;

            initBalls();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PAUSE = true;
            timer1.Stop();
        }

        private void playAnimation()
        {
            panel1.BackColor = Color.Red;

            startMoveBall();
        }

        private void startMoveBall()
        {
            
          graphic.Clear(panel1.BackColor);

          foreach (ColorBall ball in ballList)
          {
              graphic.DrawImage(Image.FromFile(@"C:\Users\Gesko927\OneDrive\Visual Projects\Ball\Ball\bin\Debug\Ship.png"), new Point(ball.X, ball.Y));
              ball.MoveBall();
          }

          graphic2.DrawImage(bitmap, 0, 0);

        }

        private void initBalls()
        {
            ballList = new List<ColorBall>();

            /**
             * При такій ініціалізації
             * ballList.Add(new ColorBall(panel1));
             * Завжди створються один і той самий об'єкт
             */
            for (int i = 0; i < 10; ++i)
            {
                int x = random.Next(SIZE, this.panel1.ClientSize.Width);
                int y = random.Next(SIZE, this.panel1.ClientSize.Height);
                int dx = random.Next(-2, 1);
                int dy = random.Next(-2, 1);
                ballList.Add(new ColorBall(panel1, x, y, dx, dy));

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!PAUSE)
            {
                playAnimation();
            }
        }
    }
}

