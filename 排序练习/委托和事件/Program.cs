using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托和事件
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee("小白", 988);
            Reporter re = new Reporter();

            //指明玩游戏这个事件触发后，由谁来处理
            e1.PlayGame += new DelegateClassHandle(re.Notify);

            e1.Game();
            Console.ReadLine();
        }
    }
    public class Employee
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public Employee(string n, int nu)
        {
            _name = n;
            _number = nu;
        }        
        /// <summary>
        /// DelegateClassHandle的事件
        /// </summary>
        public event DelegateClassHandle PlayGame;
        public void Game()
        {
            Console.WriteLine("我要玩游戏喽！");

            CustomEventnArgs e = new CustomEventnArgs();
            e.Name = _name;
            e.Number = _number;
            if (PlayGame != null)
            {
                PlayGame(this, e);
            }
        }
    }
    /// <summary>
    /// 委托
    /// </summary>
    /// <param name="sender">触发事件的源</param>
    /// <param name="e">同时携带的参数</param>
    public delegate void DelegateClassHandle(object sender, CustomEventnArgs e);
    /// <summary>
    /// 具体报告
    /// </summary>
    public class Reporter
    {
        public void Notify(object sender, CustomEventnArgs e)
        {
            Console.WriteLine("报告老板，{0}在{1}办公室玩游戏！", e.Name, ((Employee)sender).Number);
            //或者
            //Console.WriteLine("报告老板，{0}在{1}玩游戏！", e.Name, e.Number);
        }
    }
    public class CustomEventnArgs //: EventArgs
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public CustomEventnArgs()
        {

        }


    }
}
