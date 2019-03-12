using System;

namespace prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            massage first = new massage();
            first.setsender("mrA");
            first.setreader("mrB");
            first.setime(180310);
            first.setdata("how are you");
            massage firstc = first.clonemassage();
            firstc.setreader("mrC");
            Console.WriteLine("first=firstc?");
            Console.WriteLine(first == firstc);
            first.read();
            firstc.read();

        }
    }
}
