using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static orders[] list = new orders[10];
        private static bool[] listflag = new bool[10];
        [TestMethod]
        public void init()
        {
            for (int i = 0; i < 10; i++)
            {
                listflag[i] = true;
                Assert.IsTrue(listflag[1]);
            }
        }
        [TestMethod]
        static void creatorder()
        {int i=0;
            try
            {
                

                for ( i = 0; i < 10; i++)
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
                }
                export();
            }
            catch (System.OutOfMemoryException)
            {
                Console.WriteLine("fail :out of memory");
            }
            finally { Console.WriteLine("end"); };
            Assert.IsNotNull(list[i]);
        }
        [TestMethod]
        static void delete(int luckguy)
        {
            int i = 0;
            try
            {
                for ( i = 0; i < 10; i++)
                {
                    if (listflag[i] && list[i].number == luckguy)
                    {
                        listflag[i] = !listflag[i];
                        list[i] = null;

                    }
                }
                export();
            }
            catch (System.NullReferenceException)
            {

                Console.WriteLine("fail:null reference fail");

            }
            finally { Console.WriteLine("end"); };
            Assert.IsNull(list[i]);
        }
        [TestMethod]
        static void checkord(int luckguy)
        { bool  k=false ;
            try
            {
                for (int i = 0; i < 10; i++)
                    if (listflag[i] && list[i].number == luckguy)
                    { list[i].display();k = !k; break; }
                inport();
            }
            catch (System.StackOverflowException)
            {
                Console.WriteLine("fail");
            }
            finally { Console.WriteLine("end"); };
            Assert.IsTrue(k);
        }
        [TestMethod]
        static public void export()
        {
            bool k = false;
            try
            {
                var bank = new XDocument(new XElement("order", new XElement("name ", new XText("goodsname"), new XAttribute("number", "000"))));
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
                StreamWriter w = new StreamWriter(new FileStream(@"d:\bank.xml", FileMode.Create), encoding.utf8);
                bank.Save(w);
                k = (w != null);

            }
            catch (System.CannotUnloadAppDomainException)
            {
                Console.WriteLine("file opening failed");
            }
            Assert.IsNotNull(k);
        }
        [TestMethod]
        static void inport()
        {
            bool k = false;
            try
            {
                XDocument bank = new XDocument();
                bank = XDocument.Load(@"d:\bank.xml");
                var cl = from item in bank.Element("order").Elements()
                         select new
                         {
                             client = item.Name,
                             goods = item.Value,
                             number = item.Attribute("number"),
                         };
                var cl2 = from n in cl
                          group n by n.client into g
                          orderby g.Key
                          select g;
                
                foreach (var gp in cl2)
                {
                    Console.WriteLine("name{0}", gp.Key);
                    foreach (var s in gp)
                    {
                        k = (s != null);
                        Console.WriteLine("goods {0}need{0}", s.goods, s.number);
                    }
                }
          

            }
            catch (System.TypeLoadException)
            {
                Console.WriteLine("file");
            }      Assert.IsNotNull(k);
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
