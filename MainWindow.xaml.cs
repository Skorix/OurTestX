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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Avtomat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string vv = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            vv += e.Key;
            ; if (vv.Length >= 21)
            {
                if (vv == "DOem1EOemOpenBrackets")
                {
                    MessageBox.Show("UwU");
                }
                else
                {
                    vv = "";
                }
            }
            if (e.Key == Key.End)
            {
                vv = "";
            }

        }
    }
}
