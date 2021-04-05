-- =============================================
-- Author:		Javier Espinoza
-- Create date: 04/04/2021
-- Description:	Calcula existencias de productos
-- =============================================
CREATE FUNCTION [dbo].[CalculateExistenceByBarcode]
(
	@Barcode VARCHAR(20),
	@StoreId INT
)
RETURNS INT
AS
BEGIN
	
	RETURN ISNULL((SELECT SUM(Quantity) FROM Inventory I with(nolock) where I.Barcode = @Barcode AND I.StoreId = @StoreId),0)

END