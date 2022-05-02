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
    /// Interaction logic for UstawieniaAnimacji.xaml
    /// </summary>
    public partial class UstawieniaAnimacji : Window
    {
        private int _boardSize;
        public UstawieniaAnimacji()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Start

            // Wyjatki czas przejscia 
            int _interval = 1;
            try
            {
                _interval = int.Parse(interval.Text);
                if (_interval < 0 | _interval > 10) throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Czas przejścia musi być liczbą całkowitą z przedziału 1-10s");
            }



        }
        private void LoadProjects()
        {
            DostepneProj.Items.Clear();

            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var proj = from p in db.NewProjects
                       where p.boardSize == _boardSize
                       select p;
            foreach (var item in proj)
            {
                DostepneProj.Items.Add(item.projectName);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void sizeBoard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sizeBoard.SelectedItem == sizeBoard400)
            {
                    _boardSize = 400;
            }
            if (sizeBoard.SelectedItem == sizeBoard640)
            {
                    _boardSize = 640;
            }
            if (sizeBoard.SelectedItem == sizeBoard800)
            {
                    _boardSize = 800;
            }
            LoadProjects();
        }
    }
}
