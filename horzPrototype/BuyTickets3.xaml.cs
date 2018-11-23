using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.ComponentModel;

namespace horzPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BuyTickets3 : UserControl
    {
        public UserControl previous;
        public List<BuyTickets1.Ticket> a;
        public List<BuyTickets1.Ticket> c;
        public List<BuyTickets1.Ticket> s;
        public int numExtraBags;
        ObservableCollection<Ticket> items = new ObservableCollection<Ticket>();
        public string dep;

        public BuyTickets3(UserControl screen, List<BuyTickets1.Ticket> adultTickets, List<BuyTickets1.Ticket> childTickets, List<BuyTickets1.Ticket> seniorTickets, string departure)
        {
            previous = screen;
            InitializeComponent();

            a = adultTickets;
            c = childTickets;
            s = seniorTickets;
            dep = departure;

            int pplTotal = 0;

            for(int i = 0; i < a.Count; i++) { pplTotal++; items.Add(new Ticket() { passengerNo = pplTotal.ToString()+".", passengerType = "   Adult", fname = a[i].fname, lname = a[i].lname, numBags = a[i].numBags }); }
            for (int i = 0; i < c.Count; i++) { pplTotal++; items.Add(new Ticket() { passengerNo = pplTotal.ToString()+".", passengerType = "   Child", fname = c[i].fname, lname = c[i].lname, numBags = c[i].numBags }); }
            for (int i = 0; i < s.Count; i++) {pplTotal++; items.Add(new Ticket() { passengerNo = pplTotal.ToString()+".", passengerType = "   Senior", fname = s[i].fname, lname = s[i].lname, numBags = s[i].numBags }); }
            pplList.ItemsSource = items;
        }

        public class Ticket : INotifyPropertyChanged
        {
            
            public event PropertyChangedEventHandler PropertyChanged;
            public int numBags;
            public string passengerNo { get; set; }
            public string passengerType { get; set; } // adult0, child1, senior2
            public string fname { get; set; }
            public string lname { get; set; }
            
            public void increment()
            {
                NumBags = NumBags + 1;
            }
            public void decrement()
            {
                NumBags = NumBags - 1;
            }

            public int NumBags
            {
                get { return numBags; }
                set
                {
                    numBags = value;
                    OnPropertyChanged("NumBags");
                }
            }

            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            if (formStarted())
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
            else
            {
                Switcher.Switch(new MainMenu());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (formStarted())
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
                    Switcher.Switch(previous);
                }
            }
            else
            {
                Switcher.Switch(previous);
            }
        }

        private bool formStarted()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].fname != "" || items[i].lname != "") return true;
            }
            return false;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Help(this));
        }

        // cap bags at 3 per person
        private void Add_Bag_Click(object sender, RoutedEventArgs e)
        {

            if (((Ticket)((Button)sender).DataContext).numBags < 3)
            {
                numExtraBags++;
                ((Ticket)((Button)sender).DataContext).increment();
            }
            else
            {
                error_form.Text = "There is a limit of 3 checked bags per person";
            }
        }

        private void Sub_Bag_Click(object sender, RoutedEventArgs e)
        {
            if (((Ticket)((Button)sender).DataContext).numBags > 0)
            {
                numExtraBags--;
                ((Ticket)((Button)sender).DataContext).decrement();
            }
        }

        private void ProjectListView_OnRequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = true;
        }

        private void Button_Click_Confirmation(object sender, RoutedEventArgs e)
        {
            if (formFilled()) {
                error_form.Text = "";
                Switcher.Switch(new ConfirmationWindow(this, a, c, s, numExtraBags, dep));
            }
            else { 
                error_form.Text = "Please fill in all passenger information";
            }
        }

        private bool formFilled()
        {
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].fname == "" || items[i].lname == "") return false;
            }
            return true;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (formFilled()) error_form.Text = "";
        }
    }
}