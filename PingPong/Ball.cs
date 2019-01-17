using System;
using System.Windows;

namespace PingPong
{
    class Ball
    {
        public double PosY { get; private set; }
        public double PosX { get; private set; }
        public int Width { get; }
        private bool movingDown;
        private double angle;
        private readonly double speed;
        private readonly Random rand = new Random();

        public Ball()
        {
            Width = 26;
            PosX = rand.Next(MainCanvas.WIDTH - Width / 2);
            PosY = 10;
            movingDown = true;
            angle = 155;
            speed = 3;
        }

        private void CheckIfBouncesOfSides()
        {
            if (CheckIfBallTouchedLeftWall() || CheckIfBallTouchedRightWall())
            {
                angle = -angle;
            }
        }
        private void CheckIfBouncesOfTopOrPaddle()
        {
            //Check for top | Width is the same as Height
            if (CheckIfBallTouchedTop() ||
                CheckIfBallTouchedBottom() && 
                CheckIfBallTouchedPaddle())
            {
                ChangeAngle();
                ChangeDirection();
            }
        }

        private void ChangeAngle()
        {
            if (movingDown)
            {
                angle = 180 + ((PosX + Width) - (PaddleVM.Paddle.PosX - PaddleVM.Paddle.Width));
            }
            else if (!movingDown)
            {
                angle = 180 - angle;
            }

        }

        private void ChangeDirection()
        {
            movingDown = !movingDown;
        }

        private bool CheckIfBallTouchedLeftWall()
        {
            return (PosX <= 0);
        }
        private bool CheckIfBallTouchedRightWall()
        {
            return (PosX >= MainCanvas.WIDTH - Width);
        }
        private bool CheckIfBallTouchedTop()
        {
            return (!movingDown && PosY <= 0);
        }
        private bool CheckIfBallTouchedBottom()
        {
            /* Is ball moving down? Is it's position at the bottom of the canvas (we deduct its Width(Height) because
             * it's counted from top, also deduct height of paddle*/
            return (movingDown && PosY >= MainCanvas.HEIGHT - Width - PaddleVM.Paddle.Height);
        }
        private bool CheckIfBallTouchedPaddle()
        {
            return (PosX >= PaddleVM.Paddle.PosX && PosX <= PaddleVM.Paddle.PosX + PaddleVM.Paddle.Width &&
                PosY <= MainCanvas.HEIGHT);
        }

        public void MoveBall()
        {
            CheckIfBouncesOfSides();
            CheckIfBouncesOfTopOrPaddle();
            double radians = (Math.PI / 180) * angle;
            Vector vector = new Vector { X = Math.Sin(radians), Y = -Math.Cos(radians) };
            PosX += vector.X * speed;
            PosY += vector.Y * speed;
        }
    }
}
