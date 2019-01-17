using System;
using System.Windows.Threading;

namespace PingPong
{
    class BallVM: ObservableObject
    {
        private Ball ball = new Ball();
        
        public BallVM()
        {
             StartBall();
        }
        public double BallPositionY
        {
            get
            {
                return ball.PosY;
            }
        }
        public double BallPositionX
        {
            get
            {
                return ball.PosX;
            }
        }
        public int BallWidth
        {
            get
            {
                return ball.Width;
            }
        }

        private void StartBall()
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(10)
            };
            timer.Start();
            timer.Tick += TimerTick;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            ball.MoveBall();
            NotifyPropertyChanged("BallPositionX");
            NotifyPropertyChanged("BallPositionY");
        }
    }
}
