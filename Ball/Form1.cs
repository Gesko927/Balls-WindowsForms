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
        Random random;
        List<ColorBall> ballList;

        const int SIZE = 50;

        bool PAUSE;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //playAnimation();
            PAUSE = false;
            timer1.Start();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphic = panel1.CreateGraphics();

            random = new Random();
            PAUSE = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PAUSE = true;
            timer1.Stop();
        }

        private void playAnimation()
        {
            panel1.BackColor = Color.Red;

            initBalls();

            //Thread thread = new Thread(startMoveBall);

            //thread.Start();

            //thread.Join();

            startMoveBall();
            
        }

        private void startMoveBall()
        {
            
                graphic.Clear(panel1.BackColor);

                foreach (ColorBall ball in ballList)
                {
                    graphic.FillEllipse(Brushes.Green, ball.X, ball.Y, ball.SIZE, ball.SIZE);

                    ball.MoveBall();
                }


           

        }

        private void initBalls()
        {
            

            ballList = new List<ColorBall>();

            /**
             * При такій ініціалізації
             * ballList.Add(new ColorBall(panel1));
             * Завжди створються один і той самий об'єкт
             */
            for (int i = 0; i < 5; ++i)
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

