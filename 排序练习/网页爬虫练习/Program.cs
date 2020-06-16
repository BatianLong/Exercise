using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 网页爬虫练习
{
    class Program
    {
        static void Main(string[] args)
        {
            string URL = @"https://s.taobao.com/search?q={0}&s={1}";
            Console.WriteLine("请输入你要查找的商品:");
            string q = Console.ReadLine();
            Console.WriteLine("请输入要查找到多少页(每页10个商品)");
            int s = int.Parse(Console.ReadLine());
            for (int i = 1; i <= s; i++)
            {
                Console.WriteLine("--第{0}页--", i);
                string html = GetHtml(string.Format(URL, q, 22 * i));
                List<List<string>> value = Rule.GetAll(GetHtml(string.Format(URL, q, 22 * i)).Split('\n')[Rule.Inline]);

                string tmpPath = Path.Combine(Environment.CurrentDirectory.ToString(), @"htmlfile\", "Template.htm");
                string resultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"htmlfile\", "result.htm");
                HtmlHelper.WriteFile(value, tmpPath, resultPath);
                Console.WriteLine("--第{0}页完毕--", i);
            }
            Console.ReadKey();
        }
        //获取网页源码
        static string GetHtml(string url)
        {
            WebClient wc = new WebClient();
            byte[] data = wc.DownloadData(url);
            return Encoding.UTF8.GetString(data);
        }
    }
    public static class Rule
    {
        public static string[] Name = { "raw_title", "商品名称" };
        public static string[] Pic = { "pic_url", "图片地址" };
        public static string[] Url = { "detail_url", "商品地址" };
        public static string[] Price = { "view_price", "价格" };
        public static string[] Address = { "item_loc", "店铺所在地" };
        public static string[] BuyNumber = { "view_sales", "购买人数" };
        public static string[] UserId = { "user_id", "卖家ID" };
        public static string[] ShopName = { "nick", "店铺名称" };
        public static int Inline = 58;//内容所在行数
        public static List<string[]> Information = new List<string[]>() { Name, Pic, Url, Price, Address, BuyNumber, UserId, ShopName };

        public static List<List<string>> GetAll(string html)//获取所有商品信息
        {
            List<List<string>> list = new List<List<string>>();
            for (int i = 1; i <= 10; i++)
            {
                List<string> item = new List<string>();
                for (int j = 0; j < Information.Count; j++)
                {
                    int index = html.IndexOf(Information[j][0]);
                    if (index != -1)
                    {
                        html = html.Substring(index + Information[j][0].Length + 3);
                        if (j == 2)//网址转码
                            item.Add(Regex.Unescape(html.Substring(0, html.IndexOf('"'))));
                        else
                            item.Add(html.Substring(0, html.IndexOf('"')));
                    }
                }
                list.Add(item);
            }
            return list;
        }
    }
    public class HtmlHelper
    {
        public static void WriteFile(List<List<string>> resultAarry, string tmppath, string resultpath)
        {
            //---------------------读html模板页面到stringbuilder对象里----
            StringBuilder htmltext = new StringBuilder();
            try
            {
                using (StreamReader sr = new StreamReader(tmppath)) //模板页路径
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        htmltext.Append(line);
                    }
                    sr.Close();
                }
            }
            catch
            {

            }

            StringBuilder sb = new StringBuilder();
            for (int x = 0; x < resultAarry.Count; x++)
            {
                for (int y = 0; y < resultAarry[x].Count; y++)
                {
                    if (y == 1)
                    {
                        sb.Append(String.Format("<tr><td width=\"100%\" valign=\"middle\" align=\"left\">第{0}个-{1}-<img src='{2}' width='128' height='128' /></td></tr>\r\n", x + 1, Rule.Information[y][1], "http:" + resultAarry[x][y]));
                    }
                    else if (y == 2)
                    {

                        sb.Append(String.Format("<tr><td width=\"100%\" valign=\"middle\" align=\"left\">第{0}个-<a href='{2}'>{1}</a></td></tr>\r\n", x + 1, Rule.Information[y][1], "https:" + resultAarry[x][y]));
                    }
                    else
                    {
                        sb.Append(String.Format("<tr><td width=\"100%\" valign=\"middle\" align=\"left\">第{0}个-{1}-{2}</td></tr>\r\n", x + 1, Rule.Information[y][1], resultAarry[x][y]));
                    }
                }

                sb.Append(String.Format("<tr><td width=\"100%\" bgcolor='#30D5C8' valign=\"middle\" align=\"left\"></td></tr>\r\n"));
            }
            //----------替换htm里的标记为你想加的内容
            htmltext.Replace("$htmlformat[1]", sb.ToString());



            //----------生成htm文件------------------――
            try
            {
                using (StreamWriter sw = new StreamWriter(resultpath, false, System.Text.Encoding.GetEncoding("GB2312"))) //保存地址
                {
                    sw.WriteLine(htmltext);
                    sw.Flush();
                    sw.Close();

                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 自动产生编号，最多一天产生99个
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        string ConvertDate(int index)
        {
            string Res = string.Empty;
            Res = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            if (index < 10)
            {
                Res = Res + "0" + index.ToString();
            }
            else
            {
                Res = Res + index.ToString();
            }

            return Res;
        }
    }
}
