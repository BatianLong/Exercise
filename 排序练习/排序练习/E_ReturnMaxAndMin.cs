using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序练习
{
    public class E_ReturnMaxAndMin
    {
        public int[] ReturnMaxAndMin(int[] arr) {
            int[] result = {arr[0],arr[0] };
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]>result[0])
                {
                    result[0] = arr[i];
                }
                else if(arr[i]<result[1])
                {
                    result[1] = arr[i];
                }
            }
            return result;
        }
        public void PrintReturnMaxandMin() {
            int[] arrary = { 1, 2, 4, 6, 7, 8, -1, 2, -4 };
            int[] numbers = ReturnMaxAndMin(arrary);
            Console.WriteLine("Max number: {0}, Min number: {1}", numbers[0], numbers[1]);
            Console.ReadKey();
        }
    }
}
