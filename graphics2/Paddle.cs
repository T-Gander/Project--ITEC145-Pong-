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
            _y += _ySpeed;

            if (_y + _height > mainForm.ClientSize.Height)
                _y = mainForm.ClientSize.Height - _height;

            if (_y <= 0)
                _y = 0;

            gr.FillRectangle(_brush, _x, _y, _width, _height);
        }

        public void BallCollisionPlayer1(Paddle paddle, Ball ball)
        {
            if (ball.X <= paddle.X + paddle.Width && ball.GetCenterY(ball) >= paddle.Y && ball.GetCenterY(ball) <= paddle.Y + paddle.Height)
            {
                if (ball.GetCenterX(ball) <= paddle.X)                                  //Checks if X is too far behind paddle to be in front of it (based on an xSpeed of 6)
                {
                    if(ball.GetCenterY(ball) <= paddle.GetCenterY(paddle))              //Top of paddle condition
                    {
                        ball.Y = paddle.Y - ball.Height;
                    }
                    else
                    {
                        ball.Y = paddle.Y + paddle.Height;                              //Bottom of paddle condition
                    }
                    ball.ySpeed *= -1;
                }
                else
                {
                    ball.xSpeed *= -1;                                                  //In front of paddle
                    ball.ySpeed = Convert.ToInt32(Slice(paddle, ball));
                    ball.X += ball.xSpeed;
                }
            }
        }
        public void BallCollisionPlayer2(Paddle paddle, Ball ball)
        {
            if (ball.X + ball.Width >= paddle.X && ball.GetCenterY(ball) >= paddle.Y && ball.GetCenterY(ball) <= paddle.Y + paddle.Height)
            {
                if (ball.GetCenterX(ball) >= paddle.X)                                  //Checks if X is too far behind paddle to be in front of it (based on an xSpeed of 6)
                {
                    if (ball.GetCenterY(ball) <= paddle.GetCenterY(paddle))             //Top of paddle condition
                    {
                        ball.Y = paddle.Y - ball.Height;
                    }
                    else
                    {
                        ball.Y = paddle.Y + paddle.Height;                              //Bottom of paddle condition
                    }
                    ball.ySpeed *= -1;
                }
                else
                {                                                                       //In front of paddle
                    ball.xSpeed *= -1;
                    ball.ySpeed = Convert.ToInt32(Slice(paddle, ball));
                    ball.X += ball.xSpeed;
                }
            }

            
        }
        public int GetCenterY(Paddle paddle)
        {
            int half = paddle.Height / 2;
            return half + paddle.Y;
        }
        public int GetCenterX(Paddle paddle)
        {
            int half = paddle.Width / 2;
            return half + paddle.X;
        }

        public double Slice(Paddle paddle, Ball ball)
        {
            int maxSlice = 12;
            int minSlice = -12;
            double slice = 0;
            double paddleRatio = paddle.Height/2;
            double paddleTop = paddle.GetCenterY(paddle) - ball.GetCenterY(ball);
            double paddleBottom = ball.GetCenterY(ball) - paddle.GetCenterY(paddle);

            if (ball.GetCenterY(ball) < paddle.GetCenterY(paddle))
            {
                slice = paddleTop / paddleRatio;
                double finalSlice = slice * maxSlice;
                if (finalSlice > 6)
                {
                    finalSlice = maxSlice;
                }
                else if (finalSlice < -6)                           
                {
                    finalSlice = minSlice;
                }
                return -finalSlice;
            }
            else if (ball.GetCenterY(ball) > paddle.GetCenterY(paddle))
            {
                slice = paddleBottom / paddleRatio;
                double finalSlice = slice * maxSlice;
                if (finalSlice > 6)
                {
                    finalSlice = maxSlice;
                }
                else if (finalSlice < -6)
                {
                    finalSlice = minSlice;
                }
                return finalSlice;
            }
            else
            {
                return 0;
            }
            
        }

    }
}
