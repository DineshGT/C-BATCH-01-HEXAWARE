create database Hexaware;

use Hexaware;

-- creating tables for Hexaware IT company
-- Tables are Clients, Employees, Departments, Projects, EmpProjectTasks


--clients table
create table Clients
(
	client_id INT PRIMARY KEY,
	client_name VARCHAR(40) not null, --no null values 
	client_addr VARCHAR(30),
	client_email VARCHAR(30) unique,
	client_phone NUMERIC(10),
	client_business VARCHAR(20) not null -- no null values

);


-- Departments table

Create table Departments
(
	dept_no NUMERIC(2) PRIMARY KEY,
	dept_name VARCHAR(20) not null, --no null here also
	dept_location VARCHAR(20)

);


--employees table

create table Employees
(
	emp_no INT PRIMARY KEY,
	emp_name VARCHAR(20) not null, --no null values 
	emp_job VARCHAR(15),
	emp_salary NUMERIC(7) check(emp_salary>0),
	dept_no NUMERIC(2),
	FOREIGN KEY (dept_no) REFERENCES Departments(dept_no) -- Here we cannot create table first for employees because it having foreign key as deptno 
	-- so first we need to create Departments table...

);


--projects table

create table Projects
(
	project_id NUMERIC(3) primary key,
	project_descr VARCHAR(30) not null,
	planned_start_date DATE,
	planned_end_date DATE, 
	actual_end_date DATE,
	project_budget NUMERIC(10) check(project_budget > 0),
	client_id INT,
	FOREIGN KEY (client_id) REFERENCES Clients(client_id),
	check (actual_end_date > planned_end_date)
);


-- emp project tasks

create table EmpProjectTasks
(
	project_id NUMERIC(3),
	emp_no INT,
	[start_date] Date,
	[end_date] Date, 
	task VARCHAR(25) not null,
	status VARCHAR(15) not null,
	Foreign key (project_id) references Projects(project_id),
	Foreign key (emp_no) references Employees(emp_no)
);


--Inserting values in created tables

INSERT INTO Clients (client_id, client_name, client_addr, client_email, client_phone, client_business) 
VALUES 
(1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', '9567880032', 'Manufacturing'),
(1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', '8734210090', 'Consultant'),
(1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', '7799886655', 'Reseller'),
(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', '9210342219', 'Professional');

INSERT INTO Employees (emp_no, emp_name, emp_job, emp_salary, dept_no) 
VALUES 
(7001, 'Sandeep', 'Analyst', 25000, 10),
(7002, 'Rajesh', 'Designer', 30000, 10),
(7003, 'Madhav', 'Developer', 40000, 20),
(7004, 'Manoj', 'Developer', 40000, 20),
(7005, 'Abhay', 'Designer', 35000, 10),
(7006, 'Uma', 'Tester', 30000, 30),
(7007, 'Gita', 'Tech. Writer', 30000, 40),
(7008, 'Priya', 'Tester', 35000, 30),
(7009, 'Nutan', 'Developer', 45000, 20),
(7010, 'Smita', 'Analyst', 20000, 10),
(7011, 'Anand', 'Project Mgr', 65000, 10);


INSERT INTO Departments (dept_no, dept_name, dept_location) 
VALUES 
(10, 'Design', 'Pune'),
(20, 'Development', 'Pune'),
(30, 'Testing', 'Mumbai'),
(40, 'Document', 'Mumbai');

INSERT INTO Projects (project_id, project_descr, planned_start_date, planned_end_date, actual_end_date, project_budget, client_id) 
VALUES 
(401, 'Inventory', '2011-04-01', '2011-10-01', '2011-10-31', 150000, 1001),
(402, 'Accounting', '2011-08-01', '2012-01-01', NULL, 500000, 1002),
(403, 'Payroll', '2011-10-01', '2011-12-31', NULL, 75000, 1003),
(404, 'Contact Mgmt', '2011-11-01', '2011-12-31', NULL, 50000, 1004);

INSERT INTO EmpProjectTasks(project_id, emp_no, start_date, end_date, task, status) 
VALUES 
(401, 7001, '2011-04-01', '2011-04-20', 'System Analysis', 'Completed'),
(401, 7002, '2011-04-21', '2011-05-30', 'System Design', 'Completed'),
(401, 7003, '2011-06-01', '2011-07-15', 'Coding', 'Completed'),
(401, 7004, '2011-07-18', '2011-09-01', 'Coding', 'Completed'),
(401, 7006, '2011-09-03', '2011-09-15', 'Testing', 'Completed'),
(401, 7009, '2011-09-18', '2011-10-05', 'Code Change', 'Completed'),
(401, 7008, '2011-10-06', '2011-10-16', 'Testing', 'Completed'),
(401, 7007, '2011-10-06', '2011-10-22', 'Documentation', 'Completed'),
(401, 7011, '2011-10-22', '2011-10-31', 'Sign off', 'Completed'),
(402, 7010, '2011-08-01', '2011-08-20', 'System Analysis', 'Completed'),
(402, 7002, '2011-08-22', '2011-09-30', 'System Design', 'Completed'),
(402, 7004, '2011-10-01', NULL, 'Coding', 'In Progress');


-- SELECT query execution for created tables
SELECT * FROM Clients;
SELECT * FROM Departments;
SELECT * FROM Employees;
SELECT * FROM Projects;
SELECT * FROM EmpProjectTasks;