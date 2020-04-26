USE master;
DROP DATABASE IF EXISTS Task3;
CREATE DATABASE Task3;
GO
USE Task3;
CREATE TABLE Users (
    Username varchar(255),
    Name varchar(255),
    Password varchar(255),
);
CREATE TABLE Weights (
    Username varchar(255),
    Weight int,
    Published date
);

INSERT INTO Users (Username, Name, Password)
VALUES 
	('admin', 'Szabó Attila', 'admin'),
	('joemama123', 'Joe Ludwig', 'asdasd'),
	('emptyandy','John Romero', 'asdasd2');
	
INSERT INTO Weights (Username, Weight, Published)
VALUES 
	('admin', 5, '2018-11-20'),
	('admin', 2, '2018-10-22'),
	('joemama123', 15, '2009-10-22'),
	('joemama123', 2, '2010-11-22'),
	('joemama123', 5, '2010-11-23');