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
using System.Windows.Shapes;

namespace horzPrototype
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : UserControl
    {
        public UserControl previous;
        public Help(UserControl screen)
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

        private void Button_Click_Baggage(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new HelpBaggage(this));
        }

        private void Button_Click_BannedItems(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new HelpBannedItems(this));
        }

        private void Button_Click_Discounts(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new HelpDiscounts(this));
        }

        private void Button_Click_CheckIn(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new HelpCheckIn(this));
        }
    }
}
