using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ball
{
    
    class ColorBall
    {
        private int x;
        private int y;

        private int dx;
        private int dy;
        public readonly int SIZE = 25;
        
        //Крок зміни позиції кульки
        private const int H = 10;

        private Panel panel;

        public int X
        {
            get
            {
                return x;
            }

            private set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            private set
            {
                y = value;
            }
        }

        public int Dx
        {
            get
            {
                return dx;
            }

            private set
            {
                dx = value;
            }
        }

        public int Dy
        {
            get
            {
                return dy;
            }

            private set
            {
                dy = value;
            }
        }



        public ColorBall(Panel panel, int x, int y, int xDir, int yDir)
        {
            
            this.panel = panel;

            X = x;
            Y = y;

            #region Визначення початкового напряму кульки

            if (xDir >= 0)
            {
                Dx = H;
            }
            else
            {
                Dx = -H;
            }

            if (yDir >= 0)
            {
                Dy = H;
            }
            else
            {
                Dy = -H;
            }

            #endregion
            //Dx = H;
            //Dy = H;

        }

        public void MoveBall()
        {
            X += Dx;
            Y += Dy;

            #region Відбиття віл верхньої границі
            
            if (Y < 0)
            {
                if (Dx > 0)
                {
                    Dy = H;
                    Dx = H;
                }
                else
                {
                    Dy = H;
                    Dx = -H;
                }
            }

            #endregion

            #region  Відбиття від правої границі

            if (X > panel.ClientSize.Width - SIZE)
            {
                if (Dy > 0)
                {
                    Dx = -H;
                    Dy = H;
                }
                else
                {
                    Dx = -H;
                    Dy = -H;
                }
            }
            #endregion

            #region  Відбиття від нижньої границі
            if (Y > panel.ClientSize.Height - SIZE)
            {
                if (Dx < 0)
                {
                    Dx = -H;
                    Dy = -H;
                }
                else
                {
                    Dx = H;
                    Dy = -H;
                }
            }

            #endregion

            #region Відбиття від лівої границі
            if (X < 0)
            {
                if (Dy > 0)
                {
                    Dy = H;
                    Dx = H;
                }
                else
                {
                    Dy = -H;
                    Dx = H;
                }
            }

            #endregion
        }
    }
}
