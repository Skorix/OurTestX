using System.Text.RegularExpressions;
using System.IO;
using System.Windows;

namespace Task_Sort
{
    public class formation
    {
       public static void spisok_zad(string[][,] spz, string[] path)
        {
            int[] str = new int[4];
            int i1 = 0, i2 = 0, i3 = 0, i4 = 0;
            string line;
            str = t_count(path);
            spz[0] = new string[str[0], 5];
            spz[1] = new string[str[1], 5];
            spz[2] = new string[str[2], 5];
            spz[3] = new string[str[3], 5];

            for (int n =0; n!= path.Length;n++)
            {
                line = path[n];
                switch (line)
                {
                    case "[ОО]":
                        int j1 = 0;
                        n++;
                        line = path[n];
                        while (line != "[ответы]")
                        {
                            spz[0][i1, j1] += line + "\n";
                            n++;
                            line = path[n];
                        }
                        n++;
                        n++;
                        line = path[n];
                        while (line != "}")
                        {
                            j1++;
                            if (j1 < 5)
                            {
                                spz[0][i1, j1] = line;
                            }
                            n++;
                            line = path[n];
                        }
                        i1++;
                        break;

                    case "[МО]":
                        int j2 = 0;
                        n++;
                        line = path[n];
                        while (line != "[ответы]")
                        {
                            spz[1][i2, j2] += line + "\n";
                            n++;
                            line = path[n];
                        }
                        n++;
                        n++;
                        line = path[n]; while (line != "}")
                        {
                            j2++;
                            if (j2 < 5)
                            {
                                spz[1][i2, j2] = line;
                            }
                            n++;
                            line = path[n];
                        }
                        i2++;
                        break;

                    case "[ВС]":
                        int j3 = 0;
                        n++;
                        line = path[n];
                        while (line != "[ответы]")
                        {
                            spz[2][i3, j3] += line + "\n";
                            n++;
                            line = path[n];
                        }
                        n++;
                        n++;
                        line = path[n];
                        while (line != "}")
                        {
                            j3++;
                            if (j3 < 5)
                            {
                                spz[2][i3, j3] = line;
                            }
                            n++;
                            line = path[n];
                        }
                        i3++;
                        break;

                    case "[СО]":
                        int j4 = 0;
                        n++;
                        line = path[n];
                        while (line != "[ответы]")
                        {
                            spz[3][i4, j4] += line + "\n";
                            n++;
                            line = path[n];
                        }
                        if(line == "[ответы]")
                        { 
                            n++;
                            n++;
                            line = path[n]; 
                            while (line != "}")
                            {
                                j4++;
                                if (j4 < 5)
                                {
                                    spz[3][i4, j4] = line;
                                }
                                n++;
                                line = path[n];
                            }
                            i4++;
                        }
                        break;
                }
            }
        }

        public static int[] t_count(string[] path)
        {
            string[] types = new string[] { "ОО", "МО", "ВС", "СО" };
            int[] count = new int[4];
            for (int i=0; i < count.Length; i++)
            {
                for(int j=0;j<path.Length;j++)
                    if (Regex.IsMatch(path[j], types[i]) == true)
                    {
                        count[i]++;
                    }
            }

            return count;
        }
        public static int zad_count(string[] path)
        {
            int a = 0;
            for (int i = 0; i != path.Length; i++)
            {
                if (Regex.IsMatch(path[i], "\\[ОО]|\\[МО]|\\[ВС]|\\[СО]") == true)
                {
                    a++;
                }
            }
            return a;
        }
        
    }
}
