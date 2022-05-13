CREATE TABLE [dbo].[NewProject] (
    [id_project]  INT            IDENTITY (1, 1) NOT NULL,
    [projectName] VARCHAR (20)   NOT NULL,
    [boardSize]   INT            NOT NULL,
    [squareSize]  INT            NOT NULL,
    [description] BIT            NOT NULL,
    [descNew]     NVARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_project] ASC)
);

