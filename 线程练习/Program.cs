using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程练习
{
    class Program
    {
        public static Thread[] iThread=new Thread[5];
        public static ThreadStart[] iThreadStart = new ThreadStart[5];
        public static string str = "";
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                CreateThread(i);
            }
            WriteLog();
        }
        /// <summary>
        /// Create 一个线程
        /// </summary>
        /// <param name="i"></param>
        public static void CreateThread(int i)
        {
            iThread[i] = new Thread(new ParameterizedThreadStart(proc));
            iThread[i].Start(i);
            str += "线程<" + i.ToString() + ">启动！！！\r";
        }
        public static void proc(object i)
        {
            int m = (int)i;
            for (int n = 1;n<=10; n++)
            {
                str += "线程<" + i.ToString() + ">运行" + n.ToString() + "次\r";
                Console.WriteLine("线程"+m.ToString()+">运行"+n.ToString()+"次");
            }
        }
        public static void WriteLog()
        {
            //string path = "";
            //StreamWriter sw = new StreamWriter(path);
            //sw.WriteLine(str);
            //sw.Close();
            Console.WriteLine(str);
            Console.Read();
        }
    }
}
