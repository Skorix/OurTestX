using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Correct_otv
{
    public class Otveti
    {
        public static void OTV(string[][] zad,string[] path, int[] quan)
        {
            zad[0] = new string[quan[0]];
            zad[1] = new string[quan[1]];
            zad[2] = new string[quan[2]];
            zad[3] = new string[quan[3]];
            String line;
            int i1 = 0, i2 = 0, i3 = 0, i4 = 0;
            for(int n = 0; n != path.Length; n++)
            {
                line = path[n];
                switch (line)
                {
                    case "[ОО]":
                        while (Regex.IsMatch(line, "^\\{$") != true)
                        {
                                n++;
                                line = path[n];
                        }
                        while (Regex.IsMatch(line, "^\\}$") != true)
                        {
                            if (Regex.IsMatch(line, "^\\[\\+]"))
                            {
                                zad[0][i1] = line.Substring(3);
                            }
                                n++;
                                line = path[n];
                        }
                        i1++;
                        break;

                    case "[СО]":
                        int fourr = 0;
                        while (Regex.IsMatch(line, "^\\{$") != true)
                        {
                            n++;
                            line = path[n];
                        }
                        n++;
                        line = path[n];
                        while (Regex.IsMatch(line, "^\\}$") != true)
                        {
                            zad[3][i4] += line[1];
                            fourr++;
                            n++;
                            line = path[n];
                        }
                        if (fourr != 4)
                        {
                            for (; fourr != 4; fourr++)
                            {
                                zad[3][i4] += 0;
                            }
                        }
                        i4++;
                        break;

                    case "[МО]":
                        int four = 0;
                        while (Regex.IsMatch(line, "^\\{$") != true)
                        {
                            n++;
                            line = path[n];
                        }
                        n++;
                        line = path[n];
                        while (Regex.IsMatch(line, "^\\}$") != true)
                        {
                            if (Regex.IsMatch(line, "^\\[\\+]"))
                            {
                                zad[1][i3] += 1;
                                four++;
                            }
                            else
                            {
                                zad[1][i3] += 0;
                                four++;
                            }
                            n++;
                            line = path[n];
                        }
                        if (four != 4)
                        {
                            for (; four != 4; four++)
                            {
                                zad[1][i3] += 0;
                            }
                        }
                        i3++;
                        break;

                    case "[ВС]":
                        while (Regex.IsMatch(line, "^\\{$") != true)
                        {
                            n++;
                            line = path[n];
                        }
                        while (Regex.IsMatch(line, "^\\}$") != true)
                        {
                            n++;
                            line = path[n];
                            if(line.Length > 3)
                            {
                                zad[2][i2] = line.Substring(3);
                            }
                        }
                        i2++;
                        break;
                        
                }
            }
        }
    }
}
