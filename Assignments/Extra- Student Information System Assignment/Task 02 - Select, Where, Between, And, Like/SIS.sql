-- Task 02: Creating Database..

Create Database SISDB;
Use SISDB;


-- Creating database

CREATE TABLE Students (
    std_id INT PRIMARY KEY,
    first_name VARCHAR(30) not null,
    last_name VARCHAR(30),
    std_dob DATE,
    std_email VARCHAR(50) UNIQUE,
    std_phone NUMERIC(10) UNIQUE
);

CREATE TABLE Teacher (
    teacher_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    email VARCHAR(100) UNIQUE
);

CREATE TABLE Courses (
    course_id INT PRIMARY KEY,
    course_name VARCHAR(100),
    credits INT,
    teacher_id INT,
    FOREIGN KEY (teacher_id) REFERENCES Teacher(teacher_id)
);

CREATE TABLE Enrollments (
    enrollment_id INT PRIMARY KEY,
    std_id INT,
    course_id INT,
    enrollment_date DATE,
    FOREIGN KEY (std_id) REFERENCES Students(std_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id)
);

CREATE TABLE Payments (
    payment_id INT PRIMARY KEY,
    std_id INT,
    amount DECIMAL(10,2),
    payment_date DATE,
    FOREIGN KEY (std_id) REFERENCES Students(std_id)
);

 

INSERT INTO Students (std_id, first_name, last_name, std_dob, std_email, std_phnone) VALUES
(1, 'John', 'Doe', '2000-05-14', 'john.doe@gmail.com', '9876543210'),
(2, 'Emma', 'Smith', '1999-08-21', 'emma.smith@gmail.com', '9876543211'),
(3, 'Liam', 'Brown', '2001-02-10', 'liam.brown@gmail.com', '9876543212'),
(4, 'Olivia', 'Davis', '1998-11-30', 'olivia.davis@gmail.com', '9876543213'),
(5, 'Noah', 'Wilson', '2002-07-05', 'noah.wilson@gmail.com', '9876543214'),
(6, 'Ava', 'Taylor', '2000-03-18', 'ava.taylor@gmail.com', '9876543215'),
(7, 'Sophia', 'Anderson', '1997-12-22', 'sophia.anderson@gmail.com', '9876543216'),
(8, 'Mason', 'Thomas', '2003-06-15', 'mason.thomas@gmail.com', '9876543217'),
(9, 'Isabella', 'Jackson', '2001-09-08', 'isabella.jackson@gmail.com', '9876543218'),
(10, 'Lucas', 'White', '1999-04-27', 'lucas.white@gmail.com', '9876543219');


INSERT INTO Teacher (teacher_id, first_name, last_name, email) VALUES
(1, 'Robert', 'Johnson', 'robert.johnson@gmail.com'),
(2, 'Emily', 'Martinez', 'emily.martinez@gmail.com'),
(3, 'Michael', 'Harris', 'michael.harris@gmail.com'),
(4, 'Sarah', 'Clark', 'sarah.clark@gmail.com'),
(5, 'James', 'Lewis', 'james.lewis@gmail.com'),
(6, 'Mary', 'Walker', 'mary.walker@gmail.com'),
(7, 'William', 'Hall', 'william.hall@gmail.com'),
(8, 'Jessica', 'Allen', 'jessica.allen@gmail.com'),
(9, 'David', 'Young', 'david.young@gmail.com'),
(10, 'Jennifer', 'King', 'jennifer.king@gmail.com');


INSERT INTO Courses (course_id, course_name, credits, teacher_id) VALUES
(100, 'Mathematics', 3, 1),
(200, 'Physics', 4, 2),
(300, 'Chemistry', 3, 3),
(400, 'Biology', 4, 4),
(500, 'Computer Science', 5, 5),
(600, 'History', 3, 6),
(700, 'Geography', 3, 7),
(800, 'Economics', 4, 8),
(900, 'Political Science', 3, 9),
(1000, 'English Literature', 4, 10);


INSERT INTO Enrollments (enrollment_id, std_id, course_id, enrollment_date) VALUES
(1, 1, 100, '2024-01-15'),
(2, 2, 200, '2024-02-10'),
(3, 3, 300, '2024-03-05'),
(4, 4, 400, '2024-04-20'),
(5, 5, 500, '2024-05-12'),
(6, 6, 600, '2024-06-25'),
(7, 7, 700, '2024-07-30'),
(8, 8, 800, '2024-08-18'),
(9, 9, 900, '2024-09-22'),
(10, 10, 1000, '2024-10-10');


INSERT INTO Payments (payment_id, std_id, amount, payment_date) VALUES
(1, 1, 500.00, '2024-01-20'),
(2, 2, 600.00, '2024-02-15'),
(3, 3, 550.00, '2024-03-10'),
(4, 4, 700.00, '2024-04-25'),
(5, 5, 450.00, '2024-05-18'),
(6, 6, 500.00, '2024-06-30'),
(7, 7, 650.00, '2024-07-20'),
(8, 8, 480.00, '2024-08-22'),
(9, 9, 520.00, '2024-09-28'),
(10, 10, 600.00, '2024-10-15');


Select * From Students;
Select * From Teacher;
Select * From Courses;
Select * From Enrollments;
Select * From Payments;




-- Task 02 : Select, Where, Between, And, Like


--1. Write an SQL query to insert a new student into the "Students" table with the following details: 
     --a. First Name: John b. Last Name: Doe c. Date of Birth: 1995-08-15 d. Email: john.doe@example.com 
     --e. Phone Number: 1234567890 


Insert into Students
(std_id, first_name, last_name, std_dob, std_email, std_phnone) 
Values
(11, 'John', 'Doe', '1995-08-15', 'john.doe@example.com', 1234567890);



--2. Write an SQL query to enroll a student in a course. Choose an existing student and course and 
--insert a record into the "Enrollments" table with the enrollment date. 


Insert into Enrollments
(enrollment_id, std_id, course_id, enrollment_date) 
Values
(11, 1, 200, '2025-03-20');



--3. Update the email address of a specific teacher in the "Teacher" table. Choose any teacher and 
--modify their email address. 

Update Teacher 
Set email = 'newteacher@gmail.com' 
Where teacher_id = 3;



--4. Write an SQL query to delete a specific enrollment record from the "Enrollments" table. Select 
--an enrollment record based on the student and course. 

Delete From Enrollments 
Where std_id = 2 AND course_id = 200;


--5. Update the "Courses" table to assign a specific teacher to a course. Choose any course and 
--teacher from the respective tables. 

Update Courses Set teacher_id = 4 
Where course_id = 300;


--6. Delete a specific student from the "Students" table and remove all their enrollment records 
--from the "Enrollments" table. Be sure to maintain referential integrity. 

Delete From Enrollments where std_id = 6;
Delete From Payments where std_id = 6;
Delete From Students where std_id = 6;


--7. Update the payment amount for a specific payment record in the "Payments" table. Choose any 
--payment record and modify the payment amount. 

Update Payments 
Set amount = 750 where payment_id = 5;

