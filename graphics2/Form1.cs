namespace graphics2
{
    public partial class Form1 : Form
    {
        Ball ball;
        public Form1()
        {
            InitializeComponent();
            Ball.mainForm = this;

            // add the following commands to any program that is drawing graphics
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            this.Paint += Form1_Paint;
            timer1.Enabled = true;

            ball = new Ball(ClientSize.Width / 2, ClientSize.Height / 2);
            

        }

        private void Form1_Paint(object? sender, PaintEventArgs e)
        {
            ball.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate(false);   // this will force the Paint event to fire
        }

        
    }
}