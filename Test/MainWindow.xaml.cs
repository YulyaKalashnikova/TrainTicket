using System;
using System.Linq;
using System.Windows;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Helper.s_frame = MainFrame;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Helper.s_frame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            BtnBack.Visibility = Helper.s_frame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
