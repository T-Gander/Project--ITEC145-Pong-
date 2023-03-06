using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics2
{
    internal class Ball
    {
        static public Form1 mainForm;

        // private fields
        private int _x;
        private int _y;
        private int _width = 15;
        private int _height = 15;
        private int _xSpeed = 6;
        private int _ySpeed = 6;
        private Brush _brush = Brushes.White;
        

        // constructor
        public Ball(int x,int y)
        {
            _x = x;
            _y = y;

        }
        //public properties
        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } set { _height = value; } }
        public int xSpeed { get { return _xSpeed; } set { _xSpeed = value; } }
        public int ySpeed { get { return _ySpeed; } set { _ySpeed = value; } }

        // public methods
        public void Draw(Graphics gr)
        {
            _x += _xSpeed;
            _y += _ySpeed;

            /////////////////////////////////////////////////Window Boundary Collisions/////////////////////////////////////////////////

            if (_x + _width > mainForm.ClientSize.Width)
            {
                _x = mainForm.ClientSize.Width - _width;
                _xSpeed *= -1;
            }
                
            if (_x <= 0)
            {
                _x = 0;
                _xSpeed *= -1;
            }

            if (_y + _height > mainForm.ClientSize.Height)
            {
                _y = mainForm.ClientSize.Height - _height;
                _ySpeed *= -1;
            }

            if (_y <= 0)
            {
                _y = 0;
                _ySpeed *= -1;
            }

            /////////////////////////////////////////////////Window Boundary Collisions/////////////////////////////////////////////////

            gr.FillEllipse(_brush, _x, _y, _width, _height);
        }

        public double GetFirstQuarterHeight(Ball ball)
        {
            double quarter = ball.Height / 4;
            return quarter;
        }
        public double GetHalfHeight(Ball ball)
        {
            double half = ball.Height / 2;
            return half;
        }

        public double GetThirdQuarterHeight(Ball ball)
        {
            double quarter = (ball.Height / 4)*3;
            return quarter;
        }
    }
}
