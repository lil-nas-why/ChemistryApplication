using System;
using System.Windows;

namespace ChemestryApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameManager.MainFrame = MainFrame;
            FrameManager.MainFrame.Navigate(new HomePage());
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if(FrameManager.MainFrame.CanGoBack)
            {
                GoBackButton.Visibility = Visibility.Visible;
            }
            else
            {
                GoBackButton.Visibility = Visibility.Hidden;
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.GoBack();
        }
    }
}
