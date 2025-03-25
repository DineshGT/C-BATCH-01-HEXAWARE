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

 -- All values inserted..

 Select * From Artists;
 Select * From Categories;
 Select * From Artworks;
 Select * From Exhibitions;
 Select * From Exhibition_Artworks;


 -- Queries to solve..


--1. Retrieve the names of all artists along with the number of artworks they have in the gallery, and
--list them in descending order of the number of artworks.

Select Artists.Artist_name, Count(Artworks.Artwork_id) As Number_of_artworks
From Artists
Left Join Artworks
On Artists.Artist_id = Artworks.Artist_id
Group by Artist_name
Order By Number_of_artworks DESC;



--2. List the titles of artworks created by artists from 'Spanish' and 'Dutch' nationalities, and order
--them by the year in ascending order.

Select Artists.Artist_name, Artworks.Title 
From Artists
Join Artworks On Artists.Artist_id = Artworks.Artist_id
Where Artists.Nationality = 'Spanish' or Nationality = 'Dutch'
order by Artworks.Year ASC;



--3. Find the names of all artists who have artworks in the 'Painting' category, and the number of
--artworks they have in this category.


Select Artists.Artist_name, Count(Artworks.Artwork_id) As Number_of_artworks
From Artists
Join Artworks on Artists.Artist_id = Artworks.Artist_id
Join Categories on Artworks.Category_id = Categories.Category_id
Where Categories.Category_name = 'Painting'
Group by Artist_name;



--4. List the names of artworks from the 'Modern Art Masterpieces' exhibition, along with their
--artists and categories.


Select Artworks.Title, Artists.Artist_name, Categories.Category_name
From Artworks
Join Artists on Artists.Artist_id = Artworks.Artist_id
Join Categories on Artworks.Category_id = Categories.Category_id
Join Exhibition_Artworks on Exhibition_Artworks.Artwork_id = Artworks.Artwork_id
Join Exhibitions on Exhibitions.Exhibition_id = Exhibition_Artworks.Exhibition_id
Where Exhibitions.Title = 'Modern Art Masterpieces';


--5. Find the artists who have more than two artworks in the gallery.

Select Artists.Artist_id, Artists.Artist_name
From Artists Where Artist_id in (Select Artist_id From Artworks Group By Artworks.Artist_id 
		                        Having count(Artwork_id)>2);

								-- no outputs here for the given table inputs


--6. Find the titles of artworks that were exhibited in both 'Modern Art Masterpieces' and
--'Renaissance Art' exhibitions

Select Artworks.Title From Artworks
Join Exhibition_Artworks on Artworks.Artwork_id = Exhibition_Artworks.Artwork_id
Join Exhibitions on Exhibition_Artworks.Exhibition_id = Exhibitions.Exhibition_id
Where Exhibitions.Title in ('Modern Art Masterpieces','REnaissance Art')
Group by Artworks.Title
Having count(Distinct Exhibitions.Exhibition_id) = 2;



--7. Find the total number of artworks in each category

Select Categories.Category_name, Count(Artworks.Artwork_id) As NUmber_of_artworks
From Categories
Left Join Artworks on Artworks.Category_id = Categories.Category_id
Group by Category_name;


--8. List artists who have more than 3 artworks in the gallery.

Select Artists.Artist_name From Artists
Where Artist_id in (Select Artist_id From Artworks Group by Artist_id
                     Having count(Artworks.Artwork_id) > 3);



--9. Find the artworks created by artists from a specific nationality (e.g., Spanish).

Select Artworks.Title From Artworks
        Where Artist_id IN (Select Artist_id From Artists Where Nationality = 'Spanish');



--10. List exhibitions that feature artwork by both Vincent van Gogh and Leonardo da Vinci.

Select Exhibitions.Exhibition_id, Exhibitions.Title
FROM Exhibitions
Join Exhibition_Artworks  ON Exhibitions.Exhibition_id = Exhibition_Artworks.Exhibition_id
Join Artworks on Exhibition_Artworks.Artwork_id = Artworks.Artwork_id
Join Artists on Artists.Artist_id = Artworks.Artist_id
Where Artists.Artist_name IN ('Vincent van Gogh', 'Leonardo da Vinci')
Group by Exhibitions.Exhibition_id, Exhibitions.Title
Having count(DISTINCT Artworks.Artist_id) = 2;



