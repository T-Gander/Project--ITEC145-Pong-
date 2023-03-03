namespace graphics2
{
    public partial class Form1 : Form
    {
        Ball ball;
        Paddle paddle1;
        Paddle paddle2;

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

            paddle1.X = 30;
            paddle2.X = ClientSize.Width - 45;

            paddle1.BallCollisionLeft(paddle1, ball);
            paddle2.BallCollisionRight(paddle2, ball);
        }

        
    }
}