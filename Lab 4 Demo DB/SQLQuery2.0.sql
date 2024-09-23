-- I DISCARDED THIS QUERY!!!
-- CHECK OUT THE IMPROVED VERSION (SQLQuery2.1)

-- select our db to create tables within it
USE Lab4DemoDB;
GO

-- create and populate a table to store options for my drop down list in windows forms
CREATE TABLE Schools
(
id INT  NOT NULL IDENTITY PRIMARY KEY,
School CHAR(4),
);
GO

INSERT INTO Schools (School)
VALUES ('SIET'), ('SIST'), ('SAHS'), ('SBMS'), ('SIIT');
GO

SELECT * FROM Schools;
GO

-- create a table to store options from the SIET department
CREATE TABLE SchoolSIET
(
id INT  NOT NULL IDENTITY PRIMARY KEY,
Program CHAR(4),
);
GO

INSERT INTO SchoolSIET (Program)
VALUES ('HBME'), ('CPSE'), ('HIEE'), ('HIME'), ('HEPT'), ('HEMT');
GO

SELECT * FROM SchoolSIET;
GO

-- create a table to store options from the SIST department
CREATE TABLE SchoolSIST
(
id INT  NOT NULL IDENTITY PRIMARY KEY,
Program CHAR(4),
);
GO

INSERT INTO SchoolSIST (Program)
VALUES ('HISA'), ('HIIT'), ('HISE'), ('HICS');
GO

SELECT * FROM SchoolSIST;
GO

-- create a table to store options from the SAHS department
CREATE TABLE SchoolSAHS
(
id INT  NOT NULL IDENTITY PRIMARY KEY,
Program CHAR(6),
);
GO

INSERT INTO SchoolSAHS (Program)
VALUES ('pharma'), ('HIDR'), ('HITR');
GO

SELECT * FROM SchoolSAHS;
GO

-- create a table to store options from the SBMS department
CREATE TABLE SchoolSBMS
(
id INT  NOT NULL IDENTITY PRIMARY KEY,
Program CHAR(4),
);
GO

INSERT INTO SchoolSBMS (Program)
VALUES ('HIFE'), ('HIEC'), ('HFAA'), ('ISSM');
GO

SELECT * FROM SchoolSBMS;
GO

-- create a table to store options from the SIIS department
CREATE TABLE SchoolSIIT
(
id INT  NOT NULL IDENTITY PRIMARY KEY,
Program CHAR(7),
);
GO

INSERT INTO SchoolSIIT (Program)
VALUES ('HFPT'), ('biotech');
GO

SELECT * FROM SchoolSIIT;
GO

-------------------------------------------------------------------------------------------------------------------------

-- when errors arise delete the tables and start afresh
DROP TABLE Schools;
DROP TABLE SchoolSIET;
DROP TABLE SchoolSIST;
DROP TABLE SchoolSAHS;
DROP TABLE SchoolSBMS;
DROP TABLE SchoolSIIT;
GO

USE master;
GO