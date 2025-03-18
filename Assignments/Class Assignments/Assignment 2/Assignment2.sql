Create Database Assignment2;

Use Assignment2;

-- creating tables


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


-- Inserting values

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


-- Tasks..

-- 1. List all employees whose name begins with 'A'. 

Select * from Employee where Employee.emp_name LIKE 'A%';


  -- 2.  Select all those employees who don't have a manager.

Select * from Employee where Employee.manager_id is null;

-- List employee name, number and salary for those employees who earn in the range 1200 to 1400.

Select Employee.emp_name, Employee.emp_no, Employee.emp_salary From Employee
where Employee.emp_salary Between 1200 AND 1400;


-- 4. Give all the employees in the RESEARCH department a 10% pay rise. 
--Verify that this has been done by listing all their details before and after the rise. 

Select *
From Employee e
JOIN Department d ON e.dept_no = d.dept_no
Where d.dept_name = 'RESEARCH';

--Update Employee
--set emp_salary = emp_salary + emp_salary* 0.10
--Where dept_no = (Select dept_no From Department Where dept_name = 'RESEARCH');


Select *, (emp.emp_salary+ emp.emp_salary * 0.10) As Updated_salary
From Employee emp  
Inner Join Department dept ON emp.dept_no = dept.dept_no  
Where dept.dept_name = 'RESEARCH';


--5. Find the number of CLERKS employed. Give it a descriptive heading. 

Select count(*) AS NumberOfClerks From Employee 
Where emp_job = 'CLERK';


-- 6. Find the average salary for each job type and the number of people employed in each job. 

Select Employee.emp_job, Count(Employee.emp_job) AS People_Employed, AVG(Employee.emp_salary) As Average_salary
From Employee
Group by Employee.emp_job;


-- 7. List the employees with the lowest and highest salary. 

Select min(emp_salary) AS Minumum_salary, max(emp_salary) AS Maximum_salary
From Employee;

--8. List full details of departments that don't have any employees.

Select * from Department
Left Join
Employee on
Department.dept_no = Employee.dept_no
where Employee.dept_no not in (Department.dept_no);


-- 9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. 
--Sort the answer by ascending order of name. 

Select Employee.emp_name, Employee.emp_salary
From Employee
where Employee.emp_job = 'ANALYST' AND Employee.dept_no = 20
order by Employee.emp_name ASC;


-- 10. For each department, list its name and number together with the total salary paid to employees 
--in that department. 

Select Department.dept_name, Department.dept_no, sum(emp_salary) AS Total_salary
From Department
Left join Employee
on Department.dept_no = Employee.dept_no
Group by Department.dept_name, Department.dept_no;


--11. Find out salary of both MILLER and SMITH.

Select Employee.emp_name, Employee.emp_salary From Employee
Where Employee.emp_name = 'MILLER' OR Employee.emp_name = 'SMITH';


--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. 

Select Employee.emp_name FRom Employee where emp_name Like '[AM]%';


--13. Compute yearly salary of SMITH. 

Select emp_salary + emp_comm AS YearlySalary
From Employee
Where Employee.emp_name = 'SMITH';


--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850.

Select Employee.emp_name, Employee.emp_salary From Employee
where Employee.emp_salary not between 1500 AND 2850;


--15. Find all managers who have more than 2 employees reporting to them

Select Employee.manager_id, count(Employee.emp_no) AS No_of_emp
From Employee
Group by manager_id 
Having count(emp_no) > 2;





