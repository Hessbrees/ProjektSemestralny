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

namespace ProjektSemestralny
{
    /// <summary>
    /// Interaction logic for UstawieniaKoloru.xaml
    /// </summary>
    public partial class UstawieniaKoloru : Window
    {
        public UstawieniaKoloru()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(
                byte.Parse(redColor.Text) <= 255|
                byte.Parse(greenColor.Text) <= 255|
                byte.Parse(blueColor.Text) <= 255
                )
            {
                actualColor.Fill = new SolidColorBrush(Color.FromRgb(
                byte.Parse(redColor.Text),
                byte.Parse(greenColor.Text),
                byte.Parse(blueColor.Text)));
            }
            
        }
    }
}
