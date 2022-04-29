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
            try
            {
                byte red = byte.Parse(redColor.Text);
                byte green = byte.Parse(greenColor.Text);
                byte blue = byte.Parse(blueColor.Text);
                actualColor.Fill = new SolidColorBrush(Color.FromRgb(
                red, green,blue));
            }
            catch(Exception)
            {
                MessageBox.Show("Błędna wartość!");
                return;
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                byte red = byte.Parse(redColor.Text);
                byte green = byte.Parse(greenColor.Text);
                byte blue = byte.Parse(blueColor.Text);

                ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
                NewColor newColor = new NewColor()
                {
                    rgb_blue = blue,
                    rgb_green = green,
                    rgb_red = red
                };
                db.NewColors.Add(newColor);
                db.SaveChanges();


                colorList.Items.Clear();
                var proj = from p in db.NewColors
                           select p;
                foreach (var item in proj)
                {
                    colorList.Items.Add(
                        "RGB Color: "+
                        item.rgb_red
                        +" "+
                        item.rgb_green
                        +" "+
                        item.rgb_blue
                        );
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Błędna wartość!");
                return;
            }
        }
    }
}
