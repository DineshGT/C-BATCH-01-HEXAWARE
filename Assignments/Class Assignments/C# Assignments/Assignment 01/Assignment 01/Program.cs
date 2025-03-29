using System;
using System.ComponentModel.Design;
using System.Runtime.ExceptionServices;

namespace Assignment01
{
    public class Program
    {
        public static void Main()
        {

            // Number equal or not

            //int num1 = Convert.ToInt32(Console.ReadLine());
            //int num2 = Convert.ToInt32(Console.ReadLine());

            //if (num1 == num2)
            //{
            //    Console.WriteLine("{0} and {1} are equal", num1, num2);
            //}
            //else
            //{
            //    Console.WriteLine("{0} and {1} are not equal", num1, num2);
            //}


            // Positive or negative


            //int num = Convert.ToInt32(Console.ReadLine());

            //if(num > 0)
            //{
            //    Console.WriteLine("{0} is a postitve number.", num);

            //}
            //else
            //{
            //    Console.WriteLine("{0} is a Negative number.", num);

            //}



            // + - * / Operations

            //int first_number, second_number;
            //string op;

            //Console.WriteLine("Enter first Number: ");
            //first_number = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter Second Number: ");
            //second_number = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter Operator: ");
            //op = Console.ReadLine();

            //if(op == "+")
            //{
            //    Console.WriteLine("{0} + {1} = {2}", first_number, second_number, first_number + second_number);
            //}
            //else if(op == "-")
            //{
            //    Console.WriteLine("{0} - {1} = {2}", first_number, second_number, first_number - second_number);

            //}
            //else if(op == "*")
            //{
            //    Console.WriteLine("{0} * {1} = {2}", first_number, second_number, first_number * second_number);

            //}
            //else if(op == "/")
            //{
            //    Console.WriteLine("{0} / {1} = {2}", first_number, second_number, first_number / second_number);

            //}
            //else
            //{
            //    Console.WriteLine("Invalid Input");
            //}

            // Multiplication table 
            //Console.WriteLine("Enter a Number to display Multiplication Table: ");
            //int num = Convert.ToInt32(Console.ReadLine());

            //for(int i=1;i<=10;i++)
            //{
            //    Console.WriteLine("{0} x {1} = {2}",num, i, num * i);
            //}

            //5th one

            //Console.WriteLine("Enter first_number:");
            //int num1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter second_number:");
            //int num2 = Convert.ToInt32(Console.ReadLine());

            //if (num1 == num2)
            //{
            //    Console.WriteLine("Tiple of their sum is {0}",3*(num1 + num2));
            //}



            // Jagged array (array of arrays)

            //int[][] jagged_array = new int[3][];

            // each row intialization in compile time

            //jagged_array[0] = new int[] { 1, 2, 3 };
            //jagged_array[1] = new int[] { 4, 5 };
            //jagged_array[2] = new int[] { 6, 7, 8, 9};


            //for(int i=0;i<jagged_array.Length;i++)
            //{
            //    for(int j = 0; j < jagged_array[i].Length;j++)
            //    {
            //        Console.Write(jagged_array[i][j]);
            //    }
            //    Console.Write("\n");
            //}


            // Getting inputs in run time using loops
            int n;
            Console.Write("Enter number of rows: ");
            n = Convert.ToInt32(Console.ReadLine());

            int[][] jaggedArray = new int[n][];

            for(int i=0;i<n;i++)
            {
                Console.Write("Enter col value: ");
                int cols = Convert.ToInt32(Console.ReadLine());

                jaggedArray[i] = new int[cols];

                for(int j=0;j<cols;j++)
                {
                    jaggedArray[i][j] = Convert.ToInt32(Console.ReadLine());
                }

            }


            // Displaying output


            for(int i=0;i<jaggedArray.Length;i++)
            {
                for(int j = 0; j < jaggedArray[i].Length;j++)
                {
                    Console.Write(jaggedArray[i][j]);
                }
                Console.WriteLine();
            }




        }
    }
}
