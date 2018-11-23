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
using MahApps.Metro.Controls;

namespace horzPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BuyTickets2 : UserControl
    {
        public UserControl previous;
        public List<BuyTickets1.Ticket> a;
        public List<BuyTickets1.Ticket> c;
        public List<BuyTickets1.Ticket> s;
        public bool routeSelected;
        public Brush color;
        public string dep;

        public BuyTickets2(UserControl screen, List<BuyTickets1.Ticket> adultTickets, List<BuyTickets1.Ticket> childTickets, List<BuyTickets1.Ticket> seniorTickets)
        {
            previous = screen;
            InitializeComponent();

            a = adultTickets; c = childTickets; s = seniorTickets;

            routeSelected = false;

            seatTotal.Content = "Total Seats Required: " + (a.Count + c.Count + s.Count);

            int price = (80 * s.Count) + (60 * c.Count) + (120 * a.Count);

            if (price > 999)
            {
                route1.Content = "12:30 AM        3:30 AM        $" + price + "      On Time";
                route2.Content = "  1:30 AM        4:30 AM        $" + price + "      On Time";
                route3.Content = "  2:30 AM        5:30 AM        $" + price + "      On Time";
                route4.Content = "  5:15 AM        8:15 AM        $" + price + "      Delayed";
                route5.Content = "  7:30 AM      10:30 AM        $" + price + "      On Time";
                route6.Content = "  9:30 AM      12:30 PM        $" + price + "      On Time";
            }
            else
            {
                route1.Content = "12:30 AM        3:30 AM        $" + price + "        On Time";
                route2.Content = "  1:30 AM        4:30 AM        $" + price + "        On Time";
                route3.Content = "  2:30 AM        5:30 AM        $" + price + "        On Time";
                route4.Content = "  5:15 AM        8:15 AM        $" + price + "        Delayed";
                route5.Content = "  7:30 AM      10:30 AM        $" + price + "        On Time";
                route6.Content = "  9:30 AM      12:30 PM        $" + price + "        On Time";
            }

            if (a.Count + c.Count + s.Count > 3)
            {
                route2.Foreground = Brushes.Red;
                route2.IsEnabled = false;

                if (price > 999)
                {
                    route2.Content = "  1:30 AM        4:30 AM        $" + price + "      3 Seats Left";
                }
                else
                {
                    route2.Content = "  1:30 AM        4:30 AM        $" + price + "        3 Seats Left";
                }
            }

            color = route1.Background;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(previous);
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Help(this));
        }

        private void unselect()
        {
            route1.Background = color;
            route2.Background = color;
            route3.Background = color;
            route4.Background = color;
            route5.Background = color;
            route6.Background = color;
            selectRoute.Visibility = Visibility.Hidden;
            duration.Content = "Duration: 3h 0m";
        }

        private void route_click1(object sender, RoutedEventArgs e)
        {
            dep = "12:30 AM";
            seatsLeft.Content = "Seats Left: 24";
            bus_number.Content = "Bus Number: AC20";
            routeSelected = true;
            unselect();
            route1.Background = Brushes.LightGray;
        }

        private void route_click2(object sender, RoutedEventArgs e)
        {
            dep = "01:30 AM";
            seatsLeft.Content = "Seats Left: 3";
            bus_number.Content = "Bus Number: BL52";
            routeSelected = true;
            unselect();
            route2.Background = Brushes.LightGray;
        }

        private void route_click3(object sender, RoutedEventArgs e)
        {
            dep = "02:30 AM";
            seatsLeft.Content = "Seats Left: 15";
            bus_number.Content = "Bus Number: CD12";
            routeSelected = true;
            unselect();
            route3.Background = Brushes.LightGray;
        }

        private void route_click4(object sender, RoutedEventArgs e)
        {
            dep = "05:15 AM";
            seatsLeft.Content = "Seats Left: 17";
            bus_number.Content = "Bus Number: DW21";
            routeSelected = true;
            unselect();
            route4.Background = Brushes.LightGray;
        }

        private void route_click5(object sender, RoutedEventArgs e)
        {
            dep = "07:30 AM";
            seatsLeft.Content = "Seats Left: 19";
            bus_number.Content = "Bus Number: PV03";
            routeSelected = true;
            unselect();
            route5.Background = Brushes.LightGray;
        }

        private void route_click6(object sender, RoutedEventArgs e)
        {
            dep = "09:30 AM";
            seatsLeft.Content = "Seats Left: 10";
            bus_number.Content = "Bus Number: XO24";
            routeSelected = true;
            unselect();
            route6.Background = Brushes.LightGray;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (routeSelected) {
                error_route.Text = "";
                Switcher.Switch(new BuyTickets3(this, a, c, s, dep));
            }
            else {
                error_route.Text = "Please select a route";
            }
        }
    }
}