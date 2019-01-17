using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace PingPong
{
    public class RestartVM
    {
        private static string RestartMessage { get; } = "Do you want to restart the game?";

        public void Restart()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
            
        }


        private ICommand viewMessage;

        public ICommand ViewMessageCommand
        {
            get
            {
                return viewMessage = new RelayCommand(CanView,DisplayMessage);
            }
        }

        private bool CanView(object parameter)
        {
            return true;
        }       
        

        private void DisplayMessage(object parameter)
        {
            MessageBoxResult result = MessageBox.Show(RestartMessage,  
                "RESTART", MessageBoxButton.YesNoCancel);

            switch (result)
            {
                    case MessageBoxResult.Yes:
                // Yes code here 
                        Restart();
                        break;
                    case MessageBoxResult.No:  
                // No code here  
                        break;
                    case MessageBoxResult.Cancel:
                // Cancel code here  
                        break;
            }
        }
    }
}