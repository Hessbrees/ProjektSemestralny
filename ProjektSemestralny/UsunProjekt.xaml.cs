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


                var proj = from p in db.NewProjects
                           select p;
                int idNumer = 0;


                foreach (var item in proj)
                {
                    if (idNumer == projectList.SelectedIndex)
                    {
                        projectList.Items.Remove(item);

                        var def = from d in db.DefaultColors
                                  where d.id_project == item.id_project
                                  select d;
                        foreach (var d_item in def)
                        {
                            db.DefaultColors.Remove(d_item);
                        }
                        var square = from s in db.SquareFills
                                     where s.id_project == item.id_project
                                     select s;
                        foreach (var s_item in square)
                            db.SquareFills.Remove(s_item);

                        var board = from b in db.BoardColors
                                  where b.id_project == item.id_project
                                  select b;
                        foreach (var b_item in board)
                            db.BoardColors.Remove(b_item);

                        db.NewProjects.Remove(item);

                        var anim= from a in db.AnimationBoard400
                                    where a.id_project == item.id_project
                                    select a;
                        foreach (var a_item in anim)
                            db.AnimationBoard400.Remove(a_item);

                        var anim2 = from a in db.AnimationBoard640
                                   where a.id_project == item.id_project
                                   select a;
                        foreach (var a_item in anim2)
                            db.AnimationBoard640.Remove(a_item);

                        var anim3 = from a in db.AnimationBoard800
                                   where a.id_project == item.id_project
                                   select a;
                        foreach (var a_item in anim3)
                            db.AnimationBoard800.Remove(a_item);

                        db.NewProjects.Remove(item);

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
