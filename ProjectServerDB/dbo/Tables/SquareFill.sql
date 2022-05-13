CREATE TABLE [dbo].[SquareFill] (
    [id_project]           INT     NOT NULL,
    [id_defaultSquareFill] INT     IDENTITY (1, 1) NOT NULL,
    [defaultRed]           TINYINT DEFAULT ((0)) NOT NULL,
    [defaultGreen]         TINYINT DEFAULT ((0)) NOT NULL,
    [defaultBlue]          TINYINT DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_defaultSquareFill] ASC),
    CONSTRAINT [Key_SquareFill_id_project] FOREIGN KEY ([id_project]) REFERENCES [dbo].[NewProject] ([id_project])
);

