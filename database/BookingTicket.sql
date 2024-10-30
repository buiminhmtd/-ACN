--Created 11/24/2013
--Create DB
Create Database BookingTicket
Go
Use BookingTicket
Go

------------------------------Create Tables-------------------------------
--Table Admin
Create table [Admin]
(
	AdmId int identity primary key,
	Username varchar(100) not null,
	Pass varchar(100) not null,
	FullName varchar(100),
	Bod datetime,
	[Address] varchar(200),
	Phone varchar(20),
	Email varchar(100) not null
)
Go

Insert into [Admin] values('Admin', 'c4ca4238a0b923820dcc509a6f75849b', 'Pham Ngoc Tuan', '12/28/1992', 'Vp', '0123456789', 'Tuanxh12a2@gmail.com')
Go

--Table Customer
Create table Customer
(
	CusId int identity primary key,
	Username varchar(100) unique not null,
	[Password] varchar(100) not null,
	CreditCard int not null,
	FullName varchar(100) default '',
	Bod datetime,
	[Address] varchar(200) default '',
	Phone varchar(20),
	Email varchar(100) not null,
	Avata varchar(100),
	[Status] int default 1
)
Go

--Table Cinema
Create table Cinema
(
	CinId int identity primary key,
	NameCi varchar(100) not null,
	[Address] varchar(200),
	Seats int default 0,
	Phone varchar(20),
	[Image] varchar(100),
	[Status] int
)
Go

--Table Country
Create table Country
(
	CouId int identity primary key,
	NameCo varchar(100) not null,
	[Status] int
)
Go

--Table TypeFilm
Create table TypeFilm
(
	TypId int identity primary key,
	NameT varchar(100) not null,
	[Status] int
)
Go

--Table Film
Create table Film
(
	FilId int identity primary key,
	TypId int constraint FK_Film_TypId foreign key(TypId) references TypeFilm(TypId),
	CouId int constraint FK_Film_CouId foreign key(CouId) references Country(CouId),
	NameF varchar(100) not null,
	Director varchar(100),
	Actor varchar(100),
	Duration int,
	[Description] ntext,
	[Detail] ntext,
	Picture varchar(100),
	PictureBig varchar(100),
	[Status] int
)
Go

--Table Slide
Create table Slide
(
	SliId int identity primary key,
	FilId int constraint FK_Slide_FilId foreign key(FilId) references Film(FilId),
	[Image] varchar(100),
	[Status] int
)
Go

--Table ShowTimes
Create table ShowTimes
(
	ShoId int identity primary key,
	FilId int constraint FK_ShowTimes_FilId foreign key(FilId) references Film(FilId),
	CinId int constraint FK_ShowTimes_CinId foreign key(CinId) references Cinema(CinId),
	--ShowTime datetime not null check(Datediff(D, ShowTime, GETDATE()) > 0),
	ShowTime datetime not null,
	[Time] time,
	[View] int default 0,
	Price float check(Price > 0) not null,
	[Status] int
)
Go

--Create Booking
Create table Booking
(
	BooId int identity primary key,
	CusId int constraint FK_Booking_CusId foreign key(CusId) references Customer(CusId),
	ShoId int constraint FK_Booking_ShoId foreign key(ShoId) references ShowTimes(ShoId),
	Quantity int check (Quantity > 0),
	Bilmoney float,
	DateBooking datetime default getdate(),
	[Status] varchar(100) default 'No'
)
Go

--Table Feedback
Create table Feedback
(
	FeeId int identity primary key,
	FilId int constraint FK_Feedback_FilId foreign key(FilId) references Film(FilId),
	Avata nvarchar(100),
	FullName nvarchar(100) not null,
	Comment nvarchar(500) not null,
	Created datetime default getdate(),
	[Status] int default 1
)
Go

------------------------------Create Procedure-------------------------------
--Table Admin

