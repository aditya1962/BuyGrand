USE [BuyGrandSeller]
GO
/****** Object:  StoredProcedure [dbo].[sp_addUser]    Script Date: 12/20/2020 7:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/20
-- Description:	Stored procedure for adding a user when a user registers
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_addUser]
(
    @username nvarchar(15),
    @firstName nvarchar(100),
    @lastName nvarchar(100),
    @address nvarchar(500),
    @emailAddress nvarchar(50),
    @phoneNumber nvarchar(15),
    @gender nvarchar(8),
    @country nvarchar(40)
)
AS
BEGIN

	SET XACT_ABORT, NOCOUNT ON;
	DECLARE @transactionCount int;
	SET @transactionCount = @@TRANCOUNT;
	BEGIN TRY
		IF @transactionCount=0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_addUser

		insert into dbo.loggedUser
          values(@username,@firstName,@lastName,@address,@phoneNumber,@emailAddress,@gender,@country);

		IF @transactionCount=0
			COMMIT TRANSACTION;

	END TRY
	BEGIN CATCH
		DECLARE @errorNo int, @message varchar(max), @xstate int
		SELECT @errorNo = ERROR_NUMBER(), @message = ERROR_MESSAGE(), @xstate = XACT_STATE();
		IF @transactionCount = 0
			ROLLBACK TRANSACTION;
		ELSE
			IF @xstate = 1
				ROLLBACK TRANSACTION sp_addUser;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
