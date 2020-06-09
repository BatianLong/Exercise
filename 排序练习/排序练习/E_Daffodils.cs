using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace 排序练习
{

    public class E_Daffodils
    {
        public bool Daffodils(int arr){
            int hundreds = arr / 100;//获取百位数
            int ten = arr / 10 % 10;//获取十位数
            int single = arr % 10;//获取个位数
            int n = (hundreds * hundreds * hundreds) +
                (ten * ten * ten) +
                (single * single * single);
            if (arr==n)
            {
                return true;
            }
            return false;
        }
        public void PrintDaffodils() {
            for (int i = 100; i < 999; i++)
            {
                bool flag = Daffodils(i);
                if (flag)
                {
                    Console.WriteLine($"Daffodls{i}");
                }
            }
            Console.ReadKey();
        }
    }
}