-- simple schema table pairing with practice for dynamic sql
declare @sql nvarchar(500)
declare @schemaName nvarchar(100)
declare @tableName nvarchar(100)
set @schemaName = 'todo'
set @tableName = 'Todo'

-- create task table
IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = @schemaName 
                 AND TABLE_NAME = @tableName))
BEGIN
    SET @sql = 'DROP TABLE ' + quotename(@tableName)
	EXEC(@sql)
END

-- create todo schema
IF (EXISTS (SELECT *
	FROM INFORMATION_SCHEMA.SCHEMATA
	WHERE SCHEMA_NAME = @schemaName))
BEGIN
	SET @sql = 'DROP SCHEMA ' + quotename(@SchemaName)
	EXEC(@sql)
END
	SET @sql = 'CREATE SCHEMA ' + quotename(@SchemaName)
	EXEC(@sql)

SET @sql = 'CREATE TABLE ' + quotename(@schemaName) + '.' + quotename(@tableName) + '(
    TaskId INT IDENTITY(1, 1) NOT NULL,
    CONSTRAINT PK_Task_TaskID PRIMARY KEY CLUSTERED (TaskId),
	Name NVARCHAR(100) NOT NULL,
	Description NVARCHAR(300) NOT NULL
)'
GO

insert into todo.Task (Name, Description)
values
	('Make fondue', 'make the fondue following the directions')

SELECT * FROM todo.Task
