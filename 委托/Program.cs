using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Num { get; set; }
    }
    class Program
    {
        //比较年龄
        public static bool Younger(Student s1, Student s2) => s1.Age <= s2.Age;
        public static void aa() {
            Console.WriteLine("哈哈哈哈哈哈哈哈哈");
        }
        //比较学号
        public static bool NumSmaller(Student s1, Student s2) => s1.Num <= s2.Num;
        public delegate void cwaa();
        public static event cwaa Show;
        public delegate bool CompareDelegate(Student first, Student second);
        public delegate void DelChange(string[] names);
        /// <summary>
        /// 含委托参数的改变字符串的总方法，包含委托参数，需要先定义一个委托类型，返回值及参数需要和前面方法一致；
        /// </summary>
        /// <param name="names"></param>
        /// <param name="del"></param>
        static void Change(string[] names, DelChange del)
        {
            del(names);
        }


        static void Main(string[] args)
        {
            #region 委托练习1
            //Student s1 = new Student() { Name = "小红", Age = 10, Num = 1001 };
            //Student s2 = new Student() { Name = "小华", Age = 9, Num = 1002 };
            //List<Student> sList = new List<Student>();
            //sList.Add(s1);
            //sList.Add(s2);
            ////以下两种方法等价
            ////CompareDelegate myCompareDelegate = new CompareDelegate(Younger);
            //CompareDelegate myCompareDelegate = Younger;//委托推断
            //                                            //委托的实例化与使用
            //                                            //CompareDelegate myCompareDelegate = NumSmaller;//采用比较学号的方法
            //                                            //SortStudent(sList, myCompareDelegate);

            //cwaa cwaa = new cwaa(aa);
            //Show += new cwaa(aa);
            //Show += new cwaa(aa);
            ////使用委托推断，与上两行等价
            //SortStudent(sList, NumSmaller);
            //SortStudent(sList, myCompareDelegate);
            ////泛型委托
            //Func<Student, Student, bool> myCompareFunc = NumSmaller;
            //SortStudent2(sList, myCompareFunc);
            ////匿名委托
            //Console.WriteLine("匿名委托");
            //CompareDelegate anonymousCompare = delegate (Student s3, Student s4)
            //{
            //    return s1.Num <= s2.Num;
            //};
            //SortStudent(sList, anonymousCompare);
            #endregion
            #region 委托练习2
            //string[] names = { "dfsSDF", "dfsFDSFE", "DFSDdsf" };
            //Change(names, ProToLower);
            //foreach (var item in names)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region 委托练习3

            #endregion
            Console.ReadLine();
        }
        /// <summary>
        /// 将所有元素转换成大写
        /// </summary>
        /// <param name="names"></param>
        static void ProToUpper(string[] names)
        {
            for (int i = 0; i < names.Length;   i++)
            {
                names[i] = names[i].ToUpper();
            }
        }
        /// <summary>
        /// 将所有元素转换成小写
        /// </summary>
        /// <param name="names"></param>
        static void ProToLower(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].ToLower();
            }
        }
        /// <summary>
        /// 将所有元素两边加上一个引号
        /// </summary>
        /// <param name="names"></param>
        static void ProAddQuo(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = "\"" + names[i] + "\"";
            }
        }

        public static void SortStudent2(List<Student> sList, Func<Student, Student, bool> CompareMethod)
        {
            if (CompareMethod(sList[0], sList[1]))
            {
            }
            else
            {
                sList.Reverse();
            }
            Console.WriteLine($"\r\n按照 {CompareMethod.Method.Name} 排名：");
            foreach (Student s in sList)
                Console.WriteLine($"{s.Name} {s.Age} {s.Num} ");
        }
        
        ///使用委托的业务方法
        public static void SortStudent(List<Student> sList, CompareDelegate CompareMethod)
        {
            if (CompareMethod(sList[0], sList[1]))//等价于CompareMethod.Invoke(sList[0],  List[1])
            {
                //sList[0]已经在sList[1]前面了，所以什么也不用做
            }
            else
            {
                sList.Reverse();//交换位置
            }
            //获取排名采用的比较方法的名称
            Console.WriteLine($"\r\n按照 {CompareMethod.Method.Name} 排名：");
            //打印排序后的链表
            foreach (Student s in sList)
                Console.WriteLine($"{s.Name} {s.Age} {s.Num} ");
        }
    }
}
