CREATE PROCEDURE [dbo].[GetProduct]
	@ID INT
AS
	SELECT P.ProductName, C.CategoryName FROM Products P
	LEFT JOIN 
		(SELECT PC.IdProuct, C.CategoryName FROM ProductsCategories PC
			INNER JOIN Categories C ON PC.IdCategory = C.Id) C
	ON C.IdProuct = P.Id
	WHERE P.Id = @ID


RETURN 0
