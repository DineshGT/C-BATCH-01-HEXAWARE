Create database Assignment4;


use Assignment4;

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

--1. List unique departments of the EMP table. 

Select Distinct Employee.dept_no From Employee;


--2. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. 
--Label the columns Employee and Monthly Salary respectively.

Select Employee.emp_name As Employee, Employee.emp_salary As Monthly_salary From Employee
where Employee.emp_salary > 1500 AND Employee.dept_no in (10, 30);



--3. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000. 

Select Employee.emp_name, Employee.emp_job, Employee.emp_salary
From Employee
Where Employee.emp_job in ('MANAGER', 'ANALYST') And Employee.emp_salary not in(1000, 3000, 5000);

--4. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 

Select Employee.emp_name, Employee.emp_salary, Employee.emp_comm
From Employee
Where Employee.emp_comm > (Select (emp_salary + emp_salary*0.10) From Employee);


--5. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782.

Select Employee.emp_name, dept_no, manager_id From Employee
Where (emp_name like '%L%L%' and dept_no = 30) or manager_id = 7782;

--6. Display the names of employees with experience of over 30 years and under 40 yrs.
--Count the total number of employees. 

Select Employee.emp_name From Employee



--7. Retrieve the names of departments in ascending order and their employees in 
--descending order. 

Select Department.dept_name, Employee.emp_name
From Department 
Join Employee On Department.dept_no = Employee.dept_no
order by Department.dept_name DESC, Employee.emp_name ASC;


--8. Find out experience of MILLER. 

Select Employee.emp_name, 
       DATEDIFF(YEAR, hired_date, GETDATE()) AS Experience 
From Employee
Where emp_name = 'MILLER';

--9. Write a query to display all employee information where ename contains 5 or more characters

Select * From Employee 
where LEN(Employee.emp_name)>=5;

--10. Copy empno, ename of all employees from emp table who work for dept 10 into a new table called emp10

Create table emp10 (
    emp_no INT PRIMARY KEY,
    emp_name VARCHAR(50)
);

Insert into emp10 (emp_no, emp_name)
Select emp_no, emp_name 
From Employee 
Where dept_no = 10;

Select * From emp10;