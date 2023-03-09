CREATE PROCEDURE [dbo].[VendorSearch]
	 @pageSize int
	,@pageNumber int
	,@sortColumn varchar(25)
	,@sortDirection varchar(4)
	,@filterByVendorType varchar(1) null
	,@filterByVendorNumber varchar(9) null
	,@filterBySequenceNumber varchar(3) null
	,@filterByPurchasingName varchar(255) null
AS
BEGIN
	WITH cte_primary AS
	(
		SELECT VendorId, 
		       VendorType, 
			   VendorNumber, 
			   SequenceNumber,
			   PurchasingNameLine1, 
			   StatusCode 
	   FROM Vendors
	   WHERE 
			ConfidentialVendorIndicator != 'Y' 
		AND	StatusCode ='A'
		AND	W9Indicator IN ('Y','T')
		AND	(@filterByVendorType IS NULL OR VendorType = @filterByVendorType) 
		AND (@filterByVendorNumber IS NULL OR VendorNumber = @filterByVendorNumber) 
		AND (@filterBySequenceNumber IS NULL OR SequenceNumber = @filterBySequenceNumber) 
		AND (@filterByPurchasingName IS NULL OR PurchasingNameLine1 LIKE '%' + @filterByPurchasingName + '%') --TODO full text!, when not on SSMS express
	),
	cte_results AS 
	(
		select
		row_number() over
				(
					order by
					case when (@sortColumn = 'VendorType' and @sortDirection = 'ASC') then VendorType end asc,
					case when (@sortColumn = 'VendorType' and @sortDirection = 'DESC') then VendorType end desc,

					case when (@sortColumn = 'VendorNumber' and @sortDirection = 'ASC') then VendorNumber end asc,
					case when (@sortColumn = 'VendorNumber' and @sortDirection = 'DESC') then VendorNumber end desc,
					
					case when (@sortColumn = 'SequenceNumber' and @sortDirection = 'ASC') then SequenceNumber end asc,
					case when (@sortColumn = 'SequenceNumber' and @sortDirection = 'DESC') then SequenceNumber end desc,

					case when (@sortColumn = 'PurchasingNameLine1' and @sortDirection = 'ASC') then PurchasingNameLine1 end asc,
					case when (@sortColumn = 'PurchasingNameLine1' and @sortDirection = 'DESC') then PurchasingNameLine1 end desc

				) AS RowNum, t.*  from cte_primary t
	),
	cte_totalRows AS
	(
		SELECT COUNT(1) AS MaxRows
		FROM cte_results
	)

	SELECT MaxRows, t.*
	FROM cte_results t, cte_totalRows
	WHERE t.RowNum > @pageSize * (@pageNumber -1)
	AND t.RowNum <= @pageSize * @pageNumber
	ORDER BY RowNum
	OPTION (RECOMPILE);



END
GO
--GRANT EXECUTE ON  [dbo].[VendorSearch] TO [xxxxxxxxxx];
GO
