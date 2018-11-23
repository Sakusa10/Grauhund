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

namespace horzPrototype
{
    /// <summary>
    /// Interaction logic for RouteInfoScreen.xaml
    /// </summary>
    public partial class RouteInfoScreen : UserControl
    {
        public UserControl previous;
        public RouteInfoScreen(UserControl screen)
        {
            previous = screen;
            InitializeComponent();
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

        private void Button_Click_DEPART(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Departures(this));
        }

        private void Button_Click_ARRIVE(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Arrivals(this));
        }
    }
}
