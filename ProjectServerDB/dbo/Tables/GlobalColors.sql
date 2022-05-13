CREATE TABLE [dbo].[GlobalColors] (
    [id_color]          INT     IDENTITY (1, 1) NOT NULL,
    [id_values]         INT     NULL,
    [choosenColorRed]   TINYINT DEFAULT ((255)) NOT NULL,
    [choosenColorGreen] TINYINT DEFAULT ((255)) NOT NULL,
    [choosenColorBlue]  TINYINT DEFAULT ((255)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_color] ASC),
    CONSTRAINT [Key_GlobalColors_id_values] FOREIGN KEY ([id_values]) REFERENCES [dbo].[GlobalValues] ([id_values])
);

