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

namespace Test.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(Users user)
        {
            InitializeComponent();
            Load();
            LoadData();
            DataContext = user;
        }

        private void LoadData()
        {
            var from = CmbFrom.SelectedItem as Stations;
            var to = CmbTo.SelectedItem as Stations;
            var outBound = DpOutbound.SelectedDate;
            var arrival = DpArrival.SelectedDate;

            var outbouns = Helper.GetContext().Schedules.ToList()
                           .Where(x => (x.Routes.Stations.ID == from?.ID || from?.ID == 0)
                                       && (x.Routes.Stations1.ID == to?.ID || to?.ID == 0))
                           .ToList();
            if (outBound.HasValue)
            {
                outbouns = outbouns.Where(x => x.Date == outBound.Value).ToList();
            }
            OutboundGrid.ItemsSource = outbouns;
            if (_tag == 2)
            {
                var arrivals = Helper.GetContext().Schedules.ToList()
                           .Where(x => (x.Routes.Stations1.ID == from?.ID || from?.ID == 0)
                                       && (x.Routes.Stations.ID == to?.ID || to?.ID == 0))
                           .ToList();
                if (arrival.HasValue)
                {
                    arrivals = arrivals.Where(x => x.Date == arrival.Value).ToList();
                }
                ReturnsGrid.ItemsSource = arrivals;
            }
        }

        private void Load()
        {
            RolesBox.ItemsSource = Helper.GetContext().Roles.ToList();
            List<Stations> stations = Helper.GetContext().Stations.ToList();
            stations.Insert(0, new Stations() { Code = "All Stations" });
            CmbFrom.ItemsSource = stations;
            CmbTo.ItemsSource = stations;
            RoutesGrid.ItemsSource = Helper.GetContext().Routes.ToList();
            CmbWagons.ItemsSource = Helper.GetContext().Wagons.ToList();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            Helper.GetContext().SaveChanges();
        }

        private void BtnApply_OnClick(object sender, RoutedEventArgs e)
        {
            if (CmbFrom.SelectedIndex != 0 && CmbTo.SelectedIndex != 0)
            {
                if (CmbFrom.Text == CmbTo.Text)
                {
                    MessageBox.Show("Станции не могут быть одинаковыми", "Информация",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }
            LoadData();
        }

        private void BtnFavorite_Click(object sender, RoutedEventArgs e)
        {
            var route = (sender as Button).DataContext as Routes;
            if (!route.IsFavorite)
                Helper.s_user.Routes.Add(route);
            else
                Helper.s_user.Routes.Remove(route);
            Helper.GetContext().SaveChanges();
            RoutesGrid.ItemsSource = Helper.GetContext().Routes.ToList();

        }

        private int _tag = 0;
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            _tag = int.Parse((sender as RadioButton).Tag.ToString());
        }

        private void BtnBooking_Click(object sender, RoutedEventArgs e)
        {
            var wagon = CmbWagons.SelectedItem as Wagons;
            if (OutboundGrid.SelectedItem is Schedules outboundSchedule && ReturnsGrid.SelectedItem is Schedules returnSchedule)
            {
                Helper.s_frame.Navigate(new BookingPage(outboundSchedule, wagon, returnSchedule));
            }
            else if (OutboundGrid.SelectedItem is Schedules outbound)
            {
                Helper.s_frame.Navigate(new BookingPage(outbound, wagon));
            }
        }
    }
}
