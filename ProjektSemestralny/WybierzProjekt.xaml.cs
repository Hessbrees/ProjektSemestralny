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
                       select p;
            foreach(var item in proj)
            {
                projectList.Items.Add(item.projectName);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (projectList.SelectedItem != null)
            {
                ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
                var globValue = from l in db.GlobalValues
                                select l;
                var proj = from p in db.NewProjects
                           select p;
                int idNumer = 0;
                foreach (var item in proj)
                {
                    foreach(var glob in globValue)
                    if (idNumer == projectList.SelectedIndex)
                    {
                        glob.ChoosenProject = item.ID_project;
                    }
                    idNumer++;
                }
                db.SaveChanges();
                OknoEdycji win = new OknoEdycji();
                Close();
                win.Show();
            }
            else MessageBox.Show("Nie wybrano projektu!");
        }

    }
}
