CREATE DATABASE Bank;

use master
go
drop database Bank
go

use Bank;

DROP TABLE Customer;

CREATE TABLE Customer (
    CustomerId INT NOT NULL PRIMARY KEY,
    Name varchar(255),
    Email varchar(255),
    Password varchar(255),
);

INSERT INTO Customer VALUES (123, 'Vijay', 'vijay@gmail.com', 'Hello123@');

select * from Customer;


DROP TABLE Account;

CREATE TABLE Account (
    AccountId INT NOT NULL PRIMARY KEY,
	CustomerId INT CONSTRAINT FK_ACCOUNT FOREIGN KEY(CustomerId) REFERENCES Customer(CustomerId) NOT NULL,
    AccountNumber int,
);

INSERT INTO Account VALUES (456, 123, 9200);

select * from Account;


DROP TABLE AccountBalance;

CREATE TABLE AccountBalance (
	AccBalanceId INT NOT NULL PRIMARY KEY,
    AccountId INT CONSTRAINT FK_ACCOUNTBALANCE FOREIGN KEY(AccountId) REFERENCES Account(AccountId) NOT NULL,
	Balance INT NOT NULL
);

INSERT INTO AccountBalance VALUES (789, 456, 1800);

select * from AccountBalance;

SELECT cust.CustomerId, cust.Name, cust.Email, cust.Password, accbal.Balance FROM
Customer cust INNER JOIN Account acc ON cust.CustomerId=acc.CustomerId
INNER JOIN AccountBalance accbal ON acc.AccountId=accbal.AccountId
WHERE cust.CustomerId=123;