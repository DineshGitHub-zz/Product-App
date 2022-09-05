

create procedure AddProduct @ProductName varchar(100), @Qty decimal(9,2)
As
BEGIN
SET NOCOUNT ON
insert into Product values(@ProductName, @Qty)
END

--EXEC AddProduct @ProductName = 'Soap' , @Qty = '120'

create procedure UpdateProduct @Id bigint, @ProductName varchar(100), @Qty decimal(9,2)
As
BEGIN
SET NOCOUNT ON
update Product set ProductName = @ProductName, Qty = @Qty
where Id = @Id
END

--EXEC UpdateProduct @Id = 1, @ProductName = 'Shampoo' , @Qty = '12'

create procedure DeleteProduct @Id bigint
As
BEGIN
SET NOCOUNT ON
delete from Product where Id = @Id
END

--EXEC DeleteProduct @Id = 1


create procedure GetProducts
As
BEGIN
SET NOCOUNT ON
select * from Product
END

--EXEC GetProducts


create procedure GetProductById @Id bigint
As
BEGIN
SET NOCOUNT ON
select * from Product where Id = @Id
END

--EXEC GetProductById 1