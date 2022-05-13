CREATE TABLE [dbo].[AnimationBoard640] (
    [id_animation] INT IDENTITY (0, 1) NOT NULL,
    [id_project]   INT NOT NULL,
    [boardSize]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id_animation] ASC),
    CONSTRAINT [Key_AnimationBoard640_id_project] FOREIGN KEY ([id_project]) REFERENCES [dbo].[NewProject] ([id_project])
);

