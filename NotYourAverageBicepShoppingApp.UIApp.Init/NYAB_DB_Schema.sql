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

INSERT INTO [ProductsNYAB].[dbo].Products (Product_Name, Product_Price, Product_Image, Product_Overview, Product_Benefits) 
	VALUES ( 
		'Creatine Monohydrate Capsules', 
		99.99, 
		'https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/android/android-plain.svg', 
		'Our creatine monohydrate tablets are a super-convenient way to get the scientifically proven benefits of creatine, helping you to improve your performance workout after workout.
		Creatine has been shown to increase physical performance in successive bursts of short-term, high-intensity exercise,1 making this the perfect supplement to boost your training and help you reach fitness goals.  
		Getting creatine from your diet alone can be difficult as it’s mainly found in meat and fish — our tablets provide a quick way to hit your daily requirements without the fuss of meal prep, plus they’re vegetarian-friendly.',
		'Ideal for power based sports
		1 tablet gives 1g Creatine
		Can help improve strength and power'
)
INSERT INTO [ProductsNYAB].[dbo].Products (Product_Name, Product_Price, Product_Image, Product_Overview, Product_Benefits) 
	VALUES ( 
		'Essential BCAA Tablets', 
		24.99, 
		'https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/threedsmax/threedsmax-original.svg', 
		'The essential amino acid supplement, containing an optimal 2:1:1 ratio of leucine, isoleucine, and valine. Each of these naturally occur in protein, which helps to build and repair new muscle.
		These three essential amino acids can’t be produced by your body, so they must come from your diet — making our super-convenient tablets a must-have, whether you’re looking to gain muscle, tone-up, or lose weight.
		It also includes the essential vitamin B6 to help keep you sharp, your defences high, and always feeling on top of your game in and out of the gym.',
		'Helps maintain body tissue
		Can boost lean mass
		Extremely popular amino acids'
)
INSERT INTO [ProductsNYAB].[dbo].Products (Product_Name, Product_Price, Product_Image, Product_Overview, Product_Benefits) 
	VALUES ( 
		'Pre-Workout Gummies', 
		29.99, 
		'https://cdn.jsdelivr.net/gh/devicons/devicon@latest/icons/apacheairflow/apacheairflow-plain.svg', 
		'Our powerful Pre-Workout Gummies are packed with a whole host of widely researched ingredients — including citrulline, taurine, B vitamins, and caffeine to take your training to the next level.
		To help you get the most from every session and push beyond your limits, each four gummy serving delivers 20mg of caffeine, which helps improve your endurance performance and capacity. And, caffeine will make sure nothing gets in the way of your focus.
		Plus, there’s the added vitamin B6 helps to reduce tiredness and fatigue,3 contribute to normal psychological performance, while supporting the normal function of the immune system.
		But, that’s not all. We’ve added 800mg of citrulline and 400mg of taurine, a naturally occurring amino acid, that’s found in high concentrations in white blood cells, skeletal muscles, central nervous system, and heart muscles.',
		'Delicious blueberry flavour
		Convenient for on-the-go use
		20mg of caffeine per servingr'
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
Quantity int NOT NULL,
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
