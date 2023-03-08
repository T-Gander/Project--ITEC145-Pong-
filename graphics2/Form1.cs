using System.Security.Cryptography.X509Certificates;
using static graphics2.Ball;

namespace graphics2
{
    public partial class Form1 : Form
    {
        Ball ball;
        Paddle paddle1;
        Paddle paddle2;
        IScore Iplayer1Score;
        IScore Iplayer2Score;

        enum PaddleState
        {
            PaddleUp,
            PaddleDown,
            None
        }

        PaddleState Paddle1State = PaddleState.None;
        PaddleState Paddle2State = PaddleState.None;

        int count;
        public int player1Score = 0;
        public int player2Score = 0;
        bool GameEnd = false;
        int currentxSpeed;
        int currentySpeed;

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
            Iplayer1Score = new IScore((ClientSize.Width / 4) - 50, 50, "Player 1", player1Score);          //Theres a better way to line these up but it works good enough
            Iplayer2Score = new IScore(((ClientSize.Width / 4)-25) * 3, 50, "Player 2", player2Score);      //Also redundant location assignment as it gets redrawn via timer
        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            ball.Draw(e.Graphics);
            paddle1.Draw(e.Graphics);
            paddle2.Draw(e.Graphics);
            Iplayer1Score.Draw(e.Graphics);
            Iplayer2Score.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Paddle1State == PaddleState.PaddleUp)
            {
                paddle1.ySpeed = -5;
            }
            else if(Paddle1State == PaddleState.PaddleDown)
            {
                paddle1.ySpeed = 5;
            }
            else
            {
                paddle1.ySpeed = 0;
            }

            if (Paddle2State == PaddleState.PaddleUp)
            {
                paddle2.ySpeed = -5;
            }
            else if (Paddle2State == PaddleState.PaddleDown)
            {
                paddle2.ySpeed = 5;
            }
            else
            {
                paddle2.ySpeed = 0;
            }

            Iplayer1Score.X = (ClientSize.Width / 4) - 50;
            Iplayer2Score.X = ((ClientSize.Width / 4) - 25) * 3;
            Iplayer1Score.Score = player1Score;
            Iplayer2Score.Score = player2Score;

            this.Invalidate(false);   // this will force the Paint event to fire

            if (GameEnd == true)
            {
                timerWait.Enabled = true;     
            }

            paddle1.X = 30;
            paddle2.X = ClientSize.Width - 45;
            
            paddle1.BallCollisionPlayer1(paddle1, ball);
            paddle2.BallCollisionPlayer2(paddle2, ball);

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
                Paddle1State = PaddleState.PaddleUp;
            }
            if (e.KeyCode == Keys.S)
            {
                Paddle1State = PaddleState.PaddleDown;
            }
            //Player 2
            if (e.KeyCode == Keys.Up)
            {
                Paddle2State = PaddleState.PaddleUp;
            }
            if (e.KeyCode == Keys.Down)
            {
                Paddle2State = PaddleState.PaddleDown;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Player 1
            if (e.KeyCode == Keys.W && Paddle1State != PaddleState.PaddleDown)
            {
                Paddle1State = PaddleState.None;
            }
            if (e.KeyCode == Keys.S && Paddle1State != PaddleState.PaddleUp)
            {
                Paddle1State = PaddleState.None;
            }

            //Player 2
            if (e.KeyCode == Keys.Up && Paddle2State != PaddleState.PaddleDown)
            {
                Paddle2State = PaddleState.None;
            }
            if (e.KeyCode == Keys.Down && Paddle2State != PaddleState.PaddleUp)
            {
                Paddle2State = PaddleState.None;
            }
        }

        private void timerWait_Tick(object sender, EventArgs e)
        {
            if(GameEnd == true)
            {
                currentxSpeed = 0;
                currentySpeed = 0;
                GameEnd = false;
            }
            else
            {
                int newSpeed = 0;
                ball.xSpeed = newSpeed;
                ball.ySpeed = newSpeed;
                count++;

                if (count == 150)
                {
                    Random random1 = new Random();
                    Random random2 = new Random();

                    int randomroll1 = random1.Next(0, 2);
                    int randomroll2 = random2.Next(0, 2);

                    if(randomroll1 == 1)
                    {
                        currentxSpeed = 6;
                    }
                    else
                    {
                        currentxSpeed = -6;
                    }

                    if (randomroll2 == 1)
                    {
                        currentySpeed = 6;
                    }
                    else
                    {
                        currentySpeed = -6;
                    }

                    ball.xSpeed = currentxSpeed;
                    ball.ySpeed = currentySpeed;
                    count = 0;
                    timerWait.Stop();
                }
            }
        }
    }
}