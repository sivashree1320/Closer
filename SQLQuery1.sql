SELECT TOP (1000) [Id]
      ,[Name]
      ,[Price]
      ,[ImageUrl]
      ,[Category]
  FROM [Contactdb_v2].[dbo].[Products]


insert into [Contactdb_v2].[dbo].[Products] (name , price , ImageUrl , Category) values ('Formal White Shirt' , 999 ,'/images/formals.jpg' , 'Men');

insert into [Contactdb_v2].[dbo].[Products] (name , price , ImageUrl , Category) values ('Navy Blazer' , 2499 ,'/images/navy blazer.jpg' , 'Men');

insert into [Contactdb_v2].[dbo].[Products] (name , price , ImageUrl , Category) values ('Black Jeans' , 999 ,'/images/black jean.jpeg' , 'Men');
