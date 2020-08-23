USE [BuyGrandSellerReadReplica]
GO
/****** Object:  StoredProcedure [dbo].[sp_getItemCount]    Script Date: 8/23/2020 8:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Aditya Abeysinghe
-- Create date: 2020/08/20
-- Description:	Stored procedure for retrieving the number of items in seller view 
-- =============================================
CREATE PROCEDURE [dbo].[sp_getItemCount] 
	
AS
BEGIN

	SET XACT_ABORT, NOCOUNT ON;
	DECLARE @transactionCount int;
	SET @transactionCount = @@TRANCOUNT;
	BEGIN TRY
		IF @transactionCount=0
			BEGIN TRANSACTION;
		ELSE
			SAVE TRANSACTION sp_getItemCount

		select count(itemID) from item
		
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
				ROLLBACK TRANSACTION sp_getItemCount;
			ELSE
				ROLLBACK TRANSACTION;
	END CATCH
    
END
