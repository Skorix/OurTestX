using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Z
{
    public class Rnd_Z
    {
        static public void rndZ(int[] colZad, int[][] n_zad)
        {
            n_zad[0] = new int[colZad[0]];
            n_zad[1] = new int[colZad[1]];
            n_zad[2] = new int[colZad[2]];
            n_zad[3] = new int[colZad[3]];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < (colZad[i]); j++)
                {
                    n_zad[i][j] = j;
                }
            }

            System.Random rnd = new System.Random();
            for (int i = 0; i < n_zad.Length; i++)//вывод
            {
                n_zad[i] = n_zad[i].OrderBy(x => rnd.Next()).ToArray();
            }
        }

        static public int[] rndTypeZ(int[] colZad)
        {
            int[] arrayT = new int[colZad[0] + colZad[1] + colZad[2] + colZad[3]];
            int j1 = 0, j2 = 0, j3 = 0, j4 = 0;
            for (int i = 0; i < arrayT.Length; i++)
            {
                if (j1 != colZad[0])
                {
                    arrayT[i] = 0;
                    colZad[0] = colZad[0] - 1;
                }
                else if (j2 != colZad[1])
                {
                    arrayT[i] = 1;
                    colZad[1] = colZad[1] - 1;
                }
                else if (j3 != colZad[2])
                {
                    arrayT[i] = 2;
                    colZad[2] = colZad[2] - 1;
                }
                else if (j4 != colZad[3])
                {
                    arrayT[i] = 3;
                    colZad[3] = colZad[3] - 1;
                }
            }

            System.Random rnd = new System.Random();
            arrayT = arrayT.OrderBy(x => rnd.Next()).ToArray();
            return arrayT;
        }
    }
}
