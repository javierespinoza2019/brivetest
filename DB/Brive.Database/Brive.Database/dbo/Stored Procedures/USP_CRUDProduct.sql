-- =============================================
-- Author:		Javier Espinoza
-- Create date: 2021-04-03
-- Description:	CRUD de Product
-- =============================================
CREATE PROCEDURE [dbo].[USP_CRUDProduct](
@Id BIGINT=NULL,
@Name VARCHAR(200)=NULL,
@UnitPrice DECIMAL(18,2)=NULL,
@Barcode VARCHAR(20)=NULL
,@Option INT = 0
,@PageNumber INT = 0
,@RecordsPerPage INT = 0
,@ReturnAll BIT = 0)
AS
BEGIN
	IF @Option=1 BEGIN -->Accion para crear nuevo registro
		BEGIN TRY
			INSERT INTO [Product]([Name],[UnitPrice],[Barcode]) 
			VALUES (@Name,@UnitPrice,@Barcode)
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
			UPDATE TOP(1) [Product] SET
				[Name]=ISNULL(@Name,[Name]),
				[UnitPrice]=ISNULL(@UnitPrice,[UnitPrice])
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
			With ProductActived As
			(
				SELECT P.[Id],
				P.[Name],
				P.[UnitPrice],
				P.[Barcode]
			FROM [Product] P WITH(NOLOCK)
 
			),
			RecordCount AS (SELECT TOP(1) COUNT(1) As TotalRecords FROM ProductActived)
			Select *
			From ProductActived, RecordCount
			Order By [Id] ASC
			OFFSET (@PageNumber - 1) * @RecordsPerPage ROWS
			FETCH NEXT @RecordsPerPage ROWS ONLY
			FOR JSON PATH, INCLUDE_NULL_VALUES
		END
		ELSE BEGIN
			With ProductActived As
			(
				SELECT P.[Id],
				P.[Name],
				P.[UnitPrice],
				P.[Barcode]
			FROM [Product] P WITH(NOLOCK)
 
			),
			RecordCount AS (SELECT TOP(1) COUNT(1) As TotalRecords FROM ProductActived)
			Select *
			From ProductActived, RecordCount
			Order By [Id] ASC
			OFFSET (@PageNumber - 1) * @RecordsPerPage ROWS
			FETCH NEXT @RecordsPerPage ROWS ONLY
			FOR JSON PATH, INCLUDE_NULL_VALUES
		END
	END
	IF @Option=5 BEGIN -->Accion para extaer datos por ID
		SELECT TOP(1) [Id],[Name],[UnitPrice],[Barcode]
		FROM [Product] WITH(NOLOCK)
		WHERE [Id]=@Id
	END
	IF @Option=7 BEGIN -->Accion para borrar una registro (borrado físico)
		BEGIN TRY
			DELETE TOP(1) FROM [Product]
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
		FROM [Product] WITH(NOLOCK)
		WHERE [Name] LIKE '%'+ISNULL(@Name,'')+'%' FOR JSON PATH, INCLUDE_NULL_VALUES
	END
END
