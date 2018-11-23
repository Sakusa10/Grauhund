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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class BackConfirm : UserControl
    {
        private Boolean goBack = false;
        private Window container;
        public BackConfirm(Window window)
        {
            InitializeComponent();
            container = window;
        }

        private void Button_GoBack(object sender, RoutedEventArgs e)
        {
            container.Close();
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            goBack = true;
            container.Close();
        }

        public Boolean getResult()
        {
            return goBack;
        }
    }
}
