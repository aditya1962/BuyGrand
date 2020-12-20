USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_validateUser]    Script Date: 12/20/2020 6:45:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/20
-- Description:	Stored procedure for validating user for login
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_validateUser]
(
    @username nvarchar(15),
    @password nvarchar(250)
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
			SAVE TRANSACTION sp_validateUser

		select * from dbo.login where username=@username and password=@password;

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
				ROLLBACK TRANSACTION sp_validateUser;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
