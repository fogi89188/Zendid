CREATE DATABASE IF NOT EXISTS zendid;
USE zendid;

CREATE TABLE IF NOT EXISTS Users (
id INT(16) UNSIGNED AUTO_INCREMENT PRIMARY KEY,
email VARCHAR(100) NOT NULL,
password VARCHAR(256),
isAdmin BOOL
);

TRUNCATE TABLE Users;

INSERT INTO `zendid`.`users` (`email`, `password`, `isAdmin`) VALUES ('admin', 'admin', true);
INSERT INTO `zendid`.`users` (`email`, `password`, `isAdmin`) VALUES ('user', 'user', false);
INSERT INTO `zendid`.`users` (`email`, `password`, `isAdmin`) VALUES ('user1', 'user1', false);
INSERT INTO `zendid`.`users` (`email`, `password`, `isAdmin`) VALUES ('user2', 'user2', false);
INSERT INTO `zendid`.`users` (`email`, `password`, `isAdmin`) VALUES ('user3', 'user3', false);
