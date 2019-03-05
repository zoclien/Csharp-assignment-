using System;

namespace _2._9
{
    class Program
    {
        static void Main(string[] args)
        {
            int S = 2, max = 100, muti = 1;
            bool []flag = new bool[100];
            for (int i = 0; i < max; i++)
                flag[i] = true;
            for(;S<max;S++)
            {
                if (!flag[S - 1])
                    continue;
                for (muti = 2; S * muti<=max; muti++)
                    flag[S * muti - 1] = false;

            }
            for (int i=0;i<max;i++)
            {
                if (flag[i])
                    Console.WriteLine(i+1+",");
  
            }
            string s=Console.ReadLine();

        }
    }
}
