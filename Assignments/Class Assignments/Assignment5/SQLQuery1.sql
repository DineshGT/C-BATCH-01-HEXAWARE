Create database Assignment5;


use Assignment5;

-- 18/03/2025 assignment 03 with the same table for assignment2


Create table Department
(
	dept_no INT PRIMARY KEY,
	dept_name VARCHAR(30) not null,
	dept_loc VARCHAR(50)
);

Create table Employee
(
	emp_no int PRIMARY KEY,
	emp_name VARCHAR(30) not null,
	emp_job VARCHAR(20),
	manager_id int,
	hired_date DATE,
	emp_salary NUMERIC(8),
	emp_comm NUMERIC(10), 
	dept_no INT,
	FOREIGN KEY (dept_no) references Department(dept_no)
);

insert into Department
(dept_no, dept_name, dept_loc)
values
(10, 'Accounting', 'NEW YORK'),
(20, 'Research', 'DALLAS'),
(30, 'Sales', 'CHICAGO'),
(40, 'Operations', 'BOSTON');


insert into Employee
(emp_no, emp_name, emp_job, manager_id, hired_date, emp_salary, emp_comm, dept_no)
Values
(7369, 'SMITH', 'CLERK', 7902, '17-DEC-80', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '20-FEB-81', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-SEP-81', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '19-APR-87', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '08-SEP-81', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '03-DEC-81', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10);


--1. Write a SQL query to find those employees who receive a higher salary than the employee with ID 7566. 
--Return their names

Select Employee.emp_name, emp_salary From Employee
Where Employee.emp_salary > (Select emp_salary From Employee Where emp_no = 7566);


--2. Write a SQL query to find out which employees have the same designation as the employee whose ID is 7876. 
--Return name, department no and job .

Select Employee.emp_name, dept_no, emp_job From Employee
Where Employee.emp_job = (Select emp_job From Employee Where emp_no = 7876);

--3. Write a SQL query to find those employees who report to that manager whose name starts with a 'B' or 'C'. 
--Return first name, employee ID and salary

Select emp_name, emp_no, emp_salary From Employee
Where Employee.manager_id in (Select emp_no From Employee Where emp_name Like '[BC]%')



4. Use Northwid database to solve :

   --a) Find products that are more expensive than the average price of products in their own category. 
   --Include the category name, product name, and unit price in the result.

   Select Top 10 CategoryName, ProductName, UnitPrice
From Products
Join Categories ON Products.CategoryID = Categories.CategoryID
Where Products.UnitPrice > (
    Select avg(p2.UnitPrice) From Products p2 Where p2.CategoryID = Products.CategoryID);
);

   --b) For each category, display its name, the number of discontinued products in this category (discontinued),
   --and the number of all products in this category 

   