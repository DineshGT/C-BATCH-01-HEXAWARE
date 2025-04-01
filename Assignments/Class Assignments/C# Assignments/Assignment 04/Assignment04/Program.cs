using System;
using System.Diagnostics.CodeAnalysis;

namespace assi4
{
    public class assi4
    {
        public static void reverse(string input)
        {
            char[] char_arr = input.ToCharArray(); 
            Array.Reverse(char_arr);
            Console.WriteLine(new string(char_arr));
        }
        public static void stringfunc()
        {
            //1.Write a program in C# to accept a word from the user and display the length of it.

            Console.Write("Enter a word: ");
            string ? s1 = Console.ReadLine();

            Console.WriteLine($"Length of the word {s1} is {s1.Length}");


            //2.Write a program in C# to accept a word from the user and display the reverse of it. 

            Console.Write("Enter a word: ");
            string ? s2 = Console.ReadLine();

            reverse(s2);
            


            //3.Write a program in C# to accept two words from user and find out if they are same. 

            Console.WriteLine("Enter Two words: ");
            string? s3 = Console.ReadLine();
            string? s4 = Console.ReadLine();

            if (s3 == s4) Console.WriteLine("Two words are same!");
            else Console.WriteLine("Two words are not same!");


        }

        //Inheritance

        //student class
        public class Student
        {
            //fields..
            private string ? std_name { get; set; }
            private int rollno { get; set; }
            private string ? std_class { get; set; }
            private string ? std_sem { get; set; }
            private string ? std_branch { get; set; }
            protected int[] marks = new int[5];

            //Parameterized constructor

            public Student(string name, int rollno, string stdclass, string sem, string branch)
            {
                std_name = name;
                this.rollno = rollno;
                std_class = stdclass;
                std_sem = sem;
                std_branch = branch;
            }

            public void GetMarks()
            {
                for(int i=0;i<5;i++)
                {
                    Console.Write($"Enter mark {i + 1}: ");
                    int mark = Convert.ToInt32(Console.ReadLine());
                    marks[i] = mark;
                }
            }

            public int calavg()
            {
                int sum = 0;
                for(int i=0;i<5;i++)
                {
                    sum += marks[i];
                }
                Console.WriteLine($"Average mark is: {sum / 5}");

                return sum / 5;

            }

            public void DisplayData()
            {
                Console.WriteLine($"\nStudent Details:");
                Console.WriteLine($"Name: {std_name}");
                Console.WriteLine($"Roll No: {rollno}");
                Console.WriteLine($"Class: {std_class}");
                Console.WriteLine($"Semester: {std_sem}");
                Console.WriteLine($"Branch: {std_branch}");
                Console.WriteLine($"Marks: {string.Join(", ", marks)}");
            }

        }

        public class Resultcheck : Student
        {
            //like default constructor..
            public Resultcheck(string name, int rollno, string stdclass, string sem, string branch)
        : base(name, rollno, stdclass, sem, branch) { }

            bool result = false;
            bool sum = true;
            public bool DisplayResult()
            {
                for(int i=0;i<marks.Length;i++)
                {
                    if (marks[i] < 35)
                    {
                        result = false;
                        sum = false;
                        return result;
                    }
                }

                if(sum == true)
                {
                    if (calavg() > 50)
                    {
                        return true;
                    }
                    else return false;
                }
                return true;
                
            }


        }

        public static void Main(string[] args)
        {
            stringfunc();
            Resultcheck student1 = new Resultcheck("John Doe", 101, "10th", "2nd", "Science");
            student1.GetMarks();
            student1.DisplayData();
            student1.DisplayResult();
        }


    }
}
