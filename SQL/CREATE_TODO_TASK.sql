-- simple schema table pairing with practice for dynamic sql
declare @sql nvarchar(500)
declare @schemaName nvarchar(100)
set @schemaName = 'todo'

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
GO
