-- Task 01 : Database Design

CREATE database TechShop;

use TechShop;


-- the database contains customers, products, orders, orderdetails, inventory.. so first creating all tables

create table Customers
(
	cust_id INT PRIMARY KEY,
	first_name VARCHAR(30) not null, -- no null values
	last_name VARCHAR(30),
	cust_email VARCHAR(40) unique,
	cust_phone NUMERIC(10),
	cust_address VARCHAR(50) 

);

create table Products
(
	prod_id INT PRIMARY KEY,
	prod_name VARCHAR(30) not null,
	prod_description VARCHAR(50),
	prod_price NUMERIC(8)

);


create table orders
(
	order_id INT PRIMARY KEY,
	cust_id INT,
	order_date DATE,
	total_amnt NUMERIC(8),
	FOREIGN KEY (cust_id) references Customers(cust_id)
);

create table order_details
(
	order_detail_id INT PRIMARY KEY,
	order_id INT,
	prod_id INT,
	quantity INT,
	FOREIGN KEY (order_id) references Orders(order_id),
	FOREIGN KEY (prod_id) references Products(prod_id)

);


create table Inventory(
	inventory_id INT PRIMARY KEY,
	prod_id INT,
	quantityInStock INT,
	lastStockUpdate DATE,
	FOREIGN KEY (prod_id) references Products(prod_id)

);

-- inserting values to the created tables in techshop

insert into Customers
(cust_id, first_name, last_name, cust_email, cust_phone, cust_address)
Values
(100, 'Arun', 'Prasanth', 'arunprasanth@gmail', 32312, 'abcde'),
(101, 'Bala', 'Murugan', 'balamurugan@gmail', 42311, 'bcdef'),  
(102, 'Chitra', 'Devi', 'chitradevi@gmail', 52310, 'cdefg'),  
(103, 'Dinesh', 'Kumar', 'dineshkumar@gmail', 62309, 'defgh'),  
(104, 'Eshwar', 'Raj', 'eshwarraj@gmail', 72308, 'efghi'),  
(105, 'Fathima', 'Zahra', 'fathimazahra@gmail', 82307, 'fghij'),  
(106, 'Ganesh', 'Babu', 'ganeshbabu@gmail', 92306, 'ghijk'),  
(107, 'Harini', 'Priya', 'harinipriya@gmail', 102305, 'hijkl'),  
(108, 'Ilayaraja', 'Perumal', 'ilayaraja@gmail', 112304, 'ijklm'),  
(109, 'Jayanth', 'Varma', 'jayanthvarma@gmail', 122303, 'jklmn');  


insert INTO Products 
(prod_id, prod_name, prod_description, prod_price) 
VALUES
(1, 'Laptop', 'High-performance laptop', 7500),
(2, 'Smartphone', '5G-enabled smartphone', 45000),
(3, 'Wireless Earbuds', 'Noise-canceling earbuds', 8500),
(4, 'Smartwatch', 'Fitness tracking smartwatch', 1200),
(5, 'Tablet', '10-inch screen tablet', 2800),
(6, 'Gaming Mouse', 'Ergonomic gaming mouse', 3500),
(7, 'Mechanical Keyboard', 'RGB backlit keyboard', 6500),
(8, 'External Hard Drive', '1TB portable storage', 5500),
(9, 'Monitor', '27-inch Full HD monitor', 18500),
(10, 'Bluetooth Speaker', 'Waterproof portable speaker', 4000);


insert INTO Orders (order_id, cust_id, order_date, total_amnt) 
values
(1, 100, '2025-03-10', 120000.00),
(2, 101, '2025-03-11', 45000.00),
(3, 102, '2025-03-12', 18500.00),
(4, 103, '2025-03-13', 75000.00),
(5, 104, '2025-03-14', 8500.00),
(6, 105, '2025-03-15', 6500.00),
(7, 106, '2025-03-16', 3500.00),
(8, 107, '2025-03-17', 5500.00),
(9, 108, '2025-03-18', 28000.00),
(10,109, '2025-03-19', 4000.00);



