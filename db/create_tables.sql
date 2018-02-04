BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `Status` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`name`	TEXT
);
CREATE TABLE IF NOT EXISTS `Card` (
	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`title`	TEXT NOT NULL,
	`deadline`	TEXT,
	`status`	INTEGER NOT NULL,
	`description`	TEXT,
	`links`	TEXT,
	FOREIGN KEY(`status`) REFERENCES `Status`(`id`)
);
COMMIT;
