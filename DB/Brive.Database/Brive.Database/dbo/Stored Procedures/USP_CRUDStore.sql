-- =============================================
-- Author:		Javier Espinoza
-- Create date: 2021-04-04
-- Description:	CRUD de Store
-- =============================================
CREATE PROCEDURE [dbo].[USP_CRUDStore](
@Id INT=NULL,
@Name VARCHAR(50)=NULL
,@Option INT = 0
,@PageNumber INT = 0
,@RecordsPerPage INT = 0
,@ReturnAll BIT = 0)
AS
BEGIN
	IF @Option=1 BEGIN -->Accion para crear nuevo registro
		BEGIN TRY
			INSERT INTO [Store]([Name]) 
			VALUES (@Name)
			SELECT CAST(SCOPE_IDENTITY() AS BIGINT) as IdAfected
				,'Registro creado exitosamente...' as [Description]
				,1 as Success
		END TRY
		BEGIN CATCH
			SELECT
				 0 as IdAfected
				,ERROR_MESSAGE() as [Description]
				,0 as Success
		END CATCH
	END
	IF @Option=2 BEGIN -->Accion para actualizar registro
		BEGIN TRY
			UPDATE TOP(1) [Store] SET
				[Name]=ISNULL(@Name,[Name])
			WHERE [Id]=@Id
			SELECT @Id as IdAfected
				,'Registro actualizado exitosamente...' as [Description]
				,1 as Success
		END TRY
		BEGIN CATCH
			SELECT
				 0 as IdAfected
				,ERROR_MESSAGE() as [Description]
				,0 as Success
		END CATCH
	END
	IF @Option=4 BEGIN -->Accion para extraer datos paginados o sin paginar
		IF @ReturnAll=1 BEGIN
			With StoreActived As
			(
				SELECT S.[Id],
				S.[Name]
			FROM [Store] S WITH(NOLOCK)
 
			),
			RecordCount AS (SELECT TOP(1) COUNT(1) As TotalRecords FROM StoreActived)
			Select *
			From StoreActived, RecordCount
			Order By [Id] ASC
			OFFSET (@PageNumber - 1) * @RecordsPerPage ROWS
			FETCH NEXT @RecordsPerPage ROWS ONLY
			FOR JSON PATH, INCLUDE_NULL_VALUES
		END
		ELSE BEGIN
			With StoreActived As
			(
				SELECT S.[Id],
				S.[Name]
			FROM [Store] S WITH(NOLOCK)
 
			),
			RecordCount AS (SELECT TOP(1) COUNT(1) As TotalRecords FROM StoreActived)
			Select *
			From StoreActived, RecordCount
			Order By [Id] ASC
			OFFSET (@PageNumber - 1) * @RecordsPerPage ROWS
			FETCH NEXT @RecordsPerPage ROWS ONLY
			FOR JSON PATH, INCLUDE_NULL_VALUES
		END
	END
	IF @Option=5 BEGIN -->Accion para extaer datos por ID
		SELECT TOP(1) [Id],[Name]
		FROM [Store] WITH(NOLOCK)
		WHERE [Id]=@Id
	END
	IF @Option=7 BEGIN -->Accion para borrar una registro (borrado físico)
		BEGIN TRY
			DELETE TOP(1) FROM [Store]
			WHERE [Id]=@Id
			SELECT @Id as IdAfected
				,'Registro eliminado exitosamente...' as [Description]
				,1 as Success
		END TRY
		BEGIN CATCH
			SELECT
				 0 as IdAfected
				,ERROR_MESSAGE() as [Description]
				,0 as Success
		END CATCH
	END
	IF @Option=8 BEGIN -->Accion para traer una registro como cátalogo
		SELECT 
			[Id] AS Id,
			[Name] AS [Description]
		FROM [Store] WITH(NOLOCK)
		WHERE [Name] LIKE '%'+ISNULL(@Name,'')+'%' FOR JSON PATH, INCLUDE_NULL_VALUES
	END
END
