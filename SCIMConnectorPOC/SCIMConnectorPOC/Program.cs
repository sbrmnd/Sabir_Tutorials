using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCIMConnectorPOC
{
    class Program
    {
        static private int SumOftriplets(int size, int[] array)
        {
            
            List<int> list = new List<int>(array);
            Array.Sort(array);
           
            int count = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = i+1; j < size; j++)
                {
                    int sum = array[i] + array[j];
                    if (list.Contains(sum))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        static private void FetchInput()
        {
            List<int> result = new List<int>();
            int T = Convert.ToInt16(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int N = Convert.ToInt16(Console.ReadLine());
                var ints = Console
                                .ReadLine()
                                .Split()
                                .Select(int.Parse);

                int sum = SumOftriplets(N, ints.ToArray());
                if (sum != 0)
                {
                    result.Add(sum);
                }
                else
                {
                    result.Add(-1);
                }
            }
            foreach (var val in result)
            {
                Console.WriteLine(val);
            }
        }

        static void Main(string[] args)
        {
            SaleForeSCIM scim = new SaleForeSCIM();

        }
    }
}
