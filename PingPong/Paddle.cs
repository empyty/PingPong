namespace PingPong
{
    class Paddle
    {
        private const int SPEED = 10;
        public int PosX { get; private set; }
        public int PosY { get; }
        public int Width { get; }
        public int Height { get; }
        public int MaxWidth { get; }
        public bool IsStretched { get; }
        public bool IsShort { get; }

        public Paddle()
        {
            // Create Paddle in the middle of the window, as it's centered in xaml we input 0
            Width = 100;
            MaxWidth = 150;
            Height = 10;
            PosX = MainCanvas.WIDTH / 2;
            PosY = Height;
            IsShort = false;
            IsStretched = false;
        }
        
        public int CheckDirection(string direction, int value = SPEED)
        {
            return "left".Equals(direction) ? -value : value;
        }
        public void MovePaddle(int value)
        {
            PosX += value;
        }
    }
}
