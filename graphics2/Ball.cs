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
        private int _width = 30;
        private int _height = 30;
        private int _xSpeed = 15;
        private int _ySpeed = 15;
        private Color _color = Color.RebeccaPurple;
        private Pen _pen;

        // constructor
        public Ball(int x,int y)
        {
            _x = x;
            _y = y;
            _pen=new Pen(_color);

        }
        //public properties
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        // public methods
        public void Draw(Graphics gr)
        {
            _x += _xSpeed;
            _y+=_ySpeed;

            if (_x+_width > mainForm.ClientSize.Width)
                _xSpeed *= -1;

            if (_x <=0)
                _xSpeed *= -1;

            if (_y + _height > mainForm.ClientSize.Height)
                _ySpeed *= -1;

            if (_y <= 0)
                _ySpeed *= -1;


            gr.DrawEllipse(_pen, _x, _y, _width, _height);
        }


    }
}
