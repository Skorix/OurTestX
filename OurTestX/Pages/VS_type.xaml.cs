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
    /// Логика взаимодействия для VS_type.xaml
    /// </summary>
    public partial class VS_type : Page
    {
        string[][,] zad = new string[4][,];
        public VS_type()
        {
            zad = Main_Menu.zadaniya;
            InitializeComponent();
            if (Main_Menu.index_z == 0)
            {
                btn_back.IsEnabled = false;
            }
            else if (Main_Menu.index_z == (zad[0].GetLength(0)) + (zad[1].GetLength(0)) + (zad[2].GetLength(0)) + (zad[3].GetLength(0)))
            {
                btn_next.IsEnabled = false;
            }
            else
            {
                btn_back.IsEnabled = true;
                btn_next.IsEnabled = true;
            }

            tt.Text = zad[2][Main_Menu.N_zadaniya[2][Bank.VS_element], 0];
            if (Bank.otveti[2][Bank.VS_element] != null && Bank.otveti[2][Bank.VS_element] != "")
            {
                TxtBox.Text = Bank.otveti[2][Bank.VS_element];
            }
            else
            {
                TxtBox.Text = "Введите текст";
            }
            schet.Content = Main_Menu.index_z+1 + "/" + Bank.task_count;
        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TxtBox.Text == "Введите текст")
            {
                TxtBox.Text = "";
            }
        }

        private void back_btn(object sender, RoutedEventArgs e)
        {
            Bank.otveti[2][Bank.VS_element] = TxtBox.Text;
            Main_Menu.index_z--;
            if (Main_Menu.index_z != (zad[0].GetLength(0)) + (zad[1].GetLength(0)) + (zad[2].GetLength(0)) + (zad[3].GetLength(0)))
            {
                navigation(Main_Menu.types, Main_Menu.index_z, true);
            }
            else
            {
                NavigationService.Navigate(new Last_task());
            }
        }
        private void next_btn(object sender, RoutedEventArgs e)
        {
            Bank.otveti[2][Bank.VS_element]=TxtBox.Text;
            Main_Menu.index_z++;
            Bank.VS_element++;
            if (Main_Menu.index_z != (zad[0].GetLength(0)) + (zad[1].GetLength(0)) + (zad[2].GetLength(0)) + (zad[3].GetLength(0)))
            {
                navigation(Main_Menu.types, Main_Menu.index_z, false);
            }
            else
            {
                NavigationService.Navigate(new Last_task());
            }
        }

        public void navigation(int[] types, int index_z, bool back)
        {
            switch (types[index_z])
            {
                case 0:
                    if (back == true)
                    {
                        Bank.OO_element--;
                    }
                    NavigationService.Navigate(new OO_type());
                    break;
                case 1:
                    if (back == true)
                    {
                        Bank.MO_element--;
                    }
                    NavigationService.Navigate(new Pages.MO_type());
                    break;
                case 2:
                    if (back == true)
                    {
                        Bank.VS_element--;
                    }
                    NavigationService.Navigate(new Pages.VS_type());
                    break;
                case 3:
                    if (back == true)
                    {
                        Bank.CO_element--;
                    }
                    NavigationService.Navigate(new Pages.CO_type());
                    break;
            }
        }

    }
}
