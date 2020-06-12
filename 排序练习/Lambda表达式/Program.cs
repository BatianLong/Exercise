using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda表达式
{
    class Program
    {
        delegate void printstr(string str);
        delegate void printstrs(string str,string str2);
        static void Main(string[] args)
        {
            #region 单参数
            //printstr str = msg =>
            //{
            //    Console.WriteLine("输出..." + msg);
            //};
            //str("测试");
            #endregion
            #region 多参数
            printstrs strs = (msg1, msg2) =>
            {
                Console.WriteLine($"{msg1},{msg2}");
            };
            #endregion
            strs("下午四点半", "有面试");
            Console.ReadLine();
        }
    }
}
