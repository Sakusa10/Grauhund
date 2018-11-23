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
    public partial class Arrivals : UserControl
    {
        public UserControl previous;

        private String busNumber = "Bus Number: ";
        private String src = "Coming From: ";
        private String departTime = "Depart Time: ";
        private String arrivalTime = "Arrival Time: ";

        private String routeDescrption = "\n Stops on the way: dolor, sit amet\n Refreshments: none\n WiFi provided: Yes";

        List<RouteInf> items = new List<RouteInf>();

        private DateTime today = DateTime.Today;
        private DateTime tomorrow = DateTime.Today.AddDays(1);

        public Arrivals(UserControl screen)
        {
            previous = screen;
            InitializeComponent();

            items.Add(new RouteInf() { ArrTime = "12:30 AM", SrcTime = "7:00 PM", City = "Edmonton", BusCode = "AC20" });
            items.Add(new RouteInf() { ArrTime = "3:30 AM", SrcTime = "12:00 AM", City = "Vancouver", BusCode = "SD42" });
            items.Add(new RouteInf() { ArrTime = "3:30 AM", SrcTime = "5:00 AM", City = "Vancouver", BusCode = "GX52" });
            items.Add(new RouteInf() { ArrTime = "4:30 AM", SrcTime = "1:00 AM", City = "Seattle", BusCode = "PS02" });
            items.Add(new RouteInf() { ArrTime = "5:00 AM", SrcTime = "2:00 AM", City = "Airdrie", BusCode = "IO20" });
            items.Add(new RouteInf() { ArrTime = "6:30 AM", SrcTime = "3:00 AM", City = "Kelowna", BusCode = "SA88" });
            items.Add(new RouteInf() { ArrTime = "6:30 AM", SrcTime = "5:30 AM", City = "Kelowna", BusCode = "SV70" });
            items.Add(new RouteInf() { ArrTime = "8:30 AM", SrcTime = "6:00 AM", City = "Edmonton", BusCode = "FW40" });
            items.Add(new RouteInf() { ArrTime = "8:30 AM", SrcTime = "4:00 AM", City = "Edmonton", BusCode = "SE70" });
            items.Add(new RouteInf() { ArrTime = "9:30 AM", SrcTime = "7:00 AM", City = "Vancouver", BusCode = "ND41" });
            items.Add(new RouteInf() { ArrTime = "10:30 AM", SrcTime = "8:00 AM", City = "Kelowna", BusCode = "NE70" });
            items.Add(new RouteInf() { ArrTime = "11:30 AM", SrcTime = "9:00 AM", City = "Edmonton", BusCode = "RE70" });
            items.Add(new RouteInf() { ArrTime = "12:30 PM", SrcTime = "10:00 AM", City = "Vancouver", BusCode = "XD45" });

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
            public string ArrTime { get; set; }
            public string City { get; set; }
            public string BusCode { get; set; }
            public string SrcTime { get; set;}
        }

        private void routeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(routeList.SelectedItem != null && (datePicker.SelectedDate.Equals(today) || datePicker.SelectedDate.Equals(tomorrow)))
            {
                RouteInf x = (RouteInf) routeList.SelectedItem;
                String code = x.BusCode;
                String SrcCity = x.City;
                String Arrtime = x.ArrTime;
                String srcTime = x.SrcTime;

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

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(datePicker.SelectedDate.Equals(today) || datePicker.SelectedDate.Equals(tomorrow)))
            {
                NoRouteLabel.Text = "No route info available";
                ArrivalTimeLabel.Content = "";
                DestinationLabel.Content = "";
                BusNumberLabel.Content = "";
                DepartTimeLabel.Content = "";
                List <RouteInf> blank = new List<RouteInf>();
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

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            String typedIn = searchBox.Text;
            List<RouteInf> newList = new List<RouteInf>();

            if(!String.IsNullOrWhiteSpace(typedIn) && !String.IsNullOrEmpty(typedIn) && (datePicker.SelectedDate.Equals(today) || datePicker.SelectedDate.Equals(tomorrow)))
            {
                foreach(RouteInf ri in items)
                {
                    if(ri.BusCode.ToUpper().Contains(typedIn.ToUpper()) || ri.City.ToUpper().Contains(typedIn.ToUpper()))
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