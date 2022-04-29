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
    /// Interaction logic for UsunProjekt.xaml
    /// </summary>
    public partial class UsunProjekt : Window
    {
        public UsunProjekt()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            projectList.Items.Clear();
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var proj = from p in db.NewProjects
                       select p.ID_project;
            foreach (var item in proj)
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
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var proj = from p in db.NewProjects
                       select p.ID_project;
            int idNumer = 0;
            foreach (var item in proj)
            {
                if (idNumer == projectList.SelectedIndex)
                {
                    projectList.Items.Remove(item);
                }
                idNumer++;
            }
            NewProject rem = new NewProject() { ID_project = 1 };
            db.NewProjects.Remove(rem);
            db.SaveChanges();


            
            //projectList.Items.Remove(projectList.SelectedItem);
        }
    }
}
