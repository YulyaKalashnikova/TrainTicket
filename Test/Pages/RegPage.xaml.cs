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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            DataContext = new Users();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var user = DataContext as Users;
            var service = new Service(Helper.GetContext());
            try
            {
                service.Registration(TbEmail.Text, TbPassword.Text, user.PassportData);
            }
            catch (StackOverflowException)
            {
                MessageBox.Show("Данный пользователь есть в системе!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Пустые поля!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
