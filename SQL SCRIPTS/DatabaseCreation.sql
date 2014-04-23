USE emspss;

CREATE TABLE EMSUser
(
	userId VARCHAR(50),
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	userPassword VARCHAR(30),
	userType VARCHAR(30)
);

CREATE TABLE Employee
(
	eId INT NOT NULL AUTO_INCREMENT,
	hiringCompanyName VARCHAR(50),
	employFirstName VARCHAR(50),
	employLastName VARCHAR(50),
	employSIN VARCHAR(50),
	employeeStatus VARCHAR(50),
	employeeType VARCHAR(50),
	dateOfBirth DATE,
	PRIMARY KEY (eid)
);

CREATE TABLE FullTimeEmployee
(
	EId INT,
	dateOfHire DATE,
	dateOfTerm DATE,
	reason VARCHAR(50),
	salary DECIMAL(8,2),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);

CREATE TABLE PartTimeEmployee
(
	EId INT,
	dateOfHire DATE,
	dateOfTerm DATE,
	reason VARCHAR(50),
	hourlyRate DECIMAL(4,2),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);

CREATE TABLE SeasonalEmployee
(
	EId INT,
	dateOfHire DATE,
	dateOfTerm DATE,
	piecePay DECIMAL(4,2),
	reason VARCHAR(50),
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