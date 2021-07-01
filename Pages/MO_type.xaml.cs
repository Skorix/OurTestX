using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для MO_type.xaml
    /// </summary>
    public partial class MO_type : Page
    {
        string[][,] zad = new string[4][,];
        int chk_count;
        CheckBox[] chkbox;
        public MO_type()
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
            chkbox=formation_form();
            schet.Content = Main_Menu.index_z+1 + "/" + Bank.task_count;
        }
        private CheckBox[] formation_form()
        {
            tnt.Text = zad[1][Main_Menu.N_zadaniya[1][Bank.MO_element], 0];
            int count = 5;
            Button btn_array = new Button();
            TextBlock TxtBlck_content = new TextBlock();
            TxtBlck_content.TextWrapping = TextWrapping.Wrap;
            btn_array.Content = TxtBlck_content;
            CheckBox[] chkbox = chkbox_create(count, Create_TxtBlck(count, 1, zad[1]));
            chkbox_Filling(chkbox);
            return chkbox;
        }
        private void chkbox_Filling(CheckBox[] chkbox)
        {
            for (int i = 1; i < chkbox.Length; i++)
            {
                if (chkbox[i] != null)
                {
                    Wrappanel.Children.Add(chkbox[i]);
                }
            }
            chk_count = Wrappanel.Children.Count;
        }

        private CheckBox[] chkbox_create(int quantity, TextBlock[] var_otvety)
        {
            
            CheckBox[] chkbox = new CheckBox[quantity];
            for (int i = 1; i < chkbox.Length; i++)
            {
                if (var_otvety[i].Text != "")
                {
                    chkbox[i] = new CheckBox();
                    chkbox[i].Click += new RoutedEventHandler(this.CheckBox_Click);
                    chkbox[i].Content = var_otvety[i];
                    chkbox[i].Style = (Style)Application.Current.FindResource("CheckBoxStyle1");
                    chkbox[i].Margin = new Thickness(15);
                    chkbox[i].Name = "chk" + i;
                    if (Bank.otveti[1][Bank.MO_element] != null)
                    {
                        chkbox[i].IsChecked=(Convert.ToBoolean((int)Char.GetNumericValue(Bank.otveti[1][Bank.MO_element][i - 1])));
                    }
                }
            }
            return chkbox;
        }

        private TextBlock[] Create_TxtBlck(int quantity, int startNumber, string[,] var_otvety)
        {
            TextBlock[] _TxtBlck = new TextBlock[quantity];
            for (int i = 1; i < _TxtBlck.Length; i++)
            {
                _TxtBlck[i] = new TextBlock();
                _TxtBlck[i].TextWrapping = TextWrapping.Wrap;
                _TxtBlck[i].FontSize = 24;
                _TxtBlck[i].Text = var_otvety[Main_Menu.N_zadaniya[1][Bank.MO_element], i];

                if (var_otvety[Main_Menu.N_zadaniya[1][Bank.MO_element], i] != null)
                {
                    if ((Regex.IsMatch(var_otvety[Main_Menu.N_zadaniya[1][Bank.MO_element], i], "^\\[\\+]")) == true)
                    {
                        _TxtBlck[i].Text = var_otvety[Main_Menu.N_zadaniya[1][Bank.MO_element], i].Substring(3);
                    }
                    else
                    {
                        _TxtBlck[i].Text = var_otvety[Main_Menu.N_zadaniya[1][Bank.MO_element], i];
                    }
                }
            }
            return _TxtBlck;
        }

        private void back_btn(object sender, RoutedEventArgs e)
        {
            Bank.otveti[1][Bank.MO_element] = "";
            for (int i = 1; i <= chk_count; i++)
            {
                if (chkbox[i].IsChecked == true)
                {
                    Bank.otveti[1][Bank.MO_element] += 1;
                }
                else
                {
                    Bank.otveti[1][Bank.MO_element] += 0;
                }
            }
            if(Bank.otveti[1][Bank.MO_element].Length < 4)
            {
                while (Bank.otveti[1][Bank.MO_element].Length <4)
                {
                    Bank.otveti[1][Bank.MO_element] += 0;
                }
            }
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
            Bank.otveti[1][Bank.MO_element] = "";
            for (int i = 1; i <= chk_count; i++)
            {
                if (chkbox[i].IsChecked == true)
                {
                    Bank.otveti[1][Bank.MO_element] += 1;
                }
                else
                {
                    Bank.otveti[1][Bank.MO_element] += 0;
                }
            }
            if (Bank.otveti[1][Bank.MO_element].Length < 4)
            {
                while (Bank.otveti[1][Bank.MO_element].Length < 4)
                {
                    Bank.otveti[1][Bank.MO_element] += 0;
                }
            }
            Main_Menu.index_z++;
            Bank.MO_element++;
            if (Main_Menu.index_z != (zad[0].GetLength(0)) +(zad[1].GetLength(0)) + (zad[2].GetLength(0)) + (zad[3].GetLength(0)))
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

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}