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
using System.Windows.Threading;

namespace horzPrototype
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class NowPrintingWindow: UserControl
    {
        private DispatcherTimer timer;
        public NowPrintingWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();                              
            timer.Tick += Timer_Tick;                                   
            timer.Interval = System.TimeSpan.FromMilliseconds(5000);            //5s delay 
            timer.Start();                                              
        }
        private void Timer_Tick(object sender, EventArgs e)             
        {
            Switcher.Switch(new ThankYouWindow());
            timer.Stop();
        }
    }
}
