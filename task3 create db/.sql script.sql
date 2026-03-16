CREATE DATABASE shop_db;
USE shop_db;

CREATE TABLE Products (
    product_id INT AUTO_INCREMENT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    category VARCHAR(50) DEFAULT 'General',
    price DECIMAL(10, 2) NOT NULL CHECK (price > 0),
    stock_quantity INT NOT NULL DEFAULT 0
);

CREATE TABLE Customers (
    customer_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    phone VARCHAR(20),
    registration_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Orders (
    order_id INT AUTO_INCREMENT PRIMARY KEY,
    customer_id INT NOT NULL,
    product_id INT NOT NULL,
    order_date DATE NOT NULL,
    quantity INT NOT NULL CHECK (quantity > 0),
    FOREIGN KEY (customer_id) REFERENCES Customers(customer_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

ALTER TABLE Customers ADD COLUMN address VARCHAR(255);
ALTER TABLE Products MODIFY COLUMN product_name VARCHAR(150) NOT NULL;
ALTER TABLE Customers ADD CONSTRAINT UNIQUE (phone);

INSERT INTO Products (product_name, price, stock_quantity) VALUES ('iPhone 15', 999.99, 10);
INSERT INTO Products (product_name, price, stock_quantity) VALUES ('Samsung S23', 850.00, 15);
INSERT INTO Products (product_name, price, stock_quantity) VALUES ('MacBook Air', 1200.00, 5);
INSERT INTO Products (product_name, price, stock_quantity) VALUES ('AirPods Pro', 249.00, 30);
INSERT INTO Products (product_name, price, stock_quantity) VALUES ('Apple Watch', 399.00, 12);

INSERT INTO Customers (full_name, email, phone, address) VALUES ('Ivan Ivanov', 'ivan@mail.com', '777111', 'Astana, 12');
INSERT INTO Customers (full_name, email, phone, address) VALUES ('Sasha Petrov', 'sasha@mail.com', '777222', 'Almaty, 5');
INSERT INTO Customers (full_name, email, phone, address) VALUES ('Maria Sidorova', 'maria@mail.com', '777333', 'Atyrau, 8');
INSERT INTO Customers (full_name, email, phone, address) VALUES ('Elena Kim', 'elena@mail.com', '777444', 'Astana, 45');
INSERT INTO Customers (full_name, email, phone, address) VALUES ('Oleg Pak', 'oleg@mail.com', '777555', 'Almaty, 1');

INSERT INTO Orders (customer_id, product_id, order_date, quantity) VALUES (1, 1, '2023-10-01', 1);
INSERT INTO Orders (customer_id, product_id, order_date, quantity) VALUES (2, 3, '2023-10-02', 1);
INSERT INTO Orders (customer_id, product_id, order_date, quantity) VALUES (3, 4, '2023-10-05', 2);
INSERT INTO Orders (customer_id, product_id, order_date, quantity) VALUES (4, 2, '2023-10-10', 1);
INSERT INTO Orders (customer_id, product_id, order_date, quantity) VALUES (5, 5, '2023-10-12', 1);

SELECT * FROM Products;
SELECT * FROM Customers;
SELECT * FROM Orders;

SELECT o.order_id, c.full_name, p.product_name, o.quantity 
FROM Orders o, Customers c, Products p 
WHERE o.customer_id = c.customer_id AND o.product_id = p.product_id;
