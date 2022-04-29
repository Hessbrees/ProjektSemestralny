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
    /// Interaction logic for WybierzProjekt.xaml
    /// </summary>
    public partial class WybierzProjekt : Window
    {
        public WybierzProjekt()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            projectList.Items.Clear();
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var proj = from p in db.NewProjects
                       select p.ID_project;
            foreach(var item in proj)
            {
                projectList.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OknoEdycji win = new OknoEdycji();
            Close();
            win.Show();
        }

    }
}
