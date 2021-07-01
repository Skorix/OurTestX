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
using System.Text.RegularExpressions;
using Project_Avtomat.Pages;

namespace Project_Avtomat
{
    /// <summary>
    /// Логика взаимодействия для OO_type.xaml
    /// </summary>
    public partial class OO_type : Page
    {
        string[][,] zad = new string[4][,];
        public OO_type()
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
            formation_form();
            schet.Content = Main_Menu.index_z+1 + "/" + Bank.task_count;
        }

        private void formation_form()
        {
            tnt.Text = zad[0][Main_Menu.N_zadaniya[0][Bank.OO_element], 0];
            int count = 5;
            Button btn_array = new Button();
            TextBlock TxtBlck_content = new TextBlock();
            TxtBlck_content.TextWrapping = TextWrapping.Wrap;
            btn_array.Content = TxtBlck_content;

            if (PANEL.Children.Count > 0)
                PANEL.Children.Clear();

            Button[] buttons = CreateButtons(count, 1, Create_TxtBlck(count, 1, zad[0]));
            Btn_Filling(buttons);
        }

        private Button[] CreateButtons(int quantity, int startNumber, TextBlock[] var_otvety)
        {
            Button[] buttons = new Button[quantity];
            for (int i = 1; i < buttons.Length; i++)
            {
                if (var_otvety[i].Text != "")
                { 
                    buttons[i] = new Button();
                    buttons[i].Content = var_otvety[i];
                    buttons[i].VerticalAlignment = VerticalAlignment.Top;
                    buttons[i].Style = (Style)Application.Current.FindResource("ButtonStyle2");
                    buttons[i].Margin = new Thickness(0, 5, 0, 5);
                    buttons[i].MinHeight = 1;
                    buttons[i].Click += new RoutedEventHandler(this.GreetingBtn_Click);
                }
            }
            return buttons;
        }

        void GreetingBtn_Click(Object sender,EventArgs e)
        {
            var a = (Button)sender;
            var b = (TextBlock)a.Content;
            Bank.otveti[0][Bank.OO_element] = b.Text;
            next_btn(sender, e);
        }

        private TextBlock[] Create_TxtBlck(int quantity, int startNumber, string[,] var_otvety)
        {
            TextBlock[] _TxtBlck = new TextBlock[quantity];
            for (int i = 1; i < _TxtBlck.Length; i++)
            {
                _TxtBlck[i] = new TextBlock();
                if(var_otvety[Main_Menu.N_zadaniya[0][Bank.OO_element], i] != null)
                {
                    if ((Regex.IsMatch(var_otvety[Main_Menu.N_zadaniya[0][Bank.OO_element], i], "^\\[\\+]")) == true)
                    {
                        _TxtBlck[i].Text = var_otvety[Main_Menu.N_zadaniya[0][Bank.OO_element], i].Substring(3);
                    }
                    else
                    {
                        _TxtBlck[i].Text = var_otvety[Main_Menu.N_zadaniya[0][Bank.OO_element], i];
                    }
                }
                
                _TxtBlck[i].Style = (Style)Application.Current.FindResource("TextBlockStyle1");
            }
            return _TxtBlck;
        }

        private void Btn_Filling(Button[] buttons)
        {
            for (int i=1; i < buttons.Length; i++)
            {
                if (buttons[i] != null)
                {
                    PANEL.Children.Add(buttons[i]);
                }
            }    
        }

        private void back_btn(object sender, EventArgs e)
        {
            Main_Menu.index_z--;
            if (Main_Menu.index_z != (zad[0].GetLength(0)) +(zad[1].GetLength(0)) + (zad[2].GetLength(0)) + (zad[3].GetLength(0)))
            {
                navigation(Main_Menu.types, Main_Menu.index_z, true);
            }
            else
            {
                NavigationService.Navigate(new Last_task());
            }
        }
        private void next_btn(object sender, EventArgs e)
        {
            Main_Menu.index_z++;
            Bank.OO_element++;
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
