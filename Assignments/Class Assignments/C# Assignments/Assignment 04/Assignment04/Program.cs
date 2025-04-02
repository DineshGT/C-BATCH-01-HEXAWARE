using System;
using System.Diagnostics.CodeAnalysis;
using static assi4.assi4;

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


        // Interface..

        interface Istudent
        {
            //fields
            int std_id { get; set; }
            string? std_name { get; set; }
            decimal? std_fees { get; set; }

            void ShowDetails();


        }

        public class Dayscholar : Istudent
        {
            public int std_id { get; set; }
            public string? std_name { get; set; }
            public decimal? std_fees { get; set; }

            public Dayscholar(int std_id, string? std_name, decimal? std_fees)
            {
                this.std_id = std_id;
                this.std_name = std_name;
                this.std_fees = std_fees;
            }

            public void ShowDetails()
            {
                Console.WriteLine("Dayscholar Details:");
                Console.WriteLine($"ID: {std_id}, Name: {std_name}, Fees: {std_fees}\n");
            }



        }

        public class Resident : Istudent
        {
            public int std_id { get; set; }
            public string? std_name { get; set; }
            public decimal? std_fees { get; set; }

            public Resident(int std_id, string? std_name, decimal? std_fees)
            {
                this.std_id = std_id;
                this.std_name = std_name;
                this.std_fees = std_fees;
            }

            public void ShowDetails()
            {
                Console.WriteLine("Resident Details:");
                Console.WriteLine($"ID: {std_id}, Name: {std_name}, Fees: {std_fees}\n");
            }
        }



        public static void Main(string[] args)
        {
            stringfunc();
            Resultcheck std1 = new Resultcheck("John Doe", 101, "10th", "2nd", "Science");
            std1.GetMarks();
            std1.DisplayData();
            std1.DisplayResult();

            //interface

            Istudent student1 = new Dayscholar(101, "John Doe", 5000.50m);
            Istudent student2 = new Resident(102, "Jane Smith", 7500.75m);

            student1.ShowDetails();
            student2.ShowDetails();
        }


    }
}
