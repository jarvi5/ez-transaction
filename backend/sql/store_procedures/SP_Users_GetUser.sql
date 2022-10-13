USE `EZ_TRANSACTION`;
DROP procedure IF EXISTS `SP_Users_GetUser`;

DELIMITER $$
USE `EZ_TRANSACTION`$$
CREATE PROCEDURE `SP_Users_GetUser` (IN email varchar(250))
BEGIN
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
    Users.Email = email;
END$$