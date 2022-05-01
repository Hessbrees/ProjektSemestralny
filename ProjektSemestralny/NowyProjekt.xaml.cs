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
            byte green = 0; byte red = 0; byte blue = 0;
            try
            {
                if (greenFill != null)
                    green = byte.Parse(greenFill.Text);
                if (redFill != null)
                    red = byte.Parse(redFill.Text);
                if (blueFill != null)
                    blue = byte.Parse(blueFill.Text);
            }
            catch (Exception)
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
                    if (sizeBoard.SelectedItem == sizeBoard640) sizeBoardNumber = 640;
                    else if (sizeBoard.SelectedItem == sizeBoard800) sizeBoardNumber = 800;
                    else if (sizeBoard.SelectedItem == sizeBoard400) sizeBoardNumber = 400;

                    //if (squareSize.SelectedItem == squareSize128) sizeSquareNumber = sizeBoardNumber/ 128;
                    if (squareSize.Text == "1/64 Planszy") sizeSquareNumber = sizeBoardNumber / 64;
                    else if (squareSize.Text == "1/40 Planszy") sizeSquareNumber = sizeBoardNumber / 40;
                    else if (squareSize.Text == "1/32 Planszy") sizeSquareNumber = sizeBoardNumber / 32;
                    else if (squareSize.Text == "1/20 Planszy") sizeSquareNumber = sizeBoardNumber / 20;
                    else if (squareSize.Text == "1/16 Planszy") sizeSquareNumber = sizeBoardNumber / 16;

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
                        defaultRed = red,
                        defaultGreen = green,
                        defaultBlue = blue
                    };
                    for (int i = 1; i <= 6; i++)
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

                    //Zapisanie elementów nowej planszy
                    var bor = from b in db.BoardColors
                              select b;

                    for (int i = 1; i <= (sizeBoardNumber / sizeSquareNumber) * (sizeBoardNumber / sizeSquareNumber); i++)
                    {
                        BoardColor boardCol = new BoardColor()
                        {
                            rgb_blue = blue,
                            rgb_green = green,
                            rgb_red = red,
                            square_number = i
                        };
                        db.BoardColors.Add(boardCol);
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

        private void sizeBoard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sizeBoard.SelectedItem == sizeBoard640)
            {
                squareSize.Items.Clear();
                ComboBoxItem item = new ComboBoxItem();
                ComboBoxItem item2 = new ComboBoxItem();
                ComboBoxItem item3 = new ComboBoxItem();
                ComboBoxItem item4 = new ComboBoxItem();
                ComboBoxItem item5 = new ComboBoxItem();
                item.Name = "squareSize64";
                item.Content = "1/64 Planszy";
                squareSize.Items.Add(item);
                item2.Name = "squareSize32";
                item2.Content = "1/32 Planszy";
                squareSize.Items.Add(item2);
                item3.Name = "squareSize16";
                item3.Content = "1/16 Planszy";
                squareSize.Items.Add(item3);
                item4.Name = "squareSize40";
                item4.Content = "1/40 Planszy";
                squareSize.Items.Add(item4);
                item5.Name = "squareSize20";
                item5.Content = "1/20 Planszy";
                squareSize.Items.Add(item5);
            }
            else if (sizeBoard.SelectedItem == sizeBoard800)
            {
                squareSize.Items.Clear();
                ComboBoxItem item2 = new ComboBoxItem();
                ComboBoxItem item3 = new ComboBoxItem();
                ComboBoxItem item4 = new ComboBoxItem();
                ComboBoxItem item5 = new ComboBoxItem();

                item2.Name = "squareSize40";
                item2.Content = "1/40 Planszy";
                squareSize.Items.Add(item2);
                item3.Name = "squareSize20";
                item3.Content = "1/20 Planszy";
                squareSize.Items.Add(item3);
                item4.Name = "squareSize32";
                item4.Content = "1/32 Planszy";
                squareSize.Items.Add(item4);
                item5.Name = "squareSize16";
                item5.Content = "1/16 Planszy";
                squareSize.Items.Add(item5);
            }
            else if (sizeBoard.SelectedItem == sizeBoard400)
            {
                squareSize.Items.Clear();
                ComboBoxItem item = new ComboBoxItem();
                ComboBoxItem item2 = new ComboBoxItem();
                ComboBoxItem item3 = new ComboBoxItem();
                item.Name = "squareSize40";
                item.Content = "1/40 Planszy";
                squareSize.Items.Add(item);
                item2.Name = "squareSize20";
                item2.Content = "1/20 Planszy";
                squareSize.Items.Add(item2);
                item3.Name = "squareSize16";
                item3.Content = "1/16 Planszy";
                squareSize.Items.Add(item3);
            }
        }
    }
}
