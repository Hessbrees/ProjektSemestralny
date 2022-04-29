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
    /// Interaction logic for OknoEdycji.xaml
    /// </summary>
    public partial class OknoEdycji : Window
    {
        public OknoEdycji()
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
            UstawieniaKoloru win = new UstawieniaKoloru();
            win.ShowDialog();
        }

        private void AddSquare()
        {
            for (int i = 0; i < 20; i++)
            {
                for(int j=0; j< 20; j++)
                {
                    Rectangle r = new Rectangle
                    {
                        Height = 32,
                        Width = 32,
                        Fill = new SolidColorBrush(Colors.Black)
                    };
                    r.VerticalAlignment = VerticalAlignment.Top;
                    r.HorizontalAlignment = HorizontalAlignment.Left;
                    r.Margin = new Thickness(i * 32, j*32, 0, 0);
                    r.MouseLeftButtonDown += r_MouseLeftButtonDown;
                    MainLayer.Children.Add(r);
                }
            }

        }
        void r_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle tb = e.Source as Rectangle;
            tb.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddSquare();
        }
    }
}
