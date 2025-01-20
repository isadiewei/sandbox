-- create task table
IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'todo' 
                 AND TABLE_NAME = 'User'))
BEGIN
    DROP TABLE todo.[User]
END
GO
CREATE TABLE todo.[User] (
    UserId INT IDENTITY(1, 1) NOT NULL,
    CONSTRAINT PK_User_UserId PRIMARY KEY CLUSTERED (UserId),
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(300) NOT NULL
)
GO

insert into todo.[User] (Name, Description)
values
	('Ironsides', 'For Practice')

SELECT * FROM todo.[User]
