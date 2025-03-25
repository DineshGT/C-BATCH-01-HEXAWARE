Create Database Virtual_Art_Gallery;

Use Virtual_Art_Gallery;


-- Creating Tables

Create Table Artists 
(
 Artist_id INT PRIMARY KEY,
 Artist_name VARCHAR(255) NOT NULL,
 Biography TEXT,
 Nationality VARCHAR(100)
 );


 Create TABLE Categories
 (
 Category_id INT PRIMARY KEY,
 Category_name VARCHAR(100) NOT NULL
 );

 Create table Artworks 
 (
 Artwork_id INT PRIMARY KEY,
 Title VARCHAR(255) NOT NULL,
 Artist_id INT,
 Category_id INT,
 Year INT,
 Description TEXT,
 ImageURL VARCHAR(255),
 FOREIGN KEY (Artist_id) REFERENCES Artists (Artist_id),
 FOREIGN KEY (Category_id) REFERENCES Categories (Category_id)
 );


 Create Table Exhibitions (
 Exhibition_id INT PRIMARY KEY,
 Title VARCHAR(255) NOT NULL,
 StartDate DATE,
 EndDate DATE,
 Description TEXT
 );


 Create Table Exhibition_Artworks 
 (
 Exhibition_id INT,
 Artwork_id INT,
 PRIMARY KEY (Exhibition_id, Artwork_id),
 FOREIGN KEY (Exhibition_id) REFERENCES Exhibitions (Exhibition_id),
 FOREIGN KEY (Artwork_id) REFERENCES Artworks (Artwork_id)
 );