if exists (select * from dbo.sysobjects where name = 'sp_Admin_GetByAll')
	drop procedure [dbo].[sp_Admin_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_Admin_GetByAll
AS
	SELECT * FROM [Admin]
Go

if exists (select * from dbo.sysobjects where name = 'sp_Admin_GetById')
	drop procedure [dbo].[sp_Admin_GetById]
Go 
CREATE PROCEDURE dbo.sp_Admin_GetById
@AdmId	int
AS
SELECT * FROM [Admin] WHERE  AdmId= @AdmId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Admin_Update')
	drop procedure [dbo].[sp_Admin_Update]
Go 
CREATE PROCEDURE dbo.sp_Admin_Update
@AdmId	int,
@FullName	varchar(100),
@Bod	datetime,
@Address	varchar(200),
@Phone	varchar(20),
@Email	varchar(100)
AS
UPDATE [Admin] SET [FullName] = @FullName,[Bod] = @Bod,[Address] = @Address,[Phone] = @Phone,[Email] = @Email
WHERE  AdmId= @AdmId
Go

if exists (select * from sysobjects where name = 'sp_Admin_CheckLogin')
	drop procedure [sp_Admin_CheckLogin]
Go
CREATE PROCEDURE sp_Admin_CheckLogin
@Username varchar(50),
@Pass varchar(50)
AS
SELECT * FROM [Admin]
WHERE [Username]= @Username And [Pass]= @Pass
Go

if exists (select * from sysobjects where name = 'sp_Admin_ChangePass')
	drop procedure [sp_Admin_ChangePass]
Go 
CREATE PROCEDURE sp_Admin_ChangePass
@Username	varchar(50),
@Pass	varchar(50)
AS
UPDATE [Admin] SET [Pass]= @Pass
WHERE  Username= @Username
Go

--Table Customer
if exists (select * from sysobjects where name = 'sp_Customer_CheckLogin')
	drop procedure [sp_Customer_CheckLogin]
Go
CREATE PROCEDURE sp_Customer_CheckLogin
@Username varchar(50),
@Pass varchar(50)
AS
SELECT * FROM [Customer]
WHERE [Username]= @Username And [Password]= @Pass
Go

if exists (select * from sysobjects where name = 'sp_Customer_ChangePass')
	drop procedure [sp_Customer_ChangePass]
Go 
CREATE PROCEDURE sp_Customer_ChangePass
@Username	varchar(50),
@Pass	varchar(50)
AS
UPDATE [Customer] SET [Password]= @Pass
WHERE  Username= @Username
Go

if exists (select * from dbo.sysobjects where name = 'sp_Customer_GetByAll')
	drop procedure [dbo].[sp_Customer_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_Customer_GetByAll
AS
	SELECT * FROM Customer
Go

if exists (select * from dbo.sysobjects where name = 'sp_Customer_GetById')
	drop procedure [dbo].[sp_Customer_GetById]
Go 
CREATE PROCEDURE dbo.sp_Customer_GetById
@CusId	int
AS
SELECT * FROM [Customer] WHERE  CusId= @CusId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Customer_GetByTop')
	drop procedure [dbo].[sp_Customer_GetByTop]
Go 
CREATE PROCEDURE dbo.sp_Customer_GetByTop
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') * FROM [Customer]'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT * FROM [Customer]'
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_Customer_Insert')
	drop procedure [dbo].[sp_Customer_Insert]
Go 
CREATE PROCEDURE dbo.sp_Customer_Insert
@Username	varchar(100),
@Password	varchar(100),
@CreditCard	int,
@FullName	varchar(100),
@Bod	datetime,
@Address	varchar(200),
@Phone	varchar(20),
@Email	varchar(100),
@Avata varchar(100),
@Status	int
AS
	If(@Username In (Select [Username] From [Customer]))
	Begin
		Raiserror ('This account is already exists', 16, 1)
		Return
	End
	If(@Email In (Select [Email] From [Customer]))
	Begin
		Raiserror ('This email is already exists', 16, 1)
		Return
	End
INSERT INTO [Customer]([Username],[Password],[CreditCard],[FullName],[Bod],[Address],[Phone],[Email],Avata,[Status]) VALUES(@Username ,@Password ,@CreditCard ,@FullName ,@Bod ,@Address ,@Phone ,@Email ,@Avata,@Status )
Go

if exists (select * from dbo.sysobjects where name = 'sp_Customer_Update')
	drop procedure [dbo].[sp_Customer_Update]
Go 
CREATE PROCEDURE dbo.sp_Customer_Update
@CusId	int,
@Username	varchar(100),
@CreditCard	int,
@FullName	varchar(100),
@Bod	datetime,
@Address	varchar(200),
@Phone	varchar(20),
@Email	varchar(100),
@Avata varchar(100),
@Status	int
AS
	If(@Email In (Select [Email] From [Customer] Where [CusId]<>@CusId))
	Begin
		Raiserror ('Update error, this email is already exists', 16, 1)
		Return
	End
UPDATE [Customer] SET [Username] = @Username,[CreditCard] = @CreditCard,[FullName] = @FullName,[Bod] = @Bod,[Address] = @Address,[Phone] = @Phone,[Email] = @Email,Avata=@Avata,[Status] = @Status
WHERE  CusId= @CusId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Customer_Delete')
	drop procedure [dbo].[sp_Customer_Delete]
Go 
CREATE PROCEDURE dbo.sp_Customer_Delete
@CusId	int
AS
	If(@CusId In (Select CusId From [Booking]))
	Begin
		Raiserror ('Can not delete this employee', 16, 1)
		Return
	End
Delete FROM [Customer] WHERE  CusId= @CusId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Customer_Update_Status')
	drop procedure [dbo].[sp_Customer_Update_Status]
Go 
CREATE PROCEDURE dbo.sp_Customer_Update_Status
(
	@CusId int,
	@Status int
)
AS
Update [Customer] SET [Status]=@Status where CusId=@CusId
Go

--Table Cinema
if exists (select * from dbo.sysobjects where name = 'sp_Cinema_GetByAll')
	drop procedure [dbo].[sp_Cinema_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_Cinema_GetByAll
AS
	SELECT * FROM Cinema
Go

if exists (select * from dbo.sysobjects where name = 'sp_Cinema_GetById')
	drop procedure [dbo].[sp_Cinema_GetById]
Go 
CREATE PROCEDURE dbo.sp_Cinema_GetById
@CinId	int
AS
SELECT * FROM [Cinema] WHERE  CinId= @CinId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Cinema_GetByTop')
	drop procedure [dbo].[sp_Cinema_GetByTop]
Go 
CREATE PROCEDURE dbo.sp_Cinema_GetByTop
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') * FROM [Cinema]'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT * FROM [Cinema]'
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_Cinema_Insert')
	drop procedure [dbo].[sp_Cinema_Insert]
Go 
CREATE PROCEDURE dbo.sp_Cinema_Insert
@NameCi	varchar(100),
@Address	varchar(200),
@Seats	int,
@Phone	varchar(20),
@Image varchar(100),
@Status	int
AS
	If(@NameCi In (Select [NameCi] From [Cinema]))
	Begin
		Raiserror ('This cinama is already exists', 16, 1)
		Return
	End
INSERT INTO [Cinema]([NameCi],[Address],[Seats],[Phone],[Image],[Status]) VALUES(@NameCi ,@Address ,@Seats ,@Phone,@Image ,@Status )
Go

if exists (select * from dbo.sysobjects where name = 'sp_Cinema_Update')
	drop procedure [dbo].[sp_Cinema_Update]
Go 
CREATE PROCEDURE dbo.sp_Cinema_Update
@CinId	int,
@NameCi	varchar(100),
@Address	varchar(200),
@Seats	int,
@Phone	varchar(20),
@Image varchar(100),
@Status	int
AS
	If(@NameCi In (Select [NameCi] From [Cinema] Where [CinId]<>@CinId))
	Begin
		Raiserror ('Update error, this cinama is already exists', 16, 1)
		Return
	End
UPDATE [Cinema] SET [NameCi] = @NameCi,[Address] = @Address,[Seats] = @Seats,[Phone] = @Phone,[Image]=@Image,[Status] = @Status
WHERE  CinId= @CinId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Cinema_Delete')
	drop procedure [dbo].[sp_Cinema_Delete]
Go 
CREATE PROCEDURE dbo.sp_Cinema_Delete
@CinId	int
AS
	If(@CinId In (Select CinId From [ShowTimes]))
	Begin
		Raiserror ('Can not delete this cinama', 16, 1)
		Return
	End
Delete FROM [Cinema] WHERE  CinId= @CinId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Cinema_Update_Status')
	drop procedure [dbo].[sp_Cinema_Update_Status]
Go 
CREATE PROCEDURE dbo.sp_Cinema_Update_Status
(
	@CinId int,
	@Status int
)
AS
Update [Cinema] SET [Status]=@Status where CinId=@CinId
Go

--Table Country
if exists (select * from dbo.sysobjects where name = 'sp_Country_GetByAll')
	drop procedure [dbo].[sp_Country_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_Country_GetByAll
AS
	SELECT * FROM Country
Go

if exists (select * from dbo.sysobjects where name = 'sp_Country_GetById')
	drop procedure [dbo].[sp_Country_GetById]
Go 
CREATE PROCEDURE dbo.sp_Country_GetById
@CouId	int
AS
SELECT * FROM [Country] WHERE  CouId= @CouId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Country_GetByTop')
	drop procedure [dbo].[sp_Country_GetByTop]
Go 
CREATE PROCEDURE dbo.sp_Country_GetByTop
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') * FROM [Country]'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT * FROM [Country]'
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_Country_Insert')
	drop procedure [dbo].[sp_Country_Insert]
Go 
CREATE PROCEDURE dbo.sp_Country_Insert
@NameCo	varchar(100),
@Status	int
AS
	If(@NameCo In (Select [NameCo] From [Country]))
	Begin
		Raiserror ('This Country is already exists', 16, 1)
		Return
	End
INSERT INTO [Country]([NameCo],[Status]) VALUES(@NameCo ,@Status )
Go

if exists (select * from dbo.sysobjects where name = 'sp_Country_Update')
	drop procedure [dbo].[sp_Country_Update]
Go 
CREATE PROCEDURE dbo.sp_Country_Update
@CouId	int,
@NameCo	varchar(100),
@Status	int
AS
	If(@NameCo In (Select [NameCo] From [Country] Where [CouId]<>@CouId))
	Begin
		Raiserror ('Update error, this Country is already exists', 16, 1)
		Return
	End
UPDATE [Country] SET [NameCo] = @NameCo,[Status] = @Status
WHERE  CouId= @CouId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Country_Delete')
	drop procedure [dbo].[sp_Country_Delete]
Go 
CREATE PROCEDURE dbo.sp_Country_Delete
@CouId	int
AS
	If(@CouId In (Select CouId From [Film]))
	Begin
		Raiserror ('Can not delete this Country', 16, 1)
		Return
	End
Delete FROM [Country] WHERE  CouId= @CouId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Country_Update_Status')
	drop procedure [dbo].[sp_Country_Update_Status]
Go 
CREATE PROCEDURE dbo.sp_Country_Update_Status
(
	@CouId int,
	@Status int
)
AS
Update [Country] SET [Status]=@Status where CouId=@CouId
Go

--Table TypeFilm
if exists (select * from dbo.sysobjects where name = 'sp_TypeFilm_GetByAll')
	drop procedure [dbo].[sp_TypeFilm_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_TypeFilm_GetByAll
AS
	SELECT * FROM TypeFilm
Go

if exists (select * from dbo.sysobjects where name = 'sp_TypeFilm_GetById')
	drop procedure [dbo].[sp_TypeFilm_GetById]
Go 
CREATE PROCEDURE dbo.sp_TypeFilm_GetById
@TypId	int
AS
SELECT * FROM [TypeFilm] WHERE  TypId= @TypId
Go

if exists (select * from dbo.sysobjects where name = 'sp_TypeFilm_GetByTop')
	drop procedure [dbo].[sp_TypeFilm_GetByTop]
Go 
CREATE PROCEDURE dbo.sp_TypeFilm_GetByTop
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') * FROM [TypeFilm]'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT * FROM [TypeFilm]'
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_TypeFilm_Insert')
	drop procedure [dbo].[sp_TypeFilm_Insert]
Go 
CREATE PROCEDURE dbo.sp_TypeFilm_Insert
@NameT	varchar(100),
@Status	int
AS
	If(@NameT In (Select [NameT] From [TypeFilm]))
	Begin
		Raiserror ('This Type Film is already exists', 16, 1)
		Return
	End
INSERT INTO [TypeFilm]([NameT],[Status]) VALUES(@NameT ,@Status )
Go

if exists (select * from dbo.sysobjects where name = 'sp_TypeFilm_Update')
	drop procedure [dbo].[sp_TypeFilm_Update]
Go 
CREATE PROCEDURE dbo.sp_TypeFilm_Update
@TypId	int,
@NameT	varchar(100),
@Status	int
AS
	If(@NameT In (Select [NameT] From [TypeFilm] Where TypId<>@TypId))
	Begin
		Raiserror ('Update error, this Type Film is already exists', 16, 1)
		Return
	End
UPDATE [TypeFilm] SET [NameT] = @NameT,[Status] = @Status
WHERE  TypId= @TypId
Go

if exists (select * from dbo.sysobjects where name = 'sp_TypeFilm_Delete')
	drop procedure [dbo].[sp_TypeFilm_Delete]
Go 
CREATE PROCEDURE dbo.sp_TypeFilm_Delete
@TypId	int
AS
	If(@TypId In (Select TypId From [Film]))
	Begin
		Raiserror ('Can not delete this Type Film', 16, 1)
		Return
	End
Delete FROM [TypeFilm] WHERE  TypId= @TypId
Go

if exists (select * from dbo.sysobjects where name = 'sp_TypeFilm_Update_Status')
	drop procedure [dbo].[sp_TypeFilm_Update_Status]
Go 
CREATE PROCEDURE dbo.sp_TypeFilm_Update_Status
(
	@TypId int,
	@Status int
)
AS
Update [TypeFilm] SET [Status]=@Status where TypId=@TypId
Go

--Table Film
if exists (select * from dbo.sysobjects where name = 'sp_Film_GetByAll')
	drop procedure [dbo].[sp_Film_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_Film_GetByAll
AS
SELECT	*,*,* FROM Film inner join Country on Film.CouId = Country.CouId
					   inner join TypeFilm on Film.TypId = TypeFilm.TypId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Film_GetById')
	drop procedure [dbo].[sp_Film_GetById]
Go 
CREATE PROCEDURE dbo.sp_Film_GetById
@FilId	int
AS
SELECT *,*,* FROM Film inner join Country on Film.CouId = Country.CouId
					   inner join TypeFilm on Film.TypId = TypeFilm.TypId WHERE  FilId= @FilId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Film_GetByTop')
	drop procedure [dbo].[sp_Film_GetByTop]
Go 
CREATE PROCEDURE dbo.sp_Film_GetByTop
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') * FROM [Film]'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT * FROM Film '
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_Film_Insert')
	drop procedure [dbo].[sp_Film_Insert]
Go 
CREATE PROCEDURE dbo.sp_Film_Insert
@TypId	int,
@CouId	int,
@NameF	varchar(100),
@Director	varchar(100),
@Actor	varchar(100),
@Duration	int,
@Description	ntext,
@Detail ntext,
@Picture	varchar(100),
@PictureBig varchar(100),
@Status	int
AS
	If(@NameF In (Select [NameF] From [Film]))
	Begin
		Raiserror ('This Film is already exists', 16, 1)
		Return
	End
INSERT INTO [Film]([TypId],[CouId],[NameF],[Director],[Actor],[Duration],[Description],[Detail],[Picture],[PictureBig],[Status]) VALUES(@TypId ,@CouId ,@NameF ,@Director ,@Actor ,@Duration ,@Description ,@Detail,@Picture,@PictureBig ,@Status )
Go

if exists (select * from dbo.sysobjects where name = 'sp_Film_Update')
	drop procedure [dbo].[sp_Film_Update]
Go 
CREATE PROCEDURE dbo.sp_Film_Update
@FilId	int,
@TypId	int,
@CouId	int,
@NameF	varchar(100),
@Director	varchar(100),
@Actor	varchar(100),
@Duration	int,
@Description	ntext,
@Detail ntext,
@Picture	varchar(100),
@PictureBig varchar(100),
@Status	int
AS
	If(@NameF In (Select [NameF] From [Film] Where [FilId]<>@FilId))
	Begin
		Raiserror ('Update error, this Film is already exists', 16, 1)
		Return
	End
UPDATE [Film] SET [TypId] = @TypId,[CouId] = @CouId,[NameF] = @NameF,[Director] = @Director,[Actor] = @Actor,[Duration] = @Duration,[Description] = @Description,[Detail]=@Detail,[Picture] = @Picture,[PictureBig] = @PictureBig,[Status] = @Status
WHERE  FilId= @FilId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Film_Delete')
	drop procedure [dbo].[sp_Film_Delete]
Go 
CREATE PROCEDURE dbo.sp_Film_Delete
@FilId	int
AS
	If(@FilId In (Select FilId From [ShowTimes]))
	Begin
		Raiserror ('Can not delete this film', 16, 1)
		Return
	End
	If(@FilId In (Select FilId From [Feedback]))
	Begin
		Raiserror ('Can not delete this film', 16, 1)
		Return
	End
Delete FROM [Film] WHERE  FilId= @FilId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Film_GetByCouId')
	drop procedure [dbo].[sp_Film_GetByCouId]
Go 
CREATE PROCEDURE dbo.sp_Film_GetByCouId
@CouId int
AS
	SELECT * FROM [Film]
 WHERE CouId = @CouId 
Go

if exists (select * from dbo.sysobjects where name = 'sp_Film_GetByTypId')
	drop procedure [dbo].[sp_Film_GetByTypId]
Go 
CREATE PROCEDURE dbo.sp_Film_GetByTypId
@TypId int
AS
	SELECT * FROM [Film]
 WHERE TypId = @TypId 
Go

if exists (select * from dbo.sysobjects where name = 'sp_Film_Update_Status')
	drop procedure [dbo].[sp_Film_Update_Status]
Go 
CREATE PROCEDURE dbo.sp_Film_Update_Status
(
	@FilId int,
	@Status int
)
AS
Update [Film] SET [Status]=@Status where FilId=@FilId
Go

--Table ShowTimes
if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_GetByAll')
	drop procedure [dbo].[sp_ShowTimes_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_GetByAll
AS
	SELECT *,*,* FROM ShowTimes inner join Film on Film.FilId = ShowTimes.FilId
								inner join Cinema on ShowTimes.CinId = Cinema.CinId
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_GetById')
	drop procedure [dbo].[sp_ShowTimes_GetById]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_GetById
@ShoId	int
AS
SELECT *,*,* FROM ShowTimes inner join Film on Film.FilId = ShowTimes.FilId
								inner join Cinema on ShowTimes.CinId = Cinema.CinId WHERE  ShoId= @ShoId
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_GetByTop1')
	drop procedure [dbo].[sp_ShowTimes_GetByTop1]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_GetByTop1
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') *,*,* FROM ShowTimes inner join Film on Film.FilId = ShowTimes.FilId
								inner join Cinema on ShowTimes.CinId = Cinema.CinId'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT *,*,* FROM ShowTimes inner join Film on Film.FilId = ShowTimes.FilId
								inner join Cinema on ShowTimes.CinId = Cinema.CinId'
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_GetByTop2')
	drop procedure [dbo].[sp_ShowTimes_GetByTop2]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_GetByTop2
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') *,* FROM ShowTimes inner join Film on Film.FilId = ShowTimes.FilId'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT *,* FROM ShowTimes inner join Film on Film.FilId = ShowTimes.FilId'
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_GetByTop')
	drop procedure [dbo].[sp_ShowTimes_GetByTop]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_GetByTop
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') * FROM [ShowTimes]'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT * FROM ShowTimes '
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_Insert')
	drop procedure [dbo].[sp_ShowTimes_Insert]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_Insert
@FilId	int,
@CinId	int,
@ShowTime	datetime,
@Time time,
@Price	float,
@Status	int
AS
INSERT INTO [ShowTimes]([FilId],[CinId],[ShowTime],[Time],[Price],[Status]) VALUES(@FilId ,@CinId ,@ShowTime ,@Time,@Price ,@Status )
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_Update')
	drop procedure [dbo].[sp_ShowTimes_Update]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_Update
@ShoId	int,
@FilId	int,
@CinId	int,
@ShowTime	datetime,
@Time time,
@Price	float,
@Status	int
AS
UPDATE [ShowTimes] SET [FilId] = @FilId,[CinId] = @CinId,[ShowTime] = @ShowTime,[Time]=@Time,[Price] = @Price,[Status] = @Status
WHERE  ShoId= @ShoId
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_Delete')
	drop procedure [dbo].[sp_ShowTimes_Delete]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_Delete
@ShoId	int
AS
	If(@ShoId In (Select ShoId From [Booking]))
	Begin
		Raiserror ('Can not delete this ShowTimes', 16, 1)
		Return
	End
Delete FROM [ShowTimes] WHERE  ShoId= @ShoId
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_GetByCinId')
	drop procedure [dbo].[sp_ShowTimes_GetByCinId]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_GetByCinId
@CinId int
AS
	SELECT * FROM [ShowTimes]
 WHERE CinId = @CinId 
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_GetByFilId')
	drop procedure [dbo].[sp_ShowTimes_GetByFilId]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_GetByFilId
@FilId int
AS
	SELECT * FROM ShowTimes inner join Cinema on ShowTimes.CinId = Cinema.CinId
 WHERE FilId = @FilId 
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_Update_Status')
	drop procedure [dbo].[sp_ShowTimes_Update_Status]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_Update_Status
(
	@ShoId int,
	@Status int
)
AS
Update [ShowTimes] SET [Status]=@Status where ShoId=@ShoId
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_Update_View')
	drop procedure [dbo].[sp_ShowTimes_Update_View]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_Update_View
(
	@FilId int
)
AS
Update [ShowTimes] SET [View]=[View]+1 where FilId=@FilId
Go

if exists (select * from dbo.sysobjects where name = 'sp_ShowTimes_Update_Price')
	drop procedure [dbo].[sp_ShowTimes_Update_Price]
Go 
CREATE PROCEDURE dbo.sp_ShowTimes_Update_Price
(
	@ShoId int,
	@Price float
)
AS
Update [ShowTimes] SET [Price]=@Price where ShoId=@ShoId
Go

Create Trigger tg_add_showtimes on ShowTimes
for insert
as
	declare @filid1 int, @shoid int, @filid2 int
	select @filid2 = filid from showtimes
	select @filid1 = inserted.filid, @shoid = inserted.shoid from inserted
	if @filid1 = @filid2
		begin
			update showtimes
			set [status] = 0 where shoid = @shoid
		end
Go

--Create Booking----------------------------------------------

if exists (select * from dbo.sysobjects where name = 'sp_Booking_GetByAll')
	drop procedure [dbo].[sp_Booking_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_Booking_GetByAll
AS
	--SELECT * FROM Booking
	select *,* from Booking inner join Customer on Booking.CusId = Customer.CusId
Go

--if exists (select * from dbo.sysobjects where name = 'sp_Booking_GetID')
--	drop procedure [dbo].[sp_Booking_GetID]
--Go 
--CREATE PROCEDURE dbo.sp_Booking_GetID
--AS
--	--SELECT * FROM Booking
--	select *,* from Booking inner join Customer on Booking.CusId = Customer.CusId
--Go


if exists (select * from dbo.sysobjects where name = 'sp_Booking_Sum')
	drop procedure [dbo].[sp_Booking_Sum]
Go 
CREATE PROCEDURE dbo.sp_Booking_Sum
@ShoId int
AS
	SELECT tickets=SUM(Quantity) FROM Booking Where ShoId = @ShoId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Booking_GetById')
	drop procedure [dbo].[sp_Booking_GetById]
Go 
CREATE PROCEDURE dbo.sp_Booking_GetById
@BooId	int
AS
--SELECT * FROM [Booking] WHERE  BooId= @BooId
select *,*,Pic=Film.Picture,*,St=Booking.[Status] from Booking inner join Customer on Booking.CusId = Customer.CusId
						inner join ShowTimes on ShowTimes.ShoId = Booking.ShoId
						inner join Film on Film.FilId = ShowTimes.FilId WHERE  BooId= @BooId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Booking_GetByTop')
	drop procedure [dbo].[sp_Booking_GetByTop]
Go 
CREATE PROCEDURE dbo.sp_Booking_GetByTop
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') * FROM [Booking]'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT * FROM [Booking]'
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_Booking_Insert')
	drop procedure [dbo].[sp_Booking_Insert]
Go 
CREATE PROCEDURE dbo.sp_Booking_Insert
@CusId	int,
@ShoId	int,
@Bilmoney float,
@Quantity	int
AS
INSERT INTO [Booking]([CusId],[ShoId],[Bilmoney],[Quantity]) VALUES(@CusId ,@ShoId,@Bilmoney ,@Quantity )
Go

if exists (select * from dbo.sysobjects where name = 'sp_Booking_Update')
	drop procedure [dbo].[sp_Booking_Update]
Go 
CREATE PROCEDURE dbo.sp_Booking_Update
@BooId	int
AS
UPDATE [Booking] SET [Status] = 'Yes'
WHERE  BooId= @BooId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Booking_Delete')
	drop procedure [dbo].[sp_Booking_Delete]
Go 
CREATE PROCEDURE dbo.sp_Booking_Delete
@BooId	int
AS
Delete FROM [Booking] WHERE  BooId= @BooId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Booking_GetByCusId')
	drop procedure [dbo].[sp_Booking_GetByCusId]
Go 
CREATE PROCEDURE dbo.sp_Booking_GetByCusId
@CusId int
AS
	SELECT * FROM [Booking]
 WHERE CusId = @CusId 
Go

if exists (select * from dbo.sysobjects where name = 'sp_Booking_GetByShoId')
	drop procedure [dbo].[sp_Booking_GetByShoId]
Go 
CREATE PROCEDURE dbo.sp_Booking_GetByShoId
@ShoId int
AS
	SELECT * FROM [Booking]
 WHERE ShoId = @ShoId 
Go

--Table Slide
if exists (select * from dbo.sysobjects where name = 'sp_Slide_GetByAll')
	drop procedure [dbo].[sp_Slide_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_Slide_GetByAll
AS
	SELECT * FROM Slide inner join Film on Slide.FilId = Film.FilId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Slide_GetById')
	drop procedure [dbo].[sp_Slide_GetById]
Go 
CREATE PROCEDURE dbo.sp_Slide_GetById
@SliId	int
AS
SELECT * FROM [Slide] WHERE  SliId= @SliId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Slide_GetByTop')
	drop procedure [dbo].[sp_Slide_GetByTop]
Go 
CREATE PROCEDURE dbo.sp_Slide_GetByTop
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') * FROM [Slide]'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT * FROM [Slide]'
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_Slide_Insert')
	drop procedure [dbo].[sp_Slide_Insert]
Go 
CREATE PROCEDURE dbo.sp_Slide_Insert
@FilId	int,
@Image	varchar(100),
@Status	int
AS
INSERT INTO [Slide]([FilId],[Image],[Status]) VALUES(@FilId ,@Image ,@Status )
Go

if exists (select * from dbo.sysobjects where name = 'sp_Slide_Update')
	drop procedure [dbo].[sp_Slide_Update]
Go
CREATE PROCEDURE dbo.sp_Slide_Update
@SliId	int,
@FilId	int,
@Image	varchar(100),
@Status	int
AS
UPDATE [Slide] SET [FilId] = @FilId,[Image] = @Image,[Status] = @Status
WHERE  SliId= @SliId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Slide_Delete')
	drop procedure [dbo].[sp_Slide_Delete]
Go 
CREATE PROCEDURE dbo.sp_Slide_Delete
@SliId	int
AS
Delete FROM [Slide] WHERE  SliId= @SliId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Slide_Update_Status')
	drop procedure [dbo].[sp_Slide_Update_Status]
Go 
CREATE PROCEDURE dbo.sp_Slide_Update_Status
(
	@SliId int,
	@Status int
)
AS
Update [Slide] SET [Status]=@Status where SliId=@SliId
Go

--Table Feedback

if exists (select * from dbo.sysobjects where name = 'sp_Feedback_GetByAll')
	drop procedure [dbo].[sp_Feedback_GetByAll]
Go 
CREATE PROCEDURE dbo.sp_Feedback_GetByAll
AS
	SELECT * FROM Feedback
Go

if exists (select * from dbo.sysobjects where name = 'sp_Feedback_GetById')
	drop procedure [dbo].[sp_Feedback_GetById]
Go 
CREATE PROCEDURE dbo.sp_Feedback_GetById
@FeeId	int
AS
SELECT * FROM [Feedback] WHERE  FeeId= @FeeId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Feedback_GetByTop')
	drop procedure [dbo].[sp_Feedback_GetByTop]
Go 
CREATE PROCEDURE dbo.sp_Feedback_GetByTop
@Top nvarchar(10),
@Where nvarchar(500), 
@Order nvarchar(500)
AS
	Declare @SQL as nvarchar(500) 
Select @SQL = 'SELECT top (' + @Top + ') * FROM [Feedback]'
if len(@Top) = 0
BEGIN
Select @SQL = 'SELECT * FROM [Feedback]'
END
if len(@Where) >0
BEGIN
Select @SQL = @SQL + ' Where ' + @Where
END
if len(@Order) >0
BEGIN
Select @SQL = @SQL + ' Order by ' + @Order
END
EXEC (@SQL)
Go

if exists (select * from dbo.sysobjects where name = 'sp_Feedback_Insert')
	drop procedure [dbo].[sp_Feedback_Insert]
Go 
CREATE PROCEDURE dbo.sp_Feedback_Insert
@FilId	int,
@Avata	nvarchar(100),
@FullName	nvarchar(100),
@Comment	nvarchar(500)
AS
INSERT INTO [Feedback]([FilId],[Avata],[FullName],[Comment]) VALUES(@FilId ,@Avata,@FullName ,@Comment )
Go

if exists (select * from dbo.sysobjects where name = 'sp_Feedback_Update')
	drop procedure [dbo].[sp_Feedback_Update]
Go 
CREATE PROCEDURE dbo.sp_Feedback_Update
@FeeId	int,
@FilId	int,
@Avata	nvarchar(100),
@FullName	nvarchar(100),
@Comment	nvarchar(500)
AS
UPDATE [Feedback] SET [FilId] = @FilId,[Avata]=@Avata,[FullName] = @FullName,[Comment] = @Comment
WHERE  FeeId= @FeeId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Feedback_Delete')
	drop procedure [dbo].[sp_Feedback_Delete]
Go 
CREATE PROCEDURE dbo.sp_Feedback_Delete
@FeeId	int
AS
Delete FROM [Feedback] WHERE  FeeId= @FeeId
Go

if exists (select * from dbo.sysobjects where name = 'sp_Feedback_GetByFilId')
	drop procedure [dbo].[sp_Feedback_GetByFilId]
Go 
CREATE PROCEDURE dbo.sp_Feedback_GetByFilId
@FilId int
AS
	SELECT * FROM [Feedback]
 WHERE FilId = @FilId 
Go