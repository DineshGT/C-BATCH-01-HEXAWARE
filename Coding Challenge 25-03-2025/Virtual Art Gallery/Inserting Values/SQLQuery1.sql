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


 -- Now inserting values to tables..

 Insert Into Artists 
 (Artist_id, Artist_name, Biography, Nationality)
 Values
 (1, 'Pablo Picasso', 'Renowned Spanish painter and sculptor.', 'Spanish'),
 (2, 'Vincent van Gogh', 'Dutch post-impressionist painter.', 'Dutch'),
 (3, 'Leonardo da Vinci', 'Italian polymath of the Renaissance.', 'Italian');


 Insert into Categories 
 (Category_id, Category_name) 
 Values
 (1, 'Painting'),
 (2, 'Sculpture'),
 (3, 'Photography');


 Insert INTO Artworks 
 (Artwork_id, Title, Artist_id, Category_id, Year, Description, ImageURL) 
 Values
 (1, 'Starry Night', 2, 1, 1889, 'A famous painting by Vincent van Gogh.', 'starry_night.jpg'),
 (2, 'Mona Lisa', 3, 1, 1503, 'The iconic portrait by Leonardo da Vinci.', 'mona_lisa.jpg'),
 (3, 'Guernica', 1, 1, 1937, 'Pablo Picassos powerful anti-war mural.', 'guernica.jpg');


 Insert INTO Exhibitions 
 (Exhibition_id, Title, StartDate, EndDate, Description)
 Values
 (1, 'Modern Art Masterpieces', '2023-01-01', '2023-03-01', 'A collection of modern art masterpieces.'),
 (2, 'Renaissance Art', '2023-04-01', '2023-06-01', 'A showcase of Renaissance art treasures.'); INSERT INTO Exhibition_Artworks 
 (Exhibition_id, Artwork_id) 
 Values
 (1, 1),
 (1, 2),
 (1, 3),
 (2, 2);