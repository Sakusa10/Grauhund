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
    public partial class BuyTickets1 : UserControl
    {
        public UserControl previous;
        public int adult;
        public int child;
        public int senior;
        public bool destination_selected;
        List<Ticket> adultTickets = new List<Ticket>();
        List<Ticket> childTickets = new List<Ticket>();
        List<Ticket> seniorTickets = new List<Ticket>();
        public Brush color;
        public string[] destinations = new string[] { "Edmonton", "Vancouver", "Seattle", "Airdrie", "Kelowna", "Saskatoon", "Toronto", "Hamilton", "Quebec City", "Ottawa", "Olds", "Medicine Hat" };

        public BuyTickets1(UserControl screen)
        {
            previous = screen;
            InitializeComponent();

            adult = 0;
            child = 0;
            senior = 0;

            string[] destinations_toshow = searched_destinations(searchBox.Text.ToLower());

            if (destinations_toshow[0].Equals(" No search results..."))
            {
                destination1.Content = " " + destinations_toshow[0];
                destination1.IsEnabled = false;
            }
            else
            {
                destination1.Content = " " + destinations_toshow[0];
                destination1.IsEnabled = true;
            }

            if (destinations_toshow[1] == "")
            {
                destination2.Content = " " + destinations_toshow[1];
                destination2.IsEnabled = false;
            }
            else
            {
                destination2.Content = " " + destinations_toshow[1];
                destination2.IsEnabled = true;
            }

            if (destinations_toshow[2] == "")
            {
                destination3.Content = " " + destinations_toshow[2];
                destination3.IsEnabled = false;
            }
            else
            {
                destination3.Content = " " + destinations_toshow[2];
                destination3.IsEnabled = true;
            }

            if (destinations_toshow[3] == "")
            {
                destination4.Content = " " + destinations_toshow[3];
                destination4.IsEnabled = false;
            }
            else
            {
                destination4.Content = " " + destinations_toshow[3];
                destination4.IsEnabled = true;
            }

            if (destinations_toshow[4] == "")
            {
                destination5.Content = " " + destinations_toshow[4];
                destination5.IsEnabled = false;
            }
            else
            {
                destination5.Content = " " + destinations_toshow[4];
                destination5.IsEnabled = true;
            }

            if (destinations_toshow[5] == "")
            {
                destination6.Content = " " + destinations_toshow[5];
                destination6.IsEnabled = false;
            }
            else
            {
                destination6.Content = " " + destinations_toshow[5];
                destination6.IsEnabled = true;
            }

            destination_selected = false;

            color = destination1.Background;
        }

        public class Ticket
        {
            public int passengerType { get; set; } // adult0, child1, senior2
            public string fname { get; set; }
            public string lname { get; set; }
            public int numBags { get; set; }
        
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
            if (destination_selected)
            {
                if (child > 0 && senior == 0 && adult == 0)
                {
                    error.Text = "";
                    Switcher.Switch(new ChildWindow(this, adultTickets, childTickets, seniorTickets));
                }
                else if (adult > 0 || senior > 0 || child > 0)
                {
                    error.Text = "";
                    Switcher.Switch(new BuyTickets2(this, adultTickets, childTickets, seniorTickets));
                }
                else
                {
                    error.Text = "Please select number of tickets";
                    number_label.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                error.Text = "Please select a destination";
                destination_label.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void destination_click1(object sender, RoutedEventArgs e)
        {
            destination1.Background = color;
            destination2.Background = color;
            destination3.Background = color;
            destination4.Background = color;
            destination5.Background = color;
            destination6.Background = color;

            string[] destinations_toshow = searched_destinations(searchBox.Text.ToLower());

            if(destinations_toshow[0] == " Edmonton")
            {
                destination1.Background = Brushes.LightGray;
                destination_selected = true;
                if (error.Text == "Please select a destination")
                {
                    error.Text = "";
                }
                destination_label.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                if (searchBox.Text == "")
                {
                    destination_selected = true;
                    destination1.Background = Brushes.LightGray;
                    error.Text = "";
                    destination_label.Foreground = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    destination_selected = false;
                }
            }
        }

        private void destination_click2(object sender, RoutedEventArgs e)
        {
            destination1.Background = color;
            destination2.Background = color;
            destination3.Background = color;
            destination4.Background = color;
            destination5.Background = color;
            destination6.Background = color;

            string[] destinations_toshow = searched_destinations(searchBox.Text.ToLower());

            if (destinations_toshow[1] == " Edmonton")
            {
                destination_selected = true;
                destination2.Background = Brushes.LightGray;
                error.Text = "";
                destination_label.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                destination2.Background = Brushes.LightGray;
                destination_selected = false;
            }
        }

        private void destination_click3(object sender, RoutedEventArgs e)
        {
            destination1.Background = color;
            destination2.Background = color;
            destination3.Background = color;
            destination4.Background = color;
            destination5.Background = color;
            destination6.Background = color;

            string[] destinations_toshow = searched_destinations(searchBox.Text.ToLower());

            if (destinations_toshow[2] == " Edmonton")
            {
                destination_selected = true;
                destination3.Background = Brushes.LightGray;
                error.Text = "";
                destination_label.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                destination3.Background = Brushes.LightGray;
                destination_selected = false;
            }
        }

        private void destination_click4(object sender, RoutedEventArgs e)
        {
            destination1.Background = color;
            destination2.Background = color;
            destination3.Background = color;
            destination4.Background = color;
            destination5.Background = color;
            destination6.Background = color;

            string[] destinations_toshow = searched_destinations(searchBox.Text.ToLower());

            if (destinations_toshow[3] == " Edmonton")
            {
                destination_selected = true;
                destination4.Background = Brushes.LightGray;
                error.Text = "";
                destination_label.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                destination4.Background = Brushes.LightGray;
                destination_selected = false;
            }
        }

        private void destination_click5(object sender, RoutedEventArgs e)
        {
            destination1.Background = color;
            destination2.Background = color;
            destination3.Background = color;
            destination4.Background = color;
            destination5.Background = color;
            destination6.Background = color;

            string[] destinations_toshow = searched_destinations(searchBox.Text.ToLower());

            if (destinations_toshow[4] == " Edmonton")
            {
                destination_selected = true;
                error.Text = "";
                destination5.Background = Brushes.LightGray;
                destination_label.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                destination5.Background = Brushes.LightGray;
                destination_selected = false;
            }
        }

        private void destination_click6(object sender, RoutedEventArgs e)
        {
            destination1.Background = color;
            destination2.Background = color;
            destination3.Background = color;
            destination4.Background = color;
            destination5.Background = color;
            destination6.Background = color;

            string[] destinations_toshow = searched_destinations(searchBox.Text.ToLower());

            if (destinations_toshow[5] == " Edmonton")
            {
                destination_selected = true;
                error.Text = "";
                destination6.Background = Brushes.LightGray;
                destination_label.Foreground = new SolidColorBrush(Colors.Black);
            }
            else
            {
                destination6.Background = Brushes.LightGray;
                destination_selected = false;
            }
        }

        private void updateLabels()
        {
            Adult_Label.Content = adult;
            Child_Label.Content = child;
            Senior_Label.Content = senior;
            number_label.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void add_adult(object sender, RoutedEventArgs e)
        {
            if (adult + child + senior < 9)
            {
                adult++;
                adultTickets.Add(new Ticket() { passengerType = 0, numBags = 0, fname = "", lname = "" });
            }
            else error.Text = "There is a limit of 9 tickets per transaction";
            updateLabels();

        }

        private void sub_adult(object sender, RoutedEventArgs e)
        {
            if (adult > 0)
            {
                adult = adult - 1;
                //pop last adult ticket
                adultTickets.RemoveAt(adultTickets.Count - 1);
            }            
            updateLabels();
        }

        private void add_child(object sender, RoutedEventArgs e)
        {
            if (adult + child + senior < 9)
            {
                child++;
                childTickets.Add(new Ticket() { passengerType = 1, numBags = 0, fname = "", lname = "" });
            }
            else error.Text = "There is a limit of 9 tickets per transaction";
            updateLabels();
        }

        private void sub_child(object sender, RoutedEventArgs e)
        {
            if (child > 0)
            {
                child = child - 1;
                childTickets.RemoveAt(childTickets.Count - 1);
            }

            updateLabels();
        }

        private void add_senior(object sender, RoutedEventArgs e)
        {
            if (adult + child + senior < 9)
            {
                senior++;
                seniorTickets.Add(new Ticket() { passengerType = 2, numBags = 0, fname = "", lname = "" });
            }
            else error.Text = "There is a limit of 9 tickets per transaction";
            updateLabels();
        }

        private void sub_senior(object sender, RoutedEventArgs e)
        {
            if (senior > 0)
            {
                senior = senior - 1;
                seniorTickets.RemoveAt(seniorTickets.Count - 1);
            }

            updateLabels();
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] destinations_toshow = searched_destinations(searchBox.Text.ToLower());

            destination1.Background = color;
            destination2.Background = color;
            destination3.Background = color;
            destination4.Background = color;
            destination5.Background = color;
            destination6.Background = color;

            if (destinations_toshow[0].Equals(" No search results..."))
            {
                destination1.Content = destinations_toshow[0];
                destination1.IsEnabled = false;
            }
            else
            {
                destination1.Content = destinations_toshow[0];
                destination1.IsEnabled = true;
            }

            if (destinations_toshow[1] == "")
            {
                destination2.Content = destinations_toshow[1];
                destination2.IsEnabled = false;
            }
            else
            {
                destination2.Content = destinations_toshow[1];
                destination2.IsEnabled = true;
            }

            if (destinations_toshow[2] == "")
            {
                destination3.Content = destinations_toshow[2];
                destination3.IsEnabled = false;
            }
            else
            {
                destination3.Content = destinations_toshow[2];
                destination3.IsEnabled = true;
            }

            if (destinations_toshow[3] == "")
            {
                destination4.Content = destinations_toshow[3];
                destination4.IsEnabled = false;
            }
            else
            {
                destination4.Content = destinations_toshow[3];
                destination4.IsEnabled = true;
            }

            if (destinations_toshow[4] == "")
            {
                destination5.Content = destinations_toshow[4];
                destination5.IsEnabled = false;
            }
            else
            {
                destination5.Content = destinations_toshow[4];
                destination5.IsEnabled = true;
            }

            if (destinations_toshow[5] == "")
            {
                destination6.Content = destinations_toshow[5];
                destination6.IsEnabled = false;
            }
            else
            {
                destination6.Content = destinations_toshow[5];
                destination6.IsEnabled = true;
            }

            destination_selected = false;
        }

        private string[] searched_destinations(string search)
        {
            string[] tempDestinations = new string[6];

            if (search == "")
            {
                for (int a = 0; a < 6; a++)
                {
                    tempDestinations[a] = " " + destinations[a];
                }
            }
            else
            {
                int maxSearch = 0;

                for (int a = 0; a < destinations.Length; a++)
                {
                    if (destinations[a].ToLower().Contains(search) && maxSearch < 6)
                    {
                        tempDestinations[maxSearch] = " " + destinations[a];
                        maxSearch++;
                    }
                }

                int count = 0;

                for (int a = 0; a < 6; a++)
                {
                    if (tempDestinations[a] == null)
                    {
                        tempDestinations[a] = "";
                        count++;
                    }
                }

                if (count == 6)
                {
                    tempDestinations[0] = " No search results...";
                }
            }

            return tempDestinations;
        }
    }
}