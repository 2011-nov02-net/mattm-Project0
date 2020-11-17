
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
OrderId INT NOT NULL 
	FOREIGN KEY REFERENCES CustomerOrders (Id),
LocationId INT NOT NULL
	FOREIGN KEY REFERENCES Locations (Id),
OrderDate DATETIME NULL DEFAULT GETDATE(),
ProductId INT NOT NULL 
	FOREIGN KEY REFERENCES Products (Id)
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


