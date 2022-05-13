--use master
GO
--ALTER DATABASE ProjektSemestralnyDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
--DROP DATABASE ProjektSemestralnyDB
GO

use master
GO
CREATE DATABASE ProjektSemestralnyDB
GO
USE ProjektSemestralnyDB
GO

CREATE TABLE NewProject
(
id_project int identity(1,1) primary key,
projectName varchar(20) NOT NULL,
boardSize int NOT NULL,
squareSize int NOT NULL,
description bit NOT NULL,
descNew nvarchar(200) NOT NULL
);
GO

CREATE TABLE SquareFill
(
id_project int NOT NULL,
id_defaultSquareFill int identity(1,1) primary key,
defaultRed tinyint NOT NULL DEFAULT 0,
defaultGreen tinyint NOT NULL DEFAULT 0,
defaultBlue tinyint NOT NULL DEFAULT 0,
CONSTRAINT Key_SquareFill_id_project FOREIGN KEY(id_project) REFERENCES NewProject
);
GO
CREATE TABLE DefaultColors
(
id_defaultColor int identity(1,1) primary key,
id_project int NOT NULL,
rgb_red tinyint NOT NULL DEFAULT 255,
rgb_green tinyint NOT NULL DEFAULT 255,
rgb_blue tinyint NOT NULL DEFAULT 255,
positionNumber tinyint NOT NULL
CONSTRAINT Key_DefaultColors_id_project FOREIGN KEY(id_project) REFERENCES NewProject
);
GO

CREATE TABLE GlobalValues
(
id_values int primary key,
actualProject int NOT NULL
);
GO
CREATE TABLE GlobalColors
(
id_color int identity(1,1) primary key,
id_values int, 
choosenColorRed tinyint NOT NULL DEFAULT 255,
choosenColorGreen tinyint NOT NULL DEFAULT 255,
choosenColorBlue tinyint NOT NULL DEFAULT 255,
CONSTRAINT Key_GlobalColors_id_values FOREIGN KEY(id_values) REFERENCES GlobalValues
);
GO

CREATE TABLE NewColor
(
id_newColor int identity(1,1) primary key,
rgb_red tinyint NOT NULL DEFAULT 255,
rgb_green tinyint NOT NULL DEFAULT 255,
rgb_blue tinyint NOT NULL DEFAULT 255
);
GO

CREATE TABLE BoardColors
(
id_boardColors int identity(1,1) primary key,
id_project int NOT NULL,
rgb_red tinyint NOT NULL DEFAULT 255,
rgb_green tinyint NOT NULL DEFAULT 255,
rgb_blue tinyint NOT NULL DEFAULT 255,
square_number int NOT NULL
CONSTRAINT Key_BoardColors_id_project FOREIGN KEY(id_project) REFERENCES NewProject
);

GO

CREATE TABLE AnimationBoard400
(
id_animation int identity(0,1) primary key,
id_project int NOT NULL,
boardSize int NOT NULL,
CONSTRAINT Key_AnimationBoard400_id_project FOREIGN KEY(id_project) REFERENCES NewProject
);

CREATE TABLE AnimationBoard640
(
id_animation int identity(0,1) primary key,
id_project int NOT NULL,
boardSize int NOT NULL,
CONSTRAINT Key_AnimationBoard640_id_project FOREIGN KEY(id_project) REFERENCES NewProject
);

CREATE TABLE AnimationBoard800
(
id_animation int identity(0,1) primary key,
id_project int NOT NULL,
boardSize int NOT NULL,
CONSTRAINT Key_AnimationBoard800_id_project FOREIGN KEY(id_project) REFERENCES NewProject
);

--Select Top 2000 * FROM BoardColors