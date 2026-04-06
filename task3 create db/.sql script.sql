CREATE DATABASE IF NOT EXISTS OnlineShopDB;
USE OnlineShopDB;

DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS Categories;
DROP TABLE IF EXISTS Customer;

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY NOT NULL AUTO_INCREMENT UNIQUE,
    CustomerName VARCHAR(255) NOT NULL,
    CustomerLastName TEXT NOT NULL,
    CustomerAddress TEXT NOT NULL,
    CustomerDOB DATE NOT NULL,
    CustomerJoin DATE NOT NULL,
    FullNumber VARCHAR(15) NOT NULL UNIQUE
);

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY NOT NULL AUTO_INCREMENT UNIQUE,
    CategoryName VARCHAR(255) NOT NULL UNIQUE,
    CategoryDesc LONGTEXT NOT NULL,
    Status VARCHAR(20) DEFAULT 'Active'
);

CREATE TABLE Product (
    ProductID INT PRIMARY KEY NOT NULL AUTO_INCREMENT UNIQUE,
    ProductName TEXT NOT NULL,
    ProductCategory INT NOT NULL,
    SaleCount INT NOT NULL,
    Price DECIMAL(9,2) NOT NULL,
    ProductRating DECIMAL(2,1),
    Stock INT NOT NULL,
    CONSTRAINT fk_category FOREIGN KEY (ProductCategory) REFERENCES Categories(CategoryID)
);

ALTER TABLE Categories MODIFY COLUMN Status VARCHAR(100) DEFAULT 'Active';
ALTER TABLE Product MODIFY COLUMN ProductName VARCHAR(500) NOT NULL;
ALTER TABLE Customer MODIFY COLUMN FullNumber VARCHAR(20) NOT NULL UNIQUE;

INSERT INTO Customer (CustomerName, CustomerLastName, CustomerAddress, CustomerDOB, CustomerJoin, FullNumber) VALUES
('Ivan', 'Ivanov', 'Almaty', '1990-01-01', '2023-01-01', '+77011111111'),
('Petr', 'Petrov', 'Astana', '1985-05-05', '2023-02-10', '+77022222222'),
('Anna', 'Sidorova', 'Atyrau', '1995-10-10', '2023-03-15', '+77053333333'),
('Elena', 'Smirnova', 'Aktau', '1992-12-12', '2023-04-01', '+77074444444'),
('Oleg', 'Kuznetsov', 'Pavlodar', '1988-08-08', '2023-05-20', '+77085555555');

INSERT INTO Categories (CategoryName, CategoryDesc) VALUES
('Phones', 'Smartphones'),
('Laptops', 'Portable computers'),
('Audio', 'Sound devices'),
('Watches', 'Accessories'),
('Tablets', 'Multimedia devices');

INSERT INTO Product (ProductName, ProductCategory, SaleCount, Price, ProductRating, Stock) VALUES
('iPhone 15', 1, 100, 500000.00, 4.8, 10),
('MacBook', 2, 50, 700000.00, 4.9, 5),
('AirPods', 3, 200, 120000.00, 4.5, 30),
('Watch 9', 4, 80, 150000.00, 4.2, 15),
('iPad', 5, 30, 400000.00, 4.7, 7);

<<<<<<< HEAD
SELECT * FROM Customer;
SELECT * FROM Categories;
SELECT p.ProductName, c.CategoryName, p.Price FROM Product p JOIN Categories c ON p.ProductCategory = c.CategoryID;
=======
SELECT * FROM Products;
SELECT * FROM Customers;
SELECT * FROM Orders;

SELECT o.order_id, c.full_name, p.product_name, o.quantity 
FROM Orders o, Customers c, Products p 
WHERE o.customer_id = c.customer_id AND o.product_id = p.product_id;
ПО1-24 - Хисметова Аружан
>>>>>>> 2f9a6a08f47b0be39d273741ea2de38b5ef1e846
