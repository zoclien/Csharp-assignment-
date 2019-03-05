using System;

namespace su
{
    class Program
    {
        static void Main(string[] args)
        {
            int f = 2;
            double  num;
           
            int increase=1;
            string s;
            s = Console.ReadLine();
            num = double.Parse(s);
            int N = (int)Math.Sqrt(num);
           while(f<=N)
            {
                while (num%f==0)
                {
                    Console.WriteLine(f);
                    num /= f;
                }
                if (f == 3)
                    increase = 2;
                f += increase;

            }
            if (num >= f)
                Console.WriteLine(num);
           
        }
    }
}
