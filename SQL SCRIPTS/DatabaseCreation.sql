CREATE DATABASE emspss;


USE emspss;

CREATE TABLE EMSUser
(
	userId NVARCHAR(50),
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	userPassword NVARCHAR(30),
	userType NVARCHAR(30)
);

CREATE TABLE Employee
(
	eId INT NOT NULL IDENTITY(1,1),
	hiringCompanyName NVARCHAR(50),
	employFirstName NVARCHAR(50),
	employLastName NVARCHAR(50),
	employSIN NVARCHAR(50),
	employeeStatus NVARCHAR(50),
	employeeType NVARCHAR(50),
	dateOfBirth DATE,
	PRIMARY KEY (eid)
);

CREATE TABLE FullTimeEmployee
(
	EId INT,
	dateOfHire DATE,
	dateOfTerm DATE,
	reason NVARCHAR(50),
	salary DECIMAL(8,2),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);

CREATE TABLE PartTimeEmployee
(
	EId INT,
	dateOfHire DATE,
	dateOfTerm DATE,
	reason NVARCHAR(50),
	hourlyRate DECIMAL(4,2),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);

CREATE TABLE SeasonalEmployee
(
	EId INT,
	dateOfHire DATE,
	dateOfTerm DATE,
	piecePay DECIMAL(4,2),
	reason NVARCHAR(50),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);

CREATE TABLE ContractEmployee
(
	EId INT,
	dateOfIncorp DATE,
	contractStart DATE,
	contractStop DATE,
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);