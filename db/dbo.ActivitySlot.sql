CREATE TABLE [dbo].[ActivitySlot] (
    [activity] INT NOT NULL,
    [slot]     INT NOT NULL,
    CONSTRAINT [PK_SignUpSlots] PRIMARY KEY CLUSTERED ([activity] ASC, [slot] ASC),
    CONSTRAINT [FK_SignUpSlots_SignUp] FOREIGN KEY ([activity]) REFERENCES [dbo].[Activity] ([Id]),
    CONSTRAINT [FK_SignUpSlots_Period] FOREIGN KEY ([slot]) REFERENCES [dbo].[Period] ([Id])
);

