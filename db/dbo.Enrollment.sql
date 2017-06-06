CREATE TABLE [dbo].[Enrollment] (
    [Id]       INT IDENTITY (1, 1) NOT NULL,
    [reg]      INT NOT NULL,
    [timeslot] INT NOT NULL,
    [user]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Enrollment_Period] FOREIGN KEY ([timeslot]) REFERENCES [dbo].[Period] ([Id]),
    CONSTRAINT [FK_Enrollment_SignUp] FOREIGN KEY ([reg]) REFERENCES [dbo].[Activity] ([Id])
);

