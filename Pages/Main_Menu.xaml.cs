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
using System.Windows.Forms;
using Crypt;
using Task_Sort;
using Project_Avtomat.Pages;
using Random_Z;
using Correct_otv;

namespace Project_Avtomat
{
    /// <summary>
    /// Логика взаимодействия для Main_Menu.xaml
    /// </summary>
    public partial class Main_Menu : Page
    {
        string[] test_text;
        public static string[][,] zadaniya = new string[4][,];
        public static int[][] N_zadaniya = new int[4][];
        public static int index_z = 0;
        public static int[] types;
        public static int[] t_count;


        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Convert_btn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            openFileDialog.Filter = "";
            saveFileDialog.Filter = "тесты| *.gym";
            string filePath = "", savePath = "";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    savePath = saveFileDialog.FileName;
                }
            }

            if ((filePath) != "" & (savePath) != "")
            {
                Crypto.Enc(filePath, savePath);
            }
        }

        private void Open_btn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string filePath = "";
            openFileDialog.Filter = "тесты| *.gym";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                if (filePath != "")
                {
                    test_text = new string[Crypto.Dec(filePath).Length];
                    test_text = Crypto.Dec(filePath);
                    Otveti.OTV(Bank.cor_otv, test_text, formation.t_count(test_text));
                    formation.spisok_zad(zadaniya, test_text);
                    Bank.task_count=formation.zad_count(test_text);
                    Bank.otveti[0] = new string[formation.t_count(test_text)[0]];
                    Bank.otveti[1] = new string[formation.t_count(test_text)[1]];
                    Bank.otveti[2] = new string[formation.t_count(test_text)[2]];
                    Bank.otveti[3] = new string[formation.t_count(test_text)[3]];
                    types = new int[(zadaniya[0].GetLength(0))+ (zadaniya[1].GetLength(0))+ (zadaniya[2].GetLength(0))+ (zadaniya[3].GetLength(0))];
                    t_count = new int[] { (zadaniya[0].GetLength(0)), (zadaniya[1].GetLength(0)), (zadaniya[2].GetLength(0)), (zadaniya[3].GetLength(0)) };
                    types=Rnd_Z.rndTypeZ(t_count);
                    t_count = new int[] { (zadaniya[0].GetLength(0)), (zadaniya[1].GetLength(0)), (zadaniya[2].GetLength(0)), (zadaniya[3].GetLength(0)) };
                    Rnd_Z.rndZ(t_count, N_zadaniya);
                    navigation(types, index_z);
                }
            }

            //System.Windows.Forms.MessageBox.Show(Convert.ToString(zadaniya[1][0,0]));

        }

        public void navigation(int[] types, int index_z)
        {
            switch (types[index_z])
            {
                case 0:
                    NavigationService.Navigate(new OO_type());
                    break;
                case 1:
                    NavigationService.Navigate(new MO_type());
                    break;
                case 2:
                    NavigationService.Navigate(new VS_type());
                    break;
                case 3:
                    NavigationService.Navigate(new CO_type());
                    break;
            }
        }
        private void Update_btn(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Skorix/OurTestX");
        }
    }
}
