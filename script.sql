USE [QuanLyQuanCafe]
GO
/****** Object:  UserDefinedFunction [dbo].[fChuyenCoDauThanhKhongDau]    Script Date: 11/24/2019 11:45:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fChuyenCoDauThanhKhongDau](@inputVar NVARCHAR(MAX) )
RETURNS NVARCHAR(MAX)
AS
BEGIN    
    IF (@inputVar IS NULL OR @inputVar = '')  RETURN ''
   
    DECLARE @RT NVARCHAR(MAX)
    DECLARE @SIGN_CHARS NCHAR(256)
    DECLARE @UNSIGN_CHARS NCHAR (256)
 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' + NCHAR(272) + NCHAR(208)
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD'
 
    DECLARE @COUNTER int
    DECLARE @COUNTER1 int
   
    SET @COUNTER = 1
    WHILE (@COUNTER <= LEN(@inputVar))
    BEGIN  
        SET @COUNTER1 = 1
        WHILE (@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
        BEGIN
            IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@inputVar,@COUNTER ,1))
            BEGIN          
                IF @COUNTER = 1
                    SET @inputVar = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)-1)      
                ELSE
                    SET @inputVar = SUBSTRING(@inputVar, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@inputVar, @COUNTER+1,LEN(@inputVar)- @COUNTER)
                BREAK
            END
            SET @COUNTER1 = @COUNTER1 +1
        END
        SET @COUNTER = @COUNTER +1
    END
    -- SET @inputVar = replace(@inputVar,' ','-')
    RETURN @inputVar
END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 11/24/2019 11:45:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Username] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](1000) NOT NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([Username], [DisplayName], [PassWord], [Type]) VALUES (N'K9', N'ThanhTrung', N'20720532132149213101239102231223249249135100218', 1)
INSERT [dbo].[Account] ([Username], [DisplayName], [PassWord], [Type]) VALUES (N'staff', N'staff', N'20720532132149213101239102231223249249135100218', 0)
INSERT [dbo].[Account] ([Username], [DisplayName], [PassWord], [Type]) VALUES (N'thanhtrung', N'ThanhTrung', N'20720532132149213101239102231223249249135100218', 1)
/****** Object:  Table [dbo].[TableFood]    Script Date: 11/24/2019 11:45:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[status] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TableFood] ON
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (31, N'Ban 0', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (32, N'Ban 1', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (33, N'Ban 2', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (34, N'Ban 3', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (35, N'Ban 4', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (36, N'Ban 5', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (37, N'Ban 6', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (38, N'Ban 7', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (39, N'Ban 8', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (40, N'Ban 9', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (41, N'Ban 10', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (42, N'Ban 11', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (43, N'Ban 12', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (44, N'Ban 13', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (45, N'Ban 14', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (46, N'Ban 15', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (47, N'Ban 16', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (48, N'Ban 17', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (49, N'Ban 18', N'Trống')
INSERT [dbo].[TableFood] ([id], [name], [status]) VALUES (50, N'Ban 19', N'Trống')
SET IDENTITY_INSERT [dbo].[TableFood] OFF
/****** Object:  UserDefinedFunction [dbo].[GetUnsignString]    Script Date: 11/24/2019 11:45:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetUnsignString]
(
@strInput nvarchar(4000)
)
RETURNS nvarchar(4000)
AS
BEGIN
IF @strInput IS NULL
BEGIN
RETURN @strInput
END;
IF @strInput = ''
BEGIN
RETURN @strInput
END;
DECLARE @RT nvarchar(4000);
DECLARE @SIGN_CHARS nchar(136);
DECLARE @UNSIGN_CHARS nchar(136);
SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ'+NCHAR(272)+NCHAR(208);
SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyyAADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD';
DECLARE @COUNTER int;
DECLARE @COUNTER1 int;
SET @COUNTER = 1;
WHILE(@COUNTER <= LEN(@strInput))
BEGIN
SET @COUNTER1 = 1;
WHILE(@COUNTER1 <= LEN(@SIGN_CHARS) + 1)
BEGIN
IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1, 1)) = UNICODE(SUBSTRING(@strInput, @COUNTER, 1))
BEGIN
IF @COUNTER = 1
BEGIN
SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1, 1) + SUBSTRING(@strInput, @COUNTER+1, LEN(@strInput)-1);
END
ELSE
BEGIN
SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) + SUBSTRING(@UNSIGN_CHARS, @COUNTER1, 1) + SUBSTRING(@strInput, @COUNTER+1, LEN(@strInput)-@COUNTER);
END;
BREAK;
END;
SET @COUNTER1 = @COUNTER1 + 1;
END;
SET @COUNTER = @COUNTER + 1;
END;
RETURN @strInput;
END;
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 11/24/2019 11:45:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FoodCategory] ON
INSERT [dbo].[FoodCategory] ([id], [Name]) VALUES (11, N'Nông sản ')
INSERT [dbo].[FoodCategory] ([id], [Name]) VALUES (12, N'Hải sản ')
INSERT [dbo].[FoodCategory] ([id], [Name]) VALUES (13, N'Nước ')
INSERT [dbo].[FoodCategory] ([id], [Name]) VALUES (14, N'Thịt ')
INSERT [dbo].[FoodCategory] ([id], [Name]) VALUES (15, N'Cá ')
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
/****** Object:  Table [dbo].[Food]    Script Date: 11/24/2019 11:45:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[idCategory] [int] NOT NULL,
	[price] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Food] ON
INSERT [dbo].[Food] ([id], [Name], [idCategory], [price]) VALUES (13, N'Cơm sườn', 11, 25000)
INSERT [dbo].[Food] ([id], [Name], [idCategory], [price]) VALUES (14, N'Canh trứng', 11, 25000)
INSERT [dbo].[Food] ([id], [Name], [idCategory], [price]) VALUES (15, N'Cơm Gà', 11, 25000)
INSERT [dbo].[Food] ([id], [Name], [idCategory], [price]) VALUES (16, N'Lẩu Hải Sản', 12, 280000)
INSERT [dbo].[Food] ([id], [Name], [idCategory], [price]) VALUES (17, N'CAFE', 13, 25000)
INSERT [dbo].[Food] ([id], [Name], [idCategory], [price]) VALUES (18, N'Trà đường', 13, 15000)
INSERT [dbo].[Food] ([id], [Name], [idCategory], [price]) VALUES (19, N'Heo nướng', 14, 125000)
INSERT [dbo].[Food] ([id], [Name], [idCategory], [price]) VALUES (20, N'Chuột xào', 14, 80000)
SET IDENTITY_INSERT [dbo].[Food] OFF
/****** Object:  Table [dbo].[bill]    Script Date: 11/24/2019 11:45:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DataCheckIn] [date] NOT NULL,
	[DataCheckOut] [date] NULL,
	[idTable] [int] NOT NULL,
	[status] [int] NOT NULL,
	[discount] [int] NULL,
	[totalPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[bill] ON
INSERT [dbo].[bill] ([id], [DataCheckIn], [DataCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (26, CAST(0x6A400B00 AS Date), CAST(0x6A400B00 AS Date), 35, 1, 10, 45)
INSERT [dbo].[bill] ([id], [DataCheckIn], [DataCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (27, CAST(0x6A400B00 AS Date), CAST(0x6A400B00 AS Date), 39, 1, 10, 45)
INSERT [dbo].[bill] ([id], [DataCheckIn], [DataCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (28, CAST(0x6A400B00 AS Date), CAST(0x6A400B00 AS Date), 35, 1, 10, 22.5)
INSERT [dbo].[bill] ([id], [DataCheckIn], [DataCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (29, CAST(0x6A400B00 AS Date), NULL, 34, 0, 0, NULL)
INSERT [dbo].[bill] ([id], [DataCheckIn], [DataCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (30, CAST(0x6A400B00 AS Date), CAST(0x6A400B00 AS Date), 41, 1, 10, 22.5)
INSERT [dbo].[bill] ([id], [DataCheckIn], [DataCheckOut], [idTable], [status], [discount], [totalPrice]) VALUES (31, CAST(0x6A400B00 AS Date), CAST(0x6A400B00 AS Date), 35, 1, 0, 75)
SET IDENTITY_INSERT [dbo].[bill] OFF
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 11/24/2019 11:45:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Login]
@username nvarchar(100), @password nvarchar(100)
as 
begin
	select * from Account where Username = @username and PassWord = @password
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 11/24/2019 11:45:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateAccount]
	@username nvarchar(100), @displayName nvarchar(100), @passWord nvarchar(100), @newPassWord nvarchar(100)
	as
	begin
		declare @isRightPass int = 0;
		select @isRightPass = COUNT(*) from Account where Username = @username 
			and PassWord = @passWord
		if(@isRightPass = 1)
		begin
			if(@newPassWord	= NULL or @newPassWord = '')
			begin
				update Account set DisplayName = @displayName where Username = @username
			end
			else
				update Account set DisplayName = @displayName , PassWord = @passWord where Username = @username
		end
	end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 11/24/2019 11:45:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetTableList]
as select * from dbo.TableFood
GO
/****** Object:  StoredProcedure [dbo].[USP_GetAccountByUserName]    Script Date: 11/24/2019 11:45:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_GetAccountByUserName]
@username nvarchar(100)
as 
begin
	select *from Account where Username = @username
end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBill]    Script Date: 11/24/2019 11:45:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_InsertBill]
	@idTable int
	as
	begin
		insert dbo.bill(DataCheckIn, DataCheckOut, idTable, status, discount)
		values (GETDATE(), NULL,@idTable, 0, 0 )
	end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetListBillByDate]    Script Date: 11/24/2019 11:45:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_GetListBillByDate]
	@checkIn date, @checkOut date
	as
	begin
		select t.name as [Tên bàn], DataCheckIn as [Ngày vào], DataCheckOut as [Ngày ra], discount as [Giảm giá %], b.totalPrice as [Tổng tiền] 
		from bill as b, TableFood as t
		where DataCheckIn >= @checkIn and DataCheckOut <= @checkOut 
		and b.status = 1 and t.id = b.idTable
	end
GO
/****** Object:  Table [dbo].[billInfo]    Script Date: 11/24/2019 11:45:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[billInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBill] [int] NOT NULL,
	[idFood] [int] NOT NULL,
	[count] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[billInfo] ON
INSERT [dbo].[billInfo] ([id], [idBill], [idFood], [count]) VALUES (34, 27, 13, 3)
INSERT [dbo].[billInfo] ([id], [idBill], [idFood], [count]) VALUES (35, 27, 17, 1)
INSERT [dbo].[billInfo] ([id], [idBill], [idFood], [count]) VALUES (36, 28, 17, 1)
INSERT [dbo].[billInfo] ([id], [idBill], [idFood], [count]) VALUES (37, 30, 17, 1)
INSERT [dbo].[billInfo] ([id], [idBill], [idFood], [count]) VALUES (38, 31, 13, 3)
SET IDENTITY_INSERT [dbo].[billInfo] OFF
/****** Object:  StoredProcedure [dbo].[USP_SwitchTable]    Script Date: 11/24/2019 11:45:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_SwitchTable]
	@idTable1 int, @idTable2 int
	as
	begin
		declare @idFirstBill int
		declare @idSecondBill int
		declare @isFirstTableEmpty int = 1
		declare @isSecondTableEmpty int = 1
		select @idFirstBill = id from bill where idTable = @idTable1 and status = 0
		select @idSecondBill = id from bill where idTable = @idTable2 and status = 0
		if(@idFirstBill is NULL)
		begin
			insert dbo.bill(DataCheckIn, DataCheckOut, idTable, status, discount)
			values (GETDATE(), NULL, @idTable1, 0,0 )
			select @idFirstBill = MAX(id) from bill where idTable = @idTable1 and status = 0
		end
		select @isFirstTableEmpty = COUNT(*) from billInfo where idBill = @idFirstBill
		if(@idSecondBill is NULL)
		begin
			insert dbo.bill(DataCheckIn, DataCheckOut, idTable, status, discount)
			values (GETDATE(), NULL, @idTable2, 0,0 )
			select @idSecondBill = MAX(id) from bill where idTable = @idTable2 and status = 0
		end
		select @isSecondTableEmpty = COUNT(*) from billInfo where idBill = @idSecondBill
		select id into IDBillInfoTable from billInfo where idBill = @idSecondBill
		update billInfo set idBill = @idSecondBill where idBill = @idFirstBill
		update billInfo set idBill =@idFirstBill where id IN (select * from IDBillInfoTable)
		drop table IDBillInfoTable
		if(@isFirstTableEmpty = 0)
			update TableFood set status = N'Trống' where id = @idTable2
		if(@isSecondTableEmpty = 0)
			update TableFood set status = N'Trống' where id = @idTable1
	end
GO
/****** Object:  StoredProcedure [dbo].[USP_InsertBillInfo]    Script Date: 11/24/2019 11:45:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[USP_InsertBillInfo]
	@idBill int,
	@idFood int,
	@count int
	as
	begin
	declare @isExitsBillInfo int;
	declare @foodCount int =  1
	select @isExitsBillInfo = id, @foodCount = b.count from billInfo as b where idBill = @idBill and idFood = @idFood
	if(@isExitsBillInfo > 0)
	begin
		declare @newCount int =  @foodCount + @count
		if(@newCount >0)
			update billInfo	set count = @foodCount + @count where idFood = @idFood
		else
			delete billInfo where idBill = @idBill and idFood = @idFood
	end
	else
	begin
		insert dbo.billInfo(idBill, idFood, count)
			values (@idBill, @idFood, @count)
	end
	
	end
GO
/****** Object:  Default [DF__Account__Display__07020F21]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'user') FOR [DisplayName]
GO
/****** Object:  Default [DF__Account__Type__07F6335A]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[Account] ADD  DEFAULT ((0)) FOR [Type]
GO
/****** Object:  Default [DF__bill__status__173876EA]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[bill] ADD  DEFAULT ((0)) FOR [status]
GO
/****** Object:  Default [DF__billInfo__count__1CF15040]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[billInfo] ADD  DEFAULT ((0)) FOR [count]
GO
/****** Object:  Default [DF__Food__Name__117F9D94]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[Food] ADD  DEFAULT (N'chưa đặt tên') FOR [Name]
GO
/****** Object:  Default [DF__FoodCatego__Name__0CBAE877]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[FoodCategory] ADD  DEFAULT (N'chưa đặt tên') FOR [Name]
GO
/****** Object:  Default [DF__TableFood__name__014935CB]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'chưa đặt tên') FOR [name]
GO
/****** Object:  Default [DF__TableFood__statu__023D5A04]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[TableFood] ADD  DEFAULT (N'Trống') FOR [status]
GO
/****** Object:  ForeignKey [FK__bill__status__182C9B23]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[bill]  WITH CHECK ADD FOREIGN KEY([idTable])
REFERENCES [dbo].[TableFood] ([id])
GO
/****** Object:  ForeignKey [FK__billInfo__count__1DE57479]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[billInfo]  WITH CHECK ADD FOREIGN KEY([idBill])
REFERENCES [dbo].[bill] ([id])
GO
/****** Object:  ForeignKey [FK__billInfo__idFood__1ED998B2]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[billInfo]  WITH CHECK ADD FOREIGN KEY([idFood])
REFERENCES [dbo].[Food] ([id])
GO
/****** Object:  ForeignKey [FK__Food__idCategory__1273C1CD]    Script Date: 11/24/2019 11:45:40 ******/
ALTER TABLE [dbo].[Food]  WITH CHECK ADD FOREIGN KEY([idCategory])
REFERENCES [dbo].[FoodCategory] ([id])
GO
