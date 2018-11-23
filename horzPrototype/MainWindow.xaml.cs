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
    public partial class MainWindow : MetroWindow
    {
        //Used to update remaining tickets left for users
        public int user = -1;

        // "database" of purchase numbers
        public String[] val = new String[] { "10136357", "10156079", "10078908" };
        public String[] names = new String[] { "Sandra Bullock", "Leonardo DiCaprio", "Jennifer Lawrence" };
        public int[] ticketsBought = new int[] { 4, 2, 2 };
        public int[] freeTagsLeft = new int[] { 4, 2, 2 };
        public Boolean[] stillValid = new Boolean[] { true, true, true };

        public MainWindow()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new MainMenu());
        }
        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

    }
}