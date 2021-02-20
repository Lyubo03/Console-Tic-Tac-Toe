using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_project
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 1;
            int firstNum = 0;
            int sumOfPrevious = 0;
            for (int i = 0; i < n; i++)
            {
                firstNum = sum;
                sum = firstNum + sumOfPrevious;
                sumOfPrevious = firstNum;
            }
            Console.WriteLine(sum);
        }
    }
}
