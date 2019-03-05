using System;

namespace _2._7
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxnum, minnum, avge, total;
            int[] num;
            Console.WriteLine("how many numbers do you need");
            string s;
            s = Console.ReadLine();
            int n = int.Parse(s);
            num = new int[n];
            
            for(int i=0;i<n;i++)
            {
                s = Console.ReadLine();
                num[i] = int.Parse(s);
            }
            maxnum = num[0];
            minnum = num[0];
            avge = 0;
            total = 0;
            for (int i = 0; i < n; i++)
            {
                total += num[i];
                maxnum = maxnum > num[i] ?maxnum : num[i];
                minnum = minnum < num[i] ? minnum : num[i];
            }
            avge = total / n;
            Console.WriteLine("max:"+maxnum +"min:"+minnum +"average:"+avge +"total:"+total );
  
        }
    }
}
