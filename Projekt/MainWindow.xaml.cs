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

namespace Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Przełącznie sie na wypożyczalnie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rental_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new Rental();
        }
        /// <summary>
        /// Przełącznie sie na serwis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Service_Clicked(object sender, RoutedEventArgs e)
        {
            Main.Content = new Service();
        }
    }
}
