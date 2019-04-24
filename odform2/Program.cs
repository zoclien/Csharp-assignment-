using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace odform2
{

    public class orders : IComparable
    {
        public int number;
        public string client;
        public orderdeteils det;
        public int CompareTo(object s)
        {
            return number - (s as orders).number;
        }
        public override bool Equals(object obj)
        {
            var d = obj as orders;
            return this.det.Equals(d.det) && number == d.number && client == d.client;
            // return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            int hashcode = 1522631281;
            hashcode = hashcode * -1521134295 + number.GetHashCode();
            hashcode = hashcode * -1521134295 + client.GetHashCode();
            hashcode = hashcode * -1521134295 + det.GetHashCode();
            return hashcode;
            // return base.GetHashCode();
        }
        public override string ToString()
        {
            return "name:" + client + "oederid:" + number + det.ToString();
        }
        public string display()
        {
            Console.WriteLine("order number" + this.number + "client name" + this.client);
            return "order number" + this.number + "client name" + this.client;
        }
        public orders(string c,int k,string g1,string g2,string g3)
        {
            
            this.client = c;
            
            this.number = k;
            this.det = new orderdeteils(string g1,string g2,string g3);
        }
    }
    public class orderdeteils
    {
        public int[] num = new int[100];
        public int nums=3;
        public override bool Equals(object s)
        {
            var d = s as orderdeteils;
            return this.nums != 0 && this.num != d.num  ;
        }
        public override int GetHashCode()
        {
            int hashcode = 1522631281;
            hashcode = hashcode * -1521134295 + nums.GetHashCode();
            hashcode = hashcode * -1521134295 + num.GetHashCode();
            
            return hashcode;
            //turn base.GetHashCode();
        }
        public override string ToString()
        {
            string a = "";
            for (int i = 1; i <= 3; i++)
            {
                a = a + "//" +" goodslist"+i+"/"+ num[i];
            }
            return a;
        }
        public orderdeteils(string g1,string g2,string g3)
        {
            num[1] = int.Parse(g1);
            num[2] = int.Parse(g2);
            num[3] = int.Parse(g3);
            
        }
    }
    public class orderservice
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
                        Console.WriteLine("goods {0}need{0}", s.goods, s.number);
                    }
                }


            }
            catch (System.TypeLoadException)
            {
                Console.WriteLine("file");
            }
        }
        static void export()
        {
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
                StreamWriter w = new StreamWriter(new FileStream(@"d:\bank.xml", FileMode.Create), Encoding.utf8);
                bank.Save(w);
            }
            catch (System.CannotUnloadAppDomainException)
            {
                Console.WriteLine("file opening failed");
            }
        }

        public void creatorder(orders addo)
        {
            try
            {

                for (int i = 0; i < 10; i++)
                {
                    if (listflag[i])
                    {

                        
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
        }
        public void delete(string luckguy)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    if (listflag[i] && list[i].client == luckguy)
                    {
                        listflag[i] = !listflag[i];
                        list[i] = null;

                    }
                }
                export();
            }
            catch (System.NullReferenceException);
            {
                Console.WriteLine("fail:null reference fail");
            }
            }
            finally { Console.WriteLine("end"); };
        }
        public  string checkord(string luckguy)
        {
            string s="";
            try
            {
                for (int i = 0; i < 10; i++)
                    if (listflag[i] && list[i].client == luckguy)
                       s= list[i].display();
                inport();
            }
            catch (System.StackOverflowException)
            {
                Console.WriteLine("fail");
            }
            finally { Console.WriteLine("end"); };
            return s;
        }
    }
    static class Program
    {
        private static orders [] list = new orders[10];
        
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            
          Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
           
        }
    }
}
