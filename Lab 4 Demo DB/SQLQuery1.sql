-- ISS1202 assignment 4 implementation
-- create the database to connect to the forms app

CREATE DATABASE Lab4DemoDB;
GO

-- select it to create tables within it
USE Lab4DemoDB;
GO

-- create a table to store all the student records form the form input
CREATE TABLE StudentRecords (
	StudentID INT  NOT NULL IDENTITY PRIMARY KEY,
	LastName VARCHAR(30),
	FirstName VARCHAR(25),
	DateOfBirth DATE,
	Gender CHAR(1),
	NationalID NCHAR(13),
	RegNumber NCHAR(8),
	School CHAR(4),
	Course VARCHAR(7),
	Phone NVARCHAR(12),
	Email NVARCHAR(50),
	HITmail NVARCHAR(50),
);
GO

SELECT * FROM StudentRecords;
GO

-- create and fill another table with only personal details
CREATE TABLE PersonalDetails (
	StudentID INT,
	LastName VARCHAR(30),
	FirstName VARCHAR(25),
	DateOfBirth DATE,
	Gender CHAR(1),
	NationalID NCHAR(13) UNIQUE,
	Phone NVARCHAR(12),
	Email NVARCHAR(50),
);
GO

-- add a foreign key that refrences the StudentID from StudentRecords
ALTER TABLE PersonalDetails
	ADD CONSTRAINT FK_StudentRecords_PersonalDetails FOREIGN KEY (StudentID)
	REFERENCES StudentRecords(StudentID)
	ON DELETE CASCADE
	ON UPDATE CASCADE;
GO

SELECT * FROM PersonalDetails;
GO

-------------------------------------------------------------------------------------------------------------------------

-- create and fill another table with students from SIET
CREATE TABLE SIETdepartment (
StudentID INT,
LastName VARCHAR(30),
RegNumber NCHAR(8) UNIQUE,
Course VARCHAR(4),
Email NVARCHAR(50),
HITmail NVARCHAR(50),
);
GO

-- add a foreign key that refrences the StudentID from StudentRecords
ALTER TABLE SIETdepartment
	ADD CONSTRAINT FK_StudentRecords_SIETdepartment FOREIGN KEY (StudentID)
	REFERENCES StudentRecords(StudentID)
	ON DELETE CASCADE
	ON UPDATE CASCADE;
GO

SELECT * FROM SIETdepartment;
GO

-- create and fill another table with students from SIST
CREATE TABLE SISTdepartment (
	StudentID INT,
	LastName VARCHAR(30),
	RegNumber NCHAR(8) UNIQUE,
	Course VARCHAR(4),
	Email NVARCHAR(50),
	HITmail NVARCHAR(50),
);
GO

-- add a foreign key that refrences the StudentID from StudentRecords
ALTER TABLE SISTdepartment
	ADD CONSTRAINT FK_StudentRecords_SISTdepartment FOREIGN KEY (StudentID)
	REFERENCES StudentRecords(StudentID)
	ON DELETE CASCADE
	ON UPDATE CASCADE;
GO

SELECT * FROM SISTdepartment;
GO

-- create and fill another table with students from SAHS
CREATE TABLE SAHSdepartment (
StudentID INT,
LastName VARCHAR(30),
RegNumber NCHAR(8) UNIQUE,
Course VARCHAR(4),
Email NVARCHAR(50),
HITmail NVARCHAR(50),
);
GO

-- add a foreign key that refrences the StudentID from StudentRecords
ALTER TABLE SAHSdepartment
	ADD CONSTRAINT FK_StudentRecords_SAHSdepartment FOREIGN KEY (StudentID)
	REFERENCES StudentRecords(StudentID)
	ON DELETE CASCADE
	ON UPDATE CASCADE;
GO

SELECT * FROM SAHSdepartment;
GO

-- create and fill another table with students from SBMS
CREATE TABLE SBMSdepartment (
	StudentID INT,
	LastName VARCHAR(30),
	RegNumber NCHAR(8) UNIQUE,
	Course VARCHAR(4),
	Email NVARCHAR(50),
	HITmail NVARCHAR(50),
);
GO

-- add a foreign key that refrences the StudentID from StudentRecords
ALTER TABLE SBMSdepartment
	ADD CONSTRAINT FK_StudentRecords_SBMSdepartment FOREIGN KEY (StudentID)
	REFERENCES StudentRecords(StudentID)
	ON DELETE CASCADE
	ON UPDATE CASCADE;
GO

SELECT * FROM SBMSdepartment;
GO

-- create and fill another table with students from SIIT
CREATE TABLE SIITdepartment (
	StudentID INT,
	LastName VARCHAR(30),
	RegNumber NCHAR(8) UNIQUE,
	Course VARCHAR(4),
	Email NVARCHAR(50),
	HITmail NVARCHAR(50),
);
GO

-- add a foreign key that refrences the StudentID from StudentRecords
ALTER TABLE SIITdepartment
	ADD CONSTRAINT FK_StudentRecords_SIITdepartment FOREIGN KEY (StudentID)
	REFERENCES StudentRecords(StudentID)
	ON DELETE CASCADE
	ON UPDATE CASCADE;
GO

SELECT * FROM SIITdepartment;
GO

-------------------------------------------------------------------------------------------------------------------------

-- when errors arise delete the tables and start afresh
ALTER TABLE PersonalDetails DROP CONSTRAINT FK_StudentRecords_PersonalDetails;
DROP TABLE PersonalDetails;
ALTER TABLE SIETdepartment DROP CONSTRAINT FK_StudentRecords_SIETdepartment;
DROP TABLE SIETdepartment;
ALTER TABLE SISTdepartment DROP CONSTRAINT FK_StudentRecords_SISTdepartment;
DROP TABLE SISTdepartment;
ALTER TABLE SAHSdepartment DROP CONSTRAINT FK_StudentRecords_SAHSdepartment;
DROP TABLE SAHSdepartment;
ALTER TABLE SBMSdepartment DROP CONSTRAINT FK_StudentRecords_SBMSdepartment;
DROP TABLE SBMSdepartment;
ALTER TABLE SIITdepartment DROP CONSTRAINT FK_StudentRecords_SIITdepartment;
DROP TABLE SIITdepartment;
DROP TABLE StudentRecords;
GO

-- in extreme cases, delete the database too and restart
USE master;
DROP DATABASE Lab4DemoDB;
GO