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

namespace ProjektSemestralny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NowyProjekt win = new NowyProjekt();
            win.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UsunProjekt win = new UsunProjekt();
            win.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WybierzProjekt win = new WybierzProjekt();
            win.ShowDialog();
        }
    }
}
