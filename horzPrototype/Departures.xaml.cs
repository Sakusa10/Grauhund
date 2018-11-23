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
    public partial class Departures : UserControl
    {
        public UserControl previous;

        private String busNumber = "Bus Number: ";
        private String src = "Destination: ";
        private String departTime = "Depart Time: ";
        private String arrivalTime = "Arrival Time: ";

        private String routeDescrption = "\n Stops on the way: dolor, sit amet\n Refreshments: none\n WiFi provided: Yes";

        List<RouteInf> items = new List<RouteInf>();

        private DateTime today = DateTime.Today;
        private DateTime tomorrow = DateTime.Today.AddDays(1);

        public Departures(UserControl screen)
        {
            previous = screen;
            InitializeComponent();

            items.Add(new RouteInf() { DepTime = "12:30 AM", DestTime = "7:00 AM", City = "Edmonton", BusCode = "AC20" });
            items.Add(new RouteInf() { DepTime = "3:30 AM", DestTime = "12:00 PM", City = "Vancouver", BusCode = "SD42" });
            items.Add(new RouteInf() { DepTime = "3:30 AM", DestTime = "5:00 AM", City = "Vancouver", BusCode = "GX52" });
            items.Add(new RouteInf() { DepTime = "4:30 AM", DestTime = "1:00 PM", City = "Seattle", BusCode = "PS02" });
            items.Add(new RouteInf() { DepTime = "6:30 AM", DestTime = "9:30 AM", City = "Kelowna", BusCode = "SV70" });
            items.Add(new RouteInf() { DepTime = "8:30 AM", DestTime = "11:00 AM", City = "Edmonton", BusCode = "SE70" });
            items.Add(new RouteInf() { DepTime = "9:30 AM", DestTime = "11:00 AM", City = "Edmonton", BusCode = "RE70" });
            items.Add(new RouteInf() { DepTime = "10:00 AM", DestTime = "2:00 PM", City = "Airdrie", BusCode = "IO20" });
            items.Add(new RouteInf() { DepTime = "10:30 AM", DestTime = "6:00 PM", City = "Edmonton", BusCode = "FW40" });
            items.Add(new RouteInf() { DepTime = "11:30 AM", DestTime = "3:00 PM", City = "Kelowna", BusCode = "SA88" });
            items.Add(new RouteInf() { DepTime = "11:30 AM", DestTime = "7:00 PM", City = "Vancouver", BusCode = "ND41" });
            items.Add(new RouteInf() { DepTime = "12:30 PM", DestTime = "10:00 PM", City = "Vancouver", BusCode = "XD45" });
            items.Add(new RouteInf() { DepTime = "5:30 PM", DestTime = "8:00 PM", City = "Kelowna", BusCode = "NE70" });

            routeList.ItemsSource = items;

            datePicker.SelectedDate = DateTime.Today;
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

        private T FindVisualChild<T>(DependencyObject depencencyObject) where T : DependencyObject
        {
            if (depencencyObject != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depencencyObject); ++i)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depencencyObject, i);
                    T result = (child as T) ?? FindVisualChild<T>(child);
                    if (result != null)
                        return result;
                }
            }

            return null;
        }

        public class RouteInf
        {
            public string DepTime { get; set; }
            public string City { get; set; }
            public string BusCode { get; set; }
            public string DestTime { get; set; }
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(datePicker.SelectedDate.Equals(today) || datePicker.SelectedDate.Equals(tomorrow)))
            {
                NoRouteLabel.Text = "No route info available";
                ArrivalTimeLabel.Content = "";
                DestinationLabel.Content = "";
                BusNumberLabel.Content = "";
                DepartTimeLabel.Content = "";
                List<RouteInf> blank = new List<RouteInf>();
                routeList.ItemsSource = blank;
                extra.Text = "";
            }
            else
            {
                NoRouteLabel.Text = "Select a route from the left";
                ArrivalTimeLabel.Content = "";
                DestinationLabel.Content = "";
                BusNumberLabel.Content = "";
                DepartTimeLabel.Content = "";
                routeList.ItemsSource = items;
                extra.Text = "";

                String typedIn = searchBox.Text;
                List<RouteInf> newList = new List<RouteInf>();

                if (!String.IsNullOrWhiteSpace(typedIn) && !String.IsNullOrEmpty(typedIn))
                {
                    foreach (RouteInf ri in items)
                    {
                        if (ri.BusCode.ToUpper().Contains(typedIn.ToUpper()) || ri.City.ToUpper().Contains(typedIn.ToUpper()))
                            newList.Add(ri);
                    }
                    routeList.ItemsSource = newList;

                    if (newList.Count == 0)
                    {
                        NoRouteLabel.Text = "No route info available";
                        ArrivalTimeLabel.Content = "";
                        DestinationLabel.Content = "";
                        BusNumberLabel.Content = "";
                        DepartTimeLabel.Content = "";
                        extra.Text = "";
                    }
                    else
                    {
                        NoRouteLabel.Text = "Select a route from the left";
                        ArrivalTimeLabel.Content = "";
                        DestinationLabel.Content = "";
                        BusNumberLabel.Content = "";
                        DepartTimeLabel.Content = "";
                        extra.Text = "";
                    }
                }
            }
        }

        private void routeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (routeList.SelectedItem != null && (datePicker.SelectedDate.Equals(today) || datePicker.SelectedDate.Equals(tomorrow)))
            {
                RouteInf x = (RouteInf)routeList.SelectedItem;
                String code = x.BusCode;
                String SrcCity = x.City;
                String Arrtime = x.DestTime;
                String srcTime = x.DepTime;

                NoRouteLabel.Text = "";
                ArrivalTimeLabel.Content = arrivalTime + Arrtime;
                DestinationLabel.Content = src + SrcCity;
                BusNumberLabel.Content = busNumber + code;
                DepartTimeLabel.Content = departTime + srcTime;

                extra.Text = "";
                extra.Inlines.Add(new Bold(new Run(" Extra route Information: ")));
                extra.Inlines.Add(new Run(routeDescrption));
            }
            else
            {
                NoRouteLabel.Text = "No route info available";
                ArrivalTimeLabel.Content = "";
                DestinationLabel.Content = "";
                BusNumberLabel.Content = "";
                DepartTimeLabel.Content = "";
                List<RouteInf> blank = new List<RouteInf>();
                routeList.ItemsSource = blank;
                extra.Text = "";
            }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String typedIn = searchBox.Text;
            List<RouteInf> newList = new List<RouteInf>();

            if (!String.IsNullOrWhiteSpace(typedIn) && !String.IsNullOrEmpty(typedIn) && (datePicker.SelectedDate.Equals(today) || datePicker.SelectedDate.Equals(tomorrow)))
            {
                foreach (RouteInf ri in items)
                {
                    if (ri.BusCode.ToUpper().Contains(typedIn.ToUpper()) || ri.City.ToUpper().Contains(typedIn.ToUpper()))
                        newList.Add(ri);
                }
                routeList.ItemsSource = newList;

                if(newList.Count == 0)
                {
                    NoRouteLabel.Text = "No route info available";
                    ArrivalTimeLabel.Content = "";
                    DestinationLabel.Content = "";
                    BusNumberLabel.Content = "";
                    DepartTimeLabel.Content = "";
                    extra.Text = "";
                }
                else
                {
                    NoRouteLabel.Text = "Select a route from the left";
                    ArrivalTimeLabel.Content = "";
                    DestinationLabel.Content = "";
                    BusNumberLabel.Content = "";
                    DepartTimeLabel.Content = "";
                    extra.Text = "";
                }
            }
            else if (datePicker.SelectedDate.Equals(today) || datePicker.SelectedDate.Equals(tomorrow))
            {
                routeList.ItemsSource = items;
                NoRouteLabel.Text = "Select a route from the left";
                ArrivalTimeLabel.Content = "";
                DestinationLabel.Content = "";
                BusNumberLabel.Content = "";
                DepartTimeLabel.Content = "";
                extra.Text = "";
            }
            else
            {
                NoRouteLabel.Text = "No route info available";
                ArrivalTimeLabel.Content = "";
                DestinationLabel.Content = "";
                BusNumberLabel.Content = "";
                DepartTimeLabel.Content = "";
                extra.Text = "";
            }
        }
    }
}
