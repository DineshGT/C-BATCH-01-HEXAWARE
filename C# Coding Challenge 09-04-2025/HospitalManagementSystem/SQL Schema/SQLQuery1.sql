Create Database HospitalManagementSystem;

use HospitalManagementSystem;

--Creating Tables

Create Table Patient (
    patientId INT PRIMARY KEY IDENTITY(1,1),
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    dateOfBirth DATE NOT NULL,
    gender VARCHAR(10) NOT NULL,
    contactNumber VARCHAR(15),
    address NVARCHAR(255)
);

Create Table Doctor (
    doctorId INT PRIMARY KEY IDENTITY(1,1),
    firstName VARCHAR(50) NOT NULL,
    lastName VARCHAR(50) NOT NULL,
    specialization VARCHAR(100),
    contactNumber VARCHAR(15)
);

Create Table Appointment (
    appointmentId INT PRIMARY KEY IDENTITY(1,1),
    patientId INT NOT NULL,
    doctorId INT NOT NULL,
    appointmentDate DATETIME NOT NULL,
    description NVARCHAR(255),
    FOREIGN KEY (patientId) REFERENCES Patient(patientId),
    FOREIGN KEY (doctorId) REFERENCES Doctor(doctorId)
);

--Inserting Values to tables

INSERT INTO Patient (firstName, lastName, dateOfBirth, gender, contactNumber, address)
VALUES 
('Dinesh', 'GT', '1990-05-12', 'Male', '1234567890', '123 sfdas'),
('Akshay', 'Raj', '1985-10-20', 'Male', '2345678901', '456 Odfgsdfg'),
('Sailesh', 'GT', '1992-03-15', 'Male', '3456789012', '789 sdfadf'),
('Vijay', 'Shree', '2000-08-30', 'Female', '4567890123', '101 sdfassfdn'),
('Peter', 'Parker', '1978-01-05', 'Male', '5678901234', '202 Csdfvd');

Insert Into Doctor (firstName, lastName, specialization, contactNumber)
VALUES
('Alice', 'Walker', 'Cardiology', '8765432100'),
('David', 'Taylor', 'Neurology', '7654321098'),
('Laura', 'Clark', 'Pediatrics', '6543210987'),
('Daniel', 'Martinez', 'Dermatology', '5432109876'),
('Nancy', 'Allen', 'Orthopedics', '4321098765');

Insert Into Appointment (patientId, doctorId, appointmentDate, description)
VALUES
(1, 1, '2025-04-10 10:00:00', 'Routine heart check-up'),
(2, 3, '2025-04-11 14:30:00', 'Child fever consultation'),
(3, 2, '2025-04-12 09:15:00', 'Migraine assessment'),
(4, 4, '2025-04-13 11:45:00', 'Skin care examination'),
(5, 5, '2025-04-14 16:00:00', 'Knee pain review');

--Schema is created succesfullyy..