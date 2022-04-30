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
using System.ComponentModel;

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

            refreshColor();

        }
        /// <summary>
        /// Odświeżenie koloru w oknie edycji
        /// </summary>
        public void refreshColor()
        {
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var globValue = from l in db.GlobalColors
                            select l;
            foreach (var value in globValue)
            {
                actualColor.Fill = new SolidColorBrush(Color.FromRgb(
                value.choosenColorRed, value.choosenColorGreen, value.choosenColorBlue));

            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UstawieniaKoloru win = new UstawieniaKoloru();
            win.Owner = this;
            win.ShowDialog();
        }

        private void AddSquare()
        {
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var globValue = from l in db.GlobalValues
                            select l;
            var proj = from p in db.NewProjects
                       select p;
            foreach (var glob in globValue)
                foreach (var item in proj)
                {
                    if (item.ID_project == glob.ChoosenProject)
                        for (int i = 0; i < item.boardSize / item.squareSize; i++)
                        {
                            for (int j = 0; j < item.boardSize / item.squareSize; j++)
                            {
                                Rectangle r = new Rectangle
                                {
                                    Height = item.squareSize,
                                    Width = item.squareSize,
                                    Fill = new SolidColorBrush(Colors.Black)
                                };
                                r.VerticalAlignment = VerticalAlignment.Top;
                                r.HorizontalAlignment = HorizontalAlignment.Left;
                                r.Margin = new Thickness(i * item.squareSize, j * item.squareSize, 0, 0);
                                r.MouseLeftButtonDown += r_MouseLeftButtonDown;
                                MainLayer.Children.Add(r);
                            }
                        }
                }
        }
        void r_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var globValue = from l in db.GlobalColors
                            select l;
            foreach (var gc in globValue)
            {
                Rectangle tb = e.Source as Rectangle;
                tb.Fill = new SolidColorBrush(Color.FromRgb(
                    gc.choosenColorRed,
                    gc.choosenColorGreen,
                    gc.choosenColorBlue));
            }

            refreshColor();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddSquare();
        }

    }
}
