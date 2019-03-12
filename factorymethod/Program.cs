using System;
namespace factorymethod
{
    class Program
    {
        static void Main(string[] args)
        {
            TVname k = new TVname();
             TVf  factory= k.getname();
            TV tv = factory.produceTV();
            tv.play();
           

     
        }
    }
}
