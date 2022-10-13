CREATE DATABASE IF NOT EXISTS EZ_TRANSACTION;
USE EZ_TRANSACTION;

CREATE TABLE IF NOT EXISTS Users (
    Id int NOT NULL AUTO_INCREMENT,
    Email varchar(250) NOT NULL,
    LastName varchar(125) NOT NULL,
    FirstName varchar(125) NOT NULL,
    DNI varchar(20) NOT NULL,
    PasswordHash varbinary(250) NOT NULL,
    PasswordSalt varbinary(250) NOT NULL,
    PRIMARY KEY (ID)
);

CREATE TABLE IF NOT EXISTS Cards (
    Id int NOT NULL AUTO_INCREMENT,
    UserId int NOT NULL,
    CardNumber varchar(16) NOT NULL,
    CardName varchar(125) NOT NULL,
    ExperationDate date NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);