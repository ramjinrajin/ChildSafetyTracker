Create Table Band
(

BandId int Identity(1,1) Primary Key,
BandNo varchar(100),
BandSLNO varchar(100),
NotificationType varchar(100) Default 'EMAIL',
IsDeleted int Default 0


)
Go

INSERT into Band (BandNo,BandSLNO,NotificationType,IsDeleted) VALUES (@BandNo,@BandSLNO,@NotificationType,@IsDeleted)
GO

CREATE Proc SpAddBand
(
@BandNo varchar(100),
@BandSLNO varchar(100),
@NotificationType varchar(100)


)
As 
BEGIN
	Declare @Count INT=0;
	SET @Count=(select COUNT(*) FROM Band Where BandNo=@BandNo or BandSLNO=@BandSLNO)
	IF(@Count>0)
	BEGIN
	  SELECT 'Band already exists'
	END
	ELSE
	BEGIN
	INSERT into Band (BandNo,BandSLNO,NotificationType) VALUES (@BandNo,@BandSLNO,@NotificationType)
	SELECT 'Band added successfully'
	END
End 
GO