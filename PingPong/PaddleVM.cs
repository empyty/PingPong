using System.Windows.Input;

namespace PingPong
{
    class PaddleVM : ObservableObject
    {
        public static Paddle Paddle { get; } = new Paddle();

        const string LEFT = "left";
        const string RIGHT = "right";

        public int PaddlePositionX
        {
            get
            {
                return Paddle.PosX;
            }
        }
        public int PaddlePositionY
        {
            get
            {
                return Paddle.PosY;
            }
        }
        public int PaddleWidth
        {
            get
            {
                return Paddle.Width;
            }
        }
        public int PaddleMaxWidth
        {
            get
            {
                return Paddle.MaxWidth;
            }
        }
        public int PaddleHeight
        {
            get
            {
                return Paddle.Height;
            }
        }

        private ICommand movePaddle;
        public ICommand CommandMovePaddle
        {
            get
            {
                return movePaddle = new RelayCommand(CanMovePaddle, MovePaddle);
            }
        }
        private bool CanMovePaddle(object parameter)
        {
            const int BOUNDARY = MainCanvas.WIDTH;
            int valueOfDirection = Paddle.CheckDirection(parameter.ToString());
            return (CanPaddleMoveLeft(valueOfDirection) || CanPaddleMoveRight(valueOfDirection, BOUNDARY));
        }
        private bool CanPaddleMoveLeft(int valueOfDirection)
        {
            return (PaddlePositionX > 0 && valueOfDirection < 0);
        }
        private bool CanPaddleMoveRight(int valueOfDirection, int boundary)
        {
            return (PaddlePositionX < boundary - Paddle.Width && valueOfDirection > 0);
        }
        private void MovePaddle(object direction)
        {
            int movementValue = Paddle.CheckDirection(direction.ToString());
            Paddle.MovePaddle(movementValue);
            NotifyPropertyChanged("PaddlePositionX");
        }
    }
}
