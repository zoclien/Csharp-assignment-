using System;

namespace order
{
    public class orderdeteils
    {
        public int[] num = new int[100];
        public string[] goodslist = new string[100];
        public int nums;
        public orderdeteils()
        {
            string s;
            Console.WriteLine("goods numbers");
            s = Console.ReadLine();
            this.nums = int.Parse(s);
            int i;
            for (i = 0; i < this.nums; i++)
            {

                Console.WriteLine("goods" + i + "name");
                goodslist[i] = Console.ReadLine();
                Console.WriteLine("goods" + i + "number");
                s = Console.ReadLine();
                num[i] = int.Parse(s);

            }
        }
    }
    public class orders
    {
        public int number;
        string client;
        orderdeteils det = new orderdeteils();
        public void display()
        {
            Console.WriteLine("order number" + this.number + "client name" + this.client);
        }
        public orders()
        {
            Console.WriteLine("client");
            this.client = Console.ReadLine();
            Console.WriteLine("number");
            string k = Console.ReadLine();
            this.number = int.Parse(k);
            this.det = new orderdeteils();
        }
    }
    class Program
    {
        private static orders[] list = new orders[10];
        private static bool[] listflag = new bool[10];
        public void init()
        {
            for (int i = 0; i < 10; i++)
            {
                listflag[i] = true;
                
            }
        }
       static void creatorder()
        {
            try
            {

                for (int i = 0; i < 10; i++)
                {
                    if (listflag[i])
                    {
                        orders addo = new orders();
                        list[i] = addo;
                        break;
                    }
                }
            }
            catch (System.OutOfMemoryException)
            {
                Console.WriteLine("fail :out of memory");
            }
            finally { Console.WriteLine("end"); };
        }
        static void delete(int luckguy)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    if (listflag[i] && list[i].number == luckguy)
                    {
                        listflag[i] = !listflag[i];
                        list[i] = null;
                    }
                }
            }
            catch (System.NullReferenceException);
            {
                Console.WriteLine("fail:null reference fail");
            }
            }
            finally { Console.WriteLine("end"); };
        }
        static void checkord(int luckguy)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                    if (listflag[i] && list[i].number == luckguy)
                        list[i].display();
            }
            catch (System.StackOverflowException)
            {
                Console.WriteLine("fail");
            }
            finally { Console.WriteLine("end"); };
        }
        public static void Main(string[] args)
        {
            int key;
            Console.WriteLine("delete:1/check:2/creat:3/");
            string g = Console.ReadLine();
            key = int.Parse(g);


            if (key == 1)
            {
                Console.WriteLine("delete");
                g = Console.ReadLine();
                int t = int.Parse(g);
                delete(t);
            }
            
            if (key == 2)
            {
                Console.WriteLine("check");
                g = Console.ReadLine();
                int c = int.Parse(g);
                checkord(c);
            }
          
            if (key == 3)
            {
                Console.WriteLine("creat");
                creatorder();
                
            }
        }
            

            
        }
    }
}
