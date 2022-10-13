USE `EZ_TRANSACTION`;
DROP procedure IF EXISTS `SP_Users_IsRegistered`;

DELIMITER $$
USE `EZ_TRANSACTION`$$
CREATE PROCEDURE `SP_Users_IsRegistered` (IN email varchar(250))
BEGIN
SELECT COUNT(Email)
FROM Users
WHERE Users.Email = email;
END$$

DELIMITER ;