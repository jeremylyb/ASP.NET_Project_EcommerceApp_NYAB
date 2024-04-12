CREATE DATABASE ProductsNYAB
GO

USE ProductsNYAB
GO


CREATE TABLE [ProductsNYAB].[dbo].Products (
    Product_Id int NOT NULL PRIMARY KEY IDENTITY(50001, 1),
    Product_Name nvarchar(300) NOT NULL,
    Product_Price decimal(10,2) NOT NULL,
    Product_Image nvarchar(max) NOT NULL,
	Product_Overview nvarchar(max) NOT NULL,
	Product_Benefits nvarchar(max) NOT NULL
);
GO
--Example Data...
INSERT INTO [ProductsNYAB].[dbo].Products (Product_Name, Product_Price, Product_Image, Product_Overview, Product_Benefits) 
	VALUES ( 
		'Impact Whey Protein', 
		45.99, 
		'https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/alpinejs/alpinejs-original.svg', 
		'Premium whey packed with 23g of protein per serving, for the everyday protein you need from a quality source — with all-natural nutritionals, it is ideal for all of your fitness goals.
		Get yours in over 40 flavours, with delicious favourites including Chocolate, Vanilla, and Strawberry Cream.
		Want more information on protein powder, its benefits, and guidance on which one''s best for you? Check out our Protein Guide.',
		'21g protein per serving
		4.5g BCAAs
		Low in sugar'
)
INSERT INTO [ProductsNYAB].[dbo].Products (Product_Name, Product_Price, Product_Image, Product_Overview, Product_Benefits) 
	VALUES ( 'Protein Brownie', 
			85.49, 
			'https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/aarch64/aarch64-plain.svg',
			'With up to 75% less sugar than standard supermarket alternatives, enjoy an afternoon pick-me-up without ruining all your hard-earned progress.
			Created with heaps of delicious cocoa powder and baked with sweet chocolate chips, our Protein Brownies are packed with 23g of protein for an indulgent everyday treat.',
			'23g protein per brownie,
			Only 4g sugar in each serving,
			Delicious healthy alternative to standard brownies'
)
INSERT INTO [ProductsNYAB].[dbo].Products (Product_Name, Product_Price, Product_Image, Product_Overview, Product_Benefits) 
	VALUES ( 'Essential Omega-3', 
			100.68, 
			'https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/akka/akka-original.svg',
			'Omega-3s are a group of essential fatty acids that play numerous important roles in your body. They occur naturally in one of two forms, triglycerides or phospholipids. As your body cannot produce omega-3s on its own, these fatty acids must be sourced from your diet.
			Three important omega-3 essential fatty acids include ALA (alpha-linoleic acid), EPA (eicosapentaenoic acid) and DHA (docosahexaenoic acid). DHA and EPA play a vital role in human physiology as they have benefits such as helping to support heart health.
			Omega-3s are essential polyunsaturated fatty acids that your body can’t make itself, so you have to get them from your diet. They’re found naturally in fish oil — meaning it can be difficult to get enough of it from what you eat alone, if you don’t eat enough fish in your diet.',
			'18% EPA / 12% DHA
			Contributes to normal function of the heart
			Convenient softgel'
			)
INSERT INTO [ProductsNYAB].[dbo].Products (Product_Name, Product_Price, Product_Image, Product_Overview, Product_Benefits) 
	VALUES ( 'MultiVitamin', 
			36.99, 
			'https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/algolia/algolia-original.svg',
			'Each tablet is packed with seven essential vitamins including vitamin A, C, D3, E, thiamine, riboflavin and niacin — helping to support your everyday wellbeing and keep up with a hectic training schedule.
			Discover more from our Myvitamins range here.',
			'Each tablet provides high amount of key vitamins
			Great way to increase daily vitamin intake
			Easy-to-take tablet at a low price'
			)
GO 

CREATE DATABASE CartsNYAB
GO

USE CartsNYAB
GO

CREATE TABLE [CartsNYAB].[dbo].Carts (
Cart_Id int NOT NULL PRIMARY KEY IDENTITY (101, 1),
Cart_Price decimal(10, 2) NULL)
GO
CREATE TABLE [CartsNYAB].[dbo].Cart_Items (
Cart_Item_Id int NOT NULL PRIMARY KEY IDENTITY(2000001, 1),
Product_Id int NOT NULL,
Fk_Cart_Id int NOT NULL FOREIGN KEY (Fk_Cart_Id) REFERENCES
[CartsNYAB].[dbo].Carts(Cart_Id))
GO
--Example Data...
INSERT INTO [CartsNYAB].[dbo].Carts (Cart_Price) VALUES (NULL)
GO
INSERT INTO [CartsNYAB].[dbo].Cart_Items (Product_Id, Fk_Cart_Id) VALUES (50001, 101)
GO






--Drop TABLE [Employee];
--DELETE FROM Departments WHERE DEPT_NO NOT IN (SELECT FK_DEPT_NO FROM Employee);

--truncate TABLE [Departments];

--select d.DEPT_NO, d.DEPT_NAME, e.EMP_ID, e.EMP_FST, e.EMP_LST FROM Departments d LEFT JOIN Employee e on d.DEPT_NO = e.FK_DEPT_NO;

--Select e.EMP_ID, e.EMP_FST, e.EMP_LST, e.FK_DEPT_NO, d.DEPT_NAME FROM Employee e LEFT JOIN Departments d on e.FK_DEPT_NO=d.DEPT_NO WHERE EMP_FST='Jennifer' AND EMP_LST='Teo';	


--INSERT INTO [CartsAcme].[dbo].Cart_Items (Product_Id, Fk_Cart_Id) VALUES (50001, 101)
--GO
--INSERT INTO [CartsAcme].[dbo].Cart_Items (Product_Id, Fk_Cart_Id) VALUES (50001, 101)
--GO

CREATE DATABASE [OrdersNYAB]
GO

CREATE TABLE [OrdersNYAB].[dbo].Orders (
Order_Id int NOT NULL PRIMARY KEY IDENTITY (7001, 1),
Customer_Name NVARCHAR(50) NOT NULL ,
Cart_Id int NOT NULL)
GO
--Example Data...
INSERT INTO [OrdersNYAB].[dbo].Orders (Customer_Name, Cart_Id) VALUES ('John Doe', 101)
GO


USE CartsNYAB
GO
select * from Carts
go
select * from Cart_Items
go

USE ProductsNYAB
GO
select * from Products
go
USE OrdersNYAB
GO
select * from Orders
go
