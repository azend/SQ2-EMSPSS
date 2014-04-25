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
INSERT INTO Employee (hiringCompanyName, employFirstName, employLastName, employSIN, employeeStatus, employeeType, dateOfHire, dateOfTerm, dateOfBirth) VALUES
('Bob\'s Fish and Tackle', 'Bob', 'Smith', '555111228', 'ACTIVE', 'FULLTIME', '2005-01-01', NULL,  '1945-06-20'),
('VeraCorp Inc', 'Larry', 'Budmelman', '851222125', 'ACTIVE', 'FULLTIME', '1958-08-30', NULL, '1958-08-30'),
('FF-Fresh Fruit Corp', 'Frank', 'Findley', '995642352', 'INCOMPLETE', 'FULLTIME', '1999-12-31', NULL, NULL),
('Bob\'s Fish and Tackle', 'Darryl', 'Smith', '193456787', 'INACTIVE', 'FULLTIME', '2008-12-05', '2014-01-27', '1960-02-29'),
('Joe\'s Gas and Feed', 'Darryl', 'Smith', '193456787', 'ACTIVE', 'PARTTIME', '2010-11-25', NULL, '1960-02-29'),
('VeraCorp Inc', 'Sally', 'Struthers', '654852458', 'ACTIVE', 'PARTTIME', '2005-02-14', NULL, '1971-07-03'),
('Joe\'s Gas and Feed', 'Ted', 'Martin', '546511247', 'INCOMPLETE', 'PARTTIME', '2012-12-20', NULL, '1995-07-26'),
('VeraCorp Inc', 'Alice', 'Kramdon', '876543216', 'INACTIVE', 'PARTTIME', '1990-03-15', '2009-02-14', '1950-09-11'),
('FF-Fresh Fruit Corp', 'Tom', 'Joad', '325440550', 'ACTIVE', 'SEASONAL', NULL, NULL, '1980-10-20'),
('FF-Fresh Fruit Corp', 'Pa', 'Joad', '540654654', 'ACTIVE', 'SEASONAL', NULL, NULL, '1950-01-10'),
('FF-Fresh Fruit Corp', 'Al', 'Joad', '252352133', 'INCOMPLETE', 'SEASONAL', NULL, NULL, '1987-04-20'),
('FF-Fresh Fruit Corp', 'Noah', 'Joad', '984372367', 'INACTIVE', 'SEASONAL', NULL, NULL, '1975-09-22'),
('VeraCorp Inc', 'poneSDLC', '', '', 'ACTIVE', 'CONTRACT', '2002-11-01', '2014-05-30', '1958-05-05'),
('VeraCorp Inc', 'proFO-Code Inc', '', '', 'ACTIVE', 'CONTRACT', '2012-11-01', '2014-10-31', '2005-03-28'),
('VeraCorp Inc', 'Sally\'s Cleaning Services Ltd', '', '', 'INCOMPLETE', 'CONTRACT', NULL, NULL, '2010-06-15'),
('VeraCorp Inc', 'poneSDLC', '', '', 'INACTIVE', 'CONTRACT', '1992-11-01', '1998-05-30', '1958-05-05');

/* Load data into FullTimeEmployee */
INSERT INTO FullTimeEmployee (EId, reason, salary) VALUES
(0001, '', 45000.50),
(0002, '', 120560.00),
(0003, '', NULL),
(0004, 'FIRED', 32768.00);

/* Load Data into PartTimeEmployee */
INSERT INTO PartTimeEmployee (EId, reason, hourlyRate) VALUES
(0005, '', 10.25),
(0006, '', 12.56),
(0007, '', NULL),
(0008, 'RETIRED', 7.56);

/* Load data into SeasonalEmployee */
INSERT INTO SeasonalEmployee (EId, piecePay, reason) VALUES
(0009, 2.35, ''),
(0010, 3.10, ''),
(0011, 3.10, ''),
(0012, 1.56, 'SEASON-END');

/* Load data into ContractEmployee */
INSERT INTO ContractEmployee (EId, fixedAmount) VALUES
(0013, 650000.00),
(0014, 75000.00),
(0015, 20000.00),
(0016, 250000.00);

/* Enable foreign key checks */
SET FOREIGN_KEY_CHECKS=1;