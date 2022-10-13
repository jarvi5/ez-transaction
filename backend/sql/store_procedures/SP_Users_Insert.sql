USE `EZ_TRANSACTION`;
DROP procedure IF EXISTS `SP_Users_Insert`;

DELIMITER $$
USE `EZ_TRANSACTION`$$
CREATE PROCEDURE SP_Users_Insert (
	IN email varchar(250),
    IN lastName varchar(125),
    IN firstName varchar(125),
    IN dni varchar(20),
    IN passwordHash varbinary(250),
    IN passwordSalt varbinary(250)
)	
BEGIN
INSERT INTO Users
( Email, LastName, FirstName, DNI, PasswordHash, PasswordSalt)
VALUES
( email, lastName, firstName, dni, passwordHash, passwordSalt);
SELECT 
    Id,
    Email,
    LastName,
    FirstName,
    DNI,
    PasswordHash,
    PasswordSalt
FROM
    Users
WHERE
    ID = LAST_INSERT_ID();
END$$

DELIMITER ;