insert into Order_Details 
(order_detail_id, order_id, prod_id, quantity) 
VALUES
(11, 1, 1, 2),
(12, 2, 2, 1),
(13, 3, 9, 1),
(14, 4, 1, 1),
(15, 5, 3, 1),
(16, 6, 7, 1),
(17, 7, 6, 1),
(18, 8, 8, 1),
(19, 9, 5, 1),
(20, 10, 10, 1);


insert INTO Inventory 
(inventory_id, prod_id, quantityInStock, lastStockUpdate) 
VALUES
(21, 1, 50, '2025-03-01'),
(22, 2, 40, '2025-03-02'),
(23, 3, 100, '2025-03-03'),
(24, 4, 30, '2025-03-04'),
(25, 5, 25, '2025-03-05'),
(26, 6, 70, '2025-03-06'),
(27, 7, 60, '2025-03-07'),
(28, 8, 45, '2025-03-08'),
(29, 9, 20, '2025-03-09'),
(30, 10, 35, '2025-03-10');


-- Task 01 : Select, Where, Between, And, Like

-- 1. Write an SQL query to retrieve the names and emails of all customers

Select Customers.first_name, Customers.last_name, Customers.cust_email 
FROM Customers;

-- 2. Write an SQL query to list all orders with their order dates and corresponding customer names

Select orders.order_date, Customers.first_name AS Customer_name
FROM orders
INNER JOIN Customers
ON
orders.cust_id = Customers.cust_id;

-- 3. Write an SQL query to insert a new customer record into the "Customers" table. Include 
--customer information such as name, email, and address.

Insert into Customers
(cust_id, first_name, last_name, cust_email, cust_address)
Values
(111,'Peter', 'Parker', 'park@peet', '23ihgsf');

-- 4. Write an SQL query to update the prices of all electronic gadgets in the "Products" table by 
--increasing them by 10%.

Update Products
set prod_price = prod_price + ((prod_price/100)*10)

Select Products.prod_price from Products;


-- 5. Write an SQL query to delete a specific order and its associated order details from the 
--"Orders" and "OrderDetails" tables. Allow users to input the order ID as a parameter.


Delete from order_details where order_id = 10;
select * from order_details;

Delete from orders where order_id = 10;
select * from orders;


-- 6. Write an SQL query to insert a new order into the "Orders" table. Include the customer ID, 
--order date, and any other necessary information.

Insert into orders
(order_id, cust_id, order_date, total_amnt)
values
(10, 109, '2025-03-19', 29000);



-- 7. Write an SQL query to update the contact information (e.g., email and address) of a specific 
--customer in the "Customers" table. Allow users to input the customer ID and new contact information.


Update Customers
set cust_email = 'kumardinesh@gmail.com', cust_address = 'sfsfsfs'
Where cust_id = 103;

select Customers.cust_id, Customers.cust_email, Customers.cust_address from Customers;


-- 8. Write an SQL query to recalculate and update the total cost of each order in the "Orders" 
 --table based on the prices and quantities in the "OrderDetails" table.

Update Orders 
set total_amnt = (
   select sum(od.quantity * p.prod_price)
   from order_details od
   join Products p on od.prod_id= p.prod_id
   where od.order_id=orders.order_id
   );

 

 -- 9. Write an SQL query to delete all orders and their associated order details for a specific 
--customer from the "Orders" and "OrderDetails" tables. Allow users to input the customer ID as a parameter.

Delete from orders
where orders.cust_id = 101;

Delete from order_details
where order_id in (Select order_id from orders where orders.cust_id = 101);

-- 10. Write an SQL query to insert a new electronic gadget product into the "Products" table, 
--including product name, category, price, and any other relevant details.

insert INTO Products 
(prod_id, prod_name, prod_description, prod_price) 
VALUES
(11, 'Mouse', 'Gaming mouse', 2000);



-- 11. Write an SQL query to update the status of a specific order in the "Orders" table (e.g., from 
--"Pending" to "Shipped"). Allow users to input the order ID and the new status.


-- There is no such column present so we updating the table orders..

Alter table orders
Add order_status VARCHAR(20);

Update orders
Set order_status = 'Pending'
where order_id = 10;

Select * from orders;

update orders
Set orders.order_status = 'Shipped'
where order_id = 4;

