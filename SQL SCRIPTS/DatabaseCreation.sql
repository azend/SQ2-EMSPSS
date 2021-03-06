DROP DATABASE IF exists emspss;
CREATE DATABASE emspss;


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
	dateOfHire DATE,
	dateOfTerm DATE,
	dateOfBirth DATE,
	PRIMARY KEY (eid)
);

CREATE TABLE FullTimeEmployee
(
	EId INT,
	reason VARCHAR(50),
	salary DECIMAL(14,2),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);

CREATE TABLE PartTimeEmployee
(
	EId INT,
	reason VARCHAR(50),
	hourlyRate DECIMAL(14,2),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);

CREATE TABLE SeasonalEmployee
(
	EId INT,
	season VARCHAR(50),
	piecePay DECIMAL(14,2),
	reason VARCHAR(50),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);

CREATE TABLE ContractEmployee
(
	EId INT,
	fixedAmount DECIMAL(14,2),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);

CREATE TABLE AuditLog
(
	auditLogId INT NOT NULL AUTO_INCREMENT,
	eId INT,
	action VARCHAR(50),
	userId VARCHAR(50),
	attributeChanged VARCHAR(50),
	oldValue VARCHAR(100),
	newValue VARCHAR(100),
	eventTime DATETIME,
	PRIMARY KEY (auditLogId),
	FOREIGN KEY (eId) REFERENCES Employee(eId)
);

create table workweek
(
 StartDate date not null,
 EndDate date ,
 primary key(StartDate)
);




CREATE TABLE WeeklyTimeCard
(
	HoursMonday double,
	HoursTuesday double,
	HoursWednesday double,
	HoursThursday double,
	HoursFriday double,
	HoursSaturday  double,
	HoursSunday double,
	EId INT,
	StartDate date,
	PRIMARY KEY (EId, StartDate),
	FOREIGN KEY (StartDate) REFERENCES workweek(StartDate),
	FOREIGN KEY (EId) REFERENCES Employee(eId)
);
