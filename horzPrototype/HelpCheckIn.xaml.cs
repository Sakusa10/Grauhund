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
    public partial class HelpCheckIn : UserControl
    {
        public UserControl previous;
        public HelpCheckIn(UserControl screen)
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
    }
}
