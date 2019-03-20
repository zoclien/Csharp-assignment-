using System;
using System.Data;

namespace clock
{
    public delegate void setime(object sender,clockevent e);
    public class clockguard{
        public event setime timeup;
        public void guarding(string s)
        {
            while(true){ 
            if(DateTime.Now.ToString().Equals(s))
            {
                clockevent args = new clockevent();
                args.isthere = true;
                timeup(this, args);
                    break;
            }
              }

        }
    }
    public class Program
    {
        static void Main(string[] args)
        { 
            string  mytime = "";
            Console.WriteLine("set time");
            mytime = Console.ReadLine();
            clockguard c = new clockguard( );
            c.timeup += Workout;
            c.guarding(mytime);
        }
        static void Workout(object sender,clockevent e)
        {
            if (e.isthere)
                Console.WriteLine("it is high time now");
        }
    }
}
