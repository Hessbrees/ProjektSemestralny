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
    /// Interaction logic for NowyProjekt.xaml
    /// </summary>
    public partial class NowyProjekt : Window
    {
        public NowyProjekt()
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
            newProject();
        }
        private void newProject()
        {
            int sizeBoardNumber = 0;

            if (
                projectName.Text != ""
                & sizeBoard.SelectedItem != null
                & squareSize.SelectedItem != null
                & Description.SelectedItem != null
                & defaultSquareColor != null
                )
            {
                if (projectName.Text.Length > 15) MessageBox.Show("Nazwa projektu nie może mieć więcej niż 15 znaków!");
                else
                {
                    if (sizeBoard.SelectedItem == sizeBoard1) sizeBoardNumber = 1;


                    ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
                    NewProject newItem = new NewProject()
                    {
                        projectName = projectName.Text,
                        boardSize = 1,
                        description = false,
                        squareSize = 1,
                        defaultSquareFill = "white"
                    };
                    //db.NewProjects.Add(newItem);
                    //db.SaveChanges();

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Nie wszystkie pola są wypełnione!");
            }
        }
    }
}
