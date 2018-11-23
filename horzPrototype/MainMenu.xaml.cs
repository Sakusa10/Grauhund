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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_Click_BUY_TICKETS(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new BuyTickets1(this));
        }

        private void Button_Click_PICK_UP(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new PickUpScreen(this));
        }

        private void Button_Click_ROUTE(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RouteInfoScreen(this));
        }

        private void Button_Click_BAG_TAGS(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new PurchaseBagTagsScreen(this));
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Help(this));
        }
    }
}