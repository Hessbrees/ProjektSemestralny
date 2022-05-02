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
using System.Windows.Threading;

namespace ProjektSemestralny
{
    /// <summary>
    /// Interaction logic for UstawieniaAnimacji.xaml
    /// </summary>
    public partial class UstawieniaAnimacji : Window
    {
        private byte[,] red_color = new byte[50, 10000];
        private byte[,] green_color = new byte[50, 10000];
        private byte[,] blue_color = new byte[50, 10000];

        private int _boardSize;
        private List<int> _actualID400 = new List<int>();
        private List<int> _actualID640 = new List<int>();
        private List<int> _actualID800 = new List<int>();
        private int count;

        private int count_400;
        private int count_640;
        private int count_800;
        public UstawieniaAnimacji()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Start
            StartAnimation();
        }
        private void LoadProjects()
        {
            //pierwsza lista
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
        private void LoadAnimList()
        {
            //druga lista

            //czyszczenie danych po zmianie wymiaru planszy
            AnimationList.Items.Clear();
            _actualID400.Clear();
            _actualID640.Clear();
            _actualID800.Clear();
            count_400 = 0;
            count_640 = 0;
            count_800 = 0;

            //wczytywanie listy
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            if (_boardSize == 400)
            {
                var anim = from a in db.AnimationBoard400 select a;
                foreach (var a_item in anim)
                {
                    var proj = from p in db.NewProjects
                               where p.id_project == a_item.id_project
                               select p;
                    foreach (var item in proj)
                    {
                        AnimationList.Items.Add(item.projectName);
                        _actualID400.Add(item.id_project);
                    }
                }
            }
            else if (_boardSize == 640)
            {
                var anim = from a in db.AnimationBoard640 select a;
                foreach (var a_item in anim)
                {
                    var proj = from p in db.NewProjects
                               where p.id_project == a_item.id_project
                               select p;
                    foreach (var item in proj)
                    {
                        AnimationList.Items.Add(item.projectName);
                        _actualID640.Add(item.id_project);
                    }
                }
            }
            else if (_boardSize == 800)
            {
                var anim = from a in db.AnimationBoard800 select a;
                foreach (var a_item in anim)
                {
                    var proj = from p in db.NewProjects
                               where p.id_project == a_item.id_project
                               select p;
                    foreach (var item in proj)
                    {
                        AnimationList.Items.Add(item.projectName);
                        _actualID800.Add(item.id_project);
                    }
                }
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

            UstAnim.Height = 140 + _boardSize;
            UstAnim.Width = 160 + _boardSize;
            MainAnimLayer.Height = _boardSize;
            MainAnimLayer.Width = _boardSize;

            LoadProjects();
            LoadAnimList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //dodaj
            AddProject();

        }

        private void AddProject()
        {
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();

            var proj = from p in db.NewProjects
                       where p.boardSize == _boardSize
                       select p;
            int idNumer = 0;

            foreach (var item in proj)
            {
                if (idNumer == DostepneProj.SelectedIndex)
                {
                    if (_boardSize == 400)
                    {
                        AnimationBoard400 newItem1 = new AnimationBoard400()
                        {
                            id_project = item.id_project,
                            boardSize = _boardSize,
                        };
                        db.AnimationBoard400.Add(newItem1);
                    }
                    else if (_boardSize == 640)
                    {
                        AnimationBoard640 newItem2 = new AnimationBoard640()
                        {
                            id_project = item.id_project,
                            boardSize = _boardSize,
                        };
                        db.AnimationBoard640.Add(newItem2);
                    }
                    else if (_boardSize == 800)
                    {
                        AnimationBoard800 newItem3 = new AnimationBoard800()
                        {
                            id_project = item.id_project,
                            boardSize = _boardSize,
                        };
                        db.AnimationBoard800.Add(newItem3);
                    }
                    break;
                }
                idNumer++;
            }
            db.SaveChanges();
            AnimationList.Items.Add(DostepneProj.SelectedItem);
        }

        private void RemoveProject()
        {
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();
            var proj = from p in db.NewProjects
                       where p.boardSize == _boardSize
                       select p;
            if (_boardSize == 400)
            {
                var anim = from p in db.AnimationBoard400
                           select p;
                int i = 0;
                foreach (var item in anim)
                {
                    if (AnimationList.SelectedIndex == i)
                    {
                        AnimationList.Items.Remove(item);
                        db.AnimationBoard400.Remove(item);
                    }
                    i++;
                }
            }
            else if (_boardSize == 640)
            {
                var anim = from p in db.AnimationBoard640
                           select p;
                int i = 0;
                foreach (var item in anim)
                {
                    if (AnimationList.SelectedIndex == i)
                    {
                        AnimationList.Items.Remove(item);
                        db.AnimationBoard640.Remove(item);
                    }
                    i++;
                }
            }
            else if (_boardSize == 800)
            {
                var anim = from p in db.AnimationBoard800
                           select p;
                int i = 0;
                foreach (var item in anim)
                {
                    if (AnimationList.SelectedIndex == i)
                    {
                        AnimationList.Items.Remove(item);
                        db.AnimationBoard800.Remove(item);
                    }
                    i++;
                }
            }
            db.SaveChanges();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //usun
            RemoveProject();
            LoadAnimList();
        }

        private void StartAnimation()
        {
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

            //Tutaj zapis danych

            if (_boardSize == 400)
            {
                for (int i = 0; i < _actualID400.Count; i++)
                {
                    SaveColors(_actualID400[count_400], count_400);
                    count_400++;
                }
                count_400 = 0;
            }
            else if (_boardSize == 640)
            {
                for (int i = 0; i < _actualID640.Count; i++)
                {
                    SaveColors(_actualID640[count_640], count_640);
                    count_640++;
                }
                count_640 = 0;
            }
            else if (_boardSize == 800)
            {
                for (int i = 0; i < _actualID800.Count; i++)
                {
                    SaveColors(_actualID800[count_800], count_800);
                    count_800++;
                }
                count_800 = 0;
            }
            FirstLoad();
            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(TimeClick);
            Timer.Interval = new TimeSpan(0, 0, _interval);
            Timer.Start();


        }
        private void TimeClick(object sender, EventArgs e)
        {
            if (count < _actualID400.Count)
            {
                Load(_actualID400[count]);
                count++;
            }
        }
        private void FirstLoad()
        {
            MainAnimLayer.Children.Clear();
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();

            var proj = from p in db.NewProjects
                       select p;
            byte red = 0; byte green = 0; byte blue = 0;
            int k = 0;
            int i = 0;
            int j = 0;
            foreach (var item in proj)
                if (item.id_project == ID)
                {
                    var fl = from f in db.BoardColors
                             where f.id_project == item.id_project
                             select f;

                    foreach (var color in fl)
                    {
                        red = color.rgb_red;
                        green = color.rgb_green;
                        blue = color.rgb_blue;

                        Rectangle r = new Rectangle
                        {
                            Height = item.squareSize,
                            Width = item.squareSize,
                            Fill = new SolidColorBrush(Color.FromRgb(red, green, blue)),
                            Name = "s" + k.ToString()
                        };

                        r.VerticalAlignment = VerticalAlignment.Top;
                        r.HorizontalAlignment = HorizontalAlignment.Left;
                        r.Margin = new Thickness(i * item.squareSize, j * item.squareSize, 0, 0);
                        MainAnimLayer.Children.Add(r);

                        k++;
                        if (j % ((item.boardSize / item.squareSize) - 1) == 0 & j != 0)
                        {
                            i++;
                            j = 0;
                        }
                        else j++;
                    }
                }
        }
        private void SaveColors(int ID, int count_x)
        {
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();

            int k = 0;
            var proj = from p in db.NewProjects
                       select p;

            foreach (var item in proj)
                if (item.id_project == ID)
                {
                    var board = from b in db.BoardColors
                                where b.id_project == ID
                                select b;

                    foreach (var square in board)
                    {
                        blue_color[count_x, k] = square.rgb_blue;
                        red_color[count_x, k] = square.rgb_red;
                        green_color[count_x, k] = square.rgb_green;
                        k++;
                    }
                }
        }
        private void Load(int ID)
        {
            MainAnimLayer.Children.Clear();
            ProjektSemestralnyDBEntities db = new ProjektSemestralnyDBEntities();

            var proj = from p in db.NewProjects
                       select p;
            byte red = 0; byte green = 0; byte blue = 0;
            int k = 0;
            int i = 0;
            int j = 0;
            foreach (var item in proj)
                if (item.id_project == ID)
                {
                    var fl = from f in db.BoardColors
                             where f.id_project == item.id_project
                             select f;

                    foreach (var color in fl)
                    {
                        red = color.rgb_red;
                        green = color.rgb_green;
                        blue = color.rgb_blue;

                        Rectangle r = new Rectangle
                        {
                            Height = item.squareSize,
                            Width = item.squareSize,
                            Fill = new SolidColorBrush(Color.FromRgb(red, green, blue)),
                            Name = "s" + k.ToString()
                        };

                        r.VerticalAlignment = VerticalAlignment.Top;
                        r.HorizontalAlignment = HorizontalAlignment.Left;
                        r.Margin = new Thickness(i * item.squareSize, j * item.squareSize, 0, 0);
                        MainAnimLayer.Children.Add(r);

                        k++;
                        if (j % ((item.boardSize / item.squareSize) - 1) == 0 & j != 0)
                        {
                            i++;
                            j = 0;
                        }
                        else j++;
                    }
                }
        }
    }
}
