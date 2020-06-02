using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序练习
{
    public class E_BubbleSort
    {/// <summary>
     /// 冒泡排序
     /// </summary>
     /// <param name="arr"></param>
     /// <returns></returns>
        public static int[] BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
        public void PrintBubbleSort()
        {
            int[] numbers = { 2, 5, -7, 9, 3, 2, 1, -3, 0, 2 };
            int[] result = BubbleSort(numbers);
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write("{0} ", result[i]);
            }
            Console.ReadKey();
        }
    }
}
