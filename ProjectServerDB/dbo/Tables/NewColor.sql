CREATE TABLE [dbo].[NewColor] (
    [id_newColor] INT     IDENTITY (1, 1) NOT NULL,
    [rgb_red]     TINYINT DEFAULT ((255)) NOT NULL,
    [rgb_green]   TINYINT DEFAULT ((255)) NOT NULL,
    [rgb_blue]    TINYINT DEFAULT ((255)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_newColor] ASC)
);

