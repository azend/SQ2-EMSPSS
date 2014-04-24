/*
* File        : EMSPSS_Test_Inserts.sql
* Project     : SQII EMS-PSS
* Submit Date : April 25, 2014 
* Author      : Sean, Kelson, Constantine, Verdi, Richard
* Description : Populates the EMSPSS DB tables with test data.
*/
/* Temporarily disable foreign key checks */
SET FOREIGN_KEY_CHECKS=0;

/*  Load data into EMSUser (missing first/last names) */
INSERT INTO EMSUser (userId, userPassword, userType) VALUES
('general1', 'cr@zyR@bb1t', 'GENERAL'),
('general2', 'sly0ldF0x', 'GENERAL'),
('fredAnd', '3th31M3rtz', 'GENERAL'),
('admin', 'ems-pss-admin', 'ADMIN');

/*  Load data into Employee */
INSERT INTO Employee (hiringCompanyName, employFirstName, employLastName, employSIN, employeeStatus, employeeType, dateOfBirth) VALUES
('Bob\'s Fish and Tackle', 'Bob', 'Smith', '555111228', 'ACTIVE', 'FULLTIME', '1945-06-20'),
('VeraCorp Inc', 'Larry', 'Budmelman', '851222125', 'ACTIVE', 'FULLTIME', '1958-08-30'),
('FF-Fresh Fruit Corp', 'Frank', 'Findley', '995642352', 'INCOMPLETE', 'FULLTIME', NULL),
('Bob\'s Fish and Tackle', 'Darryl', 'Smith', '193456787', 'INACTIVE', 'FULLTIME', '1960-02-29'),
('Joe\'s Gas and Feed', 'Darryl', 'Smith', '193456787', 'ACTIVE', 'PARTTIME', '1960-02-29'),
('VeraCorp Inc', 'Sally', 'Struthers', '654852458', 'ACTIVE', 'PARTTIME', '1971-07-03'),
('Joe\'s Gas and Feed', 'Ted', 'Martin', '546511247', 'INCOMPLETE', 'PARTTIME', '1995-07-26'),
('VeraCorp Inc', 'Alice', 'Kramdon', '876543216', 'INACTIVE', 'PARTTIME', '1950-09-11'),
('FF-Fresh Fruit Corp', 'Tom', 'Joad', '325440550', 'ACTIVE', 'SEASONAL', '1980-10-20'),
('FF-Fresh Fruit Corp', 'Pa', 'Joad', '540654654', 'ACTIVE', 'SEASONAL', '1950-01-10'),
('FF-Fresh Fruit Corp', 'Al', 'Joad', '252352133', 'INCOMPLETE', 'SEASONAL', '1987-04-20'),
('FF-Fresh Fruit Corp', 'Noah', 'Joad', '984372367', 'INACTIVE', 'SEASONAL', '1975-09-22'),
('VeraCorp Inc', 'poneSDLC', '', '', 'ACTIVE', 'CONTRACT', NULL),
('VeraCorp Inc', 'proFO-Code Inc', '', '', 'ACTIVE', 'CONTRACT', NULL),
('VeraCorp Inc', 'Sally\'s Cleaning Services Ltd', '', '', 'INCOMPLETE', 'CONTRACT', NULL),
('VeraCorp Inc', 'poneSDLC', '', '', 'INACTIVE', 'CONTRACT', NULL);

/* Load data into FullTimeEmployee */
INSERT INTO FullTimeEmployee (EId, dateOfHire, dateOfTerm, reason, salary) VALUES
(0001, '2005-01-01', NULL, '', 45000.50),
(0002, '1958-08-30', NULL, '', 120560.00),
(0003, '1999-12-31', NULL, '', NULL),
(0004, '2008-12-05', '2014-01-27', 'FIRED', 32768.00);

/* Load Data into PartTimeEmployee */
INSERT INTO PartTimeEmployee (EId, dateOfHire, dateOfTerm, reason, hourlyRate) VALUES
(0005, '2010-11-25', NULL, '', 10.25),
(0006, '2005-02-14', NULL, '', 12.56),
(0007, '2012-12-20', NULL, '', NULL),
(0008, '1990-03-15', '2009-02-14', 'RETIRED', 7.56);

/* Load data into SeasonalEmployee */
INSERT INTO SeasonalEmployee (EId, dateOfHire, dateOfTerm, piecePay, reason) VALUES
(0009, NULL, NULL, 2.35, ''),
(0010, NULL, NULL, 3.10, ''),
(0011, NULL, NULL, 3.10, ''),
(0012, NULL, NULL, 1.56, 'SEASON-END');

/* Load data into ContractEmployee */
INSERT INTO ContractEmployee (EId, dateOfIncorp, contractStart, contractStop) VALUES
(0013, '1958-05-05', '2002-11-01', '2014-05-30'),
(0014, '2005-03-28', '2012-11-01', '2014-10-31'),
(0015, '2010-06-15', NULL, NULL),
(0016, '1958-05-05', '1992-11-01', '1998-05-30');

/* Enable foreign key checks */
SET FOREIGN_KEY_CHECKS=1;