USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getUserItemCount]    Script Date: 12/26/2020 16:36:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/12/26
-- Description:	Stored procedure for retrieving the number of items of a user in seller view
-- =============================================
CREATE PROCEDURE [dbo].[sp_getUserItemCount]

AS
BEGIN

	SET XACT_ABORT, NOCOUNT ON;
	DECLARE @transactionCount int;
	SET @transactionCount = @@TRANCOUNT;
	BEGIN TRY
		IF @transactionCount=0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_getUserItemCount

		select count(itemID) from item where username=@username;

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
				ROLLBACK TRANSACTION sp_getUserItemCount;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH

END
