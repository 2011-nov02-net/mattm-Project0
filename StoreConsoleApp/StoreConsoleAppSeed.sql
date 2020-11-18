
--DROP TABLE IF EXISTS Customer;
CREATE TABLE Customers (
Id INT IDENTITY PRIMARY KEY NOT NULL, 
FirstName NVARCHAR(50) NOT NULL CHECK (LEN(FirstName) >0),
LastName NVARCHAR(50) NOT NULL CHECK (LEN(LastName) >0),
FavoriteStore INT NULL
);

--DROP TABLE IF EXISTS PRODUCTS;
CREATE TABLE Products (
Id INT IDENTITY PRIMARY KEY NOT NULL,
Name NVARCHAR(120) NOT NULL CHECK (LEN(Name) > 0),
Price MONEY NOT NULL CHECK (Price > 0)
);

--DROP TABLE IF EXISTS Locations;
CREATE TABLE Locations (
Id Int IDENTITY PRIMARY KEY NOT NULL,
Address NVARCHAR(120) NOT NULL,
City NVARCHAR(30) NOT NULL,
State NVARCHAR(30) NULL CHECK (LEN(State) > 0 AND LEN(State) <= 2),
Country NVARCHAR(30)
);

ALTER TABLE Customers ADD
	CONSTRAINT FK_LOCATION_ID
		FOREIGN KEY (FavoriteStore) REFERENCES Locations (Id);

--DROP TABLE IF EXISTS Inventory;
CREATE TABLE Inventory (
StoreId INT NOT NULL
		FOREIGN KEY REFERENCES Locations (Id),
ItemId INT NOT NULL 
	FOREIGN KEY REFERENCES Products (Id),
Quantity INT NOT NULL DEFAULT 0 CHECK (Quantity >= 0),
);

--DROP TABLE IF EXISTS CustomerOrders;
CREATE TABLE CustomerOrders (
Id INT IDENTITY PRIMARY KEY NOT NULL,
CustomerId INT NOT Null
	FOREIGN KEY REFERENCES Customers (Id)
);

--DROP TABLE IF EXISTS Orders;
CREATE TABLE Orders (
Id INT IDENTITY NOT NULL PRIMARY KEY,
OrderId INT NOT NULL 
	FOREIGN KEY REFERENCES CustomerOrders (Id),
LocationId INT NOT NULL
	FOREIGN KEY REFERENCES Locations (Id),
OrderDate DATETIME NULL DEFAULT GETDATE(),
ProductId INT NOT NULL 
	FOREIGN KEY REFERENCES Products (Id),
Quantity INT NOT NULL Default(1) Check(Quantity > 0)
);

CREATE TABLE LocationStock (
Id INT IDENTITY NOT NULL PRIMARY KEY,
LocationId INT NOT NULL
	FOREIGN KEY REFERENCES Locations (Id),
ProductId INT NOT NULL
	FOREIGN KEY REFERENCES Products (Id),
Quantity INT NOT NULL DEFAULT(0)
);

INSERT INTO Customers (FirstName, LastName) VALUES
	('Jim', 'Halpert'),
	('Pam', 'Beasley'),
	('Michael', 'Scott'),
	('Stanley', 'Hudson'),
	('Phyllis', 'Lapin'),
	('Creed', 'Bratton'),
	('Ryan', 'Howard'),
	('Dwight', 'Schrute'),
	('Meredith', 'Palmer'),
	('Andy', 'Bernard');

INSERT INTO Products (Name, Price) VALUES
	('Rocket Roller Skates', 50.00),
	('Large Anvil', 25.00),
	('Small Anvil', 15.00),
	('Paint (For fake roads)', 10.00),
	('Disintegration Ray', 500.00),
	('Bear Trap', 50.00),
	('TNT (Detonator Sold Separately)', 200.00),
	('TNT Detonator', 100.00);

INSERT INTO Locations (Address, City, State, Country) VALUES
	('124 Main Street', 'Philadelphia', 'PA', 'USA'),
	('983 High Street', 'San Francisco', 'CA', 'USA'),
	('346 Market Street', 'Dallas', 'TX', 'USA'),
	('237 Mill Street', 'Phoenix', 'AZ', 'USA'),
	('673 Ocean Place', 'Miami', 'FL', 'USA'),
	('1 Park Place', 'New York', 'NY', 'USA');

INSERT INTO LocationStock (LocationId, ProducId, Quantity) VALUES
	(1, 1, 100),
	(1, 2, 100),
	(1, 3, 100),
	(1, 4, 100),
	(1, 5, 100),
	(1, 6, 100),
	(1, 7, 100),
	(1, 8, 100),
	(2, 1, 100),
	(2, 2, 100),
	(2, 3, 100),
	(2, 4, 100),
	(2, 5, 100),
	(2, 6, 100),
	(2, 7, 100),
	(2, 8, 100),
	(3, 1, 100),
	(3, 2, 100),
	(3, 3, 100),
	(3, 4, 100),
	(3, 5, 100),
	(3, 6, 100),
	(3, 7, 100),
	(3, 8, 100),
	(4, 1, 100),
	(4, 2, 100),
	(4, 3, 100),
	(4, 4, 100),
	(4, 5, 100),
	(4, 6, 100),
	(4, 7, 100),
	(4, 8, 100),
	(5, 1, 100),
	(5, 2, 100),
	(5, 3, 100),
	(5, 4, 100),
	(5, 5, 100),
	(5, 6, 100),
	(5, 7, 100),
	(5, 8, 100),
	(6, 1, 100),
	(6, 2, 100),
	(6, 3, 100),
	(6, 4, 100),
	(6, 5, 100),
	(6, 6, 100),
	(6, 7, 100),
	(6, 8, 100);





