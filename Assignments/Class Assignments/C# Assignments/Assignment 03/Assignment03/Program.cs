using System;

namespace assignment3
{
    public class assignment3
    {

        public class Employee
        {
            //fields
            protected int Emp_id { get; set; }
            protected string? Emp_name { get; set; }
            protected DateOnly Emp_DOB { get; set; }
            protected double Emp_salary { get; set; }

            //parameterized constructor
            public Employee(int Emp_id, string Emp_name, DateOnly Emp_DOB, double Emp_salary)
            {
                this.Emp_id = Emp_id;
                this.Emp_name = Emp_name;
                this.Emp_DOB = Emp_DOB;
                this.Emp_salary = Emp_salary;
            }

            public virtual double calculate_salary()
            {
                return Emp_salary;
            }
            
        }

        public class Manager : Employee
        {
            //fields
            double onsite_allowance { get; set; }
            double bonus { get; set; }

            public Manager(int Emp_id, string Emp_name, DateOnly Emp_DOB, double Emp_salary, double onsite_allowance, double bonus) : base(Emp_id, Emp_name, Emp_DOB, Emp_salary)
            {
                this.onsite_allowance = onsite_allowance;
                this.bonus = bonus;
            }

            public override double calculate_salary()
            {
                return Emp_salary + onsite_allowance + bonus;
            }

        }

        //Assignment 2 static keyword...
        public class statickeyword
        {

            private static int callCount = 0;


            public static void Count_function()
            {
                callCount++;
                Console.WriteLine($"Count_function called {callCount} times.");
            }



        }


        public static void Main(string[] args)
        {
            Employee emp1 = new Employee(100, "Dinesh", new DateOnly(2004, 3, 7), 10000.00);
            emp1.calculate_salary();

            Manager m1 = new Manager(100, "Dinesh", new DateOnly(2004, 3, 7), 10000.00, 5000, 5000);
            m1.calculate_salary();

        }
    }
}
