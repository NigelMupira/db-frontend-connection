-- select our db to create tables within it
USE Lab4DemoDB;
GO

-- create and populate a table to store options for my drop down lists in windows forms
CREATE TABLE Schools (
	id INT  NOT NULL IDENTITY PRIMARY KEY,
	School CHAR(4),
	SchoolSIET CHAR(4),
	SchoolSIST CHAR(4),
	SchoolSAHS CHAR(4),
	SchoolSBMS CHAR(4),
	SchoolSIIT CHAR(7),
);
GO

-- tried this first but it wasnt pretty...

/*
-- a column for the combobox of schools at HIT
INSERT INTO Schools (School)
VALUES ('SIET'), ('SIST'), ('SAHS'), ('SBMS'), ('SIIT');
GO

-- a column for the combobox of programs in the school of IET
INSERT INTO Schools (SchoolSIET)
VALUES ('HBME'), ('CPSE'), ('HIEE'), ('HIME'), ('HEPT'), ('HEMT');
GO

-- a column for the combobox of programs in the school of IST
INSERT INTO Schools (SchoolSIST)
VALUES ('HISA'), ('HIIT'), ('HISE'), ('HICS');
GO

-- a column for the combobox of programs in the school of AHS
INSERT INTO Schools (SchoolSAHS)
VALUES ('pharma'), ('HIDR'), ('HITR');
GO

-- a column for the combobox of programs in the school of BMS
INSERT INTO Schools (SchoolSBMS)
VALUES ('HIFE'), ('HIEC'), ('HFAA'), ('ISSM');
GO

-- a column for the combobox of programs in the school of IndST
INSERT INTO Schools (SchoolSIIT)
VALUES ('HFPT'), ('biotech');
GO
*/

-- insert the data to be used by the different comboboxes in the colums
INSERT INTO Schools (School, SchoolSIET, SchoolSIST, SchoolSAHS, SchoolSBMS, SchoolSIIT)
VALUES ('SIET', 'HBME', 'HISA', 'AHPH', 'HIFE', 'HFPT'),
       ('SIST', 'CPSE', 'HIIT', 'HIDR', 'HIEC', 'biotech'),
	   ('SAHS', 'HIEE', 'HISE', 'HITR', 'HFAA', ''),
	   ('SBMS', 'HIME', 'HICS', '', 'ISSM', ''),
	   ('SIIT', 'HEPT', '', '', '', ''),
	   ('', 'HEMT', '', '', '', '')
GO

SELECT * FROM Schools;
GO

-------------------------------------------------------------------------------------------------------------------------

-- when errors arise delete the table and start afresh
DROP TABLE Schools;
GO

USE master;
GO