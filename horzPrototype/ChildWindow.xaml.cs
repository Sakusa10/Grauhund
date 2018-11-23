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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class ChildWindow : UserControl
    {
        public UserControl previous;
        public List<BuyTickets1.Ticket> a;
        public List<BuyTickets1.Ticket> c;
        public List<BuyTickets1.Ticket> s;
        public ChildWindow(UserControl screen, List<BuyTickets1.Ticket> adultTicket, List<BuyTickets1.Ticket> childTicket, List<BuyTickets1.Ticket> seniorTicket)
        {
            previous = screen;
            InitializeComponent();

            a = adultTicket;
            c = childTicket;
            s = seniorTicket;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Help(this));
        }

        private void Button_Click_BACK(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(previous);
        }

        private void Button_Click_UNDERSTOOD(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new BuyTickets2(previous, a, c, s));
        }
    }
}
