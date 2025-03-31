using System;

namespace assignment2
{
    public class assignment2
    {
        public static void swapfunc()
        {
            Console.Write("Enter num1: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter num2: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Before Swapping");
            Console.WriteLine($"num1: {num1} num2: {num2}");
            //swapping 
            int temp = num1;
            num1 = num2;
            num2 = temp;
            Console.WriteLine("After Swapping");
            Console.WriteLine($"num1: {num1} num2: {num2}");
        }

        public void patternprintfunc()
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());


            for(int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    if(i%2 ==0)
                    {
                        Console.Write(num + " ");
                    }
                    else
                    {
                        Console.Write(num);
                    }
                }
                Console.WriteLine();
            }

        }

        public static void numtoday()
        {
            Console.Write("Enter day number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            switch(number)
            {
                case 1:
                    Console.WriteLine("Sunday");
                    break;
                case 2:
                    Console.WriteLine("Monday");
                    break;
                case 3:
                    Console.WriteLine("Tuesday");
                    break;
                case 4:
                    Console.WriteLine("Wednesday");
                    break;
                case 5:
                    Console.WriteLine("Thursday");
                    break;
                case 6:
                    Console.WriteLine("Friday");
                    break;
                case 7:
                    Console.WriteLine("Saturday");
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }

        public static void arrayprobfunc()
        {
            int[] numbers = { 10, 25, 7, 90, 15, 30 };

            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            double average = (double)sum / numbers.Length;

            int min = numbers[0];
            int max = numbers[0];

            foreach (int num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
                if (num > max)
                {
                    max = num;
                }
            }

            Console.WriteLine($"Average Value: {average}");
            Console.WriteLine($"Minimum Value: {min}");
            Console.WriteLine($"Maximum Value: {max}");
        }

        public static void arrayprob2()
        {
            int[] marks = new int[10];
            Console.WriteLine("Enter 10 marks:");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"Mark {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
            }

            int total = marks.Sum();
            Console.WriteLine($"Total Marks: {total}");

            double average = (double)total / marks.Length;
            Console.WriteLine($"Average Marks: {average}");

            int min = marks.Min();
            Console.WriteLine($"Minimum Marks: {min}");

            int max = marks.Max();
            Console.WriteLine($"Maximum Marks: {max}");

            int[] ascending = marks.OrderBy(x => x).ToArray();
            Console.WriteLine("Marks in Ascending Order: " + string.Join(", ", ascending));

            int[] descending = marks.OrderByDescending(x => x).ToArray();
            Console.WriteLine("Marks in Descending Order: " + string.Join(", ", descending));


        }

        public static void arrcopy()
        {
            int[] originalarr = new int[10];
            int[] copiedarr = new int[10];

            Console.WriteLine("Enter 10 numbers:");
            for (int i = 0; i < 10; i++)
            {
                originalarr[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < originalarr.Length; i++)
            {
                copiedarr[i] = originalarr[i];
            }

            Console.WriteLine("Original Array: " + string.Join(", ", originalarr));
            Console.WriteLine("Copied Array: " + string.Join(", ", copiedarr));
        }

        public static void Main(string[] args)
        {

            //swapfunc();
            //assignment2 ass2 = new assignment2();
            //ass2.patternprintfunc();
            //numtoday();
            //arrayprobfunc();
            //arrcopy();



        }
    }
}