Select * From orders;

-- 12. Write an SQL query to calculate and update the number of orders placed by each customer 
-- in the "Customers" table based on the data in the "Orders" table.

Select Customers.cust_id, count(*) AS numberOfOrdersPlaced
From Customers
inner join orders
ON Customers.cust_id = orders.cust_id
group by Customers.cust_id;









-- Task 03 : Aggregate functions, Having, Order By, GroupBy and Joins:


--1. Write an SQL query to retrieve a list of all orders along with customer information (e.g., 
--customer name) for each order.

Select orders.order_id, Customers.cust_id, Customers.first_name, Customers.cust_phone, Customers.cust_address 
From Customers
INNER JOIN
orders on
orders.cust_id = Customers.cust_id;



--2. Write an SQL query to find the total revenue generated by each electronic gadget product. 
--Include the product name and the total revenue.

Select Products.prod_name, sum(Products.prod_price * order_details.quantity) AS Total_revenue
From Products
Join
order_details on
Products.prod_id = order_details.prod_id
Group by Products.prod_name; -- here we must use prod_name to group by, using prod_id won't work



--3. Write an SQL query to list all customers who have made at least one purchase. Include their 
--names and contact information.

Select Customers.cust_id, Customers.first_name, Customers.cust_phone, count(orders.order_id) AS Orders_done
From Customers
Inner join
orders on
Customers.cust_id = orders.cust_id
Group by Customers.cust_id, Customers.first_name, Customers.cust_phone;
-- while using aggregate funcions it requires all non-aggregate columns -- very important ***



--4. Write an SQL query to find the most popular electronic gadget, which is the one with the highest 
--total quantity ordered. Include the product name and the total quantity ordered.

Select Products.prod_id, Products.prod_name, sum(order_details.quantity) AS [Total_orders]
From Products
INNER JOIN order_details
on Products.prod_id = order_details.prod_id
Group by Products.prod_id, Products.prod_name
order by Total_orders DESC;




--5. Write an SQL query to retrieve a list of electronic gadgets along with their corresponding 
--categories.



--6. Write an SQL query to calculate the average order value for each customer. Include the 
--customer's name and their average order value.

Select Customers.cust_id, Customers.first_name, AVG(orders.total_amnt) AS Average_order
FROM Customers
LEFT JOIN
orders on
Customers.cust_id = orders.cust_id
Group by Customers.cust_id, Customers.first_name;


--7. Write an SQL query to find the order with the highest total revenue. Include the order ID, 
--customer information, and the total revenue.

Select order_details.order_id, Customers.first_name, Customers.cust_phone, 
SUM(order_details.quantity * Products.prod_price) AS Total_revenue
FROM Orders
Join Customers ON 
Orders.cust_id = Customers.cust_id
join order_details ON Orders.order_id = order_details.order_id
Join Products ON order_details.prod_id = Products.prod_id
GROUP BY order_details.order_id, Customers.first_name, Customers.cust_phone
ORDER BY Total_revenue DESC;

--8. Write an SQL query to list electronic gadgets and the number of times each product has been 
--ordered.

Select Products.prod_name, Count(order_details.order_id) AS Times_ordered
From Products
Left join
order_details on
Products.prod_id = order_details.prod_id
Group by Products.prod_name;


--9. Write an SQL query to find customers who have purchased a specific electronic gadget product. 
--Allow users to input the product name as a parameter.

Select  Products.prod_name, Customers.cust_id, Customers.first_name, Customers.cust_phone,
order_details.prod_id
From orders
Inner join Customers on Customers.cust_id = orders.cust_id
Inner join order_details on orders.order_id = order_details.order_id
Inner join Products on order_details.prod_id = Products.prod_id
Where Products.prod_name = 'Gaming mouse';

--10. Write an SQL query to calculate the total revenue generated by all orders placed within a 
--specific time period. Allow users to input the start and end dates as parameters.

Select Sum(Products.prod_price * order_details.quantity) AS Total_revenue
From orders
Inner join order_details on orders.order_id = order_details.order_id
Inner join Products on order_details.prod_id = Products.prod_id
Where orders.order_date Between '2025-03-01' AND '2025-03-08';