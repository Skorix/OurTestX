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

namespace Project_Avtomat.Pages
{
    /// <summary>
    /// Логика взаимодействия для CO_type.xaml
    /// </summary>
    public partial class CO_type : Page
    {
        string[][,] zad = new string[4][,];
        int[] ll = new int[4];

        public CO_type()
        {
            zad = Main_Menu.zadaniya;
            InitializeComponent();
            if (Main_Menu.index_z == 0)
            {
                btn_back.IsEnabled = false;
            }
            else if(Main_Menu.index_z == (zad[0].GetLength(0)) + (zad[1].GetLength(0)) + (zad[2].GetLength(0)) + (zad[3].GetLength(0)))
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
            tt.Text = zad[3][Main_Menu.N_zadaniya[3][Bank.CO_element], 0];
            string[] ln = new string[zad[1].GetLength(1)];
            for(int i = 1; i != zad[1].GetLength(1); i++)
            {
                if(zad[1][0, i]!="")
                {
                    ln[i] = zad[3][Main_Menu.N_zadaniya[3][Bank.CO_element], i];
                }
            }
            if (zs.Children.Count > 0)
                zs.Children.Clear();
            frm(ln);
        }
        private void frm(string[] line)
        {
            for (int i = 1; i != line.Length; i++)
            {
                zs.Children.Add(wp_create(cmb_crate(line), t_block_crate(line))[i]);
            }
        }

        private void selChange(object sender, SelectionChangedEventArgs e)
        {
            var kk = (ComboBox)sender;
            int l = (int)Char.GetNumericValue(kk.Name[3]);
            ll[(int)char.GetNumericValue(kk.Name[3])-1] = Convert.ToInt32(kk.SelectedItem);
            //MessageBox.Show(Bank.otveti[3][Bank.CO_element]);

            //if(Regex.IsMatch(Bank.otveti[4][Bank.CO_element],))
            //MessageBox.Show(Convert.ToString(Convert.ToInt32(Char.GetNumericValue(kk.Name[3]))));
        }

        private ComboBox[] cmb_crate(string[] line)
        {
            ComboBox[] cmb = new ComboBox[line.Length];
            for (int i = 1; i != line.Length; i++)
            {
                if(line[i] != null)
                {
                    cmb[i] = new ComboBox();
                    for (int j = 1; j != line.Length; j++)
                    {
                        cmb[i].Items.Add(j);
                    }
                    cmb[i].Width = 45;
                    cmb[i].SelectionChanged += new SelectionChangedEventHandler(this.selChange);
                    cmb[i].Name = "cmb" + i;
                    if(Bank.otveti[3][Bank.CO_element] != null)
                    {
                        cmb[i].SelectedItem = ((int)char.GetNumericValue(Bank.otveti[3][Bank.CO_element][i-1]));
                    }
                }
            }
            return cmb;
        }

        private TextBlock[] t_block_crate(string[] line)
        {
            TextBlock[] tblck = new TextBlock[line.Length];
            for (int i = 1; i != tblck.Length; i++)
            {
                tblck[i] = new TextBlock();
                if (line[i] != null)
                {
                    tblck[i].Text = line[i].Substring(3);
                }
                tblck[i].TextWrapping = TextWrapping.Wrap;
                tblck[i].Margin = new Thickness(5, 0, 0, 0);
            }
            return tblck;
        }

       

        private WrapPanel[] wp_create(ComboBox[] cb, TextBlock[] tb)
        {
            WrapPanel[] wp_c = new WrapPanel[tb.Length];
            for (int i = 1; i != tb.Length; i++)
            {
                wp_c[i] = new WrapPanel();

                if (cb[i] != null && tb[i] != null)
                {
                    wp_c[i].Children.Add(cb[i]);
                    wp_c[i].Children.Add(tb[i]);
                    wp_c[i].Margin = new Thickness(5);
                }
            }
            return wp_c;
        }

        private void back_btn(object sender, RoutedEventArgs e)
        {
            Bank.otveti[3][Bank.CO_element]=formation_string(ll);
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
            Bank.otveti[3][Bank.CO_element] = formation_string(ll);
            Main_Menu.index_z++;
            Bank.CO_element++;
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
        public string formation_string(int[] num) 
        {
            string line="";
            foreach(int a in num)
            {
                line += Convert.ToString(a);
            }
            return line;
        }
    }
}
