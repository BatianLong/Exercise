using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALiWangwang
{
    public partial class Form1 : Form
    {        /// <summary>
             /// 设置UserAgent
             /// </summary>
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        public Form1()
        {
            InitializeComponent();
            string pBuffer = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
            UrlMkSetSessionOption(0x10000001, pBuffer, pBuffer.Length, 0); 			//设置UserAgent
            webBrowser1.ScriptErrorsSuppressed = true; //禁用错误脚本提示   

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InitializeComponent();
        }
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]    //API设定Cookie
        static extern int InternetSetCookieEx(string lpszURL, string lpszCookieName, string lpszCookieData, int dwFlags, IntPtr dwReserved);
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]    //API获取Cookie
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);
        private string GetCookieString(string url)    //url通过API获取完整Cookie
        {
            uint datasize = 256;
            StringBuilder cookieData = new StringBuilder((int)datasize);
            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x2000, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;
                cookieData = new StringBuilder((int)datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, IntPtr.Zero))
                    return null;
            }
            return cookieData.ToString();
        }
        public static string strCookie = "";
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().Contains("login"))
            {
                webBrowser1.Document.Window.ScrollTo(872, 290); // 定位网页显示位置
            }
            else if (webBrowser1.Url.ToString().Contains("https://www.taobao.com"))
            {
                string Cookie = GetCookieString(webBrowser1.Url.ToString());
                strCookie = Cookie;
                textLogs.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " : 淘宝账号登录成功\r\n");   //这个是输出日志 使用的是TextBox 控件
            }
        }        /// <summary>
                 /// 检测订单号 
                 /// </summary>
                 /// <param name="orderId">传入订单号</param>
                 /// <param name="strCookie">传入Cookie值</param>
                 /// <returns>返回页面的Html</returns>
        public string CheeckOrderId(string orderId, string strCookie)
        {

            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                //URL = "https://trade.taobao.com/trade/detail/e_ticket_trade_item_detail.htm?spm=a1z09.1.0.0.60663606LKpQP4&bizOrderId=" + orderId,//URL     必需项    
                URL = "https://trade.taobao.com/trade/itemlist/list_sold_items.htm?action=itemlist/SoldQueryAction&event_submit_do_query=1&auctionStatus=SEND&tabCode=haveSendGoods",
                Encoding = System.Text.Encoding.GetEncoding("gbk"),//URL     可选项 默认为Get   
                Method = "get",//URL     可选项 默认为Get   
                IsToLower = false,//得到的HTML代码是否转成小写     可选项默认转小写   
                Cookie = strCookie,
                Referer = "",//来源URL     可选项   
                Postdata = "",//Post数据     可选项GET时不需要写   
                Timeout = 100000,//连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000,//写入Post数据超时时间     可选项默认为30000   
                                         // UserAgent = "Mozilla/5.0 (Linux; U; Android 7.0; zh-CN; FRD-AL00 Build/HUAWEIFRD-AL00) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/40.0.2214.89 UCBrowser/11.3.8.909 UWS/2.10.2.5 Mobile Safari/537.36 UCBS/2.10.2.5 Nebula AlipayDefined(nt:WIFI,ws:360|0|3.0) AliApp(AP/10.0.18.062203) AlipayClient/10.0.18.062203 Language/zh-Hans useStatusBar/true",//用户的浏览器类型，版本，操作系统     可选项有默认值   
                UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.94 Safari/537.36",
                ContentType = "text/html; charset=utf-8",//返回类型    可选项有默认值   
                Allowautoredirect = false,//是否根据301跳转     可选项   

                ProxyIp = "",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    
                             //ProxyPwd = "123456",//代理服务器密码     可选项    
                             //ProxyUserName = "administrator",//代理服务器账户名     可选项   
                ResultType = ResultType.String
            };
            HttpResult result = http.GetHtml(item);
            return result.Html;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheeckOrderId("", strCookie);
        }
    }
}
