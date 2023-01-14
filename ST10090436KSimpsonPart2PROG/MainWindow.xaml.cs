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

namespace ST10090436KSimpsonPart2PROG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new RegisterPage());
        }
        private void Login(object sender, RoutedEventArgs e)
        {
            Main.NavigationService.Navigate(new LoginPage());
        }

        private void End(object sender, RoutedEventArgs e)
        {
            Close();
        }
        // (Troelsen & Japikse, 2021)
    }
}
