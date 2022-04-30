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
    /// Interaction logic for UstawieniaKoloru.xaml
    /// </summary>
    public partial class UstawieniaKoloru : Window
    {
        private OknoEdycji _ok;

        public UstawieniaKoloru(OknoEdycji OK)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            RefreshList();
            _ok = OK;

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
                red, green, blue));
            }
            catch (Exception)
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


                RefreshList();
            }
            catch (Exception)
            {
                MessageBox.Show("Błędna wartość!");
                return;
            }
        }
        private void RefreshList()
        {
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            colorList.Items.Clear();
            var proj = from p in db.NewColors
                       select p;
            foreach (var item in proj)
            {
                colorList.Items.Add(
                    "RGB Color: " +
                    item.rgb_red
                    + " " +
                    item.rgb_green
                    + " " +
                    item.rgb_blue
                    );
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (colorList.SelectedItem != null)
            {
                ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
                var proj = from p in db.NewColors
                           select p;
                int idNumer = 0;
                foreach (var item in proj)
                {
                    if (idNumer == colorList.SelectedIndex)
                    {
                        colorList.Items.Remove(item);
                        db.NewColors.Remove(item);
                    }
                    idNumer++;
                }
                db.SaveChanges();
                RefreshList();
            }
            else MessageBox.Show("Nie wybrano elementu z listy!");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (colorList.SelectedItem != null)
            {
                ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
                var globValue = from l in db.GlobalColors
                                select l;
                var proj = from p in db.NewColors
                           select p;
                int idNumer = 0;
                foreach (var item in proj)
                {
                    foreach (var glob in globValue)
                        if (idNumer == colorList.SelectedIndex)
                        {
                            glob.choosenColorRed = item.rgb_red;
                            glob.choosenColorGreen = item.rgb_green;
                            glob.choosenColorBlue = item.rgb_blue;

                            Brush bar = new SolidColorBrush(Color.FromRgb(
                            glob.choosenColorRed,
                            glob.choosenColorGreen,
                            glob.choosenColorBlue));

                            _ok.kwadracik = bar;
                        }
                    idNumer++;
                }
                db.SaveChanges();

                /*                Owner.Close();
                                OknoEdycji win = new OknoEdycji();
                                win.Show();*/

                Close();
            }
            else MessageBox.Show("Nie wybrano koloru!");
        }


    }

}
