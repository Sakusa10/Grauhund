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
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class ConfirmationWindow : UserControl
    {
        public UserControl previous;
        public List<BuyTickets1.Ticket> a;
        public List<BuyTickets1.Ticket> c;
        public List<BuyTickets1.Ticket> s;
        public int aNum, cNum, sNum, numBags, freeBags, total;
        public string dep;
        List<TicketInfo> items= new List<TicketInfo>();

        public ConfirmationWindow(UserControl screen, List<BuyTickets1.Ticket> adultTickets, List<BuyTickets1.Ticket> childTickets, List<BuyTickets1.Ticket> seniorTickets, int bags, string departure)
        {
            previous = screen;
            InitializeComponent();

            a = adultTickets;
            c = childTickets;
            s = seniorTickets;
            aNum = a.Count;
            cNum = c.Count;
            sNum = s.Count;
            dep = departure;

            header.Text = " " + dep + "                       Calgary -> Edmonton";

            numBags = bags - (aNum + cNum + sNum);
            freeBags = bags > (aNum + cNum + sNum) ? (aNum + cNum + sNum) : bags;

            if (aNum > 0) items.Add(new TicketInfo() { numTickets = aNum.ToString() + " x   ", ticketType = "Adult Ticket", ticketPrice = (aNum*120.00).ToString() });
            if (cNum > 0) items.Add(new TicketInfo() { numTickets = cNum.ToString() + " x   ", ticketType = "Child Ticket", ticketPrice = (cNum * 60.00).ToString() });
            if (sNum > 0) items.Add(new TicketInfo() { numTickets = sNum.ToString() + " x   ", ticketType = "Senior Ticket", ticketPrice = (sNum * 80.00).ToString() });
            if (freeBags > 0) items.Add(new TicketInfo() { numTickets = freeBags.ToString() + " x   ", ticketType = "Free Bag Tags", ticketPrice = "0" });
            if (numBags > 0) items.Add(new TicketInfo() { numTickets = numBags.ToString() + " x   ", ticketType = "Extra Bag Tags", ticketPrice = (numBags * 20.00).ToString() });
            orderInfo.ItemsSource = items;
            total = aNum * 120 + cNum * 60 + sNum * 80 + ((numBags > 0) ? numBags * 20 : 0);
            totalOwed.Text = "$ "+total.ToString()+".00";

            if (total == 0)
            {
                print.Text = "Print Tickets";
            } else {
                print.Text = "Pay & Print Tickets";
            }
        }

        public ConfirmationWindow(UserControl screen, List<BuyTickets1.Ticket> adultTickets, List<BuyTickets1.Ticket> childTickets, List<BuyTickets1.Ticket> seniorTickets, int bags, string departure, int freebags)
        {
            previous = screen;
            InitializeComponent();

            a = adultTickets;
            c = childTickets;
            s = seniorTickets;
            aNum = a.Count;
            cNum = c.Count;
            sNum = s.Count;
            dep = departure;

            header.Text = " " + dep + "                       Calgary -> Edmonton";

            numBags = bags - freebags;
            freeBags = bags > (aNum + cNum + sNum) ? (aNum + cNum + sNum) : bags;

            if (aNum > 0) items.Add(new TicketInfo() { numTickets = aNum.ToString() + " x   ", ticketType = "Adult Ticket", ticketPrice = "0"});
            if (cNum > 0) items.Add(new TicketInfo() { numTickets = cNum.ToString() + " x   ", ticketType = "Child Ticket", ticketPrice = "0" });
            if (sNum > 0) items.Add(new TicketInfo() { numTickets = sNum.ToString() + " x   ", ticketType = "Senior Ticket", ticketPrice = "0"});
            if (freeBags > 0) items.Add(new TicketInfo() { numTickets = freeBags.ToString() + " x   ", ticketType = "Free Bag Tags", ticketPrice = "0" });
            if (numBags > 0) items.Add(new TicketInfo() { numTickets = numBags.ToString() + " x   ", ticketType = "Extra Bag Tags", ticketPrice = (numBags * 20.00).ToString() });
            orderInfo.ItemsSource = items;
            total = ((numBags > 0) ? numBags * 20 : 0);
            totalOwed.Text = "$ " + total.ToString() + ".00";

            if (total == 0)
            {
                print.Text = "Print Tickets";
            }
            else {
                print.Text = "Pay & Print Tickets";
            }
        }

        public class TicketInfo
        {
            public string numTickets { get; set; }
            public string ticketType { get; set; }
            public string ticketPrice { get; set; }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Window confirmation = new Window()
            {
                Height = 300,
                Width = 416,
                Title = "Please Confirm",
                ResizeMode = 0
            };

            BackConfirm warning = new BackConfirm(confirmation);
            confirmation.Content = warning;
            confirmation.Left = Switcher.getMain().Left + Switcher.getMain().Width / 2 - confirmation.Width / 2;
            confirmation.Top = Switcher.getMain().Top + Switcher.getMain().Height / 2 - confirmation.Height / 2;
            confirmation.ShowDialog();

            if (warning.getResult())
            {
                Switcher.Switch(new MainMenu());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(previous);
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Help(this));
        }

        private void Button_Click_CONTINUE(object sender, RoutedEventArgs e)
        {
            if (total == 0)
            {
                Switcher.Switch(new NowPrintingWindow());
            } else {
                Switcher.Switch(new PinpadWindow());
            }
        }
    }
}