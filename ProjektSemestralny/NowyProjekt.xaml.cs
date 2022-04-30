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
                byte green = 0;byte red = 0;byte blue = 0;
            try
            {
                if(greenFill != null) 
                    green = byte.Parse(greenFill.Text);
                if (redFill != null)
                    red = byte.Parse(redFill.Text);
                if (blueFill != null)
                    blue = byte.Parse(blueFill.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("Wpisano blędne wartości kolorów!");
            }

            if (
                projectName.Text != ""
                & sizeBoard.SelectedItem != null
                & squareSize.SelectedItem != null
                & Description.SelectedItem != null
                )
            {
                if (projectName.Text.Length > 15) MessageBox.Show("Nazwa projektu nie może mieć więcej niż 15 znaków!");
                else
                {
                    // przypisanie wartosci początkowych w bazie danych
                    int sizeBoardNumber = 0;
                    int sizeSquareNumber = 0;
                    bool desc = false;
                    if (sizeBoard.SelectedItem == sizeBoard1) sizeBoardNumber = 640;

                    if (squareSize.SelectedItem == squareSize1) sizeSquareNumber = sizeBoardNumber/ 20;

                    if (Description.SelectedItem == yesDescription) desc = true;

                    ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
                    NewProject newItem = new NewProject()
                    {
                        projectName = projectName.Text,
                        boardSize = sizeBoardNumber,
                        description = desc,
                        squareSize = sizeSquareNumber,
                    };
                    SquareFill newSquare = new SquareFill()
                    {
                        defaultRed = red ,
                        defaultGreen=green,
                        defaultBlue =blue
                    };
                    for(int i =1; i <=6;i++)
                    {
                        DefaultColor defaultColor = new DefaultColor()
                        {
                            rgb_red = 255,
                            rgb_blue = 255,
                            rgb_green = 255,
                            positionNumber = (byte)i
                        };
                        db.DefaultColors.Add(defaultColor);
                    }

                    db.SquareFills.Add(newSquare);
                    db.NewProjects.Add(newItem);


                    // Sprawdzenie czy aktualna tablica z globalnymi wartościami jest pusta
                    var globValue = from l in db.GlobalValues
                                    select l;
                    if (globValue.Any() == false)
                    {
                        GlobalValue global = new GlobalValue()
                        {
                            actualProject = 0,
                        };
                        db.GlobalValues.Add(global);
                        db.SaveChanges();
                    }

                    // przypisanie kolorów startowych wypełniania
                    var globCol = from c in db.GlobalColors
                                  select c;
                    if (globCol.Any() == false)
                    {
                        GlobalColor color = new GlobalColor()
                        {
                            choosenColorRed = 255,
                            choosenColorBlue = 255,
                            choosenColorGreen = 255,
                        };
                        db.GlobalColors.Add(color);
                        db.SaveChanges();
                    }

                    foreach (var item in globCol)
                    {
                        item.choosenColorRed = 255;
                        item.choosenColorBlue = 255;
                        item.choosenColorGreen = 255;
                    }
                    db.SaveChanges();

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
