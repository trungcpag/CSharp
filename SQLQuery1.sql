create proc USP_GetAccountByUserName
@username nvarchar(100)
as 
begin
	select *from Account where Username = @username
end
go
select * from Account
exec dbo.USP_GetAccountByUserName @username = N'K9'