using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuickDateTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = 50;
            this.Top = System.Windows.SystemParameters.PrimaryScreenHeight - this.Height - 50;

            this.Background = new SolidColorBrush(Colors.White);
            this.Background.Opacity = 0.0;

            txtTimeLT.Text = txtTimeRT.Text = txtTimeLB.Text = txtTimeRB.Text = txtTime.Text = DateTime.Now.ToShortTimeString();
            txtDateLT.Text = txtDateRT.Text = txtDateLB.Text = txtDateRB.Text = txtDate.Text = DateTime.Now.ToString("d MMMM dddd");

            ThreadPool.QueueUserWorkItem((state) =>
            {
                Thread.Sleep(3000);

                Process.GetCurrentProcess().Kill();
            });
        }

        private void pnlContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
