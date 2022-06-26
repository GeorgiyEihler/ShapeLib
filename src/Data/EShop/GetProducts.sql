CREATE PROCEDURE [dbo].[GetProducts]
	
AS

	SELECT P.ProductName, C.CategoryName FROM Products P
	LEFT JOIN 
		(SELECT PC.IdProuct, C.CategoryName FROM ProductsCategories PC
			INNER JOIN Categories C ON PC.IdCategory = C.Id) C
	ON C.IdProuct = P.Id

RETURN 0
