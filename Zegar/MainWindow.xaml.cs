using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using Time_TimePeriod;
namespace Zegar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static TimePeriod sekunda = new TimePeriod(0, 0, 1);
        Time czas = new Time((byte)DateTime.Now.Hour, (byte)DateTime.Now.Minute, (byte)DateTime.Now.Second);
        public MainWindow()
        {
            InitializeComponent();
            godzinaLabel.Content = czas;
        }

        private async void Grid_Initialized(object sender, EventArgs e)
        {
            while (true)
            {
                await Task.Delay(1000);
                czas = czas + sekunda;
                godzinaLabel.Content = czas;
            }
        }
    }
}
