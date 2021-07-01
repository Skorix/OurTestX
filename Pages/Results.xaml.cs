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

namespace Project_Avtomat.Pages
{
    /// <summary>
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Page
    {
        public Results()
        {
            InitializeComponent();
            int ocenka;
            ocenka = ((Bank.ball / Bank.task_count) * 100);
            if (ocenka <= 70) { Score.Text += " " + 2; }
            if (ocenka >= 71 & ocenka <= 80) { Score.Text += " " + 3; }
            if (ocenka >= 81 & ocenka <= 90) { Score.Text += " " + 4; }
            if (ocenka >= 91) { Score.Text += " " + 5; }
            Correct.Text += " " + Bank.ball;
            Falls.Text += " "+(Bank.task_count - Bank.ball);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Main_Menu());
        }
    }
}
