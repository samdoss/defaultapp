alter PROCEDURE [dbo].[spGetMaterials] 
(
	@ProductID	int = null
)
AS
BEGIN	
	SELECT 
		M.MaterialID,
		M.ProductID,		
		M.MaterialDescription,
		M.MaterialCode,
		M.MaterialQuality,
		M.TaxInclusive,
		M.TaxID,
		Tx.TaxName,
		U.Unit,
		Tx.TaxPercentage,
		M.MaterialRate,
		M.UnitID,
		isnull(M.SpecialInstruction,'') as SpecialInstruction,
		M.IsEnabled,
		M.AuditUserID,
		M.AuditDate
	FROM Material M
	left join Unit U on U.UnitID = M.UnitID
	left join Tax Tx on Tx.TaxId = M.TaxID
	WHERE M.IsEnabled = 1 and M.ProductID = @ProductID
	ORDER BY M.MaterialID
END