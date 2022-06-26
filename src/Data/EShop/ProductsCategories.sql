CREATE TABLE [dbo].[ProductsCategories]
(
	[IdCategory] INT CONSTRAINT FK_ProductsCategories_Categories FOREIGN KEY REFERENCES [dbo].[Categories]([Id])
		ON DELETE CASCADE ON UPDATE CASCADE,
	[IdProuct] INT CONSTRAINT FK_ProductsCategories_Products FOREIGN KEY REFERENCES [dbo].[Products]([Id])
		ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT PK_ProductsCategories PRIMARY KEY ([IdCategory], [IdProuct])
)
