using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace 面试题实操
{
    class BaseClass
    {
        public int i;
    }
    class MyClass : BaseClass
    {
        public new int i;
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass y = new MyClass();
            BaseClass x = y;
            x.i = 100;
            Console.WriteLine("{0}, {1}", x.i, y.i);

            //    //Resource r0 = new Resource(100);
            //    //using (Resource r1 = new Resource(100))
            //    //{
            //    //    r1.print();
            //    //    r1 = new Resource(50);

            //    //}
            //    enum a { a1, a2, a3 };
            //object i = 100, j = 200, k = 300;
            //Interlocked.CompareExchange(ref i, j, k);
            //    Console.WriteLine($"{i},{j},{k}");
            //    XmlDocument xd = new XmlDocument();
            //xd.LoadXml("&lt; Person & gt; &lt; name & gt; 诸葛亮 & lt;/ name & gt; &lt;/ Person & gt;");
            //    Console.WriteLine(xd.DocumentElement.InnerXml);
                Console.Read();
            //    //Response.Write(Server.HtmlEncode(xd.DocumentElement.InnerXml));

        }
    }
}
