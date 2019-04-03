using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Xml;
namespace ord5
{
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
        static void inport()
        {
            try
            {
                XDocument bank = new XDocument();
                bank = XDocument.Load(@"d:\bank.xml");
                var cl = from item in bank.Element("order").Elements()
                         select new
                         {
                             client=item.Name,
                             goods=item.Value,
                             number=item.Attribute("number"),
                         };
                var cl2 = from n in cl
                          group n by n.client into g
                          orderby g.Key
                          select g;
                foreach(var gp in cl2 )
                {
                    Console.WriteLine("name{0}", gp.Key);
                    foreach(var s in gp )
                    {
                        Console.WriteLine("goods {0}need{0}", s.goods, s.number);
                    }
                }

              
            }
            catch (System .TypeLoadException)
            {
                Console.WriteLine("file");
            }
        }
        static void export(){
      try
       {
                var bank = new XDocument(new XElement("order",new XElement("name ",new XText("goodsname"), new XAttribute("number", "000"))));
                XNode r = bank.FirstNode;
                for (int i = 0; i < 10; i++)
           {
                    if (!listflag[i])
                { 
              
                        for (int j = 1; j < list[i].det.nums; j++)
                    {
                            XElement child = new XElement(list[i].client, new XText(list[i].det.goodslist[j]), new XAttribute("number", list[i].det.num[j]));
                     r.AddAfterSelf(child);
                    }
               
               }
            
            }
                StreamWriter w = new StreamWriter(new FileStream(@"d:\bank.xml",FileMode.Create),Encoding.utf8);
                bank.Save(w);
      }
            catch(System.CannotUnloadAppDomainException){
                Console.WriteLine("file opening failed"); 
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
                        while (true)
                        {
                            if (addo.CompareTo(list[i]) >= 0)
                            {
                                list[i] = addo;
                                break;
                            }
                        }
                        break;
                    }
                }export();
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
                }export();
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
                inport();
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
