﻿using System;
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

            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var globValue = from l in db.GlobalValues
                            select l;
            foreach(var item in globValue)
            {
                var proj = from p in db.NewProjects
                           where p.id_project == item.actualProject
                           select p;
                foreach(var item2 in proj)
                {
                    OknoPar.Height = 140 + item2.boardSize;
                    OknoPar.Width = 160 + item2.boardSize;
                    MainLayer.Height = item2.boardSize;
                    MainLayer.Width = item2.boardSize;
                }
            }



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
            MessageBoxResult result= MessageBox.Show(
                "Niezapisane zmiany zostaną utracone. Chcesz zamknąć projekt?"
                , "Uwaga!", MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes) Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cl0.IsChecked == false)
            {
                if (cl1.IsChecked == true |
                   cl2.IsChecked == true |
                   cl3.IsChecked == true |
                   cl4.IsChecked == true |
                   cl5.IsChecked == true
                    )
                {
                    UstawieniaKoloru win = new UstawieniaKoloru(this);
                    win.Owner = this;
                    win.ShowDialog();
                }
                else MessageBox.Show("Nie wybrano koloru!");
            }
            else MessageBox.Show("Nie można zmienić domyślnego koloru!");
        }

        private void AddSquare()
        {
            // reset
            MainLayer.Children.Clear();
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
            MessageBox.Show("Wczytano!");
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
            // reset
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
        private void changeColor(int i)
        {
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var globValue = from l in db.GlobalValues
                            select l.actualProject;
            var globColor = from c in db.GlobalColors
                            select c;
            var def = from d in db.DefaultColors
                      where d.positionNumber == i
                      select d;

            foreach (var item in globValue)
                foreach (var colors in globColor)
                    foreach (var col in def)
                    {
                        if (item == col.id_project)
                        {
                            colors.choosenColorBlue = col.rgb_blue;
                            colors.choosenColorRed = col.rgb_red;
                            colors.choosenColorGreen = col.rgb_green;
                        }
                    }
            db.SaveChanges();
            refreshColor();
        }
        private void cl1_Checked(object sender, RoutedEventArgs e) => changeColor(1);
        private void cl2_Checked(object sender, RoutedEventArgs e) => changeColor(2);
        private void cl3_Checked(object sender, RoutedEventArgs e) => changeColor(3);
        private void cl4_Checked(object sender, RoutedEventArgs e) => changeColor(4);
        private void cl5_Checked(object sender, RoutedEventArgs e) => changeColor(5);

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //zapisz
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var globValue = from l in db.GlobalValues
                            select l.actualProject;

            var board = from b in db.BoardColors
                        where b.id_project == globValue.First()
                        select b;
            foreach(var item in board)
            {
                item.rgb_blue = 255;
                item.rgb_red = 255;
                item.rgb_green = 255;
            }

        }
    }
}
