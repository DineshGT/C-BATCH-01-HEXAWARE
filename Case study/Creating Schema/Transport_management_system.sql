-- Case Study For Transport Management System

-- SQL Schema 

Create Database Transport_Management_System;

Use Transport_Management_System;

-- Creating Tables

Create Table Vehicles 
(
	Vehicle_id INT IDENTITY(100,1) PRIMARY KEY,
	Model VARCHAR(255),
	Capacity DECIMAL(10, 2),
    Type VARCHAR(50),
	Status VARCHAR(50)

);

Create Table Routes 
(
    Route_id INT IDENTITY(1,1) PRIMARY KEY,
    Start_destination VARCHAR(255),
    End_destination VARCHAR(255),
    Distance DECIMAL(10,2)
);


Create Table Trips (
    Trip_id INT IDENTITY(10,1) PRIMARY KEY,
    Vehicle_id INT,
    Route_id INT,
    DepartureDate DATETIME,
    ArrivalDate DATETIME,
    Status VARCHAR(50),
    TripType VARCHAR(50) DEFAULT 'Freight',
    MaxPassengers INT,
    FOREIGN KEY (Vehicle_id) REFERENCES Vehicles(Vehicle_id),
    FOREIGN KEY (Route_id) REFERENCES Routes(Route_id)
);

Create Table Passengers (
    Passenger_id INT IDENTITY(1,1) PRIMARY KEY,
    First_name VARCHAR(255),
    Gender VARCHAR(255),
    Age INT,
    Email VARCHAR(255) UNIQUE,
    Phone_number VARCHAR(50)
);


Create Table Bookings (
    Booking_id INT IDENTITY(1,1) PRIMARY KEY,
    Trip_id INT,
    Passenger_id INT,
    Booking_date DATETIME,
    Status VARCHAR(50),
    FOREIGN KEY (Trip_id) REFERENCES Trips(Trip_id),
    FOREIGN KEY (Passenger_id) REFERENCES Passengers(Passenger_id)
);


-- Creating new Table Drivers for Case study

CREATE TABLE Drivers (
    Driver_id INT IDENTITY(1,1) PRIMARY KEY,
    First_name VARCHAR(100),
    Last_name VARCHAR(100),
    License_number VARCHAR(100) UNIQUE,
    Phone_number VARCHAR(50),
    Email VARCHAR(255),
    Experience_years INT
);

-- Inserting values

Insert into Vehicles 
(Model, Capacity, Type, Status) 
Values
('Tata Ace', 750.00, 'Mini Truck', 'Available'),
('Mahindra Bolero', 1000.00, 'SUV', 'In Service'),
('Ashok Leyland', 1250.50, 'Truck', 'Available'),
('Force Traveller', 2000.00, 'Van', 'Under Maintenance'),
('Tata Prima', 25000.00, 'Heavy Truck', 'Available');

-- Creating a new Table TripDrivers for managing trips..
CREATE TABLE TripDrivers (
    Trip_id INT,
    Driver_id INT,
    FOREIGN KEY (Trip_id) REFERENCES Trips(Trip_id),
    FOREIGN KEY (Driver_id) REFERENCES Drivers(Driver_id),
    PRIMARY KEY (Trip_id, Driver_id)
);

Insert into Routes 
(Start_destination, End_destination, Distance)
VALUES
('Mumbai', 'Pune', 150.00),
('Delhi', 'Jaipur', 270.00),
('Bangalore', 'Chennai', 350.00),
('Hyderabad', 'Vijayawada', 275.00),
('Kolkata', 'Bhubaneswar', 440.00);


Insert Into Trips 
(Vehicle_id, Route_id, DepartureDate, ArrivalDate, Status, TripType, MaxPassengers)
VALUES
(100, 1, '2025-03-25 08:00:00', '2025-03-25 12:00:00', 'Scheduled', 'Passenger', 12),
(101, 2, '2025-03-26 09:00:00', '2025-03-26 14:30:00', 'Scheduled', 'Freight', NULL),
(102, 3, '2025-03-27 07:30:00', '2025-03-27 13:00:00', 'Ongoing', 'Passenger', 18),
(103, 4, '2025-03-28 10:00:00', '2025-03-28 14:30:00', 'Completed', 'Freight', NULL),
(104, 5, '2025-03-29 06:00:00', '2025-03-29 16:00:00', 'Scheduled', 'Passenger', 24);

Insert Into Passengers 
(First_name, Gender, Age, Email, Phone_number)
VALUES
('Rahul Sharma', 'Male', 29, 'rahul.sharma@gmail.com', '9876543210'),
('Priya Singh', 'Female', 25, 'priya.singh@gmail.com', '8765432109'),
('Amit Verma', 'Male', 32, 'amit.verma@yahoo.com', '7654321098'),
('Neha Patil', 'Female', 28, 'neha.patil@hotmail.com', '6543210987'),
('Vikram Reddy', 'Male', 35, 'vikram.reddy@gmail.com', '5432109876');


Insert into Bookings (Trip_id, Passenger_id, Booking_date, Status)
VALUES
(10, 1, '2025-03-20 11:30:00', 'Confirmed'),
(11, 2, '2025-03-20 12:00:00', 'Pending'),
(12, 3, '2025-03-21 15:45:00', 'Confirmed'),
(13, 4, '2025-03-22 10:00:00', 'Cancelled'),
(14, 5, '2025-03-23 09:15:00', 'Confirmed');

Insert into Drivers (First_name, Last_name, License_number, Phone_number, Email, Experience_years)
Values
('Gokul', 'Raj', 123, 4123421, 'gokul@gmail.com', 5);


Select * From Vehicles;
Select * From Trips;
Select * From TripDrivers;
Select * From Bookings;
Select * From Drivers;
Select * From Bookings;
Select * From Passengers;
Select * From Routes;

Update Trips
Set MaxPassengers = 10 Where Trips.Trip_id = 13;