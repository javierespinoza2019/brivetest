-- =============================================
-- Author:		Javier Espinoza
-- Create date: 2021-04-04
-- Description:	CRUD de Inventory
-- =============================================
CREATE PROCEDURE [dbo].[USP_CRUDInventory](
@Id BIGINT=NULL,
@StoreId INT=NULL,
@TransactionDate DATETIME=NULL,
@Barcode VARCHAR(20)=NULL,
@Quantity INT=NULL,
@ProductName VARCHAR(200)=NULL
,@Option INT = 0
,@PageNumber INT = 0
,@RecordsPerPage INT = 0
,@ReturnAll BIT = 0)
AS
BEGIN
	IF @Option=1 BEGIN -->Accion para crear nuevo registro
		BEGIN TRY
			INSERT INTO [Inventory]([StoreId],[TransactionDate],[Barcode],[Quantity]) 
			VALUES (@StoreId,@TransactionDate,@Barcode,@Quantity)
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
			UPDATE TOP(1) [Inventory] SET
				[StoreId]=ISNULL(@StoreId,[StoreId]),
				[TransactionDate]=ISNULL(@TransactionDate,[TransactionDate]),
				[Barcode]=ISNULL(@Barcode,[Barcode]),
				[Quantity]=ISNULL(@Quantity,[Quantity])
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
			With InventoryActived As
			(
				SELECT DISTINCT
					P.[Barcode],
					P.[Name] AS ProductName,
					P.UnitPrice,
					dbo.CalculateExistenceByBarcode(P.Barcode, @StoreId) AS Existence,
					S.[Name] AS StoreName
				FROM [Inventory] I WITH(NOLOCK)
				FULL OUTER JOIN Product P WITH(NOLOCK) ON P.Barcode = I.[Barcode] AND I.StoreId = @StoreId
				LEFT JOIN Store S WITH(NOLOCK) on S.Id = COALESCE(I.StoreId,@StoreId) 
				WHERE ((COALESCE(@ProductName,'') = '') OR (P.[Name] LIKE '%' + @ProductName + '%'))
					AND COALESCE(P.Barcode,'') != ''
			),
			RecordCount AS (SELECT TOP(1) COUNT(1) As TotalRecords FROM InventoryActived)
			Select *
			From InventoryActived, RecordCount
			Order By StoreName, ProductName ASC
			OFFSET (@PageNumber - 1) * @RecordsPerPage ROWS
			FETCH NEXT @RecordsPerPage ROWS ONLY
			FOR JSON PATH, INCLUDE_NULL_VALUES
		END
		ELSE BEGIN
			With InventoryActived As
			(
				SELECT DISTINCT
					P.[Barcode],
					P.[Name] AS ProductName,
					P.UnitPrice,
					dbo.CalculateExistenceByBarcode(P.Barcode, @StoreId) AS Existence,
					S.[Name] AS StoreName
				FROM [Inventory] I WITH(NOLOCK)
				FULL OUTER JOIN Product P WITH(NOLOCK) ON P.Barcode = I.[Barcode] AND I.StoreId = @StoreId
				LEFT JOIN Store S WITH(NOLOCK) on S.Id = COALESCE(I.StoreId,@StoreId) 
				WHERE ((COALESCE(@ProductName,'') = '') OR (P.[Name] LIKE '%' + @ProductName + '%'))
					AND COALESCE(P.Barcode,'') != ''
			),
			RecordCount AS (SELECT TOP(1) COUNT(1) As TotalRecords FROM InventoryActived)
			Select *
			From InventoryActived, RecordCount
			Order By StoreName, ProductName ASC
			OFFSET (@PageNumber - 1) * @RecordsPerPage ROWS
			FETCH NEXT @RecordsPerPage ROWS ONLY
			FOR JSON PATH, INCLUDE_NULL_VALUES
		END
	END
	IF @Option=5 BEGIN -->Accion para extaer datos por ID
		SELECT TOP(1) [Id],[StoreId],[TransactionDate],[Barcode],[Quantity]
		FROM [Inventory] WITH(NOLOCK)
		WHERE [Id]=@Id
	END
	IF @Option=7 BEGIN -->Accion para borrar una registro (borrado físico)
		BEGIN TRY
			DELETE TOP(1) FROM [Inventory]
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
END
