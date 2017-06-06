CREATE TABLE [dbo].[Activity] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [name]        NVARCHAR (50)  NOT NULL,
    [description] NVARCHAR (MAX) NULL,
    [lifetime]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SignUp_Period] FOREIGN KEY ([lifetime]) REFERENCES [dbo].[Period] ([Id]) ON DELETE CASCADE
);