--11. Find all the artworks that have not been included in any exhibition.

Select Artworks.Artwork_id, Artworks.Title
From Artworks 
Left Join Exhibition_Artworks On Artworks.Artwork_id = Exhibition_Artworks.Artwork_id
Where Exhibition_Artworks.Exhibition_id IS NULL;


--12. List artists who have created artworks in all available categories.

--inserting some values 

Insert into Artworks (Artwork_id, Title, Artist_id, Category_id, Year, Description, ImageURL) 
Values
(4, 'Sunflowers', 2, 2, 1888, 'A famous painting by Van Gogh.', 'sunflowers.jpg'),
(5, 'The Thinker', 3, 2, 1902, 'A sculpture by Rodin.', 'thinker.jpg'),
(6, 'The Last Supper', 3, 3, 1495, 'A famous mural by Leonardo da Vinci.', 'last_supper.jpg'),
(7, 'Weeping Woman', 1, 3, 1937, 'A painting by Picasso.', 'weeping_woman.jpg'),
(8, 'Portrait of an Artist', 1, 2, 1972, 'A modern painting by David Hockney.', 'portrait_artist.jpg');

Select Artists.Artist_id, Artists.Artist_name
From Artists 
Join Artworks  On Artists.Artist_id = Artworks.Artist_id
Group by Artists.Artist_id, Artists.Artist_name
Having count(Distinct Artworks.Category_id) = (select count(*) From Categories); 



--13. List the total number of artworks in each category.

Select Categories.Category_id, Categories.Category_name, Count(Artworks.Artwork_id) As Total
From Categories
Left Join Artworks on Artworks.Category_id = Categories.Category_id
Group by Categories.Category_id, Categories.Category_name;


--14. Find the artists who have more than 2 artworks in the gallery.

Select Artists.Artist_id, Artist_name From Artists
where Artist_id in ( Select Artist_id from Artworks 
                              Group by Artist_id 
                                 Having count(Artwork_id) > 2);

--15. List the categories with the average year of artworks they contain, only for categories with more
--than 1 artwork.

Select Categories.Category_id, Categories.Category_name, avg(Artworks.Year) As Average_Year
From Artworks 
Join Categories ON Artworks.Category_id = Categories.Category_id
Group by Categories.Category_id, Categories.Category_name
Having count(Artworks.Artwork_id) > 1;



--16. Find the artworks that were exhibited in the 'Modern Art Masterpieces' exhibition.

Select Artworks.Artwork_id, Artworks.Title
FROM Artworks
Join Exhibition_Artworks on Artworks.Artwork_id = Exhibition_Artworks.Artwork_id
Join Exhibitions on Exhibition_Artworks.Exhibition_id = Exhibitions.Exhibition_id
where Exhibitions.Title = 'Modern Art Masterpieces';



--17. Find the categories where the average year of artworks is greater than the average year of all artworks.

Select Categories.Category_id, Categories.Category_name, avg(Artworks.Year) AS Average_Year
From Artworks
Join Categories on Artworks.Category_id = Categories.Category_id
Group by Categories.Category_id, Categories.Category_name
Having AVG(Artworks.Year) > (Select avg(Year) From Artworks);


--18. List the artworks that were not exhibited in any exhibition.

Select Artworks.Artwork_id, Title
From Artworks
Where Artwork_id not in (Select Artwork_id From Exhibition_Artworks);



--19. Show artists who have artworks in the same category as "Mona Lisa."

Select Artists.Artist_id, Artists.Artist_name
From Artists
Join Artworks ON Artists.Artist_id = Artworks.Artist_id
Where Artworks.Category_id = (select Category_id From Artworks Where Title = 'Mona Lisa');


--20. List the names of artists and the number of artworks they have in the gallery.

Select Artists.Artist_name, COUNT(Artworks.Artwork_id) AS Number_of_artworks
From Artists
Left Join Artworks on Artists.Artist_id = Artworks.Artist_id
Group by Artists.Artist_name;
