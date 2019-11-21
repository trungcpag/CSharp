create proc USP_GetAccountByUserName
@username nvarchar(100)
as 
begin
	select *from Account where Username = @username
end
go
select * from Account
exec dbo.USP_GetAccountByUserName @username = N'K9'
select * from Account where username = 'K9' and password = '1'

--create proc USP_GetAccountByUserName
--@username nvarchar(100)
--as 
--begin
--	select *from Account where Username = @username
--end
--go

declare @i int = 0
while @i < 10
begin
	insert dbo.TableFood (name)
		values (N'Ban ' + CAST(@i as Nvarchar(100)) )
		set @i = @i +1
end
go

select *from dbo.TableFood
go 
create proc USP_GetTableList
as select * from dbo.TableFood
go

exec dbo.USP_GetTableList