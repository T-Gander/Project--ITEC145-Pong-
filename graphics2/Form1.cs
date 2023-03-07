using System.Security.Cryptography.X509Certificates;
using static graphics2.Ball;

namespace graphics2
{
    public partial class Form1 : Form
    {
        Ball ball;
        Paddle paddle1;
        Paddle paddle2;
        public int player1Score = 0;
        public int player2Score = 0;
        bool GameEnd = false;

        public Form1()
        {
            InitializeComponent();
            Ball.mainForm = this;
            Paddle.mainForm = this;
            this.BackColor = Color.Gray;

            // add the following commands to any program that is drawing graphics
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.Paint += Form1_Paint;
            timer1.Enabled = true;

            ball = new Ball(ClientSize.Width / 2, ClientSize.Height / 2);
            paddle1 = new Paddle(30, ClientSize.Height / 2 - 50);
            paddle2 = new Paddle(ClientSize.Width - 45, ClientSize.Height / 2 - 50);
        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            ball.Draw(e.Graphics);
            paddle1.Draw(e.Graphics);
            paddle2.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate(false);   // this will force the Paint event to fire
            if(GameEnd == true)
            {
                Thread.Sleep(2000);     //Sorry for this, I know it's bad programming...
                GameEnd = false;
            }

            paddle1.X = 30;
            paddle2.X = ClientSize.Width - 45;

            paddle1.BallCollisionLeft(paddle1, ball);
            paddle2.BallCollisionRight(paddle2, ball);

            if (ball.X + ball.Width > mainForm.ClientSize.Width)
            {
                player1Score++;
                //Reset and player 1 gains a point
                ball.Reset(ball);
                GameEnd = true;
            }

            if (ball.X <= 0)
            {
                player2Score++;
                //Reset and player 2 gains a point
                ball.Reset(ball);
                GameEnd = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Player 1
            if (e.KeyCode == Keys.W)
            {
                paddle1.ySpeed = -5;
            }
            if (e.KeyCode == Keys.S)
            {
                paddle1.ySpeed = 5;
            }
            //Player 2
            if (e.KeyCode == Keys.Up)
            {
                paddle2.ySpeed = -5;
            }
            if (e.KeyCode == Keys.Down)
            {
                paddle2.ySpeed = 5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Player 1
            if (e.KeyCode == Keys.W)
            {
                paddle1.ySpeed = 0;
            }
            if (e.KeyCode == Keys.S)
            {
                paddle1.ySpeed = 0;
            }
            //Player 2
            if (e.KeyCode == Keys.Up)
            {
                paddle2.ySpeed = 0;
            }
            if (e.KeyCode == Keys.Down)
            {
                paddle2.ySpeed = 0;
            }
        }
    }
}