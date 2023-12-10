using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test.Services;

namespace Test.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var service = new Service(Helper.GetContext());
            try
            {
                var user = service.Authorization(LoginBox.Text, PasswordBox.Password);
                Helper.s_user = user;
                switch (user.RoleID)
                {
                    case 1:
                        break;
                    case 2:
                        Helper.s_frame.Navigate(new MainPage(user));
                        break;
                }
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("Данного пользователя нет в системе!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Пустые поля!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            Helper.s_frame.Navigate(new RegPage());
        }
    }
}
