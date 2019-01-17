namespace PingPong
{
    class SingleDataContext
    {
        public MainCanvasVM MainCanvasVM { get; } = new MainCanvasVM();
        public PaddleVM PaddleVM { get; } = new PaddleVM();
        public RestartVM RestartVm { get; } = new RestartVM();
        public BallVM BallVM { get; } = new BallVM();
    }
}
