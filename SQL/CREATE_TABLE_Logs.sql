USE sandbox
GO
IF (EXISTS(SELECT *
	FROM INFORMATION_SCHEMA.TABLES
		WHERE SCHEMA_NAME = 'todo'
			AND TABLE_NAME = 'logs'))
BEGIN
	DROP TABLE todo.logs
END
GO

CREATE TABLE todo.Logs (
	[LogId] INT IDENTITY(1,1) NOT NULL,
	[Level] VARCHAR(MAX) NOT NULL,
	[CallSite] VARCHAR(MAX) NOT NULL,
	[Type] VARCHAR(MAX) NOT NULL,
	[Message] VARCHAR(MAX) NOT NULL,
	[StackTrace] VARCHAR(MAX) NOT NULL,
	[InnerException] VARCHAR(MAX) NOT NULL,
	[AdditionalInfo] VARCHAR(MAX) NOT NULL,
	[LoggedOnDate] DATETIME NOT NULL 
		CONSTRAINT [DF_Logs_LoggedOnDate] DEFAULT (GETUTCDATE()),
	CONSTRAINT [Pk_Logs_LogId] PRIMARY KEY CLUSTERED (LogId)
)
GO
