using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab0UsingList
{
    
    internal class Program
    {
        public static bool CheckIsPrime(int n)
        {
            int div = 2;
            while (div < n)
            {
                if (n % div == 0)
                {
                    return false;
                }
                else
                {
                    div++;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            //This lab is done using List
            Console.Write("Enter the low number: ");
            int lowNum = Convert.ToInt32(Console.ReadLine());
            while (lowNum < 0)
            {
                Console.WriteLine("Low number should be positive. Try again.");
                Console.Write("Enter the low number: ");
                lowNum = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Enter the high number: ");
            int highNum = Convert.ToInt32(Console.ReadLine());
            while (highNum < lowNum)
            {
                Console.WriteLine("High number should be greater than low number. Try again");
                Console.Write("Enter the high number: ");
                highNum = Convert.ToInt32(Console.ReadLine());
            }

            int difference = highNum - lowNum;
            Console.WriteLine($"The difference between {highNum} and {lowNum} is {difference}");
            Console.WriteLine();

            List<int> numList = new List<int>();
            int lowEnd = lowNum + 1;
            while (lowEnd < highNum)
            {
                numList.Add(lowEnd);
                lowEnd++;
            }

            Console.WriteLine("Array members of the numList are: ");
            foreach (int number in numList)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();
            
            using (StreamWriter numWriter = new StreamWriter("numbers.txt"))
            {
                for (int j = numList.Count - 1; j >= 0; j--)
                {
                    numWriter.WriteLine(numList[j]);
                }
            }
                

            Console.WriteLine("The numbers in the file are as follows: ");

            int sum = 0;
            using (StreamReader numReader = new StreamReader("numbers.txt"))
            {
                string line;
                while ((line = numReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    if (int.TryParse(line, out int number))
                    {
                        sum += number;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine($"The sum of the numbers in the file is {sum}");

            Console.WriteLine();
            Console.WriteLine("Prime members of the numList are: ");
            bool isPrime;
            foreach (int number in numList)
            {
                isPrime = CheckIsPrime(number);
                if (isPrime == true)
                {
                    Console.WriteLine(number);
                }
            }




            Console.ReadLine();
        }
    }
}
