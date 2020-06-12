using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 事件
{
    public delegate void GetPacage(string code);

    public class Heater
    {
        public event EventHandler OnBoiled;
        public event GetPacage PackageHandler;
        private void RasieBoiledEvent()
        {
            if (OnBoiled == null)
            {
                Console.WriteLine("加热完成处理订阅事件为空");
            }
            else
            {
                OnBoiled(this, new EventArgs());
            }
        }
        public void Begin()
        {
            heatTime = 5;
            Heat();
            Console.WriteLine("加热器已经开启", heatTime);

         }
        private int heatTime;
        private void Heat()
        {
            Console.WriteLine("当前Heat Method线程：" + Thread.CurrentThread.ManagedThreadId);
            while (true)
            {
                Console.WriteLine("加热还需{0}秒", heatTime);
                if (heatTime == 0)
                {
                    RasieBoiledEvent();
                    return;
                }
                heatTime--;
                Thread.Sleep(1000);
            }
        }

    }
}
