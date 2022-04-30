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
    public partial class OknoEdycji : Window, INotifyPropertyChanged
    {
        public OknoEdycji()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            DataContext = this;

            refreshColor();

        }

        private Brush _kwadracik;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public Brush kwadracik
        {
            get { return _kwadracik; }
            set
            {
                _kwadracik = value;
                OnPropertyChanged(nameof(kwadracik));
            }
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
                kwadracik = new SolidColorBrush(Color.FromRgb(
                value.choosenColorRed, value.choosenColorGreen, value.choosenColorBlue));

            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UstawieniaKoloru win = new UstawieniaKoloru(this);
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
            byte red = 0; byte green = 0; byte blue = 0;

            foreach (var glob in globValue)
                foreach (var item in proj)
                {
                    if (item.id_project == glob.actualProject)
                        for (int i = 0; i < item.boardSize / item.squareSize; i++)
                        {
                            for (int j = 0; j < item.boardSize / item.squareSize; j++)
                            {
                                var fl = from f in db.SquareFills
                                         where f.id_project == item.id_project
                                         select f;
                                if (i == 0 & j == 0)
                                    foreach (var color in fl)
                                    {
                                        red = color.defaultRed;
                                        green = color.defaultGreen;
                                        blue = color.defaultBlue;
                                    }
                                Rectangle r = new Rectangle
                                {
                                    Height = item.squareSize,
                                    Width = item.squareSize,
                                    Fill = new SolidColorBrush(Color.FromRgb(red, green, blue))
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

        private void cl0_Checked(object sender, RoutedEventArgs e)
        {
            //domyslny rb
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var globValue = from l in db.GlobalValues
                            select l.actualProject;

            var fl = from f in db.SquareFills
                     select f;
            var globColor = from c in db.GlobalColors
                            select c;
            foreach (var item in globValue)
                foreach (var colors in globColor)
                    foreach (var color in fl)
                    {
                        if (item == color.id_project)
                        {
                            colors.choosenColorRed = color.defaultRed;
                            colors.choosenColorGreen = color.defaultGreen;
                            colors.choosenColorBlue = color.defaultBlue;

                        }
                    }
            db.SaveChanges();
            refreshColor();
        }

        private void cl1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cl2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cl3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cl4_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cl5_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
