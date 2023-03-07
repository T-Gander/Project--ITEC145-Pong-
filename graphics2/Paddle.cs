using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics2
{
    internal class Paddle
    {
        static public Form1 mainForm;

        // private fields
        private int _x;
        private int _y;
        private int _width = 15;
        private int _height = 100;
        private int _xSpeed = 0;
        private int _ySpeed = 0;
        private Brush _brush = Brushes.White;

        // constructor
        public Paddle(int x,int y)
        {
            _x = x;
            _y = y;

        }
        //public properties
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        public int ySpeed { get { return _ySpeed; } set { _ySpeed = value; } }

        // public methods
        public void Draw(Graphics gr)
        {
            _x += _xSpeed;
            _y += _ySpeed;

            if (_x+_width > mainForm.ClientSize.Width)
                _x = mainForm.ClientSize.Width - _width;

            if (_x <=0)
                _x = 0;

            if (_y + _height > mainForm.ClientSize.Height)
                _y = mainForm.ClientSize.Height - _height;

            if (_y <= 0)
                _y = 0;

            gr.FillRectangle(_brush, _x, _y, _width, _height);
        }

        public void BallCollisionLeft(Paddle paddle, Ball ball)
        {
            if (ball.X <= paddle.X + paddle.Width && ball.GetCenterY(ball) >= paddle.Y && ball.GetCenterY(ball) <= paddle.Y + paddle.Height)
            {
                if (ball.GetCenterX(ball) <= paddle.X)
                {
                    if(ball.GetCenterY(ball) <= paddle.GetCenterY(paddle))
                    {
                        ball.Y = paddle.Y - ball.Height;
                    }
                    else
                    {
                        ball.Y = paddle.Y + paddle.Height;
                    }
                    ball.ySpeed *= -1;
                }
                else
                {
                    ball.xSpeed *= -1;
                    ball.X += ball.xSpeed;
                }
            }

            //if (ball.X < paddle.X + paddle.Width && ball.Y >= paddle.Y - ball.Height)
            //{
            //    ball.ySpeed *= -1;
            //    ball.Y = paddle.Y + ball.Height;
            //}
        }
        public void BallCollisionRight(Paddle paddle, Ball ball)
        {
            if (ball.X + ball.Width >= paddle.X && ball.GetCenterY(ball) >= paddle.Y && ball.GetCenterY(ball) <= paddle.Y + paddle.Height)
            {
                if (ball.GetCenterX(ball) >= paddle.X)
                {
                    if (ball.GetCenterY(ball) <= paddle.GetCenterY(paddle))
                    {
                        ball.Y = paddle.Y - ball.Height;
                    }
                    else
                    {
                        ball.Y = paddle.Y + paddle.Height;
                    }
                    ball.ySpeed*= -1;
                }
                else
                {
                    ball.xSpeed *= -1;
                    ball.X += ball.xSpeed;
                }
            }

            
        }
        public double GetCenterY(Paddle paddle)
        {
            double half = paddle.Height / 2;
            return half + paddle.Y;
        }
        public double GetCenterX(Paddle paddle)
        {
            double half = paddle.Width / 2;
            return half + paddle.X;
        }

    }
}
