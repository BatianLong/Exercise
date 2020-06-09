using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序练习
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 冒泡排序
            //E_BubbleSort e_BubbleSort = new E_BubbleSort();
            //e_BubbleSort.PrintBubbleSort();
            #endregion
            #region 100~999之间的水仙花数
            //E_Daffodils e_Daffodils = new E_Daffodils();
            //e_Daffodils.PrintDaffodils();
            #endregion
            #region 取出数组中最大值和最小值
            E_ReturnMaxAndMin e_ReturnMaxAndMin = new E_ReturnMaxAndMin();
            e_ReturnMaxAndMin.PrintReturnMaxandMin();
            #endregion
        }

    }
}
