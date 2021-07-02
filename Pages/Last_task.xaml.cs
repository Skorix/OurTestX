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
    /// Логика взаимодействия для Last_task.xaml
    /// </summary>
    public partial class Last_task : Page
    {
        public Last_task()
        {
            InitializeComponent();
        }

        private void back_btn(object sender, RoutedEventArgs e)
        {
            Main_Menu.index_z--;
            if (Main_Menu.index_z != 8)
            {
                navigation(Main_Menu.types, Main_Menu.index_z);
            }
            else
            {
                NavigationService.Navigate(new Last_task());
            }
        }

        public void navigation(int[] types, int index_z)
        {
            switch (types[index_z])
            {
                case 0:
                    Bank.OO_element--;
                    NavigationService.Navigate(new OO_type());
                    break;
                case 1:
                    Bank.MO_element--;
                    NavigationService.Navigate(new MO_type());
                    break;
                case 2:
                    Bank.VS_element--;
                    NavigationService.Navigate(new VS_type());
                    break;
                case 3:
                    Bank.CO_element--;
                    NavigationService.Navigate(new CO_type());
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j != 4; j++)
            {
                foreach (string a in Bank.otveti[j])
                {
                    for (int i = 0; i < Main_Menu.N_zadaniya[j].Length; i++)
                    {
                        if (a == (Bank.cor_otv[j][Main_Menu.N_zadaniya[j][i]]))
                        {
                            Bank.ball++;
                            break;
                        }
                    }
                }
            }
            NavigationService.Navigate(new Results());

        }
    }
}
