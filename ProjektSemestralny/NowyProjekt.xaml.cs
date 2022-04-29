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
                
                )
            {
                if (sizeBoard.SelectedItem == sizeBoard1) sizeBoardNumber = 1;

                

            }
        }
    }
}
