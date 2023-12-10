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
    /// Логика взаимодействия для BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        Schedules _outbound;
        Schedules _arrival;
        Wagons _wagon;
        public BookingPage(Schedules outbound, Wagons wagon, Schedules arrival = null)
        {
            InitializeComponent();
            _outbound = outbound;
            _arrival = arrival;
            _wagon = wagon;
            if (_arrival == null)
                ArrivalBox.Visibility = Visibility.Collapsed;
            DataContext = new { Outbound = _outbound, Arrival = _arrival, Wagon = _wagon };
        }

        private void BtnAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameBox.Text)
                || string.IsNullOrWhiteSpace(FirstNameBox.Text))
            {
                return;
            }
            PassportData passenger = new PassportData();
            if (IssueDateBox.SelectedDate.HasValue)
                passenger.DateOfIssue = IssueDateBox.SelectedDate.Value;
            passenger.FirstName = FirstNameBox.Text;
            passenger.LastName = LastNameBox.Text;
            passenger.MiddleName = MiddleNameBox.Text;
            passenger.Series = SeriesBox.Text;
            passenger.Number = NumberBox.Text;
            PassengersGrid.Items.Add(passenger);
        }

        private void BtnDeletePassengers_Click(object sender, RoutedEventArgs e)
        {
            if (PassengersGrid.SelectedItem is PassportData passenger)
            {
                PassengersGrid.Items.Remove(passenger);
                PassengersGrid.Items.Refresh();
            }
        }

        List<PassportData> _passengers;
        private void BtnConfirmBooking_Click(object sender, RoutedEventArgs e)
        {
            var service = new Service(Helper.GetContext());
            _passengers = new List<PassportData>();
            foreach (var item in PassengersGrid.Items.Cast<PassportData>().ToList())
            {
                var duplicate = Helper.GetContext().PassportData.SingleOrDefault(x => x.LastName == item.LastName && x.FirstName == item.FirstName);
                if (duplicate != null)
                {
                    _passengers.Add(duplicate);
                }
                else
                {
                    Helper.GetContext().PassportData.Add(item);
                    Helper.GetContext().SaveChanges();
                    var last = Helper.GetContext().PassportData.ToList().LastOrDefault();
                    _passengers.Add(last);
                }
            }

            if (_outbound != null)
            {
                foreach (var item in _passengers)
                {
                    try
                    {
                        service.AddTicket(Helper.s_user, item, _outbound, _wagon);
                    }
                    catch (StackOverflowException)
                    {
                        continue;
                    }
                }
            }
            if (_arrival != null)
            {
                foreach (var item in _passengers)
                {
                    try
                    {
                        service.AddTicket(Helper.s_user, item, _arrival, _wagon);
                    }
                    catch (StackOverflowException)
                    {
                        continue;
                    }
                }
            }
            Helper.s_frame.GoBack();
        }
    }
}
