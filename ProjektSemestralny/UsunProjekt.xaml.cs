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
                       select p;
            foreach (var item in proj)
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


                var square = from s in db.SquareFills
                             select s;
                var proj = from p in db.NewProjects
                           select p;
                int idNumer = 0;
                
                foreach (var s_item in square)
                    foreach (var item in proj)
                    {
                        if (idNumer == projectList.SelectedIndex)
                        {
                            projectList.Items.Remove(item);
                            db.NewProjects.Remove(item);
                            db.SquareFills.Remove(s_item);
                            var def = from d in db.DefaultColors
                                      where d.id_project == item.id_project
                                      select d;
                            foreach (var d_item in def)
                            {
                                db.DefaultColors.Remove(d_item);
                            }

                        }
                        idNumer++;
                    }
                db.SaveChanges();
                Close();
            }
            else MessageBox.Show("Nie wybrano projektu!");


        }
    }
}
