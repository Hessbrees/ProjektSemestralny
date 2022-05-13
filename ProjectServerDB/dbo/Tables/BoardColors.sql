CREATE TABLE [dbo].[BoardColors] (
    [id_boardColors] INT     IDENTITY (1, 1) NOT NULL,
    [id_project]     INT     NOT NULL,
    [rgb_red]        TINYINT DEFAULT ((255)) NOT NULL,
    [rgb_green]      TINYINT DEFAULT ((255)) NOT NULL,
    [rgb_blue]       TINYINT DEFAULT ((255)) NOT NULL,
    [square_number]  INT     NOT NULL,
    PRIMARY KEY CLUSTERED ([id_boardColors] ASC),
    CONSTRAINT [Key_BoardColors_id_project] FOREIGN KEY ([id_project]) REFERENCES [dbo].[NewProject] ([id_project])
);

