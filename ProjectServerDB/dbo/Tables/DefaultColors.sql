CREATE TABLE [dbo].[DefaultColors] (
    [id_defaultColor] INT     IDENTITY (1, 1) NOT NULL,
    [id_project]      INT     NOT NULL,
    [rgb_red]         TINYINT DEFAULT ((255)) NOT NULL,
    [rgb_green]       TINYINT DEFAULT ((255)) NOT NULL,
    [rgb_blue]        TINYINT DEFAULT ((255)) NOT NULL,
    [positionNumber]  TINYINT NOT NULL,
    PRIMARY KEY CLUSTERED ([id_defaultColor] ASC),
    CONSTRAINT [Key_DefaultColors_id_project] FOREIGN KEY ([id_project]) REFERENCES [dbo].[NewProject] ([id_project])
);

