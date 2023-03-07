using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphics2
{
    internal class IScore
    {
        static public Form1 mainForm;
        private string _player;
        private int _x;
        private int _y;
        private int _score;
        private Brush _brush;
        private FontFamily _fontFamily = new FontFamily("Arial");
        private Font _font;

        public int X { get { return _x; } set { _x = value; } }
        public int Y { get { return _y; } set { _y = value; } }
        public int Score { get { return _score; } set { _score = value; } }

        public IScore(int x, int y, string player, int score)
        {
            _player = player;
            _x = x;
            _y = y;
            _score = score;
            _brush = Brushes.White;
            _font = new Font(
            _fontFamily,
            22,
            FontStyle.Bold,
            GraphicsUnit.Pixel);
    }

        public void Draw(Graphics gr)
        {
            gr.DrawString($"{_player}: {_score}", _font, _brush, _x, _y);
        }
    }
}
