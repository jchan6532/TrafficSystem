DROP DATABASE IF EXISTS trafficsystem;
CREATE DATABASE trafficsystem;
USE trafficsystem;

#VEHICLE TABLE
CREATE TABLE IF NOT EXISTS Vehicle (
    `VehicleID` INT NOT NULL AUTO_INCREMENT,
    `VIN` VARCHAR(20) NOT NULL,
    `Type` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`VehicleID`),
    UNIQUE INDEX `VehicleID_UNIQUE` (`VehicleID` ASC) VISIBLE);
    
INSERT INTO Vehicle (VehicleID, VIN, Type) VALUES(1, 'ABC', 'SEDAN');
INSERT INTO Vehicle (VehicleID, VIN, Type) VALUES(2, 'ABCD', 'SEDAN');