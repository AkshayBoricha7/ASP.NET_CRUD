CREATE DATABASE AddressBook;

use AddressBook;

CREATE TABLE Country
(
	CountryID INT PRIMARY KEY IDENTITY(1,1),
	CountryName VARCHAR(100) UNIQUE NOT NULL,
	CountryCode VARCHAR(50),
	CreationDate DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE State
(
	StateID INT PRIMARY KEY IDENTITY(1,1),
	CountryID INT NOT NULL FOREIGN KEY REFERENCES Country(CountryID),
	StateName VARCHAR(100) UNIQUE NOT NULL,
	StateCode VARCHAR(50),
	CreationDate DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE City
(
	CityID INT PRIMARY KEY IDENTITY(1,1),
	StateID INT NOT NULL FOREIGN KEY REFERENCES State(StateID),
	CityName VARCHAR(100) UNIQUE NOT NULL,
	STDCode VARCHAR(50),
	PinCode VARCHAR(6),
	CreationDate DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE ContactCategory
(
	ContactCategoryID INT PRIMARY KEY IDENTITY(1,1),
	ContactCategoryName VARCHAR(100) NOT NULL,
	CreationDate DATETIME NOT NULL DEFAULT GETDATE()
);


CREATE TABLE Contact
(
	ContactID INT PRIMARY KEY IDENTITY(1,1),
	CountryID INT NOT NULL FOREIGN KEY REFERENCES Country(CountryID),
	StateID INT NOT NULL FOREIGN KEY REFERENCES State(StateID),
	CityID INT NOT NULL FOREIGN KEY REFERENCES City(CityID),
	ContactCategoryID INT NOT NULL FOREIGN KEY REFERENCES ContactCategory(ContactCategoryID),
	ContactName VARCHAR(250) NOT NULL,
	ContactNo VARCHAR(250) NOT NULL,
	WhatsAppNo VARCHAR(250),
	BirthDate DATETIME,
	Email VARCHAR(250) NOT NULL,
	Age INT,
	Address VARCHAR(500) NOT NULL,
	BloodGroup VARCHAR(50),
	FacebookID VARCHAR(250),
	LinkedINID VARCHAR(250),
	CreationDate DATETIME NOT NULL DEFAULT GETDATE()
);











CREATE PROCEDURE PR_Country_SelectAll
AS
SELECT
	CountryID, CountryName, CountryCode, CreationDate
FROM Country
ORDER BY CountryName;


CREATE PROCEDURE PR_Country_SelectAll
AS
SELECT
	CountryID, CountryName, CountryCode, CreationDate FROM Country
ORDER BY CountryName;


CREATE PROCEDURE PR_Country_SelectByCountryID
	@CountryID int
AS
SELECT
	CountryID, CountryName, CountryCode, CreationDate FROM Country
	where CountryID = @CountryID


CREATE PROCEDURE PR_Country_Insert
	@CountryName VARCHAR(100),
	@CountryCode VARCHAR(50)
AS
INSERT INTO Country (CountryName, CountryCode) VALUES 
(@CountryName, @CountryCode);


CREATE PROCEDURE PR_Country_UpdateByCountryID
	@CountryID INT,
	@CountryName VARCHAR(100),
	@CountryCode VARCHAR(50)
AS
UPDATE Country set CountryName = @CountryName, CountryCode = @CountryCode
where CountryID = @CountryID;



CREATE PROCEDURE PR_Country_DeleteByCountryID
	@CountryID INT
AS
DELETE FROM Country WHERE CountryID = @CountryID;


CREATE PROCEDURE PR_State_SelectAll
AS
SELECT
	s.StateID, s.StateName, s.StateCode, c.CountryName, s.CreationDate
FROM State s INNER JOIN Country c
ON s.CountryID = c.CountryID
ORDER BY c.CountryName, s.StateName;


CREATE PROCEDURE PR_State_SelectByStateID
	@StateID INT
AS
SELECT
	s.StateID, s.StateName, s.StateCode, c.CountryName, s.CreationDate
FROM State s INNER JOIN Country c
ON s.CountryID = c.CountryID
where s.StateID = @StateID
ORDER BY c.CountryName, s.StateName;



CREATE PROCEDURE PR_State_Insert
	@StateID INT,
	@StateName VARCHAR(100),
	@CountryID INT,
	@StateCode VARCHAR(50)
AS
INSERT INTO State (StateID, CountryID, StateName, StateCode) VALUES
(@StateID, @CountryID, @StateName, @StateCode);



CREATE PROCEDURE PR_State_UpdateByStateID
	@StateID INT,
	@StateName VARCHAR(100),
	@CountryID INT,
	@StateCode VARCHAR(50)
AS
UPDATE State SET 
	StateName = @StateName,
	CountryID = @CountryID,
	StateCode = @StateCode
WHERE StateID = @StateID;




CREATE PROCEDURE PR_State_DeleteByStateID
	@StateID INT
AS
DELETE FROM State WHERE StateID = @StateID;



CREATE PROCEDURE PR_City_SelectAll
AS
SELECT
	ci.CityID, ci.CityName, s.StateName, c.CountryName, ci.PinCode, ci.STDCode, ci.CreationDate
FROM City ci INNER JOIN State s 
ON ci.StateID = s.StateID
INNER JOIN Country c
ON s.CountryID = c.CountryID
ORDER BY c.CountryName, s.StateName, ci.CityName;



CREATE PROCEDURE PR_City_SelectByCityID
	@CityID INT
AS
SELECT
	ci.CityID, ci.CityName, s.StateName,  c.CountryName, ci.PinCode, ci.STDCode, ci.CreationDate
FROM City ci INNER JOIN State s 
ON ci.StateID = s.StateID
INNER JOIN Country c
ON s.CountryID = c.CountryID
WHERE CityID = @CityID
ORDER BY c.CountryName, s.StateName, ci.CityName;



CREATE PROCEDURE PR_City_Insert
	@CityName VARCHAR(100),
	@StateID INT,
	@PinCode VARCHAR(6),
	@StdCode VARCHAR(5)
AS
INSERT INTO City (CityName, StateID, PinCode, STDCode) VALUES
(@CityName, @StateID, @PinCode, @StdCode);



CREATE PROCEDURE PR_City_UpdateByCityID
	@CityID INT,
	@CityName VARCHAR(100),
	@StateID INT,
	@PinCode VARCHAR(6),
	@StdCode VARCHAR(5)
AS
UPDATE City
SET
	CityName = @CityName,
	StateID = @StateID,
	PinCode = @PinCode,
	STDCode = @StdCode
WHERE CityID = @CityID;




CREATE PROCEDURE PR_City_DeleteByCityID
	@CityID INT
AS
	DELETE FROM City where CityID = @CityID;






CREATE PROCEDURE PR_ContactCategory_SelectAll
AS
SELECT ContactCategoryID, ContactCategoryName, CreationDate
FROM ContactCategory
ORDER BY ContactCategoryName;



CREATE PROCEDURE PR_ContactCategory_SelectByContactCategoryID
	@ContactCategoryID INT
AS
SELECT ContactCategoryID, ContactCategoryName, CreationDate
FROM ContactCategory
WHERE ContactCategoryID = @ContactCategoryID
ORDER BY ContactCategoryName;





CREATE PROCEDURE PR_ContactCategory_Insert
	@ContactCategoryName VARCHAR(100)
AS
INSERT INTO ContactCategory (ContactCategoryName) VALUES
(@ContactCategoryName);




CREATE PROCEDURE PR_ContactCategory_UpdateByContactCategoryID
	@ContactCategoryID INT,
	@ContactCategoryName VARCHAR(100)
AS
UPDATE ContactCategory
SET ContactCategoryName = @ContactCategoryName
WHERE ContactCategoryID = @ContactCategoryID;



CREATE PROCEDURE PR_ContactCategory_DeleteByContactCategoryID
	@ContactCategoryID INT
AS
DELETE FROM ContactCategory
WHERE ContactCategoryID = @ContactCategoryID;




CREATE PROCEDURE PR_Contact_SelectAll
AS
SELECT 
	c.ContactID,
	c.ContactName,
	cc.ContactCategoryName,
	c.ContactNo,
	ct.CityName,
	s.StateName,
	cnt.CountryName,
	c.WhatsAppNo,
	c.BirthDate,
	c.Email,
	c.Age,
	c.Address,
	c.BloodGroup,
	c.FacebookID,
	c.LinkedINID,
	c.CreationDate
FROM Contact c
INNER JOIN ContactCategory cc
ON c.ContactCategoryID = cc.ContactCategoryID
INNER JOIN City ct 
ON c.CityID = ct.CityID
INNER JOIN State s
ON s.StateID = ct.StateID
INNER JOIN Country cnt
ON cnt.CountryID = c.CountryID
ORDER BY cnt.CountryName, s.StateName, ct.CityName, cc.ContactCategoryName, c.ContactName;


CREATE PROCEDURE PR_Contact_SelectByContactID
	@ContactID INT
AS
SELECT 
	c.ContactID,
	c.ContactName,
	cc.ContactCategoryName,
	c.ContactNo,
	ct.CityName,
	s.StateName,
	cnt.CountryName,
	c.WhatsAppNo,
	c.BirthDate,
	c.Email,
	c.Age,
	c.Address,
	c.BloodGroup,
	c.FacebookID,
	c.LinkedINID,
	c.CreationDate
FROM Contact c
INNER JOIN ContactCategory cc
ON c.ContactCategoryID = cc.ContactCategoryID
INNER JOIN City ct 
ON c.CityID = ct.CityID
INNER JOIN State s
ON s.StateID = ct.StateID
INNER JOIN Country cnt
ON cnt.CountryID = c.CountryID

WHERE ContactID = @ContactID

ORDER BY cnt.CountryName, s.StateName, ct.CityName, cc.ContactCategoryName, c.ContactName;





CREATE PROCEDURE PR_Contact_Insert
	@CountryID INT,
	@StateID INT,
	@CityID INT,
	@ContactCategoryID INT,
	@ContactName VARCHAR(250),
	@ContactNo VARCHAR(250),
	@WhatsAppNo VARCHAR(250),
	@BirthDate DATETIME,
	@Email VARCHAR(250),
	@Age INT,
	@Address VARCHAR(500),
	@BloodGroup VARCHAR(50),
	@FacebookID VARCHAR(250),
	@LinkedINID VARCHAR(250)
AS
INSERT INTO Contact
(
	CountryID,
	StateID,
	CityID,
	ContactCategoryID,
	ContactName,
	ContactNo,
	WhatsAppNo,
	BirthDate,
	Email,
	Age,
	Address,
	BloodGroup,
	FacebookID,
	LinkedINID
)
VALUES
(
	@CountryID,
	@StateID,
	@CityID,
	@ContactCategoryID,
	@ContactName,
	@ContactNo,
	@WhatsAppNo,
	@BirthDate,
	@Email,
	@Age,
	@Address,
	@BloodGroup,
	@FacebookID,
	@LinkedINID
);







CREATE PROCEDURE PR_Contact_UpdateByContactID
	@ContactID INT,
	@CountryID INT,
	@StateID INT,
	@CityID INT,
	@ContactCategoryID INT,
	@ContactName VARCHAR(250),
	@ContactNo VARCHAR(250),
	@WhatsAppNo VARCHAR(250),
	@BirthDate DATETIME,
	@Email VARCHAR(250),
	@Age INT,
	@Address VARCHAR(500),
	@BloodGroup VARCHAR(50),
	@FacebookID VARCHAR(250),
	@LinkedINID VARCHAR(250)
AS
UPDATE Contact
SET
	CountryID = @CountryID,
	StateID = @StateID,
	CityID = @CityID,
	ContactCategoryID = @ContactCategoryID,
	ContactName = @ContactName,
	ContactNo = @ContactNo,
	WhatsAppNo = @WhatsAppNo,
	BirthDate = @BirthDate,
	Email = @Email,
	Age = @Age,
	Address = @Address,
	BloodGroup = @BloodGroup,
	FacebookID = @FacebookID,
	LinkedINID = @LinkedINID
WHERE ContactID = @ContactID;










CREATE PROCEDURE PR_Contact_DeleteByContactID
	@ContactID INT
AS
DELETE FROM Contact WHERE ContactID = @ContactID;










ALTER PROCEDURE [dbo].[PR_State_SelectByCountryID]
	@CountryID INT
AS
SELECT StateID, StateName from State
GROUP BY CountryID, StateID, StateName
HAVING CountryID = @CountryID
ORDER BY StateName;