using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project_Avtomat
{
    class Bank
    {
        public static int OO_element { get; set; } = 0;
        public static int CO_element { get; set; } = 0;
        public static int MO_element { get; set; } = 0;
        public static int VS_element { get; set; } = 0;
        public static string[][] otveti { get; set; } = new string[4][];
        public static string[][] cor_otv { get; set; } = new string[4][];

        public static int ball = 0;
        public static int task_count;

    }
}
