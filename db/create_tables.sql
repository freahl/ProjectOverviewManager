BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `Status` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`name`	TEXT
);
INSERT INTO `Status` VALUES (1,'Inkö');
INSERT INTO `Status` VALUES (2,'Analys');
INSERT INTO `Status` VALUES (3,'Under arbete');
INSERT INTO `Status` VALUES (4,'Granskning');
INSERT INTO `Status` VALUES (5,'Klart');
CREATE TABLE IF NOT EXISTS `Card` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`title`	TEXT NOT NULL,
	`deadline`	TEXT,
	`status`	INTEGER NOT NULL,
	`description`	TEXT,
	`links`	TEXT,
	FOREIGN KEY(`status`) REFERENCES `Status`(`id`)
);
INSERT INTO `Card` VALUES (1,'Test','2018-02-04',1,'Här är en beskrivning','www.google.se');
INSERT INTO `Card` VALUES (2,'Test 2','2018-02-04',3,'Här är en beskrivning','www.google.se');
COMMIT;
