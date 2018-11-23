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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PurchaseBagTagsScreen : UserControl
    {
        public UserControl previous;
        public int bag;
        public bool validNum;
        public List<BuyTickets1.Ticket> a = new List<BuyTickets1.Ticket>();
        public List<BuyTickets1.Ticket> c = new List<BuyTickets1.Ticket>();
        public List<BuyTickets1.Ticket> s = new List<BuyTickets1.Ticket>();
        public string dep;

        public PurchaseBagTagsScreen(UserControl screen)
        {
            previous = screen;
            InitializeComponent();

            bag = 0;
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

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (validNum && bag > 0)
            {
                invalid.Content = "";
                Switcher.Switch(new ConfirmationWindow(this, a, c, s, bag, dep, Switcher.getMain().freeTagsLeft[Switcher.getMain().user]));
            }
            else if (validNum == false)
            {
                invalid.Content = "Please enter a valid purchase number";
            }
            else
            {
                invalid.Content = "Please add at least one bag tag";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            included.Content = "";
            bag_num.Content = "0";
            String PN = searchBox.Text;
            Boolean shouldClear = true;

            // "database" of purchase numbers gets stored in the main window now
            String[] val = Switcher.getMain().val;
            String[] names = Switcher.getMain().names;
            int[] ticketsBought = Switcher.getMain().ticketsBought;
            int[] freeTagsLeft = Switcher.getMain().freeTagsLeft;

            for (int i = 0; i < val.Length; i++)
            {
                if (PN == val[i])
                {
                    shouldClear = false;
                    invalid.Content = "";
                    check.Visibility = Visibility.Visible;
                    included.Visibility = Visibility.Visible;
                    barcode1.Visibility = Visibility.Collapsed;
                    text_bar1.Visibility = Visibility.Collapsed;
                    validNum = true;

                    a = new List<BuyTickets1.Ticket>();
                    c = new List<BuyTickets1.Ticket>();
                    s = new List<BuyTickets1.Ticket>();
                    switch (PN)
                    {
                        case "10136357":
                            a.Add(new BuyTickets1.Ticket() { passengerType = 0, numBags = 0, fname = "", lname = "" });
                            a.Add(new BuyTickets1.Ticket() { passengerType = 0, numBags = 0, fname = "", lname = "" });
                            a.Add(new BuyTickets1.Ticket() { passengerType = 0, numBags = 0, fname = "", lname = "" });
                            a.Add(new BuyTickets1.Ticket() { passengerType = 0, numBags = 0, fname = "", lname = "" });
                            dep = "07:30 PM";
                            break;
                        case "10156079":
                            a.Add(new BuyTickets1.Ticket() { passengerType = 0, numBags = 0, fname = "", lname = "" });
                            c.Add(new BuyTickets1.Ticket() { passengerType = 1, numBags = 0, fname = "", lname = "" });
                            dep = "12:30 AM";
                            break;
                        case "10078908":
                            a.Add(new BuyTickets1.Ticket() { passengerType = 0, numBags = 0, fname = "", lname = "" });
                            c.Add(new BuyTickets1.Ticket() { passengerType = 1, numBags = 0, fname = "", lname = "" });
                            dep = "11:30 PM";
                            break;
                    }
                    Switcher.getMain().user = i;
                    nameLabel.Visibility = Visibility.Visible;
                    name.Visibility = Visibility.Visible;
                    name.Content = names[i];
                    ticketsLabel.Visibility = Visibility.Visible;
                    tickets.Visibility = Visibility.Visible;
                    tickets.Content = ticketsBought[i];
                    included.Content = freeTagsLeft[i] + " free bag" + (freeTagsLeft[i] == 1 ? "" : "s") + " available";
                }
            }
            if (shouldClear)
            {
                if (PN.Length == 8)
                {
                    ex.Visibility = Visibility.Visible;
                }
                else
                {
                    ex.Visibility = Visibility.Collapsed;
                }
                check.Visibility = Visibility.Collapsed;
                barcode1.Visibility = Visibility.Visible;
                text_bar1.Visibility = Visibility.Visible;
                nameLabel.Visibility = Visibility.Collapsed;
                name.Visibility = Visibility.Collapsed;
                ticketsLabel.Visibility = Visibility.Collapsed;
                tickets.Visibility = Visibility.Collapsed;
                validNum = false;

                bag = 0;
                update();
                invalid.Content = "";
            }
            shouldClear = true;
        }

        private void update()
        {
            bag_num.Content = bag;
        }

        private void add_Bag(object sender, RoutedEventArgs e)
        {
            String[] val = Switcher.getMain().val;

            if (searchBox.Text == val[0] || searchBox.Text == val[1] || searchBox.Text == val[2])
            {
                switch (searchBox.Text)
                {
                    case "10136357":
                        if (bag < 12)
                        {
                            bag++;
                            int free = (bag >= a.Count + c.Count + s.Count) ? 0 : (a.Count + c.Count + s.Count - bag);
                            included.Content = free + " free bag" + (free == 1 ? "" : "s") + " available";
                        }
                        else invalid.Content = "Limit of 3 checked bags per person";
                        break;
                    case "10156079":
                        if (bag < 6)
                        {
                            bag++;
                            int free = (bag >= a.Count + c.Count + s.Count) ? 0 : (a.Count + c.Count + s.Count - bag);
                            included.Content = free + " free bag" + (free == 1 ? "" : "s") + " available";
                        }
                        else invalid.Content = "Limit of 3 checked bags per person";
                        break;
                    case "10078908":
                        if (bag < 6)
                        {
                            bag++;
                            int free = (bag >= a.Count + c.Count + s.Count) ? 0 : (a.Count + c.Count + s.Count - bag);
                            included.Content = free + " free bag" + (free == 1 ? "" : "s") + " available";
                        }
                        else invalid.Content = "Limit of 3 checked bags per person";
                        break;
                }
                update();
            }
            else
            {
                invalid.Content = "Please enter a valid purchase number";
            }
        }

        private void sub_Bag(object sender, RoutedEventArgs e)
        {
            if (bag > 0)
            {
                bag--;
                int free = (bag >= a.Count + c.Count + s.Count) ? 0 : (a.Count + c.Count + s.Count - bag);
                included.Content = free + " free bag" + (free == 1 ? "" : "s") + " available";
                if ((String)invalid.Content == "Limit of 3 checked bags per person")
                {
                    invalid.Content = "";
                }
            }
            update();
        }
    }
}