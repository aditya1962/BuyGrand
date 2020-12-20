USE [BuyGrandSeller]
GO
/****** Object:  StoredProcedure [dbo].[sp_updateLogin]    Script Date: 12/20/2020 7:28:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/20
-- Description:	Stored procedure for updating login at forgot password
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_updateLogin]
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
			SAVE TRANSACTION sp_updateLogin

		update dbo.login set password=@password where username=@username;

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
				ROLLBACK TRANSACTION sp_updateLogin;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
