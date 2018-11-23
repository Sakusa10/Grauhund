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
using System.Windows.Threading; //Needed for timer, remove when we have a 'pinpad'


namespace horzPrototype
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class PinpadWindow: UserControl
    {
        private DispatcherTimer timer;                                  //Needed for timer, remove when we have a 'pinpad'
        public PinpadWindow()
        {
            InitializeComponent(); 
            timer = new DispatcherTimer();                              //Needed for timer, remove when we have a 'pinpad'
            timer.Tick += Timer_Tick;                                   //Needed for timer, remove when we have a 'pinpad'
            timer.Interval = System.TimeSpan.FromMilliseconds(5000);    //Needed for timer, remove when we have a 'pinpad'
            timer.Start();                                              //Needed for timer, remove when we have a 'pinpad'
        }
        private void Timer_Tick(object sender, EventArgs e)             //Needed for timer, remove when we have a 'pinpad'
        {
            Switcher.Switch(new NowPrintingWindow());
            timer.Stop();
        }
    }
}
