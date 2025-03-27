Create database Assignment3;


use Assignment3;

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


Select * from Department;
Select * from Employee;

--1. Retrieve a list of MANAGERS. 

Select e1.emp_name, e2.manager_id
From Employee As e1
Join Employee As e2
on e1.emp_no = e2.manager_id
order by e1.emp_name;



-- 2. Find out the names and salaries of all employees earning more than 1000 per month. 

Select Employee.emp_name, Employee.emp_salary
From Employee
Where emp_salary > 1000;



-- 3. Display the names and salaries of all employees except JAMES. 

Select Employee.emp_name, Employee.emp_salary
From Employee
where Employee.emp_name != 'JAMES';


--4. Find out the details of employees whose names begin with ‘S’. 

Select * From Employee
Where Employee.emp_name like 'S%';


-- 5. Find out the names of all employees that have ‘A’ anywhere in their name. 

Select * From Employee
Where Employee.emp_name like '%A%';


-- 6. Find out the names of all employees that have ‘L’ as their third character in their name. 

Select * From Employee
Where Employee.emp_name like '__A%';



--7. Compute daily salary of JONES. 

Select Employee.emp_name, Employee.emp_salary/ DAY(EOMONTH(hired_date)) As Daily_Salary
From Employee
Where Employee.emp_name = 'JONES';
--here EOMONTH will give the last day of the month so this will be the count of days in tthat particular month..



--8. Calculate the total monthly salary of all employees. 

Select sum(Employee.emp_salary) AS Total_salary 
From Employee;


--9. Print the average annual salary . 


Select AVG(emp_salary * 12) As Average_annual_salary From Employee;


--10. Select the name, job, salary, department number of all employees except 
--SALESMAN from department number 30. 

Select Employee.emp_name, Employee.emp_job, Employee.emp_salary, Employee.dept_no 
From Employee
where Employee.emp_job != 'SALESMAN' AND Employee.dept_no = 30;



-- list the names, job, salary of all emp whose job is same as as and salary is less than any of emp whose job is salesman


Select Employee.emp_name, Employee.emp_job, Employee.emp_salary From Employee
where Employee.emp_salary < any(Select emp_salary From Employee where emp_job = 'SALESMAN');
