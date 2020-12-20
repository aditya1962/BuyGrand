USE [BuyGrandSeller]
GO
/****** Object:  StoredProcedure [dbo].[sp_addLogin]    Script Date: 12/20/2020 6:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/20
-- Description:	Stored procedure for adding a login when a user registers
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[sp_addLogin]
(
    @username nvarchar(15),
    @password nvarchar(250),
    @secretQuestion nvarchar(150),
    @secretAnswer nvarchar(100)
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
			SAVE TRANSACTION sp_addLogin

		insert into dbo.login
          values(@username,@password,@secretQuestion,@secretAnswer,"seller",0,current_timestamp,0);

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
				ROLLBACK TRANSACTION sp_addLogin;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
