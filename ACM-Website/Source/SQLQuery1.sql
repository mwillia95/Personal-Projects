CREATE TABLE Users (
uname varchar(255) NOT NULL UNIQUE,
password_hash int NOT NULL,
fname varchar(255) NOT NULL,
lname varchar(255) NOT NULL
);

CREATE TABLE Admins (
uname varchar(255) NOT NULL UNIQUE);

CREATE TABLE Captains (
uname varchar(255) NOT NULL UNIQUE);