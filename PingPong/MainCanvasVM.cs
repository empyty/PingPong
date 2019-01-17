namespace PingPong
{
    class MainCanvasVM
    {
        public int CanvasHeight
        {
            get
            {
                return MainCanvas.HEIGHT;
            }
        }
        public int CanvasWidth
        {
            get
            {
                return MainCanvas.WIDTH;
            }
        }

        private const int WINDOW_BORDER = 30;

        public int HeightForMainWindow
        {
            get
            {
                return MainCanvas.HEIGHT + WINDOW_BORDER;
            }
        }
        public int WidthForMainWindow
        {
            get
            {
                return MainCanvas.WIDTH + WINDOW_BORDER;
            }
        }
        
    }
}
